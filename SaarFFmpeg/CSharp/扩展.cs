using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public static class 扩展 {
		public static bool IsPlanar(this AVSampleFormat @this) {
			return FF.av_sample_fmt_is_planar(@this) != 0;
		}

		public static AVSampleFormat ToPacked(this AVSampleFormat @this) {
			return FF.av_get_packed_sample_fmt(@this);
		}

		public static AVSampleFormat ToPlanar(this AVSampleFormat @this) {
			return FF.av_get_planar_sample_fmt(@this);
		}

		public static bool EqualsType(this AVSampleFormat @this, AVSampleFormat other) {
			return @this.ToPacked() == other.ToPacked();
		}
	}
}
