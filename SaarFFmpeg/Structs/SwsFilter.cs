using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct SwsFilter {
		public SwsVector* LumH;
		public SwsVector* LumV;
		public SwsVector* ChrH;
		public SwsVector* ChrV;
	}
}
