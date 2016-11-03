using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class DoubleIFFT : DoubleFFTBase {
		public override int InputBytes => fftComplexCount * sizeof(double) * 2;

		public override int OutputBytes => fftSize * sizeof(double);

		public DoubleIFFT(int fftSize) : base(fftSize) {
		}

		protected override IntPtr AllocInput()
			=> fftw.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr AllocOutput()
			=> fftw.alloc_real((IntPtr) fftSize);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftw.dft_c2r_1d(fftSize, input, output, flags);

		public override string ToString()
			=> $"double IFFT({fftSize})";
	}
}
