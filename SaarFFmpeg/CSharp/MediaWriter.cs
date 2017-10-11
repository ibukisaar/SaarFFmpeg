using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class MediaWriter : MediaStream {
		private class FixedAudioFrame {
			public AudioFrame Frame { get; }
			public int Offset { get; private set; } = 0;

			public FixedAudioFrame(AudioFormat format, int fixedCount) {
				Frame = new AudioFrame(format);
				Frame.Resize(fixedCount);
			}

			public void AppendForEach(AudioFrame input, Action<AudioFrame> callback) {
				int fixedCount = Frame.sampleCount;
				int length = Offset + input.sampleCount;
				int i;
				if (fixedCount <= length) {
					for (i = 0; i + fixedCount <= length; i += fixedCount) {
						if (i == 0) {
							input.CopyToNoResize(0, fixedCount - Offset, Frame, Offset);
						} else {
							input.CopyToNoResize(i - Offset, fixedCount, Frame, 0);
						}
						callback(Frame);
					}
					input.CopyToNoResize(i - Offset, length - i, Frame, 0);
					Offset = length - i;
				} else {
					input.CopyToNoResize(0, input.sampleCount, Frame, Offset);
					Offset += input.sampleCount;
				}
			}
		}

		public delegate Frame RequestFrameHandle(Encoder encoder);

		private bool remuxing = false;
		private Packet packet = new Packet();
		private AVOutputFormat* outputFormat;
		private List<Encoder> encoders = new List<Encoder>();
		private HashSet<Encoder> readyEncoders;
		private AVFormatContext* inputFmtCtx;
		private FixedAudioFrame[] fixedAudioFrames;

		public IReadOnlyList<Encoder> Encoders => encoders;

		public AVCodecID AudioCodecID => remuxing ? inputFmtCtx->AudioCodecId : outputFormat->AudioCodec;
		public AVCodecID VideoCodecID => remuxing ? inputFmtCtx->VideoCodecId : outputFormat->VideoCodec;

		/// <summary>
		/// 创建一个编码模式的媒体写入器
		/// </summary>
		/// <param name="file">输出的文件路径</param>
		/// <param name="ignoreExtension">如果为true，则不会根据文件扩展名自动推断编码器</param>
		public MediaWriter(string file, bool ignoreExtension = false)
			: base(File.Open(file, FileMode.Create, FileAccess.Write), true, FF.av_guess_format(null, ignoreExtension ? null : file, null)) {
			outputFormat = formatContext->Oformat;
		}

		/// <summary>
		/// 创建一个编码模式的媒体写入器
		/// </summary>
		/// <param name="outputStream">输出的流</param>
		/// <param name="mediaName">根据"mp3","flac","h264"等多媒体的短名称自动推断编码器</param>
		public MediaWriter(Stream outputStream, string mediaName = null)
			: base(outputStream, true, FF.av_guess_format(mediaName, null, null)) {
			outputFormat = formatContext->Oformat;
		}

		/// <summary>
		/// 创建一个封装模式的媒体写入器
		/// </summary>
		/// <param name="file"></param>
		/// <param name="mediaReader"></param>
		public MediaWriter(string file, MediaReader mediaReader)
			: base(File.Open(file, FileMode.Create, FileAccess.Write), true, FF.av_guess_format(null, file, null)) {
			outputFormat = formatContext->Oformat;
			remuxing = true;

			SetEncoders(mediaReader);
		}

		/// <summary>
		/// 创建一个封装模式的媒体写入器
		/// </summary>
		/// <param name="outputStream"></param>
		/// <param name="mediaName"></param>
		/// <param name="mediaReader"></param>
		public MediaWriter(Stream outputStream, string mediaName, MediaReader mediaReader)
			: base(outputStream, true, FF.av_guess_format(mediaName, null, null)) {
			outputFormat = formatContext->Oformat;
			remuxing = true;

			SetEncoders(mediaReader);
		}

		private void SetEncoders(MediaReader mediaReader) {
			try {
				foreach (var decoder in mediaReader.Decoders) {
					if (decoder != null) {
						var stream = FF.avformat_new_stream(formatContext, decoder.codec);
						if (stream == null) throw new InvalidOperationException("无法创建流");
						int result = FF.avcodec_copy_context(stream->Codec, decoder.codecContext);
						if (result < 0) throw new FFmpegException(result);
						stream->Codec->CodecTag = 0;
						if (outputFormat->Flags.HasFlag(AVFmt.GlobalHeader)) {
							stream->Codec->Flags |= AVCodecFlag.GlobalHeader;
						}
						stream->TimeBase = mediaReader.formatContext->Streams[decoder.StreamIndex]->TimeBase;
						//stream->TimeBase = decoder.codecContext->TimeBase;
						result = FF.avcodec_parameters_from_context(stream->Codecpar, stream->Codec);
						if (result < 0) throw new CSharp.FFmpegException(result);
					}
				}
				inputFmtCtx = mediaReader.formatContext;
			} catch {
				Dispose();
				throw;
			}
		}

		public MediaWriter AddAudio(AudioFormat format, BitRate bitRate) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			if (outputFormat->AudioCodec == AVCodecID.None)
				throw new InvalidOperationException($"该{nameof(MediaWriter)}对象并不支持音频");

			var stream = FF.avformat_new_stream(formatContext, Codec.GetEncoder(outputFormat->AudioCodec));
			if (stream == null) throw new Exception("无法创建流");
			var codecContext = stream->Codec;
			var audioEncoder = new AudioEncoder(stream, format, bitRate);
			stream->TimeBase = codecContext->TimeBase;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, codecContext);
			if (result < 0) throw new CSharp.FFmpegException(result);
			encoders.Add(audioEncoder);
			return this;
		}

		public MediaWriter AddAudio(AudioFormat format) {
			return AddAudio(format, BitRate.Zero);
		}

		public MediaWriter AddVideo(VideoFormat format, VideoEncoderParameters encoderParams = null) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			if (outputFormat->VideoCodec == AVCodecID.None)
				throw new InvalidOperationException($"该{nameof(MediaWriter)}对象并不支持视频");

			var stream = FF.avformat_new_stream(formatContext, Codec.GetEncoder(outputFormat->VideoCodec));
			if (stream == null) throw new Exception("无法创建流");
			var codecContext = stream->Codec;
			var videoEncoder = new VideoEncoder(stream, format, encoderParams);
			stream->TimeBase = codecContext->TimeBase;
			stream->AvgFrameRate = codecContext->Framerate;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, codecContext);
			if (result < 0) throw new CSharp.FFmpegException(result);
			encoders.Add(videoEncoder);
			return this;
		}

		public MediaWriter AddEncoder(Encoder encoder) {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");

			if (outputFormat == null) {
				var desc = FF.avcodec_descriptor_get(encoder.ID);
				if (desc == null) throw new InvalidOperationException("无法获得编码器的短名称描述");
				outputFormat = FF.av_guess_format(desc->Name, null, null);
				if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");
				formatContext->Oformat = outputFormat;
			}

			var stream = FF.avformat_new_stream(formatContext, encoder.codec);
			if (stream == null) throw new Exception("无法创建流");
			// stream->TimeBase = encoder.codecContext->TimeBase;
			int result = FF.avcodec_parameters_from_context(stream->Codecpar, encoder.codecContext);
			if (result < 0) throw new CSharp.FFmpegException(result);
			encoder.stream = stream;
			encoders.Add(encoder);
			return this;
		}

		public MediaWriter Initialize() {
			if (readyEncoders != null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象已经初始化");
			if (outputFormat == null) throw new InvalidOperationException("无法确定媒体的输出格式");

			int result = FF.avformat_write_header(formatContext, null);
			if (result < 0) throw new CSharp.FFmpegException(result, "写入头部错误");

			readyEncoders = new HashSet<Encoder>(encoders);
			fixedAudioFrames = new FixedAudioFrame[encoders.Count];
			return this;
		}

		/// <summary>
		/// 封装模式专用
		/// </summary>
		/// <param name="packet"></param>
		public void Write(Packet packet) {
			if (packet.StreamIndex >= 0 && packet.StreamIndex < formatContext->NbStreams) {
				if (inputFmtCtx != null) {
					var inTimebase = inputFmtCtx->Streams[packet.StreamIndex]->TimeBase;
					var outTimebase = formatContext->Streams[packet.StreamIndex]->TimeBase;
					if (packet.packet->Pts != long.MinValue) {
						packet.packet->Pts = FF.av_rescale_q(packet.packet->Pts, inTimebase, outTimebase);
					}
					if (packet.packet->Dts != long.MinValue) {
						packet.packet->Dts = FF.av_rescale_q(packet.packet->Dts, inTimebase, outTimebase);
					}
					packet.packet->Duration = FF.av_rescale_q(packet.packet->Duration, inTimebase, outTimebase);
				}
				packet.packet->Pos = -1;
				InternalWrite(packet);
			}
		}

		private void InternalWrite(Packet packet) {
			if (packet.Size > 0) {
				var result = FF.av_interleaved_write_frame(formatContext, packet.packet);
				if (result < 0) throw new FFmpegException(result);
			}
		}

		private void Encode(Encoder encoder, Frame frame) {
			var audioEncoder = encoder as AudioEncoder;
			var audioFrame = frame as AudioFrame;
			if (audioEncoder != null && audioFrame != null) {
				ref FixedAudioFrame fixedAudioFrame = ref fixedAudioFrames[encoder.StreamIndex];
				if (fixedAudioFrame == null)
					fixedAudioFrame = new FixedAudioFrame(audioFrame.format, audioEncoder.RequestSamples);
				if (fixedAudioFrame.Frame.SampleCount != audioEncoder.RequestSamples)
					throw new InvalidOperationException();

				fixedAudioFrame.AppendForEach(audioFrame, f => {
					if (encoder.Encode(f, packet)) {
						InternalWrite(packet);
					}
				});
			} else {
				if (encoder.Encode(frame, packet)) {
					InternalWrite(packet);
				}
			}
		}

		/// <summary>
		/// 编码并写入流
		/// </summary>
		/// <param name="handler">当 handler 返回 null 表示编码结束。不要调用 Encoder.Encode，MediaWriter 会自动调用。</param>
		/// <returns>当全部编码结束时返回false</returns>
		public bool Write(RequestFrameHandle handler) {
			if (readyEncoders == null) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象未初始化或已释放");

			var encoder = readyEncoders.Minimal(e => e.InputFrames * e.codecContext->TimeBase.Value);
			if (encoder == null) return false;

			var frame = handler(encoder);
			if (frame == null) {
				readyEncoders.Remove(encoder);
			} else {
				Encode(encoder, frame);
			}

			return true;
		}

		public void Write(Frame frame) {
			if (readyEncoders == null || encoders.Count == 0) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象未初始化或已释放");
			if (encoders.Count != 1) throw new InvalidOperationException($"该{nameof(MediaWriter)}对象包含一个以上的编码流，因此不能调用此方法");

			var encoder = encoders[0];
			Encode(encoder, frame);
		}

		public void Flush() {
			if (readyEncoders == null) return;

			for (int i = 0; i < fixedAudioFrames.Length; i++) {
				var fixedFrame = fixedAudioFrames[i];
				if (fixedFrame != null && fixedFrame.Offset > 0) {
					var encoder = encoders[i];
					using (var tempFrame = new AudioFrame(fixedFrame.Frame.format)) {
						tempFrame.Resize(fixedFrame.Offset);
						fixedFrame.Frame.CopyToNoResize(0, fixedFrame.Offset, tempFrame);
						if (encoder.Encode(tempFrame, packet)) InternalWrite(packet);
					}
					fixedFrame.Frame.Dispose();
					fixedAudioFrames[encoder.StreamIndex] = null;
				}
			}

			readyEncoders = new HashSet<Encoder>(encoders);
			while (true) {
				var encoder = readyEncoders.Minimal(e => e.InputFrames * e.codecContext->TimeBase.Value);
				if (encoder == null) break;

				while (encoder.Encode(null, packet)) InternalWrite(packet);
				readyEncoders.Remove(encoder);
				formatContext->Streams[encoder.StreamIndex]->Duration = encoder.InputTimestamp.Ticks / 10;
			}

			int result = FF.av_write_trailer(formatContext);
			if (result < 0) throw new FFmpegException(result);
			readyEncoders = null;
		}

		protected override void Dispose(bool disposing) {
			Flush();

			if (disposing) {
				packet.Dispose();
				foreach (var enc in encoders)
					enc.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
