using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Enumerates {
	public enum AVPictureStructure : int {
		Unknown,
		TopField,
		BottomField,
		Frame
	}
}
