using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVIOContext {
		public AVClass* AvClass;
		public byte* Buffer;
		public int BufferSize;
		public byte* BufPtr;
		public byte* BufEnd;
		public void* Opaque;
		public IntPtr ReadPacket; // 待处理方法
		public IntPtr WritePacket; // 待处理方法
		public IntPtr Seek; // 待处理方法
		public long Pos;
		public int MustFlush;
		public int EofReached;
		public int WriteFlag;
		public int MaxPacketSize;
		public uint Checksum;
		public byte* ChecksumPtr;
		public IntPtr UpdateChecksum; // 待处理方法
		public int Error;
		public IntPtr ReadPause; // 待处理方法
		public IntPtr ReadSeek; // 待处理方法
		public int Seekable;
		public long Maxsize;
		public int Direct;
		public long BytesRead;
		public int SeekCount;
		public int WriteoutCount;
		public int OrigBufferSize;
		public int ShortSeekThreshold;
		public byte* ProtocolWhitelist;
		public byte* ProtocolBlacklist;
		public IntPtr WriteDataType; // 待处理方法
		public int IgnoreBoundaryPoint;
		public AVIODataMarkerType CurrentType;
		public long LastTime;
	}
}