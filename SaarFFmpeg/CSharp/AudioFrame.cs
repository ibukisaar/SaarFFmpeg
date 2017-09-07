using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public sealed class AudioFrame : Frame {
		internal AudioFormat format;
		internal IntPtr[] datas = new IntPtr[8];
		internal int sampleCount;

		public int TotalBytes => format.GetBytes(sampleCount);
		public IntPtr[] Data => datas;
		public int LineDataBytes => format.GetLineBytes(SampleCount);
		public int SampleCount => sampleCount;
		public AudioFormat Format => format;
		public override AVMediaType Type => AVMediaType.Audio;
		public bool IsEmpty => sampleCount == 0;

		public AudioFrame() { }

		public AudioFrame(AudioFormat format) {
			this.format = format ?? throw new ArgumentNullException(nameof(format));
		}

		public void Resize(int sampleCount) {
			if (format == null) throw new InvalidOperationException($"{nameof(AudioFrame)} 对象未指定格式");

			this.sampleCount = sampleCount;
			int bytes = format.GetBytes(sampleCount);
			cache.Resize(bytes);
			FF.av_samples_fill_arrays(datas, null, cache.data, format.Channels, sampleCount, format.SampleFormat, 1);
		}

		public void Resize(AudioFormat format, int sampleCount) {
			this.format = format;
			Resize(sampleCount);
		}

		public void Update(int sampleCount, IntPtr newData) {
			if (format.LineCount != 1) throw new ArgumentException("数组长度和数据行数不一致", nameof(newData));
			Resize(sampleCount);
			FF.av_samples_copy(datas, &newData, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		public void Update(int sampleCount, Array newData) {
			var handle = GCHandle.Alloc(newData, GCHandleType.Pinned);
			try {
				Update(sampleCount, handle.AddrOfPinnedObject());
			} finally {
				handle.Free();
			}
		}

		public void Update(int sampleCount, params IntPtr[] newDatas) {
			if (newDatas.Length != format.LineCount) throw new ArgumentException("数组长度和数据行数不一致", nameof(newDatas));
			Resize(sampleCount);
			FF.av_samples_copy(datas, newDatas, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		public void Update(int sampleCount, params Array[] newDatas) {
			if (newDatas.Length != format.LineCount) throw new ArgumentException("数组长度和数据行数不一致", nameof(newDatas));
			Resize(sampleCount);

			int lineBytes = format.GetLineBytes(sampleCount);
			for (int i = newDatas.Length - 1; i >= 0; i--) {
				var handle = GCHandle.Alloc(newDatas[i], GCHandleType.Pinned);
				try {
					Buffer.MemoryCopy((void*) handle.AddrOfPinnedObject(), (void*) datas[i], lineBytes, lineBytes);
				} finally {
					handle.Free();
				}
			}
		}

		public void PackedCopyTo(IntPtr outBuffer, int bufferBytes) {
			int lineBytes = format.GetLineBytes(sampleCount);
			if (!format.IsPlanarFormat) {
				Buffer.MemoryCopy((void*) cache, (void*) outBuffer, bufferBytes, lineBytes);
				return;
			}

			var resampler = AudioResampler.GetPackedResampler(format);
			fixed (IntPtr* input = datas) {
				resampler.Resample((IntPtr) input, SampleCount, (IntPtr) (&outBuffer), SampleCount);
			}
		}

		public void ToPacked() {
			AudioResampler.ToPacked(this);
		}

		public void ToPlanar() {
			AudioResampler.ToPlanar(this);
		}

		public void PackedCopyTo(Array dstArray, int dstBytesOffset = 0) {
			int copyLength = TotalBytes;
			int arrayLength = Buffer.ByteLength(dstArray);
			if (dstBytesOffset + copyLength > arrayLength)
				throw new IndexOutOfRangeException();

			GCHandle handle = GCHandle.Alloc(dstArray, GCHandleType.Pinned);
			try {
				IntPtr dst = handle.AddrOfPinnedObject() + dstBytesOffset;
				PackedCopyTo(dst, copyLength);
			} finally {
				handle.Free();
			}
		}

		internal override void UpdateFromNative() {
			int sampleCount = frame->NbSamples;
			Resize(sampleCount);
			FF.av_samples_copy(datas, (IntPtr*) frame->ExtendedData, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		protected override void Setup() {
			frame->NbSamples = sampleCount;
			frame->Format = (int) format.SampleFormat;
			frame->ExtendedData = (byte**) &frame->Data;
			FF.av_samples_fill_arrays(frame->ExtendedData, frame->Linesize, (byte*) cache, format.Channels, sampleCount, format.SampleFormat, 1);
		}

		public void CopyTo(int srcSampleOffset, int srcSampleCount, AudioFrame dstFrame) {
			dstFrame.format = format;
			dstFrame.Resize(srcSampleCount);
			FF.av_samples_copy(dstFrame.datas, datas, 0, srcSampleOffset, srcSampleCount, format.Channels, format.SampleFormat);
		}

		public void CopyToNoResize(int srcSampleOffset, int srcSampleCount, AudioFrame dstFrame, int dstSampleOffset = 0) {
			if (dstFrame.format != format) throw new ArgumentException("目标帧格式不一致", nameof(dstFrame));
			FF.av_samples_copy(dstFrame.datas, datas, dstSampleOffset, srcSampleOffset, srcSampleCount, format.Channels, format.SampleFormat);
		}

		public static void Merge(AudioFrame outFrame, params AudioFrame[] inFrames) {
			if (inFrames.Length == 0) return;
			var format = inFrames[0].format;
			for (int i = 1; i < inFrames.Length; i++) {
				if (format != inFrames[i].format) throw new ArgumentException($"{nameof(inFrames)}的所有元素的{nameof(Format)}必须一致", nameof(inFrames));
			}

			int outSampleCount = inFrames.Sum(frame => frame.sampleCount);
			outFrame.format = format;
			outFrame.Resize(outSampleCount);

			int offset = 0;
			for (int i = 0; i < inFrames.Length; i++) {
				FF.av_samples_copy(outFrame.datas, inFrames[i].datas, offset, 0, inFrames[i].sampleCount, format.Channels, format.SampleFormat);
				offset += inFrames[i].sampleCount;
			}
		}
	}
}
