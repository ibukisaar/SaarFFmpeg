using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public struct Fraction : IComparable<Fraction> {
		public readonly int Num;
		public readonly int Den;

		public bool Invalid => Den == 0;
		public double Value => (double) Num / Den;
		public Fraction Reciprocal => new Fraction(Den, Num);

		public Fraction(int num, int den) {
			if (num == 0) {
				this.Num = 0;
				this.Den = 1;
			} else if (den == 0) {
				this.Num = 0;
				this.Den = 0;
			} else {
				int r = GCD(num, den);
				this.Num = num / r;
				this.Den = den / r;
			}
		}

		public Fraction(int num) : this(num, 1) { }

		internal AVRational ToAVRational() => new AVRational { Num = Num, Den = Den };

		public override string ToString() => $"({Num}/{Den}={Value})";


		public int CompareTo(Fraction other) {
			return ((long) Num * other.Den).CompareTo((long) Den * other.Num);
		}

		public override bool Equals(object obj) {
			return obj is Fraction other && CompareTo(other) == 0;
		}

		public override int GetHashCode() {
			return Num ^ Den;
		}

		public static implicit operator AVRational(Fraction @this) {
			return @this.ToAVRational();
		}

		public static implicit operator Fraction(AVRational rational) {
			return new Fraction(rational.Num, rational.Den);
		}

		private static int GCD(int x, int y) {
			if (y == 0) return x;
			else return GCD(y, x % y);
		}
	}
}
