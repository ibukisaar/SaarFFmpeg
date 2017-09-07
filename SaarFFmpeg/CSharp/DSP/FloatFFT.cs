using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class FloatFFT : FloatFFTBase {
		public static FloatFFT Create(int fftSize)
			=> Create(typeof(FloatFFT), fftSize, () => new FloatFFT(fftSize));

		public override int InputBytes => fftSize * sizeof(float);

		public override int OutputBytes => fftComplexCount * sizeof(float) * 2;

		private FloatFFT(int fftSize) : base(fftSize) { }

		public override IntPtr AllocInput()
			=> fftwf.alloc_real((IntPtr) fftSize);

		public override IntPtr AllocOutput()
			=> fftwf.alloc_complex((IntPtr) fftComplexCount);

		protected override IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags)
			=> fftwf.dft_r2c_1d(fftSize, input, output, flags);

		protected override void Execute(IntPtr plan, IntPtr input, IntPtr output)
			=> fftwf.execute_dft_r2c(plan, input, output);

		public override string ToString()
			=> $"float FFT({fftSize})";
	}
}
