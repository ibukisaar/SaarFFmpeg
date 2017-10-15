using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public struct Timestamp : IComparable<Timestamp> {
		public static readonly Fraction NET_TicksTimeBase = new Fraction(1, 1000_0000);
		public static readonly Fraction FFmpeg_AVTimeBase = new Fraction(1, 1000_000);
		
		public long Value { get; private set; }
		public Fraction TimeBase { get; private set; }
		public TimeSpan TimeSpan => TimeSpan.FromTicks(GetTimestamp(NET_TicksTimeBase));

		public Timestamp(long timestamp, Fraction timeBase) {
			this.Value = timestamp;
			this.TimeBase = timeBase;
		}

		public long GetTimestamp(Fraction dstTimeBase) {
			return FF.av_rescale_q(this.Value, this.TimeBase, dstTimeBase);
		}

		public void Transform(Fraction dstTimeBase) {
			this.Value = GetTimestamp(dstTimeBase);
			this.TimeBase = dstTimeBase;
		}

		public override string ToString()
			=> TimeSpan.ToString();

		public override bool Equals(object obj)
			=> obj is Timestamp other && TimeSpan == other.TimeSpan;

		public override int GetHashCode()
			=> TimeSpan.GetHashCode();

		public int CompareTo(Timestamp other)
			=> TimeSpan.CompareTo(other.TimeSpan);
	}
}
