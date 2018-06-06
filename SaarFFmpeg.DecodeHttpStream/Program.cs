using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;
using System.Net;
using System.Drawing;

namespace SaarFFmpeg.DecodeHttpStream {
	class Program {
		static void Main(string[] args) {
			var httpRequest = WebRequest.CreateHttp("https://txy.live-play.acgvideo.com/live-txy/148029/live_16159326_5264177.flv?wsSecret=f120730be328d6c1bdbe50dc42f1fc65&wsTime=1510802458");
			httpRequest.Method = "GET";
			var httpResponse = httpRequest.GetResponse() as HttpWebResponse;
			var reader = new MediaReader(httpResponse.GetResponseStream());
			var decoder = reader.Decoders.OfType<VideoDecoder>().First();
			decoder.OutFormat = new VideoFormat(decoder.InFormat.Width, decoder.InFormat.Height, AVPixelFormat.Bgr24, 4);
			var frame = new VideoFrame();
			for (int i = 0; i < 100; i++) {
				reader.NextFrame(frame, decoder.StreamIndex);
				var bitmap = new Bitmap(frame.Format.Width, frame.Format.Height, frame.Format.Strides[0], System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame.Scan0);
				bitmap.Save($@"Z:\{i}.png");
			}
		}
	}
}
