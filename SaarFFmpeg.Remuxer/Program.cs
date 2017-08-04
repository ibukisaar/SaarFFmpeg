using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.Remuxer {
	class Program {
		static void Main(string[] args) {
			using (var reader = new MediaReader(@"Z:\game.dat_000004.wmv"))
			using (var writer = new MediaWriter(@"Z:\test.mkv", reader).Initialize()) {
				Packet packet = new Packet();
				while (reader.ReadPacket(packet)) {
					writer.Write(packet);
				}
			}
		}
	}
}
