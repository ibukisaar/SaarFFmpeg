using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class DoubleFFTBase : FFTBase {
		public override Type SampleType => typeof(double);

		protected DoubleFFTBase(int fftSize) : base(fftSize) { }

		protected override void DestroyPlan(IntPtr plan)
			=> fftw.destroy_plan(plan);

		public override void Free(IntPtr buffer)
			=> fftw.free(buffer);

		protected override void SaveConfig()
			=> fftw.export_wisdom_to_filename(FFTW_ConfigName);
	}
}
