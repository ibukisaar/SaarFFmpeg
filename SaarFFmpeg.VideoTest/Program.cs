using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.Codecs;
using Saar.FFmpeg.Enumerates;
using System.Drawing;
using System.Drawing.Imaging;

namespace SaarFFmpeg.VideoTest {
	class Program {
		static void Main(string[] args) {
			var media = new MediaReader(@"Z:\game.dat_000004.wmv");
			var decoder = media.Decoders.OfType<VideoDecoder>().First();
			decoder.OutFormat = new VideoFormat(decoder.InFormat.Width, decoder.InFormat.Height, AVPixelFormat.Bgr24, 4);
			VideoFrame frame = new VideoFrame();
			for (int i = 0; i < 10; i++) {
				if (media.NextFrame(frame, decoder.StreamIndex)) {
					Bitmap image = new Bitmap(frame.Format.Width, frame.Format.Height, frame.Format.Strides[0], PixelFormat.Format24bppRgb, frame.Scan0);
					image.Save($@"Z:\{i}.png");
				}
			}
		}
	}
}
