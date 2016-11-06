using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class DoubleFFTBase : FFTBase {
		static DoubleFFTBase() {
			// 导入智能方案后速度反而更低了，已取消此功能
			// fftw.import_wisdom_from_filename(FFTW_ConfigName);
		}

		public override Type SampleType => typeof(double);

		public DoubleFFTBase(int fftSize) : base(fftSize) { }

		public DoubleFFTBase(int fftSize, IntPtr inData, IntPtr outData) : base(fftSize, inData, outData) { }

		protected override void DestroyPlan(IntPtr plan)
			=> fftw.destroy_plan(plan);

		protected override void Free(IntPtr buffer)
			=> fftw.free(buffer);

		protected override void SaveConfig()
			=> fftw.export_wisdom_to_filename(FFTW_ConfigName);
	}
}
