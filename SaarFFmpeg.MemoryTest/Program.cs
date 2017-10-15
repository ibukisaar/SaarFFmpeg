using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.MemoryTest {
	class Program {
		static void Main(string[] args) {
			const string TestFile = @"Z:\Halozy-厄神様のジレンマ.mp3";
			MediaReader media = new MediaReader(TestFile);
			var decoder = media.Decoders[0] as AudioDecoder;
			decoder.OutFormat = new AudioFormat(48000, 2, 32);
			var packet = new Packet();
			while (media.ReadPacket(packet, decoder.StreamIndex)) {
				Console.Write($"\r{packet.PresentTimestamp}");
				using (var frame = new AudioFrame()) {
					decoder.Decode(packet, frame);
				}
			}
			Console.WriteLine($"\r{packet.PresentTimestamp}");
			Console.ReadKey();
		}
	}
}
