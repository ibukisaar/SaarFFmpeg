using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public enum AVRounding {
		Zero = 0,
		Inf = 1,
		Down = 2,
		Up = 3,
		NearInf = 4,
		PassMinMax = 8192,
	}
}
