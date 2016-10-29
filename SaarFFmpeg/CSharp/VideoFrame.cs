using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public sealed class VideoFrame : Frame {
		internal VideoFormat format;
		internal IntPtr[] datas = new IntPtr[4];
		internal AVPictureType pictureType;

		public override AVMediaType Type => AVMediaType.Video;
		public VideoFormat Format => format;
		public IntPtr Scan0 => cache.data;
		public IntPtr[] Data => datas;
		public AVPictureType PictureType => pictureType;

		public VideoFrame() { }

		public VideoFrame(VideoFormat format) {
			this.format = format;
			Resize();
		}

		public VideoFrame(VideoFormat format, IntPtr scan0) : this(format) {
			Update(scan0);
		}

		public void Update(IntPtr scan0) {
			if (format == null) throw new InvalidOperationException($"{nameof(VideoFrame)} 对象未指定格式");
			if (format.PlaneCount != 1) throw new InvalidOperationException($"{nameof(format)}的{nameof(format.PlaneCount)}必须等于1");

			FF.av_image_copy_plane((byte*) datas[0], format.strides[0], (byte*) scan0, format.strides[0], format.strides[0], format.Height);
		}

		public void Update(byte[] bitmapData) {
			fixed (byte *data = bitmapData) {
				Update((IntPtr) data);
			}
		}

		internal void Resize() {
			if (format == null) throw new InvalidOperationException($"{nameof(VideoFrame)} 对象未指定格式");

			cache.Resize(format.Bytes);

			fixed (IntPtr* datas = this.datas)
			fixed (int* linesize = format.strides) {
				FF.av_image_fill_pointers((byte**) datas, format.PixelFormat, format.Height, (byte*) cache, linesize);
			}
		}

		internal override void UpdateFromNative() {
			Resize();
			fixed (IntPtr* datas = this.datas)
			fixed (int* dstLinesize = format.strides) {
				FF.av_image_copy((byte**) datas, dstLinesize, frame->ExtendedData, frame->Linesize, format.PixelFormat, format.Width, format.Height);
			}
		}

		protected override void Setup() {
			frame->ExtendedData = (byte**) (&frame->Data);
			frame->Width = format.Width;
			frame->Height = format.Height;
			frame->Format = (int) format.PixelFormat;
			FF.av_image_fill_arrays(frame->ExtendedData, frame->Linesize, (byte*) cache, format.PixelFormat, format.Width, format.Height, format.Align);
		}
	}
}
