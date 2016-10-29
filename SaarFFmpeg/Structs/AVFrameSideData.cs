using System;
using Saar.FFmpeg.Enumerates;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVFrameSideData {
		public AVFrameSideDataType Type;
		public byte* Data;
		public int Size;
		public AVDictionary* Metadata;
		public AVBufferRef* Buf;
	}
}