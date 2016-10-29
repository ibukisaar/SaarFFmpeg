using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Enumerates {
	[Flags]
	public enum AVPktFlag : int {
		Key = 1,
		Corrupt = 2
	}
}
