using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVOptionRange {
		public byte* Str;
		public double ValueMin;
		public double ValueMax;
		public double ComponentMin;
		public double ComponentMax;
		public int IsRange;
	}
}