using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;
using System.Drawing;
using System.Drawing.Imaging;
using Saar.FFmpeg.Structs;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace SaarFFmpeg.VideoTest {
	unsafe class Program {
		static void Main(string[] args) {
			var media = new MediaReader(@"D:\MyDocuments\Videos\bandicam 2018-05-07 20-38-22-722.mp4");
			var decoder = media.Decoders.OfType<VideoDecoder>().First();
			decoder.OutFormat = new VideoFormat(decoder.InFormat.Width, decoder.InFormat.Height, AVPixelFormat.Bgr24, 4);
			VideoFrame frame = new VideoFrame();
			for (int i = 0; i < 100; i++) {
				if (media.NextFrame(frame, decoder.StreamIndex)) {
					Bitmap image = new Bitmap(frame.Format.Width, frame.Format.Height, frame.Format.Strides[0], PixelFormat.Format24bppRgb, frame.Scan0);
					image.Save($@"D:\MyDocuments\Videos\{i}.png");
				}
			}

			//AVFormatContext* formatCtx = null;
			//const string filename = @"D:\MyDocuments\Music\虾米音乐\Cyua-Blumenkranz.mp3";
			//FF.avformat_open_input(&formatCtx, filename, null, null).CheckFFmpegCode();
			//FF.avformat_find_stream_info(formatCtx, null);

			//AVCodec* codec;
			//int index = FF.av_find_best_stream(formatCtx, AVMediaType.Audio, -1, -1, &codec, 0).CheckFFmpegCode();
			//AVStream* stream = formatCtx->Streams[index];

			//// var codec = FF.avcodec_find_decoder(stream->Codecpar->CodecId);
			//var parser = FF.av_parser_init(codec->Id);
			//var codecCtx = FF.avcodec_alloc_context3(codec);
			//FF.avcodec_parameters_to_context(codecCtx, stream->Codecpar);
			//Debug.Print(*stream->Codecpar);
			//FF.avcodec_open2(codecCtx, codec, null).CheckFFmpegCode();

			//// FF.av_dump_format(formatCtx, 0, filename, false);

			//var frame = FF.av_frame_alloc();
			//AVPacket packet;
			//FF.av_init_packet(&packet);
			//packet.Data = null;
			//packet.Size = 0;

			//void decode_packet(AVPacket* _packet) {
			//	int r = FF.avcodec_send_packet(codecCtx, _packet).CheckFFmpegCode();
			//	AVRational rational = codecCtx->PktTimebase;
			//	while (r >= 0) {
			//		r = FF.avcodec_receive_frame(codecCtx, frame);
			//		switch (r) {
			//			case var _ when r == Error.EAGAIN.AVError():
			//				Console.Write('.');
			//				return;
			//			case (int)AVError.Eof:
			//				Console.WriteLine("EOF");
			//				return;
			//			case var _ when r < 0:
			//				throw new FFmpegException(r);
			//		}
			//		Console.Write('!');
			//	}
			//}

			//while (FF.av_read_frame(formatCtx, &packet) >= 0) {
			//	if (packet.StreamIndex == index) {
			//		decode_packet(&packet);
			//	}
			//	FF.av_packet_unref(&packet);
			//}
			//decode_packet(null);
		}
	}
}
