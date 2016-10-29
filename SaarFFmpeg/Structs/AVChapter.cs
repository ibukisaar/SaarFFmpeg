using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVChapter {
		public int Id;
		public AVRational TimeBase;
		public long Start;
		public long End;
		public AVDictionary* Metadata;
	}
}