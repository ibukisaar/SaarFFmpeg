using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
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
			if (align <= 0) align = 1;

			Width = width;
			Height = height;
			PixelFormat = pixelFormat;
			Align = align;
			Bytes = FF.av_image_get_buffer_size(pixelFormat, width, height, align);
			PlaneCount = FF.av_pix_fmt_count_planes(pixelFormat);
			strides = new int[PlaneCount];
			fixed (int* linesize = strides) {
				FF.av_image_fill_linesizes(linesize, pixelFormat, width);
			}
			for (int i = 0; i < PlaneCount; i++) {
				int tail = strides[i] % align;
				if (tail != 0) {
					strides[i] += align - tail;
				}
			}
		}

		public static bool operator ==(VideoFormat left, VideoFormat right) {
			if (ReferenceEquals(left, right)) return true;
			if (ReferenceEquals(left, null)) return false;
			return left.Equals(right);
		}

		public static bool operator !=(VideoFormat left, VideoFormat right) {
			if (ReferenceEquals(left, right)) return false;
			if (ReferenceEquals(left, null)) return true;
			return !left.Equals(right);
		}

		public override bool Equals(object obj) {
			var other = obj as VideoFormat;
			if (ReferenceEquals(other, null)) return false;
			return Width == other.Width
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
