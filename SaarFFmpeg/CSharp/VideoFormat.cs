using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public sealed class VideoFormat {
		internal int[] strides;

		public int Width { get; }
		public int Height { get; }
		public AVPixelFormat PixelFormat { get; }
		public int PlaneCount { get; }
		public int Align { get; }
		public int Bytes { get; }
		public int[] Strides => strides;

		unsafe public VideoFormat(int width, int height, AVPixelFormat pixelFormat, int align = 8) {
			if (!align.IsPowOf2()) throw new ArgumentException($"对齐数必须是2的整数幂", nameof(align));

			Width = width;
			Height = height;
			PixelFormat = pixelFormat;
			Align = align;
			Bytes = FF.av_image_get_buffer_size(pixelFormat, width, height, align).CheckFFmpegCode();
			PlaneCount = FF.av_pix_fmt_count_planes(pixelFormat).CheckFFmpegCode();

			//--- 参考 imgutils.c 的 av_image_fill_arrays
			var stridesTmp = stackalloc int[4];
			FF.av_image_fill_linesizes(stridesTmp, pixelFormat, width).CheckFFmpegCode();

			strides = new int[PlaneCount];
			for (int i = 0; i < PlaneCount; i++) {
				strides[i] = (stridesTmp[i] + (align - 1)) & ~(align - 1);
			}
			//---
		}

		public static bool operator ==(VideoFormat left, VideoFormat right) {
			if (ReferenceEquals(left, right)) return true;
			if (left is null) return false;
			return left.Equals(right);
		}

		public static bool operator !=(VideoFormat left, VideoFormat right) {
			if (ReferenceEquals(left, right)) return false;
			if (left is null) return true;
			return !left.Equals(right);
		}

		public override bool Equals(object obj) {
			return obj is VideoFormat other
				&& Width == other.Width
				&& Height == other.Height
				&& PixelFormat == other.PixelFormat
				&& Align == other.Align;
		}

		public override int GetHashCode() {
			return Width + Height + (int) PixelFormat + Align;
		}

		public override string ToString() {
			return $"{Width}x{Height},{PixelFormat},Align:{Align}";
		}
	}
}
