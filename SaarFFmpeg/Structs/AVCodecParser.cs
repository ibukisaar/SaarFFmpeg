using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodecParser {
		public fixed int CodecIds[5];
		public int PrivDataSize;
		public IntPtr ParserInit; // 待处理方法
		public IntPtr ParserParse; // 待处理方法
		public IntPtr ParserClose; // 待处理方法
		public IntPtr Split; // 待处理方法
		public AVCodecParser* Next;
	}
}