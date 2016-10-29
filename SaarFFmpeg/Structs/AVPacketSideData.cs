using Saar.FFmpeg.Enumerates;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVPacketSideData {
		public byte* Data;
		public int Size;
		public AVPacketSideDataType Type;
	}
}