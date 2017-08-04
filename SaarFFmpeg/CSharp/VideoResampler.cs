using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public sealed class VideoResampler : DisposableObject {
		private SwsContext* ctx;

		public VideoFormat Source { get; }
		public VideoFormat Destination { get; }

		public VideoResampler(VideoFormat source, VideoFormat destination, SwsFlags flags = SwsFlags.FastBilinear) {
			Source = source;
			Destination = destination;

			ctx = FF.sws_getContext(
				source.Width, source.Height, source.PixelFormat,
				destination.Width, destination.Height, destination.PixelFormat,
				flags, null, null, null);
		}

		protected override void Dispose(bool disposing) {
			if (ctx == null) return;

			FF.sws_freeContext(ctx);
			ctx = null;
		}

		public void Resample(IntPtr srcDatas, IntPtr srcLengths, IntPtr dstDatas, IntPtr dstLengths) {
			FF.sws_scale(ctx, (byte**) srcDatas, (int*) srcLengths, 0, Source.Height, (byte**) dstDatas, (int*) dstLengths);
		}

		internal void InternalResample(VideoFrame frame) {
			frame.format = Destination;
			frame.Resize();

			fixed (IntPtr* dst = frame.datas)
			fixed (int* dstLinesize = Destination.strides) {
				Resample((IntPtr) (&frame.frame->Data), (IntPtr) frame.frame->Linesize, (IntPtr) dst, (IntPtr) dstLinesize);
			}
		}

		public void Resample(VideoFrame src, VideoFrame dst) {
			if (src.format != Source)
				throw new ArgumentException("输入帧的格式和重采样器的源格式不一致", nameof(src));

			dst.format = Destination;
			dst.Resize();
			fixed (IntPtr* input = src.datas)
			fixed (int* inputLengths = Source.strides)
			fixed (IntPtr* output = dst.datas)
			fixed (int* outputLengths = Destination.strides) {
				Resample((IntPtr) input, (IntPtr) inputLengths, (IntPtr) output, (IntPtr) outputLengths);
			}
		}
	}
}
