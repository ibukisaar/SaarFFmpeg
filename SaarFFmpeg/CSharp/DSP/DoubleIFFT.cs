using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class DoubleIFFT : DoubleFFTBase {
		public static DoubleIFFT Create(int fftSize)
			=> Create(fftSize, () => new DoubleIFFT(fftSize));

		public override int InputBytes => fftComplexCount * sizeof(double) * 2;

		public override int OutputBytes => fftSize * sizeof(double);

		private DoubleIFFT(int fftSize) : base(fftSize) { }

		public override IntPtr AllocInput()
			=> fftw.alloc_complex((IntPtr) fftComplexCount);

		public override IntPtr AllocOutput()
			=> fftw.alloc_real((IntPtr) fftSize);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftw.dft_c2r_1d(fftSize, input, output, flags);

		protected override void Execute(IntPtr plan, IntPtr input, IntPtr output)
			=> fftw.execute_dft_c2r(plan, input, output);

		public override string ToString()
			=> $"double IFFT({fftSize})";
	}
}
