using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVHWAccel {
		public byte* Name;
		public AVMediaType Type;
		public AVCodecID Id;
		public AVPixelFormat PixFmt;
		public int Capabilities;
		public AVHWAccel* Next;
		public IntPtr AllocFrame; // 待处理方法
		public IntPtr StartFrame; // 待处理方法
		public IntPtr DecodeSlice; // 待处理方法
		public IntPtr EndFrame; // 待处理方法
		public int FramePrivDataSize;
		public IntPtr DecodeMb; // 待处理方法
		public IntPtr Init; // 待处理方法
		public IntPtr Uninit; // 待处理方法
		public int PrivDataSize;
	}
}