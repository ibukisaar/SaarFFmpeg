using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public enum AVCodecFlag : int {
		Unaligned = 1 << 0,
		Qscale = 1 << 1,
		_4MV = 1 << 2,
		OutputCorrupt = 1 << 3,
		Qpel = 1 << 4,
		Pass1 = 1 << 9,
		Pass2 = 1 << 10,
		LoopFilter = 1 << 11,
		Gray = 1 << 13,
		Psnr = 1 << 15,
		Truncated = 1 << 16,
		InterlacedDCT = 1 << 18,
		LowDelay = 1 << 19,
		GlobalHeader = 1 << 22,
		BitExact = 1 << 23,
		AcPred = 1 << 24,
		InterlacedMe = 1 << 29,
		ClosedGop = 1 << 31,
	}
}
