using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public sealed class NuttallWindow : Window {
		public NuttallWindow(int fftSize) : base(fftSize) {
			const double a0 = 0.355768;
			const double a1 = 0.487396;
			const double a2 = 0.144232;
			const double a3 = 0.012604;
			for (int i = 0; i < fftSize; i++) {
				window[i] = a0
					- a1 * Math.Cos(2 * Math.PI * i / (fftSize - 1))
					+ a2 * Math.Cos(4 * Math.PI * i / (fftSize - 1))
					- a3 * Math.Cos(6 * Math.PI * i / (fftSize - 1));
			}
		}
	}
}
