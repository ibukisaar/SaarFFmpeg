using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public sealed class BlackmanWindow : Window {
		public BlackmanWindow(int fftSize) : base(fftSize) {
			const double a0 = 0.42;
			const double a1 = 0.5;
			const double a2 = 0.08;
			for (int i = 0; i < fftSize; i++) {
				window[i] = a0
					- a1 * Math.Cos(2 * Math.PI * i / (fftSize - 1))
					+ a2 * Math.Cos(4 * Math.PI * i / (fftSize - 1));
			}
		}
	}
}
