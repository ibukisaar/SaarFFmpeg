using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.Codecs;
using Coolest;
using Coolest.Windows;

namespace SaarFFmpeg.AudioTest {
	public class Program {
		class AudioStream : IWaveStream, IDisposable {
			public MediaReader media;
			AudioDecoder decoder;
			AudioFrame frame = new AudioFrame();
			int over = 0;

			public AudioStream(Stream stream) {
				media = new MediaReader(stream);
				decoder = media.Decoders.OfType<AudioDecoder>().First();
			}

			public WaveFormat Format
				=> new WaveFormat(decoder.InFormat.SampleRate, decoder.InFormat.ValidBitsPerSample, decoder.InFormat.Channels);

			public TimeSpan Position {
				get { return media.Position; }
				set {
					decoder.Resampler?.Reset();
					media.Position = value;
					over = 0;
				}
			}

			public void Dispose() {
				media.Dispose();
				frame.Dispose();
			}

			public int Read(byte[] buffer, int start, int length) {
				if (over == 0) {
					if (!media.NextFrame(frame, decoder.StreamIndex)) {
						Position = TimeSpan.Zero;
						return 0;
					}
					frame.ToPacked();
					over = frame.TotalBytes;
				}

				int writeLength = Math.Min(over, length);
				Marshal.Copy(frame.Data[0] + frame.TotalBytes - over, buffer, start, writeLength);
				over -= writeLength;
				return writeLength;
			}

			public void Resample(WaveFormat format) {
				decoder.OutFormat = new AudioFormat(format.SampleRate, format.Channels, format.ValidBitsPerSample);
				Saar.FFmpeg.Support.Debug.Warning($"重采样(resample) ({decoder.InFormat}) => ({decoder.OutFormat})");
			}
		}

		static void Main(string[] args) {
			var audioStream = new AudioStream(File.OpenRead(@"Z:\04 - The Flower Is Most Beautiful When It Blooms In Despair.mp3"));
			using (var wasapi = new WasapiOut(ShareMode.Shared, true, Role.Multimedia, 320)) {
				wasapi.Resample += (sender, e) => {
					audioStream.Resample(e.OutFormat);
				};
				wasapi.Initialize(audioStream);
				wasapi.Play();

				Console.ReadKey();
			}
		}
	}
}
