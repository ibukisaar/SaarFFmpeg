using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.EncodeVideo {
	class Program {
		unsafe static void Main(string[] args) {
			var audioFormat = new AudioFormat(44100, AVChannelLayout.LayoutStereo, AVSampleFormat.FloatPlanar);
			var videoFormat = new VideoFormat(1280, 720, AVPixelFormat.Bgr24);
			using (var writer = new MediaWriter(@"Z:\test.mkv")
				.AddVideo(videoFormat)
				.AddAudio(audioFormat)
				.Initialize()) {
				
				var aframe = new AudioFrame(audioFormat);
				var vframe = new VideoFrame(videoFormat);
				float[] left = new float[1024];
				byte[] bitmap = new byte[videoFormat.Bytes];
				vframe.Update(bitmap);
				for (int j = 0; j < 1000; j++) {
					writer.Write(encoder => {
						if (encoder is AudioEncoder) {
							int samples = left.Length;
							long offset = encoder.InputFrames;
							for (int i = 0; i < samples; i++) {
								float value = (float) Math.Sin(440d / 44100 * Math.PI * 2 * (i + offset));
								left[i] = value;
							}
							aframe.Update(samples, left, left);
							return aframe;
						} else {
							Console.WriteLine($"{encoder.FullName} ---> ({encoder.InputFrames}) {encoder.InputTimestamp}");
							return vframe;
						}
					});
				}
			}
		}
	}
}
