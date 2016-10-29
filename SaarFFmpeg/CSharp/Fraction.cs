using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public struct Fraction : IComparable<Fraction> {
		internal int num;
		internal int den;

		public int Numerator => num;
		public int Denominator => den;
		public bool Invalid => den == 0;
		public double Value => (double) num / den;

		public Fraction(int num, int den) {
			this.num = num;
			this.den = den;
		}

		public Fraction(int num) : this(num, 1) { }

		public Fraction ToReciprocal() => new Fraction(den, num);

		internal AVRational ToAVRational() => new AVRational { Num = num, Den = den };

		public override string ToString() => $"({num}/{den}={Value})";


		public int CompareTo(Fraction other) {
			return ((long) num * other.den).CompareTo((long) den * other.num);
		}

		public override bool Equals(object obj) {
			if (!(obj is Fraction)) return false;
			return CompareTo((Fraction) obj) == 0;
		}

		public override int GetHashCode() {
			return num ^ den;
		}

		public static implicit operator AVRational(Fraction @this) {
			return @this.ToAVRational();
		}

		public static implicit operator Fraction(AVRational rational) {
			return new Fraction(rational.Num, rational.Den);
		}
	}
}
