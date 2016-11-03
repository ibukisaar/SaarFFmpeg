using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.FFTW;

namespace Saar.FFmpeg.CSharp.DSP {
	public static class FFTWisdom {
		public readonly static string ConfigFileName = "fft.wisdom";

		static FFTWisdom() {
			fftw.import_wisdom_from_filename(ConfigFileName);
		}

		public static void LoadConfig() { }
	}
}
