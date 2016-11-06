using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public static class FFTTools {
		// 20 / ln(10)
		public const double LOG_2_DB = 8.6858896380650365530225783783321;

		// ln(10) / 20
		public const double DB_2_LOG = 0.11512925464970228420089957273422;



		public static int GetComplexCount(int fftSize) => fftSize / 2 + 1;

		/// <summary>
		/// FFT结果取模
		/// </summary>
		/// <param name="fftSize">fft大小</param>
		/// <param name="input">输入缓冲区</param>
		/// <param name="output">输出缓冲区，应是输入缓冲区大小的一半</param>
		/// <param name="sqrt">true则进行sqrt运算</param>
		public static void Abs(int fftSize, double* input, double* output, bool sqrt = true) {
			int length = GetComplexCount(fftSize);
			double real = input[0];
			double imag = input[1];

			if (sqrt) {
				output[0] = Math.Sqrt(real * real + imag * imag) / fftSize;
				for (int i = 1; i < length; i++) {
					real = input[i * 2 + 0];
					imag = input[i * 2 + 1];
					output[i] = Math.Sqrt(real * real + imag * imag) / fftSize * 2;
				}
			} else {
				output[0] = (real * real + imag * imag) / fftSize;
				for (int i = 1; i < length; i++) {
					real = input[i * 2 + 0];
					imag = input[i * 2 + 1];
					output[i] = (real * real + imag * imag) / fftSize * 2;
				}
			}
		}

		public static double DB(double x, double maxDB) {
			double r = Math.Log(x) * LOG_2_DB + maxDB;
			// double r = Math.Log(x * MAX_DB_CONST_VALUE) * LOG_2_DB;
			return r < 0 ? 0 : r;
		}

		public static void ToDB(double* data, int length, double maxDB = 60) {
			for (int i = 0; i < length; i++) {
				data[i] = DB(data[i], maxDB);
			}
		}

		public static void Scale(double* data, int length, double scale) {
			for (int i = 0; i < length; i++) {
				data[i] *= scale;
			}
		}

		public static int GetFrequencyIndex(int fftSize, double frequency, int sampleRate) {
			return (int) Math.Round(frequency * fftSize / sampleRate);
		}

		private static double Max(double* data, int length, double index1, double index2) {
			double y = 0;

			int ix1 = Math.Max((int) Math.Round(index1), 0);
			int ix2 = Math.Min((int) Math.Round(index2), length - 1);

			for (int i = ix1; i <= ix2; i++) {
				if (data[i] > y) y = data[i];
			}

			return y;
		}

		public static void Logarithm(double* src, int srcWidth, int srcMinFrequency, int srcMaxFrequency, double* dst, int dstWidth, ILogarithm log) {
			if (log != null) {
				double scale = (srcWidth - 1) / (srcMaxFrequency - srcMinFrequency);
				double minMel = log.Log(srcMinFrequency);
				double maxMel = log.Log(srcMaxFrequency);
				double mscale = (maxMel - minMel) / dstWidth;

				for (int i = 0; i < dstWidth; i++) {
					double x1 = (log.ILog(i * mscale + minMel) - srcMinFrequency) * scale;
					double x2 = (log.ILog((i + 1) * mscale + minMel) - srcMinFrequency) * scale;
					dst[i] = Max(src, srcWidth, x1, x2);
				}
			} else {
				double scale = (double) (srcWidth - 1) / dstWidth;
				for (int i = 0; i < dstWidth; i++) {
					double x1 = i * scale;
					double x2 = x1 + scale;
					dst[i] = Max(src, srcWidth, x1, x2);
				}
			}
		}
	}
}
