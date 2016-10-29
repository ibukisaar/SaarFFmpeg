using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVProbeData {
		public byte* Filename;
		public byte* Buf;
		public int BufSize;
		public byte* MimeType;
	}
}