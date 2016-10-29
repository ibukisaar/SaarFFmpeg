using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVClass {
		public byte* ClassName;
		public IntPtr ItemName; // 待处理方法
		public AVOption* Option;
		public int Version;
		public int LogLevelOffsetOffset;
		public int ParentLogContextOffset;
		public IntPtr ChildNext; // 待处理方法
		public IntPtr ChildClassNext; // 待处理方法
		public AVClassCategory Category;
		public IntPtr GetCategory; // 待处理方法
		public IntPtr QueryRanges; // 待处理方法
	}
}