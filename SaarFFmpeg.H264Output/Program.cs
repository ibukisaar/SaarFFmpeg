using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.H264Output {
	class Program {
		static void Main(string[] args) {
			var reader = new MediaReader(@"Z:\N-tone-MISOGI-fft.mp4");
			var decoder = reader.Decoders.OfType<VideoDecoder>().First();
			var packet = new Packet();
			using (var writer = new MediaRemuxer(@"Z:\output.mp4", reader.Decoders[0], reader.Decoders[1])) {
				while (reader.ReadPacket(packet)) {
					writer.Write(packet);
				}
			}
		}
	}
}
