using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public sealed class GaussianWindow : Window {
		public GaussianWindow(int fftSize, double sigma = 0.3) : base(fftSize) {
			double center = (fftSize - 1) / 2.0;
			double den = sigma * center;

			for (int x = 0; x < fftSize; x++) {
				double t = (x - center) / den;
				window[x] = Math.Exp(t * t * -0.5);
			}
		}
	}
}
