using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP {
	public sealed class Spectrum3DLog : ILogarithm {
		const double CutOffFrequency = 440;

		/// <summary>
		/// 440 / (e ^ (<paramref name="y"/> / 1127) - 1)
		/// </summary>
		/// <param name="y"></param>
		/// <returns></returns>
		public double ILog(double y) {
			return CutOffFrequency * (Math.Exp(y / 1127) - 1);
		}

		/// <summary>
		/// 1127 * ln(1 + <paramref name="x"/> / 440)
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public double Log(double x) {
			return 1127 * Math.Log(1 + x / CutOffFrequency);
		}
	}
}
