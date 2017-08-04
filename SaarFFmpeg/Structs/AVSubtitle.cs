using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVSubtitle {
		public ushort Format;
		public uint StartDisplayTime;
		public uint EndDisplayTime;
		public uint NumRects;
		public AVSubtitleRect** Rects;
		public long Pts;
	}
}