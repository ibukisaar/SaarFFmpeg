using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.GenYuv {
	class Program {
		static void Write(FileStream stream, IntPtr dataPtr, int bytes) {
			byte[] data = new byte[bytes];
			Marshal.Copy(dataPtr, data, 0, bytes);
			stream.Write(data, 0, bytes);
		}

		static void Main(string[] args) {
			var reader = new MediaReader(@"G:\请问您今天来点兔子吗\[Hakugetsu&VCB-Studio]Gochuumon wa Usagi Desuka[1080p]\[Hakugetsu&VCB-Studio]Gochuumon wa Usagi Desuka[01][Hi10p_1080p][x264_2flac].mkv");
			var decoder = reader.Decoders.OfType<VideoDecoder>().First();
			decoder.OutFormat = new VideoFormat(
				decoder.InFormat.Width,
				decoder.InFormat.Height,
				Saar.FFmpeg.CSharp.AVPixelFormat.Yuv420p);
			VideoFrame frame = new VideoFrame();

			for (int i = 0; i < 10; i++) {
				if (reader.NextFrame(frame, decoder.StreamIndex)) {
					var writer = File.OpenWrite($@"Z:\{i}.yuv");
					Write(writer, frame.Data[0], frame.Format.Strides[0] * frame.Format.Height);
					Write(writer, frame.Data[1], frame.Format.Strides[1] * frame.Format.Height / 2);
					Write(writer, frame.Data[2], frame.Format.Strides[2] * frame.Format.Height / 2);
					writer.Close();
				}
			}
		}
	}
}
