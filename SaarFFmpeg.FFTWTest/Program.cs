using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;
using Saar.FFmpeg.CSharp.DSP;
using System.Threading;

namespace SaarFFmpeg.FFTWTest {
	class Program {
		static void Main(string[] args) {
			const int FFTSize = 65536;
			const int FFTComplexSize = FFTSize / 2 + 1;
			const int N = 5;
			var ins = new IntPtr[N];
			var outs = new IntPtr[N];
			var tasks = new Task[N];
			for (int i = 0; i < N; i++) {
				ins[i] = fftw.alloc_real((IntPtr) FFTSize);
				outs[i] = fftw.alloc_complex((IntPtr) FFTComplexSize);
			}
			IntPtr plan = fftw.dft_r2c_1d(FFTSize, IntPtr.Zero, IntPtr.Zero, fftw_flags.Measure);
			for (int i = 0; i < N; i++) {
				var j = i;
				tasks[i] = Task.Run(() => fftw.execute_dft_r2c(plan, ins[j], outs[j]));
			}
			Task.WaitAll(tasks);
			Console.WriteLine("end");

			var fft1 = DoubleFFT.Create(10000);
			var fft2 = DoubleFFT.Create(10000);
			Thread.Sleep(10000);
		}
	}
}
