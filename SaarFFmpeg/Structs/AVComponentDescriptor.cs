using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVComponentDescriptor {
		public int Plane;
		public int Step;
		public int Offset;
		public int Shift;
		public int Depth;
		private int Deprecated1;
		private int Deprecated2;
		private int Deprecated3;
	}
}
