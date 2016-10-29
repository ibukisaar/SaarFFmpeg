using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodecDescriptor {
		public AVCodecID Id;
		public AVMediaType Type;
		public byte* Name;
		public byte* LongName;
		public int Props;
		public byte** MimeTypes;
		public AVProfile* Profiles;
	}
}