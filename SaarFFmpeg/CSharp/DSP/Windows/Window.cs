using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP.Windows {
	public abstract class Window {
		internal protected double[] window;

		public Window(int fftSize) {
			window = new double[fftSize];
		}

		unsafe public void Apply(double* input, double* output) {
			int length = window.Length;
			for (int i = 0; i < length; i++) {
				output[i] = input[i] * window[i];
			}
		}
	}
}
