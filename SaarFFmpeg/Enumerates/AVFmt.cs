using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Enumerates {
	[Flags]
	public enum AVFmt : uint {
		NoFile = 1,
		NeedNumber = 2,
		ShowIds = 8,
		RawPicture = 0x20,
		GlobalHeader = 0x40,
		NoTimestamps = 0x80,
		GenericIndex = 0x100,
		TsDiscont = 0x200,
		VariableFPS = 0x400,
		NoDimensions = 0x800,
		NoStreams = 0x1000,
		NoBinSearch = 0x2000,
		NoGenSearch = 0x4000,
		NoByteSeek = 0x8000,
		AllowFlush = 0x10000,
		TsNonStrict = 0x20000,
		TsNegative = 0x40000,
		SeekToPts = 0x4000000
	}
}
