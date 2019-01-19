using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Internal;

using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace SaarFFmpeg.ApiTest {
	class Program {
		static void Main(string[] args) {
			var encoder = new VideoEncoder(AVCodecID.H264, 
				new VideoFormat(100, 100, AVPixelFormat.Yuv420p, 16), 
				new VideoEncoderParameters {
					BitRate = BitRate.FromKBitPerSecond(1080),
					FrameRate = new Fraction(15),
					GopSize = 15,
					ResampleFlags = SwsFlags.FastBilinear
				}
			);
			
			var memory = new System.IO.MemoryStream();
			using (var writer = new MediaWriter(memory).AddEncoder(encoder).Initialize()) {

			}
		}
	}
}
