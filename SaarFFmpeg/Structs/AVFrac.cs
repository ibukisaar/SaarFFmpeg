using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	public struct AVFrac {
		public long Val;
		public long Num;
		public long Den;

		public override string ToString() => $"({Val}+{Num}/{Den}={Val + (float) Num / Den})";
	}
}