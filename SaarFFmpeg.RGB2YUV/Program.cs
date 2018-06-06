using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Saar.FFmpeg.CSharp;
using System.Runtime.InteropServices;

namespace SaarFFmpeg.RGB2YUV {
	class Program {
		static void Write(FileStream stream, IntPtr dataPtr, int bytes) {
			byte[] data = new byte[bytes];
			Marshal.Copy(dataPtr, data, 0, bytes);
			stream.Write(data, 0, bytes);
		}

		static void Main(string[] args) {
			Bitmap bitmap = new Bitmap(@"Z:\1.png");
			VideoFrame inFrame = new VideoFrame(new VideoFormat(bitmap.Width, bitmap.Height, AVPixelFormat.Bgr24, 4));
			VideoFrame outFrame = new VideoFrame(new VideoFormat(1366, 768, AVPixelFormat.Yuv420p, 16));
			var bitmapData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			inFrame.Update(bitmapData.Scan0);
			bitmap.UnlockBits(bitmapData);
			var resampler = new VideoResampler(inFrame.Format, outFrame.Format, SwsFlags.Bicublin);
			resampler.Resample(inFrame, outFrame);
			using (var file = File.OpenWrite(@"Z:\1.yuv")) {
				Write(file, outFrame.Data[0], outFrame.Format.Strides[0] * outFrame.Format.Height);
				Write(file, outFrame.Data[2], outFrame.Format.Strides[2] * outFrame.Format.Height / 2);//V
				Write(file, outFrame.Data[1], outFrame.Format.Strides[1] * outFrame.Format.Height / 2);//U
			}
		}
	}
}
