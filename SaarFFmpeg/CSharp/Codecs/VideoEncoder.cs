using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp.Codecs {
	unsafe public sealed class VideoEncoder : Encoder {
		private VideoResampler resampler;
		private VideoFrame tempFrame;
		private VideoFormat outFormat;

		public VideoFormat InFormat { get; }
		public VideoFormat OutFormat => outFormat;
		public VideoResampler Resampler => resampler;

		public VideoEncoder(AVCodecID codecID, VideoFormat format, VideoEncoderParameters encoderParams = null) : base(codecID) {
			encoderParams = encoderParams ?? VideoEncoderParameters.Default;
			if (codec->Type != AVMediaType.Video)
				throw new ArgumentException($"{codecID}不是视频格式", nameof(codecID));

			codecContext = FF.avcodec_alloc_context3(codec);
			if (codecContext == null) throw new Exception("无法分配编码器上下文");

			InFormat = format;
			Init(encoderParams);
		}

		internal VideoEncoder(AVStream* stream, VideoFormat format, VideoEncoderParameters encoderParams = null) : base(stream) {
			encoderParams = encoderParams ?? VideoEncoderParameters.Default;

			InFormat = format;
			Init(encoderParams);
		}

		private void Init(VideoEncoderParameters encoderParams) {
			var pixelFormats = GetSupportedPixelFormats(codec);
			if (pixelFormats != null && !pixelFormats.Contains(InFormat.PixelFormat)) {
				outFormat = new VideoFormat(InFormat.Width, InFormat.Height, pixelFormats[0]);
				resampler = new VideoResampler(InFormat, OutFormat, encoderParams.ResampleFlags);
				tempFrame = new VideoFrame();
			} else {
				outFormat = InFormat;
			}

			try {
				codecContext->PixFmt = OutFormat.PixelFormat;
				codecContext->Width = OutFormat.Width;
				codecContext->Height = OutFormat.Height;
				codecContext->BitRate = encoderParams.BitRate.Value;
				codecContext->TimeBase = encoderParams.FrameRate.ToReciprocal();
				codecContext->Framerate = encoderParams.FrameRate;
				if (encoderParams.GopSize != 0)
					codecContext->GopSize = encoderParams.GopSize;
				if (encoderParams.MaxBFrames != 0)
					codecContext->MaxBFrames = encoderParams.MaxBFrames;
				if (encoderParams.MbDecision != 0)
					codecContext->MbDecision = encoderParams.MbDecision;
				if (encoderParams.Qmin != 0)
					codecContext->Qmin = encoderParams.Qmin;
				if (encoderParams.Qmax != 0)
					codecContext->Qmax = encoderParams.Qmax;

				var result = FF.avcodec_open2(codecContext, codec, null);
				if (result < 0) throw new Support.FFmpegException(result);
			} catch {
				Dispose();
				throw;
			}
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

		private static AVCodec* CheckCodec(AVCodec* codec) {
			if (codec->Type != AVMediaType.Video)
				throw new ArgumentException($"{codec->Id}不是视频格式");

			return codec;
		}

		public static bool IsSupportedFormat(AVCodecID codecID, AVPixelFormat pixelFormat, AVRational frameRate) {
			var codec = GetEncoder(codecID);
			var pixelFormats = GetSupportedPixelFormats(codec);
			var frameRates = GetSupportedFrameRates(codec);

			return (pixelFormats?.Contains(pixelFormat) ?? true)
				&& (frameRates?.Contains(frameRate) ?? true);
		}

		public static void MatchSupportedFormat(AVCodecID codecID, ref AVPixelFormat pixelFormat, ref AVRational frameRate) {
			var codec = GetEncoder(codecID);
			var pixelFormats = GetSupportedPixelFormats(codec);
			var frameRates = GetSupportedFrameRates(codec);

			if (pixelFormats != null && !pixelFormats.Contains(pixelFormat)) {
				pixelFormat = pixelFormats.First();
			}

			if (frameRates != null && !frameRates.Contains(frameRate)) {
				foreach (var fr in frameRates.OrderBy(fr => fr.Value)) {
					frameRate = fr;
					if (fr.Value >= frameRate.Value) {
						break;
					}
				}
			}
		}

		private static List<AVPixelFormat> GetSupportedPixelFormats(AVCodec* codec) {
			if (codec->PixFmts == null) return null;

			var result = new List<AVPixelFormat>();
			for (var p = codec->PixFmts; *p != AVPixelFormat.None; p++) {
				result.Add(*p);
			}
			return result;
		}

		private static List<AVRational> GetSupportedFrameRates(AVCodec* codec) {
			if (codec->SupportedFramerates == null) return null;

			var result = new List<AVRational>();
			for (var p = codec->SupportedFramerates; p->Num != 0; p++) {
				result.Add(*p);
			}
			return result;
		}

		public static List<AVPixelFormat> GetSupportedPixelFormats(AVCodecID codecID) {
			return GetSupportedPixelFormats(GetEncoder(codecID));
		}

		public static List<AVRational> GetSupportedFrameRates(AVCodecID codecID) {
			return GetSupportedFrameRates(GetEncoder(codecID));
		}

		public override bool Encode(Frame frame, Packet outPacket) {
			if (frame != null) {
				if (!(frame is VideoFrame)) throw new ArgumentException($"{nameof(frame)}必须是{nameof(VideoFrame)}类型", nameof(frame));
				if (!(frame as VideoFrame).format.Equals(InFormat)) throw new ArgumentException("输入帧的格式和编码器输入格式不同");
			}
			
			if (resampler != null) {
				if (frame != null) {
					resampler.Resample(frame as VideoFrame, tempFrame);
					frame = tempFrame;
				}
			}

			outPacket.Unref();
			int gotPicture = 0;
			if (frame != null) {
				try {
					frame.SetupToNative();
					frame.frame->Pts = inputFrames;
					int result = FF.avcodec_encode_video2(codecContext, outPacket.packet, frame.frame, &gotPicture);
					if (result < 0) throw new Support.FFmpegException(result, "视频编码发生错误");
				} finally {
					frame.ReleaseSetup();
				}
				
				inputFrames++;
				encodeFrames = 1;
			} else {
				int result = FF.avcodec_encode_video2(codecContext, outPacket.packet, null, &gotPicture);
				if (result < 0) throw new Support.FFmpegException(result, "视频编码发生错误");
			}

			ConfigPakcet(outPacket);
			return gotPicture != 0;
		}

		public override string ToString()
			=> $"{FullName}, 输出:{OutFormat}";
	}
}
