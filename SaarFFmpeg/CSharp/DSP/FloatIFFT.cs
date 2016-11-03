using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class FloatIFFT : FloatFFTBase {
		public override int InputBytes => fftComplexCount * sizeof(float) * 2;

		public override int OutputBytes => fftSize * sizeof(float);

		public FloatIFFT(int fftSize) : base(fftSize) {
		}

		protected override IntPtr AllocInput()
			=> fftwf.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr AllocOutput()
			=> fftwf.alloc_real((IntPtr) fftSize);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftwf.dft_c2r_1d(fftSize, input, output, flags);

		public override string ToString() 
			=> $"float IFFT({fftSize})";
	}
}
