using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodec {
		public readonly byte* Name;
		public readonly byte* LongName;
		public readonly AVMediaType Type;
		public readonly AVCodecID Id;
		public readonly int Capabilities;
		/// <summary>
		/// 支持的帧率，结束为0
		/// </summary>
		public readonly AVRational* SupportedFramerates;
		/// <summary>
		/// 支持的像素格式，结束为<see cref="AVPixelFormat.None"/>
		/// </summary>
		public readonly AVPixelFormat* PixFmts;
		/// <summary>
		/// 支持的采样率，结束为0
		/// </summary>
		public readonly int* SupportedSamplerates;
		/// <summary>
		/// 支持的采样格式，结束为<see cref="AVSampleFormat.None"/>
		/// </summary>
		public readonly AVSampleFormat* SampleFmts;
		/// <summary>
		/// 支持的通道数，结束为0
		/// </summary>
		public readonly AVChannelLayout* ChannelLayouts;
		public readonly byte MaxLowres;
		public readonly AVClass* PrivClass;
		public readonly AVProfile* Profiles;
		public readonly int PrivDataSize;
		public readonly AVCodec* Next;
		public readonly IntPtr InitThreadCopy; // 待处理方法
		public readonly IntPtr UpdateThreadContext; // 待处理方法
		public readonly AVCodecDefault* Defaults;
		public readonly IntPtr InitStaticData; // 待处理方法
		public readonly IntPtr Init; // 待处理方法
		public readonly IntPtr EncodeSub; // 待处理方法
		public readonly IntPtr Encode2; // 待处理方法
		public readonly IntPtr Decode; // 待处理方法
		public readonly IntPtr Close; // 待处理方法
		public readonly IntPtr SendFrame; // 待处理方法
		public readonly IntPtr SendPacket; // 待处理方法
		public readonly IntPtr ReceiveFrame; // 待处理方法
		public readonly IntPtr ReceivePacket; // 待处理方法
		public readonly IntPtr Flush; // 待处理方法
		public readonly int CapsInternal;
	}
}