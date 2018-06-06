using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.FFTW {
	public static partial class fftwf {
		const string DllName = "libfftw3f-3";

		static fftwf() {
			thread_safe();
		}
	}

	public static partial class fftw {
		const string DllName = "libfftw3-3";

		static fftw() {
			thread_safe();
		}
	}
}
