using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVOutputFormat {
		public readonly byte* Name;
		public readonly byte* LongName;
		public readonly byte* MimeType;
		public readonly byte* Extensions;
		public readonly AVCodecID AudioCodec;
		public readonly AVCodecID VideoCodec;
		public readonly AVCodecID SubtitleCodec;
		public readonly AVFmt Flags;
		public readonly AVCodecTag** CodecTag;
		public readonly AVClass* PrivClass;
		public readonly AVOutputFormat* Next;
		public readonly int PrivDataSize;
		public readonly IntPtr WriteHeader; // 待处理方法
		public readonly IntPtr WritePacket; // 待处理方法
		public readonly IntPtr WriteTrailer; // 待处理方法
		public readonly IntPtr InterleavePacket; // 待处理方法
		public readonly IntPtr QueryCodec; // 待处理方法
		public readonly IntPtr GetOutputTimestamp; // 待处理方法
		public readonly IntPtr ControlMessage; // 待处理方法
		public readonly IntPtr WriteUncodedFrame; // 待处理方法
		public readonly IntPtr GetDeviceList; // 待处理方法
		public readonly IntPtr CreateDeviceCapabilities; // 待处理方法
		public readonly IntPtr FreeDeviceCapabilities; // 待处理方法
		public readonly AVCodecID DataCodec;
		public readonly IntPtr Init; // 待处理方法
		public readonly IntPtr Deinit; // 待处理方法
		public readonly IntPtr CheckBitstream; // 待处理方法
	}
}