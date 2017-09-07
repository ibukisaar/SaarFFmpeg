using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;
using System.Threading;
using System.Collections.Concurrent;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class FFTBase : DisposableObject {
		public static readonly string FFTW_ConfigName = "fftw.wisdom";
		public static readonly string FFTWF_ConfigName = "fftwf.wisdom";

		private struct OptimalPlanKey {
			public Type type;
			public int fftSize;

			public OptimalPlanKey(Type type, int fftSize) {
				this.type = type;
				this.fftSize = fftSize;
			}
		}

		private static readonly IDictionary<OptimalPlanKey, FFTBase> optimalPlanMap = new ConcurrentDictionary<OptimalPlanKey, FFTBase>();

		protected static T Create<T>(Type type, int fftSize, Func<T> creator) where T : FFTBase {
			lock (optimalPlanMap) {
				if (optimalPlanMap.TryGetValue(new OptimalPlanKey(type, fftSize), out var result)) {
					result.Ref();
				} else {
					result = creator();
					optimalPlanMap.Add(new OptimalPlanKey(type, fftSize), result);
				}
				return result as T;
			}
		}

		internal int refCount = 1;
		protected IntPtr fftPlan;
		protected Task<IntPtr> optimalPlanTask;
		protected int fftSize, fftComplexCount;

		public abstract Type SampleType { get; }
		public abstract int InputBytes { get; }
		public abstract int OutputBytes { get; }
		public int FFTSize => fftSize;
		public int FFTComplexCount => fftComplexCount;

		protected FFTBase(int fftSize) {
			if (fftSize <= 0) throw new ArgumentException($"{nameof(fftSize)}不能小于等于0", nameof(fftSize));

			this.fftSize = fftSize;
			fftComplexCount = fftSize / 2 + 1;

			fftPlan = CreatePlan(fftSize, IntPtr.Zero, IntPtr.Zero, fftw_flags.Estimate);
			if (fftSize > 4096) {
				optimalPlanTask = GetOptimalPlan();
			}
		}

		public abstract IntPtr AllocInput();

		public abstract IntPtr AllocOutput();

		protected abstract IntPtr CreatePlan(int fftSize, IntPtr input, IntPtr output, fftw_flags flags);

		protected abstract void DestroyPlan(IntPtr plan);

		public abstract void Free(IntPtr buffer);

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
			lock (this) {
				if (optimalPlanTask != null && optimalPlanTask.Status == TaskStatus.RanToCompletion) {
					DestroyPlan(fftPlan);
					fftPlan = optimalPlanTask.Result;
					optimalPlanTask = null;
				}
			}
		}

		public void Execute(IntPtr inData, IntPtr outData) {
			TrySwitchOptimalPlan();
			Execute(fftPlan, inData, outData);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) Unref();
		}

		protected void Free() {
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
				
				fftPlan = IntPtr.Zero;
			}
		}

		protected void Ref() {
			lock (this) { refCount++; }
		}

		protected void Unref() {
			lock (this) {
				refCount--;
				if (refCount == 0) {
					Free();
					optimalPlanMap.Remove(new OptimalPlanKey(GetType(), fftSize));
				}
			}
		}
	}
}
