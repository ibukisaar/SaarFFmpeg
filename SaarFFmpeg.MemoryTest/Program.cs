using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.Codecs;

namespace SaarFFmpeg.MemoryTest {
	class Program {
		static void Main(string[] args) {
			const string TestFile = @"Z:\test.flac";
			MediaReader media = new MediaReader(TestFile);
			var decoder = media.Decoders[0] as AudioDecoder;
			decoder.OutFormat = new AudioFormat(48000, 2, 32);
			var packet = new Packet();
			while (media.ReadPacket(packet, decoder.StreamIndex)) {
				using (var frame = new AudioFrame()) {
					decoder.Decode(packet, frame);
				}
			}
			Console.ReadKey();
		}
	}
}
