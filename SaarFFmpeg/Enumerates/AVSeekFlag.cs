using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	[Flags]
	public enum AVSeekFlag {
		/// <summary>
		/// seek backward
		/// </summary>
		Backward = 1,
		/// <summary>
		/// seeking based on position in bytes
		/// </summary>
		Byte = 2,
		/// <summary>
		/// seek to any frame, even non-keyframes
		/// </summary>
		Any = 4,
		/// <summary>
		/// seeking based on frame number
		/// </summary>
		Frame = 8,
	}
}
