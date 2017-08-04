using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp.DSP {
	unsafe public abstract class Filter : DisposableObject {
		public abstract int GetOutCount(int inCount);

		public abstract int Filtering(double* src, int srcCount, double* dst, int dstCount);

		public int Filtering(double[] src, int srcOffset, int srcCount, double[] dst, int dstOffset, int dstCount) {
			fixed (double* input = &src[srcOffset])
			fixed (double* output = &dst[dstOffset]) {
				return Filtering(input, srcCount, output, dstCount);
			}
		}

		protected override void Dispose(bool disposing) {

		}
	}
}
