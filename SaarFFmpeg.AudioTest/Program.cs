using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.DSP;
using Coolest;
using Coolest.Windows;

namespace SaarFFmpeg.AudioTest {
	public class Program {
		class AudioStream : IWaveStream, IDisposable {
			public MediaReader media;
			public AudioDecoder decoder;
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
				Saar.FFmpeg.CSharp.Debug.Warning($"重采样(resample) ({decoder.InFormat}) => ({decoder.OutFormat})");
			}
		}

		/*
		unsafe class FilterTest : IWaveStream {
			private Convolver convolver;
			private AudioStream audioStream;
			private AudioResampler resampler;
			private AudioFrame inFrame, outFrame;
			private byte[] temp = new byte[4096 * 3];
			private WaveFormat inWaveFormat;
			private int over = 0;

			public FilterTest(AudioStream audioStream) {
				this.audioStream = audioStream;
				this.convolver = new Convolver(new double[] { 1 });
				inWaveFormat = new WaveFormat(audioStream.Format.SampleRate, 32, audioStream.Format.Channels);
				audioStream.Resample(inWaveFormat);
				inFrame = new AudioFrame(audioStream.decoder.OutFormat.ToPacked());
			}

			public WaveFormat Format => inWaveFormat;

			public int Read(byte[] buffer, int start, int length) {
				if (over == 0) {
					over = audioStream.Read(temp, 0, temp.Length);
					inFrame.Update(over / inWaveFormat.BlockAlign, temp);
					double[] input = new double[inFrame.SampleCount];
					double* frameData = (double*) inFrame.Data[0];
					for (int i = 0; i < input.Length; i++) {
						input[i] = frameData[i * 2];
					}
					double[] output = new double[convolver.GetOutLength(input.Length)];
					int len = convolver.Convolve(input, 0, input.Length, output, 0, output.Length);

					if (resampler != null) {

					}
				}

				return 0;
			}

			public void Resample(WaveFormat format) {
				resampler = new AudioResampler(
					new AudioFormat(Format.SampleRate, Format.ValidBitsPerSample, Format.Channels),
					new AudioFormat(format.SampleRate, format.ValidBitsPerSample, format.Channels)
					);
				outFrame = new AudioFrame(new AudioFormat(format.SampleRate, format.Channels, format.ValidBitsPerSample, true));
			}
		}
		*/

		static void Main(string[] args) {
			var audioStream = new AudioStream(File.OpenRead(@"D:\MyDocuments\Music\虾米音乐\Cyua-Blumenkranz.mp3"));
			using (var wasapi = new WasapiOut(ShareMode.Shared, true, Role.Multimedia, 640)) {
				wasapi.Resample += (sender, e) => {
					audioStream.Resample(e.OutFormat);
				};
				wasapi.Initialize(audioStream);
				wasapi.Play();
				Console.WriteLine("播放...");
				Console.ReadKey();
			}
			Console.WriteLine("释放");
		}
	}
}
