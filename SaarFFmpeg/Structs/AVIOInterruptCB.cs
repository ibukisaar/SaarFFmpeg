using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVIOInterruptCB {
		public IntPtr Callback; // 待处理方法
		public void* Opaque;
	}
}