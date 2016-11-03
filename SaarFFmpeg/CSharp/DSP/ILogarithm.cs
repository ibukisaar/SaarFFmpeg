using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP {
	public interface ILogarithm {
		double Log(double x);
		double ILog(double y);
	}
}
