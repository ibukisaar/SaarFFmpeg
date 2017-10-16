using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.CSharp.DSP;
using Saar.FFmpeg.CSharp.DSP.Windows;
using System.Runtime.InteropServices;

namespace SaarFFmpeg.FFTVisual {
	class Program {
		unsafe static void Main(string[] args) {
			const double MinimumFrequency = 10;
			const double MaximumFrequency = 20000;
			const double MaxDB = 65;
			const int fftSize = 4192 * 6;

			var reader = new MediaReader(@"Z:\Land-YOU-Rammentatore.mp3");
			var decoder = reader.Decoders.OfType<AudioDecoder>().First();
			var videoFormat = new VideoFormat(1280, 720, AVPixelFormat.Rgb0);
			var writer = new MediaWriter(@"Z:\Land-YOU-Rammentatore-fft.mkv")
				.AddEncoder(new VideoEncoder(AVCodecID.H264, videoFormat, new VideoEncoderParameters { FrameRate = new Fraction(30), GopSize = 10 }))
				.AddEncoder(new AudioEncoder(AVCodecID.Mp3, decoder.InFormat))
				//.AddVideo(videoFormat, new VideoEncoderParameters { FrameRate = new Fraction(30), GopSize = 10 })
				//.AddAudio(decoder.InFormat)
				.Initialize();

			int sampleRate = decoder.InFormat.SampleRate;
			int channels = decoder.InFormat.Channels;
			var resampler = new AudioResampler(decoder.InFormat, new AudioFormat(sampleRate, channels, 64));
			var inFrame = new AudioFrame();
			var outFrame = new AudioFrame();
			var image = new VideoFrame(videoFormat);

			var viewHeight = videoFormat.Height / 2;
			var observer = new StreamObserver<double>(fftSize * 2, fftSize / 6, 2);
			var fft = DoubleFFT.Create(fftSize);
			var inFFT = fft.AllocInput();
			var outFFT = fft.AllocOutput();
			var cutLength = FFTTools.CutFrequencyLength(fftSize, MinimumFrequency, MaximumFrequency, sampleRate, fft.FFTComplexCount);
			var cutFFT = Marshal.AllocHGlobal(cutLength * sizeof(double));
			var outFFT2 = Marshal.AllocHGlobal(fft.FFTComplexCount * sizeof(double));
			var outFFTFinal = Marshal.AllocHGlobal(viewHeight * sizeof(double));
			var window = new BlackmanHarrisWindow(fftSize);
			var log = new Spectrum3DLog();

			void FFT() {
				window.Apply((double*) inFFT, (double*) inFFT);
				fft.Execute(inFFT, outFFT);
				FFTTools.Abs(fftSize, (double*) outFFT, (double*) outFFT2);
				FFTTools.CutFrequency(fftSize, (double*) outFFT2, fft.FFTComplexCount, MinimumFrequency, MaximumFrequency, sampleRate, (double*) cutFFT, cutLength);
				FFTTools.Logarithm((double*) cutFFT, cutLength, MinimumFrequency, MaximumFrequency, (double*) outFFTFinal, viewHeight, log);
				FFTTools.ToDB((double*) outFFTFinal, viewHeight, MaxDB);
				FFTTools.Scale((double*) outFFTFinal, viewHeight, 1 / MaxDB);
			}

			void LeftShiftImage() {
				int w = image.Format.Width - 1;
				int h = image.Format.Height;
				for (int y = 0; y < h; y++) {
					var p = (uint*) (image.Data[0] + image.Format.Strides[0] * y);
					for (int x = 0; x < w; x++) {
						p[x] = p[x + 1];
					}
				}
			}

			observer.Completed += data => {
				LeftShiftImage();

				int w = image.Format.Width - 1;
				int h = image.Format.Height;
				var p = (byte*) ((uint*) image.Data[0] + w);
				var stride = image.Format.Strides[0];

				for (int i = 0; i < fftSize; i++) ((double*) inFFT)[i] = ((double*) data)[2 * i];
				FFT();
				for (int y = 0; y < viewHeight; y++, p += stride) {
					var val = ((double*) outFFTFinal)[viewHeight - y - 1] * 256;
					if (val < 0) val = 0; else if (val > 255) val = 255;
					p[0] = p[1] = p[2] = (byte) val;
				}

				for (int i = 0; i < fftSize; i++) ((double*) inFFT)[i] = ((double*) data)[2 * i + 1];
				FFT();
				for (int y = 0; y < viewHeight; y++, p += stride) {
					var val = ((double*) outFFTFinal)[viewHeight - y - 1] * 256;
					if (val < 0) val = 0; else if (val > 255) val = 255;
					p[0] = p[1] = p[2] = (byte) val;
				}
			};

			bool run = true;
			while (run) {
				writer.Write(encoder => {
					switch (encoder) {
						case AudioEncoder audioEncoder:
							Console.Write($"\r{audioEncoder.InputTimestamp}");
							if (reader.NextFrame(inFrame, decoder.StreamIndex)) {
								resampler.Resample(inFrame, outFrame);
								observer.Write(outFrame.Data[0], outFrame.SampleCount * channels);
								return inFrame;
							} else {
								resampler.ResampleFinal(outFrame);
								observer.Write(outFrame.Data[0], outFrame.SampleCount * channels);
								run = false;
								Console.WriteLine($"\r{audioEncoder.InputTimestamp}");
								return null;
							}
						case VideoEncoder videoEncoder:
							return image;
						default:
							throw new NotImplementedException();
					}
				});
			}
			writer.Dispose();
		}
	}
}
