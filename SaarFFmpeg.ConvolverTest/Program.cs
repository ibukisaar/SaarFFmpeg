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
			var kernel = Enumerable.Range(0, 30).Select(n => n * 0.01).ToArray();
			var conv = new Convolver(kernel);
			var inData = Enumerable.Range(0, 200).Select(n => 1d).ToArray();
			var outData = new double[200 + 128];
			int len = conv.Convolve(inData, 0, 100, outData, 0, outData.Length);
			int len2 = conv.Convolve(inData, 100, 100, outData, len, outData.Length - len);
			int len3 = conv.ConvolveFinal(outData, len + len2, outData.Length - len - len2);
		}
	}
}
