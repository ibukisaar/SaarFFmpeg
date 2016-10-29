using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVIndexEntry {
		public long Pos;
		public long Timestamp;
		public int Flags_Size;
		public int MinDistance;
	}
}