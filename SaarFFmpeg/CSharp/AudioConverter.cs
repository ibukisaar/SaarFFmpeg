using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public abstract class AudioConverter : DisposableObject {
		public abstract void Convert(AudioFrame inFrame, AudioFrame outFrame);
	}
}
