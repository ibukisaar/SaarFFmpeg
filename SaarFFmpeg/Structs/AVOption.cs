using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVOption {
		public byte* Name;
		public byte* Help;
		public int Offset;
		public AVOptionType Type;
		public long DefaultVal;
		public double Min;
		public double Max;
		public int Flags;
		public byte* Unit;
	}
}