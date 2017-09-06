using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp.DSP {
	/// <summary>
	/// 快速卷积运算
	/// </summary>
	unsafe public class Convolver : DisposableObject {
		const int Size = sizeof(double);
		const int Threshold = 32;
		const int FixedStep = 1024;

		private DoubleFFT fft;
		private DoubleIFFT ifft;
		private double[] kernel;
		private IntPtr fftKernel;
		private int delay = 0;
		private AutoCache delayData = new AutoCache();
		private AutoCache tempBuffer = new AutoCache();

		public Convolver(double[] kerenl) : this(kerenl, 0, kerenl.Length) { }

		public Convolver(double[] kernel, int index, int length) {
			if (kernel == null) throw new ArgumentNullException(nameof(kernel));
			if (index < 0 || index > kernel.Length) throw new ArgumentOutOfRangeException(nameof(index));
			if (length < 0 || index + length > kernel.Length) throw new ArgumentOutOfRangeException(nameof(length));

			this.kernel = new double[length];
			Array.Copy(kernel, index, this.kernel, 0, length);

			if (length > Threshold) {
				fft = new DoubleFFT(length * 2);
				ifft = new DoubleIFFT(length * 2, fft.OutData, IntPtr.Zero);
				fftKernel = Marshal.AllocHGlobal(fft.FFTComplexCount * Size * 2);
				Marshal.Copy(this.kernel, 0, fft.InData, length);
				fft.Execute();
				Buffer.MemoryCopy((void*) fft.OutData, (void*) fftKernel, fft.FFTComplexCount * Size * 2, fft.FFTComplexCount * Size * 2);
			}
		}

		public int GetOutLength(int inLength) {
			return delay + inLength;
		}

		private void FFTConvolveOnce(double* dst, int dstLength) {
			int kernelLength = kernel.Length;

			fft.Execute();

			int complexCount = fft.FFTComplexCount;
			double* in1 = (double*) fft.OutData;
			double* in2 = (double*) fftKernel;
			for (int i = 0; i < complexCount; i++) {
				double r1 = in1[i * 2 + 0], i1 = in1[i * 2 + 1];
				double r2 = in2[i * 2 + 0], i2 = in2[i * 2 + 1];
				in1[2 * i + 0] = r1 * r2 - i1 * i2;
				in1[2 * i + 1] = r1 * i2 + i1 * r2;
			}

			ifft.Execute();

			int fftSize = fft.FFTSize;
			double* @out = (double*) ifft.OutData;
			int start = kernelLength - 1;
			int end = start + dstLength;
			for (int i = start; i < end; i++) {
				@out[i] /= fftSize;
			}

			Buffer.MemoryCopy(@out + start, dst, dstLength * Size, dstLength * Size);
		}

		private void ConvolveOnce(double* dst, int dstLength) {
			int kernelLength = kernel.Length;
			double* @in = (double*) tempBuffer.data;

			for (int i = 0; i < dstLength; i++) {
				double sum = 0;
				for (int j = 0; j < kernelLength; j++) {
					sum += kernel[j] * @in[i + j];
				}
				dst[i] = sum;
			}
		}

		private void ConvolveOnce(double* dst, int dstLength, bool fft) {
			if (fft) {
				FFTConvolveOnce(dst, dstLength);
			} else {
				ConvolveOnce(dst, dstLength);
			}
		}

		public int Convolve(double* src, int srcLength, double* dst, int dstLength) {
			var input = new UnionBuffer(delayData.Data, delay * Size, (IntPtr) src, srcLength * Size);
			int kernelLength = kernel.Length, offset = 0, step, copyLength;
			int outLen = Math.Max(Math.Min(delay + srcLength - (kernelLength - 1), dstLength), 0);
			IntPtr tempInput;
			bool fast = fft != null;
			
			if (fast) {
				copyLength = fft.FFTSize;
				tempInput = fft.InData;
				step = kernelLength + 1;
			} else {
				copyLength = FixedStep + kernelLength - 1;
				tempBuffer.Resize(copyLength * Size);
				tempInput = tempBuffer.Data;
				step = FixedStep;
			}
			
			for (; outLen >= step; outLen -= step, offset += step) {
				input.CopyTo(offset * Size, tempInput, copyLength * Size);
				ConvolveOnce(dst, step, fast);
				dst += step;
			}
			if (outLen > 0) {
				input.CopyTo(offset * Size, tempInput, (outLen + kernelLength - 1) * Size);
				ConvolveOnce(dst, outLen, fast);
				offset += outLen;
			}

			delay = Math.Min(Math.Max(kernelLength - 1, delay + srcLength - dstLength), delay + srcLength);
			tempBuffer.Resize(delay * Size);
			input.CopyTo(offset * Size, tempBuffer.Data, delay * Size);

			var temp = tempBuffer;
			tempBuffer = delayData;
			delayData = temp;

			return offset;
		}

		public int Convolve(double[] src, int srcOffset, int srcLength, double[] dst, int dstOffset, int dstLength) {
			fixed (double* input = &src[srcOffset])
			fixed (double* output = &dst[dstOffset]) {
				return Convolve(input, srcLength, output, dstLength);
			}
		}

		public int ConvolveFinal(double* dst, int dstLength) {
			double[] padding = new double[kernel.Length - 1];
			fixed (double* srcPadding = padding) {
				int result = Convolve(srcPadding, padding.Length, dst, dstLength);
				delay = 0;
				return result;
			}
		}

		public int ConvolveFinal(double[] dst, int dstOffset, int dstLength) {
			fixed (double* output = &dst[dstOffset]) {
				return ConvolveFinal(output, dstLength);
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				ifft?.Dispose();
				fft?.Dispose();
			}

			if (fftKernel != IntPtr.Zero) {
				Marshal.FreeHGlobal(fftKernel);
				fftKernel = IntPtr.Zero;
			}
			delayData.Free();
			tempBuffer.Free();
		}
	}
}
