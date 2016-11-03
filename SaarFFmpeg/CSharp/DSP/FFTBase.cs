using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class FFTBase : DisposableObject {
		public static readonly string FFTW_ConfigName = "fftw.wisdom";
		public static readonly string FFTWF_ConfigName = "fftwf.wisdom";

		// 20 / ln(10)
		public const double LOG_2_DB = 8.6858896380650365530225783783321;

		// ln(10) / 20
		public const double DB_2_LOG = 0.11512925464970228420089957273422;

		protected IntPtr fftPlan;
		protected Task<IntPtr> optimalPlanTask;
		protected int fftSize, fftComplexCount;
		private IntPtr tempInput;
		protected IntPtr inData, outData;


		public abstract Type SampleType { get; }
		public abstract int InputBytes { get; }
		public abstract int OutputBytes { get; }
		public IntPtr InData => inData;
		public IntPtr OutData => outData;
		public int FFTSize => FFTSize;
		public int FFTComplexCount => fftComplexCount;

		public FFTBase(int fftSize) {
			if (fftSize <= 0) throw new ArgumentException($"{nameof(fftSize)}不能小于等于0", nameof(fftSize));

			this.fftSize = fftSize;
			fftComplexCount = fftSize / 2 + 1;

			inData = AllocInput();
			outData = AllocOutput();
			fftPlan = CreatePlan(fftSize, inData, outData, fftw_flags.Estimate);
			optimalPlanTask = GetOptimalPlan();
		}

		protected abstract IntPtr AllocInput();

		protected abstract IntPtr AllocOutput();

		protected abstract IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags);

		protected abstract void DestroyPlan(IntPtr plan);

		protected abstract void Free(IntPtr buffer);

		protected abstract void Execute(IntPtr plan);

		protected abstract void SaveConfig();
		

		private Task<IntPtr> GetOptimalPlan() {
			return Task.Run(() => {
				tempInput = AllocInput();
				IntPtr tempOutput = AllocOutput();
				IntPtr fft = CreatePlan(fftSize, tempInput, tempOutput, fftw_flags.Measure);
				Free(tempOutput);
				SaveConfig();
				return fft;
			});
		}

		private void TrySwitchOptimalPlan() {
			if (optimalPlanTask != null && optimalPlanTask.Status == TaskStatus.RanToCompletion) {
				DestroyPlan(fftPlan);
				fftPlan = optimalPlanTask.Result;

				Buffer.MemoryCopy((void*) inData, (void*) tempInput, InputBytes, InputBytes);
				Free(inData);
				inData = tempInput;

				optimalPlanTask = null;
			}
		}

		public void Execute() {
			TrySwitchOptimalPlan();
			Execute(fftPlan);
		}

		protected override void Dispose(bool disposing) {
			if (fftPlan != IntPtr.Zero) {
				DestroyPlan(fftPlan);
				Free(inData);
				Free(outData);
				fftPlan = IntPtr.Zero;
			}
		}
	}
}
