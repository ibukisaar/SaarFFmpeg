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
	}
}
