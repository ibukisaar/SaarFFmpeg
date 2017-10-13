using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.Remuxer {
	class Program {
		static void Main(string[] args) {
			using (var reader = new MediaReader(@"Z:\game.dat_000004.wmv")) {
				var decoder = reader.Decoders.OfType<VideoDecoder>().First();
				using (var writer = new MediaRemuxer(@"Z:\test.mkv", decoder)) {
					Packet packet = new Packet();
					while (reader.ReadPacket(packet)) {
						packet.StreamIndex = decoder.StreamIndex;
						writer.Write(packet);
					}
				}
			}
		}
	}
}
