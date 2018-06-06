using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.AllCodec {
	class Program {
		static void Main(string[] args) {
			foreach (var codec in Codec.GetAllCodecs()) {
				Console.WriteLine(codec);
			}
		}
	}
}
