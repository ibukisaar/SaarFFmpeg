using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class MediaRemuxer : MediaStream {
		private AVOutputFormat* outputFormat;
		private bool isFlush = false;

		public MediaRemuxer(string file, params Codec[] codecs)
			: base(File.Open(file, FileMode.Create, FileAccess.Write), true, FF.av_guess_format(null, file, null)) {

			outputFormat = formatContext->Oformat;
			NewStreams(codecs);
		}

		public MediaRemuxer(Stream outputStream, string mediaName = null, params Codec[] codecs)
			: base(outputStream, true, FF.av_guess_format(mediaName, null, null)) {

			outputFormat = formatContext->Oformat;
			NewStreams(codecs);
		}

		private void NewStreams(Codec[] codecs) {
			try {
				foreach (var codec in codecs) {
					var stream = FF.avformat_new_stream(formatContext, codec.codec);
					if (stream == null) throw new InvalidOperationException("无法创建流");
					FF.avcodec_copy_context(stream->Codec, codec.codecContext).CheckFFmpegCode();
					stream->Codec->CodecTag = 0;
					if (outputFormat->Flags.HasFlag(AVFmt.GlobalHeader)) {
						stream->Codec->Flags |= AVCodecFlag.GlobalHeader;
					}
					stream->TimeBase = codec.codecContext->TimeBase;
					FF.avcodec_parameters_from_context(stream->Codecpar, stream->Codec).CheckFFmpegCode();
				}

				FF.avformat_write_header(formatContext, null).CheckFFmpegCode();
			} catch {
				Dispose();
				throw;
			}
		}

		public void Write(Packet packet) {
			packet.packet->Pos = -1;
			InternalWrite(packet);
		}

		public void Flush() {
			if (!isFlush) {
				FF.av_write_trailer(formatContext).CheckFFmpegCode();
				isFlush = true;
			}
		}

		protected override void Dispose(bool disposing) {
			Flush();
			base.Dispose(disposing);
		}
	}
}
