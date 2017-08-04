using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVOptionRanges {
		public AVOptionRange** Range;
		public int NbRanges;
		public int NbComponents;
	}
}