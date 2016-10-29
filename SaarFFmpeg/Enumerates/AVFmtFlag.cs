using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Enumerates {
	[Flags]
	public enum AVFmtFlag : int {
		/// <summary>
		/// Generate missing pts even if it requires parsing future frames.
		/// </summary>
		GenPts = 0x0001,
		/// <summary>
		/// Ignore index.
		/// </summary>
		IgnIdx = 0x0002,
		/// <summary>
		/// Do not block when reading packets from input.
		/// </summary>
		NonBlock = 0x0004,
		/// <summary>
		/// Ignore DTS on frames that contain both DTS &amp; PTS
		/// </summary>
		IgnDts = 0x0008,
		/// <summary>
		/// Do not infer any values from other values, just return what is stored in the container
		/// </summary>
		NoFillIn = 0x0010,
		/// <summary>
		/// Do not use AVParsers, you also must set AVFMT_FLAG_NOFILLIN as the fillin code works on frames and no parsing -> no frames. Also seeking to frames can not work if parsing to find frame boundaries has been disabled
		/// </summary>
		NoParse = 0x0020,
		/// <summary>
		/// Do not buffer frames when possible
		/// </summary>
		NoBuffer = 0x0040,
		/// <summary>
		/// The caller has supplied a custom AVIOContext, don't avio_close() it.
		/// </summary>
		CustomIO = 0x0080,
		/// <summary>
		/// Discard frames marked corrupted
		/// </summary>
		DiscardCorrupt = 0x0100,
		/// <summary>
		/// Flush the AVIOContext every packet.
		/// </summary>
		FlushPackets = 0x0200,
		BitExact = 0x0400,
		/// <summary>
		/// Enable RTP MP4A-LATM payload
		/// </summary>
		Mp4aLatm = 0x8000,
		/// <summary>
		/// try to interleave outputted packets by dts (using this flag can slow demuxing down)
		/// </summary>
		SortDts = 0x10000,
		/// <summary>
		/// Enable use of private options by delaying codec open (this could be made default once all code is converted)
		/// </summary>
		PrivOpt = 0x20000,
		/// <summary>
		/// Don't merge side data but keep it separate.
		/// </summary>
		KeepSideData = 0x40000,
		/// <summary>
		/// Enable fast, but inaccurate seeks for some formats
		/// </summary>
		FastSeek = 0x80000
	}
}
