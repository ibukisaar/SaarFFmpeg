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

		protected IntPtr fftPlan;
		protected Task<IntPtr> optimalPlanTask;
		protected int fftSize, fftComplexCount;
		protected IntPtr inData, outData;
		private bool canFreeInData, canFreeOutData;


		public abstract Type SampleType { get; }
		public abstract int InputBytes { get; }
		public abstract int OutputBytes { get; }
		public IntPtr InData => inData;
		public IntPtr OutData => outData;
		public int FFTSize => fftSize;
		public int FFTComplexCount => fftComplexCount;

		public FFTBase(int fftSize) : this(fftSize, IntPtr.Zero, IntPtr.Zero) {
		}

		public FFTBase(int fftSize, IntPtr inData, IntPtr outData) {
			if (fftSize <= 0) throw new ArgumentException($"{nameof(fftSize)}不能小于等于0", nameof(fftSize));

			this.fftSize = fftSize;
			fftComplexCount = fftSize / 2 + 1;

			canFreeInData = inData == IntPtr.Zero;
			canFreeOutData = outData == IntPtr.Zero;

			this.inData = canFreeInData ? AllocInput() : inData;
			this.outData = canFreeOutData ? AllocOutput() : outData;

			fftPlan = CreatePlan(fftSize, this.inData, this.outData, fftw_flags.Estimate);
			if (fftSize > 4096) {
				optimalPlanTask = GetOptimalPlan();
			}
		}

		protected abstract IntPtr AllocInput();

		protected abstract IntPtr AllocOutput();

		protected abstract IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags);

		protected abstract void DestroyPlan(IntPtr plan);

		protected abstract void Free(IntPtr buffer);

		protected abstract void Execute(IntPtr plan, IntPtr input, IntPtr output);

		protected abstract void SaveConfig();


		private Task<IntPtr> GetOptimalPlan() {
			return Task.Run(() => {
				IntPtr tempIn = AllocInput();
				IntPtr tempOut = AllocOutput();
				IntPtr fft = CreatePlan(fftSize, tempIn, tempOut, fftw_flags.Measure);
				Free(tempIn);
				Free(tempOut);

				// SaveConfig();
				return fft;
			});
		}

		private void TrySwitchOptimalPlan() {
			if (optimalPlanTask != null && optimalPlanTask.Status == TaskStatus.RanToCompletion) {
				DestroyPlan(fftPlan);
				fftPlan = optimalPlanTask.Result;
				optimalPlanTask = null;
			}
		}

		public void Execute() {
			TrySwitchOptimalPlan();
			Execute(fftPlan, inData, outData);
		}

		protected override void Dispose(bool disposing) {
			if (fftPlan != IntPtr.Zero) {
				if (optimalPlanTask != null) {
					var currFft = fftPlan;
					Task.Run(() => {
						optimalPlanTask.Wait();
						DestroyPlan(currFft);
						DestroyPlan(optimalPlanTask.Result);
					});
				} else {
					DestroyPlan(fftPlan);
				}
				
				if (canFreeInData) Free(inData);
				if (canFreeOutData) Free(outData);
				fftPlan = IntPtr.Zero;
			}
		}
	}
}
