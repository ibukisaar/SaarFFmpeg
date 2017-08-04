using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public enum AVSeek : int {
		Seek,
		Size = 0x10000,
		Force = 0x20000
	}
}
