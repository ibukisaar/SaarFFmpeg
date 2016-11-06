using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class FloatFFT : FloatFFTBase, IPositiveFFT {
		public override int InputBytes => fftSize * sizeof(float);

		public override int OutputBytes => fftComplexCount * sizeof(float) * 2;

		public FloatFFT(int fftSize) : base(fftSize) { }

		public FloatFFT(int fftSize, IntPtr inData, IntPtr outData) : base(fftSize, inData, outData) { }

		protected override IntPtr AllocInput()
			=> fftwf.alloc_real((IntPtr) fftSize);

		protected override IntPtr AllocOutput()
			=> fftwf.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftwf.dft_r2c_1d(fftSize, input, output, flags);

		protected override void Execute(IntPtr plan, IntPtr input, IntPtr output)
			=> fftwf.execute_dft_r2c(plan, input, output);

		public override string ToString()
			=> $"float FFT({fftSize})";

		unsafe public void ApplyWindow(Windows.Window window) {
			float* input = (float*) inData;
			double[] win = window.window;
			for (int i = 0; i < fftSize; i++) {
				input[i] = (float) (input[i] * win[i]);
			}
		}
	}
}
