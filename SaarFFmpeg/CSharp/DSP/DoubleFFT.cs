using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp.DSP.Windows;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class DoubleFFT : DoubleFFTBase, IPositiveFFT {
		public override int InputBytes => fftSize * sizeof(double);

		public override int OutputBytes => fftComplexCount * sizeof(double) * 2;

		public DoubleFFT(int fftSize) : base(fftSize) {
		}

		protected override IntPtr AllocInput()
			=> fftw.alloc_real((IntPtr) fftSize);

		protected override IntPtr AllocOutput()
			=> fftw.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftw.dft_r2c_1d(fftSize, input, output, flags);

		public override string ToString()
			=> $"double FFT({fftSize})";

		unsafe public void ApplyWindow(Window window) {
			double* input = (double*) inData;
			double[] win = window.window;
			for (int i = 0; i < fftSize; i++) {
				input[i] *= win[i];
			}
		}
	}
}
