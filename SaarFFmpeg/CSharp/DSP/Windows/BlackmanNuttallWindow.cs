using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public sealed class BlackmanNuttallWindow : Window {
		public BlackmanNuttallWindow(int fftSize) : base(fftSize) {
			const double a0 = 0.3635819;
			const double a1 = 0.4891775;
			const double a2 = 0.1365995;
			const double a3 = 0.0106411;
			for (int i = 0; i < fftSize; i++) {
				window[i] = a0
					- a1 * Math.Cos(2 * Math.PI * i / (fftSize - 1))
					+ a2 * Math.Cos(4 * Math.PI * i / (fftSize - 1))
					- a3 * Math.Cos(6 * Math.PI * i / (fftSize - 1));
			}
		}
	}
}
