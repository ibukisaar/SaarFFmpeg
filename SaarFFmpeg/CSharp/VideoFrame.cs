using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
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

		public void Update(IntPtr newData, int planeIndex = 0) {
			if (format == null) throw new InvalidOperationException($"{nameof(VideoFrame)} 对象未指定格式");
			if (planeIndex < 0 || planeIndex >= format.PlaneCount) throw new ArgumentOutOfRangeException(nameof(planeIndex), $"{nameof(planeIndex)}必须大于等于0，且小于格式的{nameof(format.PlaneCount)}");

			var bytewidth = FF.av_image_get_linesize(format.PixelFormat, format.Width, planeIndex);
			FF.av_image_copy_plane((byte*) datas[planeIndex], format.strides[planeIndex], (byte*) newData, format.strides[planeIndex], bytewidth, format.Height);
		}

		public void Update(params IntPtr[] newDatas) {
			if (format.PlaneCount != newDatas.Length) throw new InvalidOperationException($"该 {nameof(VideoFrame)} 对象格式的{nameof(format.PlaneCount)}必须等于参数个数");

			for (int i = 0; i < format.PlaneCount; i++) {
				Update(newDatas[i], i);
			}
		}

		public void Update(Array newData, int planeIndex = 0) {
			var handle = GCHandle.Alloc(newData, GCHandleType.Pinned);
			try {
				Update(handle.AddrOfPinnedObject(), planeIndex);
			} finally {
				handle.Free();
			}
		}

		public void Update(params Array[] newDatas) {
			if (format.PlaneCount != newDatas.Length) throw new InvalidOperationException($"该 {nameof(VideoFrame)} 对象格式的{nameof(format.PlaneCount)}必须等于数组个数");

			for (int i = 0; i < format.PlaneCount; i++) {
				var handle = GCHandle.Alloc(newDatas[i], GCHandleType.Pinned);
				try {
					Update(handle.AddrOfPinnedObject(), i);
				} finally {
					handle.Free();
				}
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

		public void Resize(VideoFormat format) {
			this.format = format;
			Resize();
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
