using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;
using System.Linq.Expressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public sealed class FFT : DisposableObject {
		public enum ComplexType {
			Double, Float
		}

		public IntPtr Plan {
			get {
				if (measureTask != null) {
					rwLocker.EnterWriteLock();
					try {
						if (measureTask != null && measureTask.IsCompleted) {
							var (newPlan, newInput, newOutput) = measureTask.Result;
							Buffer.MemoryCopy((void*)plan.Input, (void*)newInput, FFTSize * elementSize, FFTSize * elementSize);
							Buffer.MemoryCopy((void*)plan.Output, (void*)newOutput, FFTSize * elementSize, FFTSize * elementSize);
							DestroyPlan(plan);
							plan = (newPlan, newInput, newOutput);
							measureTask = null;
						}
					} finally {
						rwLocker.ExitWriteLock();
					}
				} else return plan.Plan;

				rwLocker.EnterReadLock();
				try {
					return plan.Plan;
				} finally {
					rwLocker.ExitReadLock();
				}
			}
		}

		public IntPtr Input {
			get {
				rwLocker.EnterReadLock();
				try {
					return plan.Input;
				} finally {
					rwLocker.ExitReadLock();
				}
			}
		}

		public IntPtr Output {
			get {
				rwLocker.EnterReadLock();
				try {
					return plan.Output;
				} finally {
					rwLocker.ExitReadLock();
				}
			}
		}

		public int FFTSize { get; }
		public int FFTComplexCount { get; }
		public ComplexType Type { get; }

		private readonly ReaderWriterLockSlim rwLocker = new ReaderWriterLockSlim();
		private (IntPtr Plan, IntPtr Input, IntPtr Output) plan;
		private Task<(IntPtr Plan, IntPtr Input, IntPtr Output)> measureTask;
		private readonly int elementSize;
		private readonly Func<int, IntPtr> fftwAlloc;
		private readonly Action<IntPtr> fftwFree;
		private readonly Func<int, IntPtr, IntPtr, fftw_direction, fftw_flags, IntPtr> fftwCreatePlan;
		private readonly Action<IntPtr> fftwDestroyPlan;
		private readonly Action<IntPtr> fftwExecute;

		public FFT(int fftSize, fftw_direction dir, ComplexType complexType = ComplexType.Double) {
			FFTSize = fftSize;
			FFTComplexCount = FFTSize / 2 + 1;
			Type = complexType;

			switch (complexType) {
				case ComplexType.Double:
					fftwAlloc = _fftSize => fftw.alloc_complex((IntPtr)_fftSize);
					fftwFree = fftw.free;
					fftwCreatePlan = fftw.dft_1d;
					fftwDestroyPlan = fftw.destroy_plan;
					fftwExecute = fftw.execute;
					elementSize = sizeof(double) * 2;
					break;
				case ComplexType.Float:
					fftwAlloc = _fftSize => fftwf.alloc_complex((IntPtr)_fftSize);
					fftwFree = fftwf.free;
					fftwCreatePlan = fftwf.dft_1d;
					fftwDestroyPlan = fftwf.destroy_plan;
					fftwExecute = fftwf.execute;
					elementSize = sizeof(float) * 2;
					break;
				default: throw new ArgumentException("超出预期值", nameof(complexType));
			}
			{
				var input = fftwAlloc(fftSize * elementSize);
				var output = fftwAlloc(fftSize * elementSize);
				var plan = fftwCreatePlan(fftSize, input, output, dir, fftw_flags.Estimate);
				this.plan = (plan, input, output);
			}
			measureTask = Task.Run(() => {
				var input = fftwAlloc(FFTSize * elementSize);
				var output = fftwAlloc(FFTSize * elementSize);
				var result = fftwCreatePlan(fftSize, input, output, dir, fftw_flags.Measure);
				return (result, input, output);
			});
		}

		public void DestroyPlan((IntPtr Plan, IntPtr Input, IntPtr Output) plan) {
			fftwDestroyPlan(plan.Plan);
			fftwFree(plan.Input);
			fftwFree(plan.Output);
		}

		public void Execute() {
			if (Plan == null) throw new InvalidOperationException("对象已释放。");
			fftwExecute(Plan);
		}

		protected override void Dispose(bool disposing) {
			rwLocker.EnterWriteLock();
			try {
				if (plan.Plan != IntPtr.Zero) {
					if (measureTask != null) {
						Task.Run(() => {
							measureTask.Wait();
							DestroyPlan(measureTask.Result);
						});
					}
					DestroyPlan(plan);
					plan = (IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
				}
			} finally {
				rwLocker.ExitWriteLock();
			}
		}

		public void WriteInput(IntPtr src, int srcBytes) {
			Buffer.MemoryCopy((void*)src, (void*)Input, srcBytes, FFTSize * elementSize);
		}

		public void WriteInput(Array src) {
			var elementSize = Marshal.SizeOf(src.GetType().GetElementType());
			var handle = GCHandle.Alloc(src, GCHandleType.Pinned);
			try {
				WriteInput(handle.AddrOfPinnedObject(), src.Length * elementSize);
			} finally {
				handle.Free();
			}
		}

		public void WriteComplexToInput(double* src, int srcComplexCount) {
			if (elementSize == sizeof(double) * 2) {
				WriteInput((IntPtr)src, srcComplexCount * sizeof(double) * 2);
			} else {
				var count = Math.Min(FFTSize, srcComplexCount) * 2;
				var input = (float*)Input;
				for (int i = 0; i < count; i++) {
					input[i] = (float)src[i];
				}
			}
		}

		public void WriteComplexToInput(double[] src) {
			fixed (double* p = src) {
				WriteComplexToInput(p, src.Length / 2);
			}
		}

		public void WriteRealToInput(double* src, int srcRealCount) {
			var count = Math.Min(FFTSize, srcRealCount);
			if (elementSize == sizeof(double) * 2) {
				var input = (double*)Input;
				for (int i = 0; i < count; i++) {
					input[2 * i] = src[i];
					input[2 * i + 1] = 0;
				}
			} else {
				var input = (float*)Input;
				for (int i = 0; i < count; i++) {
					input[2 * i] = (float)src[i];
					input[2 * i + 1] = 0;
				}
			}
		}

		public void WriteRealToInput(double[] src) {
			fixed (double* p = src) {
				WriteRealToInput(p, src.Length);
			}
		}


		public void ReadOutput(IntPtr dst, int dstBytes) {
			Buffer.MemoryCopy((void*)Output, (void*)dst, FFTSize * elementSize, dstBytes);
		}

		public void ReadOutput(Array dst) {
			var elementSize = Marshal.SizeOf(dst.GetType().GetElementType());
			var handle = GCHandle.Alloc(dst, GCHandleType.Pinned);
			try {
				ReadOutput(handle.AddrOfPinnedObject(), dst.Length * elementSize);
			} finally {
				handle.Free();
			}
		}

		public void ReadComplexFromOutput(double* dst, int dstComplexCount) {
			if (elementSize == sizeof(double) * 2) {
				ReadOutput((IntPtr)dst, dstComplexCount * sizeof(double) * 2);
			} else {
				var count = Math.Min(FFTSize, dstComplexCount) * 2;
				var output = (float*)Output;
				for (int i = 0; i < count; i++) {
					dst[i] = output[i];
				}
			}
		}

		public void ReadComplexFromOutput(double[] dst) {
			fixed (double* p = dst) {
				ReadComplexFromOutput(p, dst.Length / 2);
			}
		}

		public void ReadMagnitudeFromOutput(double* dst, int dstRealCount) {
			var count = Math.Min(FFTSize, dstRealCount);
			if (elementSize == sizeof(double) * 2) {
				var output = (double*)Output;
				for (int i = 0; i < count; i++) {
					dst[i] = Math.Sqrt(output[2 * i] * output[2 * i] + output[2 * i + 1] + output[2 * i + 1]);
				}
			} else {
				var output = (float*)Output;
				for (int i = 0; i < count; i++) {
					dst[i] = Math.Sqrt(output[2 * i] * output[2 * i] + output[2 * i + 1] + output[2 * i + 1]);
				}
			}
		}

		public void ReadMagnitudeFromOutput(double[] dst) {
			fixed (double* p = dst) {
				ReadMagnitudeFromOutput(p, dst.Length);
			}
		}
	}
}
