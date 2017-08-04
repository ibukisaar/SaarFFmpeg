using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVStreamInfo {
		public long LastDts;
		public long DurationGcd;
		public int DurationCount;
		public long RfpsDurationSum;
		public IntPtr DurationError; // 待处理方法
		public long CodecInfoDuration;
		public long CodecInfoDurationFields;
		public int FoundDecoder;
		public long LastDuration;
		public long FpsFirstDts;
		public int FpsFirstDtsIdx;
		public long FpsLastDts;
		public int FpsLastDtsIdx;
	}
}