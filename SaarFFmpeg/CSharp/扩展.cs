using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public static class 扩展 {
		public static bool IsPlanar(this AVSampleFormat @this)
			=> FF.av_sample_fmt_is_planar(@this) != 0;

		public static AVSampleFormat ToPacked(this AVSampleFormat @this)
			=> FF.av_get_packed_sample_fmt(@this);

		public static AVSampleFormat ToPlanar(this AVSampleFormat @this)
			=> FF.av_get_planar_sample_fmt(@this);

		public static bool EqualsType(this AVSampleFormat @this, AVSampleFormat other)
			=> @this.ToPacked() == other.ToPacked();

		public static T Minimal<T, E>(this IEnumerable<T> @this, Func<T, E> map) where E : IComparable<E> {
			using (var enumer = @this.GetEnumerator()) {
				if (!enumer.MoveNext()) return default;

				var result = enumer.Current;
				var minValue = map(result);

				while (enumer.MoveNext()) {
					var otherValue = map(enumer.Current);
					if (otherValue.CompareTo(minValue) < 0) {
						result = enumer.Current;
						minValue = otherValue;
					}
				}

				return result;
			}
		}

		public static bool IsPowOf2(this int x)
			=> x != 0 && (x & (x - 1)) == 0;

		public static int CheckFFmpegCode(this int code)
			=> code >= 0 ? code : throw new FFmpegException(code);

		public static int CheckFFmpegCode(this int code, string message)
			=> code >= 0 ? code : throw new FFmpegException(code, message);

		public static int AVError(this Error error) => -(int)error;
	}
}
