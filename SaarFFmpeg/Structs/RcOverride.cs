using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	public struct RcOverride {
		public int StartFrame;
		public int EndFrame;
		public int Qscale;
		public float QualityFactor; 
	}
}
