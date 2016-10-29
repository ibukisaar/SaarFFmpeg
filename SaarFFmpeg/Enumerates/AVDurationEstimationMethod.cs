using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Enumerates {
	public enum AVDurationEstimationMethod {
		FromPts,
		FromStream,
		FromBitrate
	}
}
