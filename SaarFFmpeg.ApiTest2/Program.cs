using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace SaarFFmpeg.ApiTest2 {
	unsafe class Program {
		static void Main(string[] args) {
			void* i = null;
			List<(string Name, string LongName, Ptr<AVOutputFormat>)> list = new List<(string Name, string LongName, Ptr<AVOutputFormat>)>();
			while (Ptr.Get(FF.av_muxer_iterate(&i), out var outFormat)) {
				list.Add((outFormat->Debug_Name, outFormat->Debug_LongName, new Ptr<AVOutputFormat>(outFormat)));
			}
		}
	}
}
