using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp.DSP;
using System.Threading;

namespace SaarFFmpeg.ConvolverTest {
	class Program {
		static void Main(string[] args) {
			var kernel = Enumerable.Range(0, 128).Select(n => n * 0.01).ToArray();
			var conv = new Convolver(kernel);
			var inData = Enumerable.Range(0, 200).Select(n => 1d).ToArray();
			var outData = new double[200 + 128];
			int len = conv.Convolve(inData, 0, inData.Length, outData, 0, outData.Length);
			conv.ConvolveFinal(outData, len, outData.Length - len);
		}
	}
}
