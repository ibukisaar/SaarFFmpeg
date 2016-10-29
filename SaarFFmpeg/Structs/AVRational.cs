using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	public struct AVRational {
		public int Num;
		public int Den;

		public AVRational(int num, int den) {
			Num = num;
			Den = den;
		}

		public double Value => (double) Num / Den;

		public bool Invalid => Den == 0;

		public override string ToString() => $"({Num}/{Den}={Value})";
	}
}
