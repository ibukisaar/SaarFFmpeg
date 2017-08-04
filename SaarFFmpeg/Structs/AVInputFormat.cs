using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVInputFormat {
		public readonly byte* Name;
		public readonly byte* LongName;
		public readonly int Flags;
		public readonly byte* Extensions;
		public readonly IntPtr CodecTag_AVCodecTagPtrPtr;
		public readonly AVClass* PrivClass;
		public readonly byte* MimeType;
		public readonly AVInputFormat* Next;
		public readonly int RawCodecId;
		public readonly int PrivDataSize;
		public readonly IntPtr ReadProbe; // 待处理方法
		public readonly IntPtr ReadHeader; // 待处理方法
		public readonly IntPtr ReadPacket; // 待处理方法
		public readonly IntPtr ReadClose; // 待处理方法
		public readonly IntPtr ReadSeek; // 待处理方法
		public readonly IntPtr ReadTimestamp; // 待处理方法
		public readonly IntPtr ReadPlay; // 待处理方法
		public readonly IntPtr ReadPause; // 待处理方法
		public readonly IntPtr ReadSeek2; // 待处理方法
		public readonly IntPtr GetDeviceList; // 待处理方法
		public readonly IntPtr CreateDeviceCapabilities; // 待处理方法
		public readonly IntPtr FreeDeviceCapabilities; // 待处理方法
	}
}