using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVPacket {
		public AVBufferRef* Buf;
		public long Pts;
		public long Dts;
		public byte* Data;
		public int Size;
		public int StreamIndex;
		public AVPktFlag Flags;
		public AVPacketSideData* SideData;
		public int SideDataElems;
		public long Duration;
		public long Pos;
		public long ConvergenceDuration;
	}
}