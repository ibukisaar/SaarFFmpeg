using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVIODirEntry {
		public byte* Name;
		public AVIODirEntryType Type;
		public int Utf8;
		public long Size;
		public long ModificationTimestamp;
		public long AccessTimestamp;
		public long StatusChangeTimestamp;
		public long UserId;
		public long GroupId;
		public long Filemode;
	}
}