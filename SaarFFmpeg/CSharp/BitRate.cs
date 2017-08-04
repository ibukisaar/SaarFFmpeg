using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public struct BitRate : IComparable<BitRate> {
		public long Value { get; set; }

		public BitRate(long bitPerSecond) {
			Value = bitPerSecond;
		}

		private BitRate(double value) {
			Value = (long) value;
		}

		public long BitPerSecond => Value;
		public double BytePerSecond => Value / 8d;
		public double KBitPerSecond => Value / 1000d;
		public double KBytePerSecond => Value / (1000d * 8);
		public double MBitPerSecond => Value / (1000d * 1000);
		public double MBytePerSecond => Value / (1000d * 1000 * 8);
		public double GBitPerSecond => Value / (1000d * 1000 * 1000);
		public double GBytePerSecond => Value / (1000d * 1000 * 1000 * 8);

		public override bool Equals(object obj) {
			if (obj is BitRate) {
				return Value == ((BitRate) obj).Value;
			}
			return false;
		}

		unsafe public override int GetHashCode() {
			double temp = Value;
			return ((int*) &temp)[0] ^ ((int*) &temp)[1];
		}

		public override string ToString() {
			if (Value < 8000) {
				return $"{Value / 8d:N2} B/s";
			} else if (Value < 8000 * 1000) {
				return $"{Value / 8000d:N2} KB/s";
			} else if (Value < 8000L * 1000 * 1000) {
				return $"{Value / (8000d * 1000):N2} MB/s";
			} else {
				return $"{Value / (8000d * 1000 * 1000):N2} GB/s";
			}
		}


		public static BitRate FromBitPerSecond(long bitPerSecond)
			=> new BitRate(bitPerSecond);

		public static BitRate FromBytePerSecond(double bytePerSecond)
			=> new BitRate(bytePerSecond * 8);

		public static BitRate FromKBitPerSecond(double kBitPerSecond)
			=> new BitRate(kBitPerSecond * 1000);

		public static BitRate FromKBytePerSecond(double kBytePerSecond)
			=> new BitRate(kBytePerSecond * 1000 * 8);

		public static BitRate FromMBitPerSecond(double mBitPerSecond)
			=> new BitRate(mBitPerSecond * 1000 * 1000);

		public static BitRate FromMBytePerSecond(double mBytePerSecond)
			=> new BitRate(mBytePerSecond * 1000 * 1000 * 8);

		public static BitRate FromGBitPerSecond(double gBitPerSecond)
			=> new BitRate(gBitPerSecond * 1000 * 1000 * 1000);

		public static BitRate FromGBytePerSecond(double gBytePerSecond)
			=> new BitRate(gBytePerSecond * 1000 * 1000 * 1000 * 8);

		public int CompareTo(BitRate other) {
			return Value.CompareTo(other.Value);
		}

		public static implicit operator BitRate(long value) => new BitRate(value);
		public static explicit operator long(BitRate bitRate) => bitRate.Value;

		public static bool operator ==(BitRate left, BitRate right)
			=> left.Value == right.Value;

		public static bool operator !=(BitRate left, BitRate right)
			=> left.Value != right.Value;

		public static bool operator <(BitRate left, BitRate right)
			=> left.Value < right.Value;

		public static bool operator <=(BitRate left, BitRate right)
			=> left.Value <= right.Value;

		public static bool operator >(BitRate left, BitRate right)
			=> left.Value > right.Value;

		public static bool operator >=(BitRate left, BitRate right)
			=> left.Value >= right.Value;

		public static BitRate operator +(BitRate @this)
			=> @this;

		public static BitRate operator +(BitRate left, BitRate right)
			=> left.Value + right.Value;

		public static BitRate operator -(BitRate @this)
			=> -@this.Value;

		public static BitRate operator -(BitRate left, BitRate right)
			=> left.Value - right.Value;

		public static double operator /(BitRate left, BitRate right)
			=> (double) left.Value / right.Value;

		public static BitRate operator *(BitRate @this, double scale)
			=> new BitRate(@this.Value * scale);


		public readonly static BitRate Zero = new BitRate();
		public readonly static BitRate _64Kbps = FromKBitPerSecond(64);
		public readonly static BitRate _80Kbps = FromKBitPerSecond(80);
		public readonly static BitRate _96Kbps = FromKBitPerSecond(96);
		public readonly static BitRate _128Kbps = FromKBitPerSecond(128);
		public readonly static BitRate _160Kbps = FromKBitPerSecond(160);
		public readonly static BitRate _192Kbps = FromKBitPerSecond(192);
		public readonly static BitRate _224Kbps = FromKBitPerSecond(224);
		public readonly static BitRate _256Kbps = FromKBitPerSecond(256);
		public readonly static BitRate _320Kbps = FromKBitPerSecond(320);
	}
}
