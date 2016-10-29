using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVPacketList {
		public AVPacket Pkt;
		public AVPacketList* Next;
	}
}