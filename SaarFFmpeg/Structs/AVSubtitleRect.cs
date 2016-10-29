using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Support;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVSubtitleRect {
		public int X;
		public int Y;
		public int W;
		public int H;
		public int NbColors;
		public AVPicture Pict;
		public BytePtrArray4 Data;
		public fixed int Linesize[4];
		public AVSubtitleType Type;
		public byte* Text;
		public byte* Ass;
		public int Flags;
	}
}