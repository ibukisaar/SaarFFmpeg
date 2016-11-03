using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public sealed class TriangularWindow : Window {
		public TriangularWindow(int fftSize) : base(fftSize) {
			double center = (fftSize - 1) / 2.0;
			double den = fftSize / 2.0;
			for (int x = 0; x < fftSize; x++) {
				window[x] = 1 - Math.Abs((x - center) / den);
			}
		}
	}
}
