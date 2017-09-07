using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp.DSP.Windows;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public sealed class DoubleFFT : DoubleFFTBase {
		public static DoubleFFT Create(int fftSize)
			=> Create(typeof(DoubleFFT), fftSize, () => new DoubleFFT(fftSize));

		public override int InputBytes => fftSize * sizeof(double);

		public override int OutputBytes => fftComplexCount * sizeof(double) * 2;

		private DoubleFFT(int fftSize) : base(fftSize) { }

		public override IntPtr AllocInput()
			=> fftw.alloc_real((IntPtr) fftSize);

		public override IntPtr AllocOutput()
			=> fftw.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftw.dft_r2c_1d(fftSize, input, output, flags);

		protected override void Execute(IntPtr plan, IntPtr input, IntPtr output)
			=> fftw.execute_dft_r2c(plan, input, output);

		public override string ToString()
			=> $"double FFT({fftSize})";
	}
}
