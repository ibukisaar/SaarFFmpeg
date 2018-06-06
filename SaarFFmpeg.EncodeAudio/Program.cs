using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Internal;
using System.Diagnostics;
using System.IO;

namespace SaarFFmpeg.EncodeAudio {
	class Program {
		unsafe static void Main(string[] args) {
			using (var reader = new MediaReader(@"D:\MyDocuments\Music\夕立のりぼん+inst（NoMastering）_island__201411091428.mp3")) {
				var decoder = reader.Decoders.OfType<AudioDecoder>().First();
				var frame = new AudioFrame();
				using (var writer = new MediaWriter(@"D:\MyDocuments\Music\夕立のりぼん+inst（NoMastering）_island__201411091428-output.mp3").AddAudio(decoder.OutFormat, BitRate._320Kbps).Initialize()) {
					var enc = writer.Encoders[0] as AudioEncoder;
					while (reader.NextFrame(frame, decoder.StreamIndex)) {
						var pos = reader.Position;
						writer.Write(frame);
						Console.Write($"\rframes: {enc.InputFrames}, time: {enc.InputTimestamp}");
					}
					writer.Flush();
					Console.WriteLine($"\rframes: {enc.InputFrames}, time: {enc.InputTimestamp}");
				}
			}
		}
	}
}
