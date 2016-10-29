using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.Codecs;
using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Internal;
using System.Diagnostics;

namespace SaarFFmpeg.EncodeAudio {
	class Program {
		unsafe static void Main(string[] args) {
			using (var reader = new MediaReader(@"Z:\15 - 青空サーチライト-Re-□-.mp3")) {
				var decoder = reader.Decoders.OfType<AudioDecoder>().First();
				var encoder = new AudioEncoder(AVCodecID.Mp3, decoder.OutFormat, BitRate._320KBps);
				var frame = new AudioFrame();
				using (var writer = new MediaWriter(@"Z:\output.mp3", true).AddEncoder(encoder).Initialize()) {
					var enc = writer.Encoders[0] as AudioEncoder;
					while (reader.NextFrame(frame, decoder.StreamIndex)) {
						Console.Write($"\rframes: {enc.InputFrames}, time: {enc.InputTimestamp}");
						writer.Write(frame);
					}
					Console.WriteLine($"\rframes: {enc.InputFrames}, time: {enc.InputTimestamp}");
				}
			}
		}
	}
}
