using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodecDefault {
		public byte* Key;
		public byte* Value;
	}
}
