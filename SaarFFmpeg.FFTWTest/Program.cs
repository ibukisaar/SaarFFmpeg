using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;
using Saar.FFmpeg.CSharp.DSP;
using System.Threading;
using System.Numerics;

namespace SaarFFmpeg.FFTWTest {
	unsafe class Program {
		static readonly double[] Kernel = {
			-3.2983e-05,-2.2005e-05,-1.7024e-05,4.1472e-06,5.0638e-05,0.00013312,0.00026315,0.000452,0.00070932,0.0010416,0.0014504,0.0019309,0.0024706,0.0030481,0.0036338,0.0041899,0.0046725,0.0050342,0.0052279,0.0052106,0.0049486,0.004422,0.0036286,0.0025874,0.0013403,-4.8223e-05,-0.0014932,-0.0028937,-0.0041393,-0.0051188,-0.0057296,-0.0058878,-0.0055383,-0.0046629,-0.0032866,-0.0014803,0.00063942,0.0029159,0.0051612,0.0071695,0.0087326,0.0096587,0.0097907,0.0090242,0.0073224,0.0047272,0.0013648,-0.0025558,-0.0067499,-0.010873,-0.014539,-0.017352,-0.018928,-0.01893,-0.017096,-0.013262,-0.0073849,0.00044795,0.010016,0.020971,0.032855,0.045125,0.057184,0.068419,0.07824,0.086121,0.091631,0.094464,0.094464,0.091631,0.086121,0.07824,0.068419,0.057184,0.045125,0.032855,0.020971,0.010016,0.00044795,-0.0073849,-0.013262,-0.017096,-0.01893,-0.018928,-0.017352,-0.014539,-0.010873,-0.0067499,-0.0025558,0.0013648,0.0047272,0.0073224,0.0090242,0.0097907,0.0096587,0.0087326,0.0071695,0.0051612,0.0029159,0.00063942,-0.0014803,-0.0032866,-0.0046629,-0.0055383,-0.0058878,-0.0057296,-0.0051188,-0.0041393,-0.0028937,-0.0014932,-4.8223e-05,0.0013403,0.0025874,0.0036286,0.004422,0.0049486,0.0052106,0.0052279,0.0050342,0.0046725,0.0041899,0.0036338,0.0030481,0.0024706,0.0019309,0.0014504,0.0010416,0.00070932,0.000452,0.00026315,0.00013312,5.0638e-05,4.1472e-06,-1.7024e-05,-2.2005e-05,-3.2983e-05
		};

		static Complex Filter(double hz, double FFTSize) {
			var z = Complex.Exp(new Complex(0, 2 * Math.PI / FFTSize * hz));
			var b = 0.669152709119095 + 1.33830541823819 * Complex.Pow(z, -1) + 0.669152709119095 * Complex.Pow(z, -2);
			var a = 1 + 1.40381719814556 * Complex.Pow(z, -1) + 0.599389555365550 * Complex.Pow(z, -2);
			return b / a;
		}

		static void Main(string[] args) {
			const int FFTSize = 240;
			const int FFTComplexSize = FFTSize / 2 + 1;
			var fft = new FFT(FFTSize, fftw_direction.Forward);
			var input = new Complex[FFTSize];
			var input2 = new Complex[FFTSize];
			var output = new Complex[FFTSize];
			const int RectWaveWidth = 40;
			const int RectWaveWidth2 = 30;
			var conv = new Convolver(Kernel);

			for (int i = 0; i < FFTSize; i++) {
				//input[i] = i / RectWaveWidth % 2 == 0 ? 1 : 0;
				//input[i] += i / RectWaveWidth2 % 2 == 0 ? 1 : 0;
				input[i] = 1000 + 50000 * Math.Sin(2 * Math.PI / FFTSize * 20.1 * i) + 40000 * Math.Sin(2 * Math.PI / FFTSize * 7 * i) + 9000 * Math.Sin(2 * Math.PI / FFTSize * 119 * i);
				// input[i] = 1 * Math.Sin(2 * Math.PI / FFTSize * 7 * i);
				// input[i] *= 2 * Math.Cos(2 * Math.PI / FFTSize * 5 * i);
			}

			var filter = new Complex[FFTSize];
			for (int i = 0; i < FFTSize; i++) {
				filter[i] = Filter(i, FFTSize);
			}

			
			fft.WriteInput(input);
			fft.Execute();
			fft.ReadOutput(output);

			{
				var sum = 0d;
				for (int i = 0; i < output.Length; i++) {
					var c = output[i] / (i > 0 ? fft.FFTSize / 2 : FFTSize);
					var abs = Complex.Abs(c);
					sum += abs;
					Console.WriteLine($"{i}=abs({c.Real:N6},{c.Imaginary:N6})={abs:N6}");
				}
				Console.WriteLine($"sum={sum:N6}");
			}

			//output[0] = 100 * FFTSize;
			//for (int i = 1; i < 50; i++) {
			//	output[i] = output[FFTSize - i] = 100 * FFTSize / 2;
			//}

			for (int i = 0; i < FFTSize; i++) {
				output[i] *= filter[i];
			}

			var ifft = new FFT(FFTSize, fftw_direction.Backward);
			ifft.WriteInput(output);
			ifft.Execute();
			ifft.ReadOutput(input2);

			for (int i = 0; i < input2.Length; i++) {
				input2[i] /= FFTSize;
			}

			fft.WriteInput(input2);
			fft.Execute();
			fft.ReadOutput(output);

			{
				var sum = 0d;
				for (int i = 0; i < output.Length; i++) {
					var c = output[i] / (i > 0 ? fft.FFTSize / 2 : FFTSize);
					var abs = Complex.Abs(c);
					sum += abs;
					Console.WriteLine($"{i}=abs({c.Real:N6},{c.Imaginary:N6})={abs:N6}");
				}
				Console.WriteLine($"sum={sum:N6}");
			}

		}
	}
}
