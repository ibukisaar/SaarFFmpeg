using System;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVBufferRef {
		public IntPtr AVBufferPtr;
		public byte* Data;
		public int Size;
	}
}
