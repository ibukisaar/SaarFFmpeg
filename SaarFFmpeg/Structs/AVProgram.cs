using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVProgram {
		public int Id;
		public int Flags;
		public AVDiscard Discard;
		public uint* StreamIndex;
		public uint NbStreamIndexes;
		public AVDictionary* Metadata;
		public int ProgramNum;
		public int PmtPid;
		public int PcrPid;
		public long StartTime;
		public long EndTime;
		public long PtsWrapReference;
		public int PtsWrapBehavior;
	}
}