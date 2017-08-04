using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class AudioEncoder : Encoder {
		private AudioResampler resampler;
		private AudioFrame tempFrame;
		private AudioFormat outFormat;

		public AudioFormat InFormat { get; }
		public AudioFormat OutFormat => outFormat;
		public AudioResampler Resampler => resampler;
		public int RequestSamples => codecContext->FrameSize;

		public override TimeSpan InputTimestamp
			=> TimeSpan.FromTicks(inputFrames * 10000000 / outFormat.SampleRate);

		public override TimeSpan OutputTimestamp
			=> TimeSpan.FromTicks(outputFrames * 10000000 / outFormat.SampleRate);

		public AudioEncoder(AVCodecID codecID, AudioFormat inFormat)
			: this(codecID, inFormat, BitRate.Zero) { }

		public AudioEncoder(AVCodecID codecID, AudioFormat inFormat, BitRate bitRate) : base(codecID) {
			if (codec->Type != AVMediaType.Audio)
				throw new ArgumentException($"{codecID}不是音频格式", nameof(codecID));

			codecContext = FF.avcodec_alloc_context3(codec);
			if (codecContext == null) throw new Exception("无法分配编码器上下文");

			InFormat = inFormat;
			Init(codecID, bitRate);
		}

		internal AudioEncoder(AVStream* stream, AudioFormat inFormat, BitRate bitRate) : base(stream) {
			InFormat = inFormat;
			Init(codecContext->CodecId, bitRate);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				resampler = null;
				tempFrame?.Dispose();
				tempFrame = null;
			}
			base.Dispose(disposing);
		}

		private void Init(AVCodecID codecID, BitRate bitRate) {
			outFormat = MatchSupportedFormat(codecID, InFormat);
			if (!InFormat.Equals(OutFormat)) {
				resampler = new AudioResampler(InFormat, OutFormat);
				tempFrame = new AudioFrame();
			}

			try {
				codecContext->SampleFmt = outFormat.SampleFormat;
				codecContext->SampleRate = outFormat.SampleRate;
				codecContext->ChannelLayout = outFormat.ChannelLayout;
				codecContext->Channels = outFormat.Channels;
				codecContext->BitRate = bitRate.Value;
				var rates = codecContext->Flags;

				int result = FF.avcodec_open2(codecContext, codec, null);
				if (result < 0) throw new CSharp.FFmpegException(result);
			} catch {
				Dispose();
				throw;
			}
		}

		public static bool IsSupportedFormat(AVCodecID codecID, AudioFormat format) {
			var codec = GetEncoder(codecID);
			var sampleFormats = GetSupportedSampleFormats(codec);
			var sampleRates = GetSupportedSampleRates(codec);
			var channelLayouts = GetSupportedChannelLayouts(codec);
			return (sampleFormats?.Contains(format.SampleFormat) ?? true)
				&& (sampleRates?.Contains(format.SampleRate) ?? true)
				&& (channelLayouts?.Contains(format.ChannelLayout) ?? true);
		}

		public static AudioFormat MatchSupportedFormat(AVCodecID codecID, AudioFormat format) {
			var codec = GetEncoder(codecID);
			var sampleFormats = GetSupportedSampleFormats(codec);
			var sampleRates = GetSupportedSampleRates(codec);
			var channelLayouts = GetSupportedChannelLayouts(codec);
			return format.Match(sampleRates, sampleFormats, channelLayouts);
		}

		private static AVCodec* CheckCodec(AVCodec* codec) {
			if (codec->Type != AVMediaType.Audio)
				throw new ArgumentException($"{codec->Id}不是音频格式");

			return codec;
		}

		public static IReadOnlyList<AVSampleFormat> GetSupportedSampleFormats(AVCodecID codecID) {
			return GetSupportedSampleFormats(CheckCodec(GetEncoder(codecID)));
		}

		public static IReadOnlyList<int> GetSupportedSampleRates(AVCodecID codecID) {
			return GetSupportedSampleRates(CheckCodec(GetEncoder(codecID)));
		}

		public static IReadOnlyList<AVChannelLayout> GetSupportedChannelLayouts(AVCodecID codecID) {
			return GetSupportedChannelLayouts(CheckCodec(GetEncoder(codecID)));
		}

		private static List<AVSampleFormat> GetSupportedSampleFormats(AVCodec* codec) {
			if (codec->SampleFmts == null) return null;

			var result = new List<AVSampleFormat>();
			for (var p = codec->SampleFmts; *p != AVSampleFormat.None; p++) {
				result.Add(*p);
			}
			return result;
		}

		private static List<int> GetSupportedSampleRates(AVCodec* codec) {
			if (codec->SupportedSamplerates == null) return null;

			var result = new List<int>();
			for (var p = codec->SupportedSamplerates; *p != 0; p++) {
				result.Add(*p);
			}
			return result;
		}

		private static List<AVChannelLayout> GetSupportedChannelLayouts(AVCodec* codec) {
			if (codec->ChannelLayouts == null) return null;

			var result = new List<AVChannelLayout>();
			for (var p = codec->ChannelLayouts; *p != 0; p++) {
				result.Add(*p);
			}
			return result;
		}

		public override bool Encode(Frame frame, Packet outPacket) {
			if (frame != null) {
				if (!(frame is AudioFrame)) throw new ArgumentException($"{nameof(frame)}必须是{nameof(AudioFrame)}类型", nameof(frame));
				if (!(frame as AudioFrame).format.Equals(InFormat)) throw new ArgumentException("输入帧的格式和编码器输入格式不同");
			}

			if (resampler != null) {
				if (frame != null) {
					resampler.Resample(frame as AudioFrame, tempFrame);
					frame = tempFrame;
				} else {
					resampler.ResampleFinal(tempFrame);
					if (tempFrame.sampleCount > 0) {
						frame = tempFrame;
					}
				}
			}

			outPacket.Unref();
			int gotPicture = 0;
			if (frame != null) {
				try {
					frame.SetupToNative();
					frame.frame->Pts = FF.av_rescale_q(inputFrames, new AVRational(1, OutFormat.SampleRate), codecContext->TimeBase);
					int result = FF.avcodec_encode_audio2(codecContext, outPacket.packet, frame.frame, &gotPicture);
					if (result < 0) throw new CSharp.FFmpegException(result, "音频编码发生错误");
				} finally {
					frame.ReleaseSetup();
				}
				encodeFrames = frame.frame->NbSamples;
				inputFrames += encodeFrames;
			} else {
				int result = FF.avcodec_encode_audio2(codecContext, outPacket.packet, null, &gotPicture);
				if (result < 0) throw new CSharp.FFmpegException(result, "音频编码发生错误");
			}

			if (gotPicture != 0) {
				outputFrames += encodeFrames;
				ConfigPakcet(outPacket);
				return true;
			}
			return false;
		}

		public override string ToString()
			=> $"{FullName}, 输出:{OutFormat}";
	}
}
