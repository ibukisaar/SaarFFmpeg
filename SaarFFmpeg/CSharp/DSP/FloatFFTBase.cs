using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class FloatFFTBase : FFTBase {
		static FloatFFTBase() {
			// fftwf.import_wisdom_from_filename(FFTWF_ConfigName);
			fftwf.thread_safe();
		}

		public override Type SampleType => typeof(float);

		public FloatFFTBase(int fftSize) : base(fftSize) { }

		public FloatFFTBase(int fftSize, IntPtr inData, IntPtr outData) : base(fftSize, inData, outData) { }

		protected override void DestroyPlan(IntPtr plan)
			=> fftwf.destroy_plan(plan);

		protected override void Free(IntPtr buffer)
			=> fftwf.free(buffer);

		protected override void SaveConfig()
			=> fftwf.export_wisdom_to_filename(FFTWF_ConfigName);
	}
}
