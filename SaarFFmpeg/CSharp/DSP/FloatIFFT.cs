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

		public FloatIFFT(int fftSize) : base(fftSize) { }

		public FloatIFFT(int fftSize, IntPtr inData, IntPtr outData) : base(fftSize, inData, outData) { }

		protected override IntPtr AllocInput()
			=> fftwf.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr AllocOutput()
			=> fftwf.alloc_real((IntPtr) fftSize);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftwf.dft_c2r_1d(fftSize, input, output, flags);

		protected override void Execute(IntPtr plan, IntPtr input, IntPtr output)
			=> fftwf.execute_dft_c2r(plan, input, output);

		public override string ToString() 
			=> $"float IFFT({fftSize})";
	}
}
