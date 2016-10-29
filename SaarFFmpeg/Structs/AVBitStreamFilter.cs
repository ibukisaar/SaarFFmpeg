using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Support;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVBitStreamFilter {
		public byte* Name;
		public AVCodecID CodecIds;
		public AVClass* PrivClass;
		public int PrivDataSize;
		public IntPtr Init; // 待处理方法
		public IntPtr Filter; // 待处理方法
		public IntPtr Close; // 待处理方法
	}
}
