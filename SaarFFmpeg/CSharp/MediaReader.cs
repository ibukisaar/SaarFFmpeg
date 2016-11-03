using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.CSharp.Codecs;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class MediaReader : MediaStream {
		private string filename;
		private Packet packet = new Packet();
		private int defaultStreamIndex = 0;


		public TimeSpan Duration { get; }

		public IReadOnlyList<Decoder> Decoders { get; }

		/// <summary>
		/// FPS
		/// </summary>
		public double FramesPerSecond { get; }

		public int VideoStreamIndex { get; } = -1;

		public bool HasVideo => VideoStreamIndex >= 0;


		public MediaReader(string file) : this(File.OpenRead(file)) { }

		public MediaReader(Stream inputStream) : base(inputStream) {
			if (!inputStream.CanRead) throw new ArgumentException($"流不能被读取，请确保{nameof(Stream)}.{nameof(inputStream.CanRead)}为true");

			try {
				filename = (inputStream as FileStream)?.Name;

				int resultCode;
				fixed (AVFormatContext** pFormatContext = &formatContext) {
					resultCode = FF.avformat_open_input(pFormatContext, null, null, null);
				}
				if (resultCode != 0) throw new Support.FFmpegException(resultCode);

				resultCode = FF.avformat_find_stream_info(formatContext, null);
				if (resultCode != 0) throw new Support.FFmpegException(resultCode);

				var decoders = new Decoder[StreamCount];
				for (int i = 0; i < StreamCount; i++) {
					decoders[i] = Decoder.Create(formatContext->Streams[i]);
					if (formatContext->Streams[i]->Codec->CodecType == AVMediaType.Video) {
						FramesPerSecond = formatContext->Streams[i]->AvgFrameRate.Value;
						VideoStreamIndex = i;
						defaultStreamIndex = i;
					}
				}
				Decoders = decoders;
				if (formatContext->Duration != long.MinValue) {
					Duration = TimeSpan.FromTicks(formatContext->Duration * 10);
				}
			} catch {
				Dispose();
				throw;
			}
		}

		public bool ReadPacket(Packet packet, int matchStreamIndex = -1) {
			while (true) {
				packet.Unref();

				int result = FF.av_read_frame(formatContext, packet.packet);
				if (result != 0) {
					return false;
				}

				if (matchStreamIndex == -1 || packet.StreamIndex == matchStreamIndex) {
					double timebase = formatContext->Streams[packet.StreamIndex]->TimeBase.Value;
					if (packet.packet->Pts != long.MinValue) {
						packet.timestamp = TimeSpan.FromSeconds(packet.packet->Pts * timebase);
					} else {
						packet.timestamp = TimeSpan.MinValue;
					}
					if (packet.packet->Dts != long.MinValue) {
						packet.codecTimestamp = TimeSpan.FromSeconds(packet.packet->Dts * timebase);
					} else {
						packet.codecTimestamp = TimeSpan.MinValue;
					}
					return true;
				}
			}
		}

		public Packet ReadPacket(int matchStreamIndex = -1) {
			var result = new Packet();
			if (ReadPacket(result, matchStreamIndex)) {
				return result;
			} else {
				return null;
			}
		}

		/// <summary>
		/// 自动解码
		/// </summary>
		/// <param name="matchStreamIndex"></param>
		/// <returns></returns>
		public bool NextFrame(Frame outFrame, int matchStreamIndex) {
			while (true) {
				if (ReadPacket(packet, matchStreamIndex)) {
					if (Decoders[matchStreamIndex].Decode(packet, outFrame)) return true;
				} else {
					return Decoders[matchStreamIndex].Decode(null, outFrame);
				}
			}
		}

		public TimeSpan Position {
			get {
				var stream = formatContext->Streams[defaultStreamIndex];
				return TimeSpan.FromSeconds(stream->CurDts * stream->TimeBase.Value);
			}
			set {
				FF.av_seek_frame(formatContext, -1, value.Ticks / 10, AVSeekFlag.Any);
				//foreach (Decoder decoder in Decoders) {
				//	if (decoder is AudioDecoder || decoder is VideoDecoder) {
				//		var timebase = formatContext->Streams[decoder.StreamIndex]->TimeBase;
				//		int ret = FF.av_seek_frame(formatContext, decoder.StreamIndex, (long) (value.TotalSeconds * timebase.Den / timebase.Num), AVSeekFlag.Any);
				//		if (ret < 0) throw new Support.FFmpegException(ret);
				//	}
				//}
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				packet?.Dispose();
				if (Decoders != null) {
					foreach (Decoder decoder in Decoders) {
						if (decoder != null) decoder.Dispose();
					}
				}
			}

			base.Dispose(disposing);
		}
	}
}
