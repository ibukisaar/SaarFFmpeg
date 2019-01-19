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

		public int TotalBytes => format?.GetBytes(sampleCount) ?? 0;
		public IntPtr[] Data => datas;
		public int LineDataBytes => format?.GetLineBytes(SampleCount) ?? 0;
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
			if (format.LineCount != 1) throw new ArgumentException($"该{nameof(AudioFrame)}对象拥有大于1的数据行数，因此不能调用此方法", nameof(newData));
			Resize(sampleCount);
			FF.av_samples_copy(datas, &newData, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData) where T : unmanaged {
			fixed (T* p = newData) {
				Update(sampleCount, (IntPtr)p);
			}
		}

		public void Update<T>(int sampleCount, T* newData) where T : unmanaged => Update(sampleCount, (IntPtr)newData);

		public void Update(int sampleCount, params IntPtr[] newDatas) {
			if (newDatas.Length != format.LineCount) throw new ArgumentException("参数个数和数据行数不一致", nameof(newDatas));
			Resize(sampleCount);
			FF.av_samples_copy(datas, newDatas, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2) where T : unmanaged {
			if (2 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是2才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2) {
				T** srcPointers = stackalloc[] { p1, p2 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3) where T : unmanaged {
			if (3 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是3才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3) {
				T** srcPointers = stackalloc[] { p1, p2, p3 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3, ReadOnlySpan<T> newData4) where T : unmanaged {
			if (4 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是4才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3)
			fixed (T* p4 = newData4) {
				T** srcPointers = stackalloc[] { p1, p2, p3, p4 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3, ReadOnlySpan<T> newData4, ReadOnlySpan<T> newData5) where T : unmanaged {
			if (5 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是5才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3)
			fixed (T* p4 = newData4)
			fixed (T* p5 = newData5) {
				T** srcPointers = stackalloc[] { p1, p2, p3, p4, p5 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3, ReadOnlySpan<T> newData4, ReadOnlySpan<T> newData5, ReadOnlySpan<T> newData6) where T : unmanaged {
			if (6 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是6才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3)
			fixed (T* p4 = newData4)
			fixed (T* p5 = newData5)
			fixed (T* p6 = newData6) {
				T** srcPointers = stackalloc[] { p1, p2, p3, p4, p5, p6 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3, ReadOnlySpan<T> newData4, ReadOnlySpan<T> newData5, ReadOnlySpan<T> newData6, ReadOnlySpan<T> newData7) where T : unmanaged {
			if (7 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是7才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3)
			fixed (T* p4 = newData4)
			fixed (T* p5 = newData5)
			fixed (T* p6 = newData6)
			fixed (T* p7 = newData7) {
				T** srcPointers = stackalloc[] { p1, p2, p3, p4, p5, p6, p7 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, ReadOnlySpan<T> newData1, ReadOnlySpan<T> newData2, ReadOnlySpan<T> newData3, ReadOnlySpan<T> newData4, ReadOnlySpan<T> newData5, ReadOnlySpan<T> newData6, ReadOnlySpan<T> newData7, ReadOnlySpan<T> newData8) where T : unmanaged {
			if (8 != format.LineCount) throw new InvalidOperationException($"{nameof(Format)}的数据行数必须是8才能调用此方法");
			Resize(sampleCount);

			fixed (T* p1 = newData1)
			fixed (T* p2 = newData2)
			fixed (T* p3 = newData3)
			fixed (T* p4 = newData4)
			fixed (T* p5 = newData5)
			fixed (T* p6 = newData6)
			fixed (T* p7 = newData7)
			fixed (T* p8 = newData8) {
				T** srcPointers = stackalloc[] { p1, p2, p3, p4, p5, p6, p7, p8 };
				FF.av_samples_copy(datas, (IntPtr*)srcPointers, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void Update<T>(int sampleCount, params T*[] newDatas) where T : unmanaged {
			if (newDatas.Length != format.LineCount) throw new ArgumentException("数组个数和数据行数不一致", nameof(newDatas));
			Resize(sampleCount);

			fixed (T** p = newDatas) {
				FF.av_samples_copy(datas, (IntPtr*)p, 0, 0, sampleCount, format.Channels, format.SampleFormat);
			}
		}

		public void PackedCopyTo(IntPtr outBuffer, int bufferBytes) {
			int lineBytes = format.GetLineBytes(sampleCount);
			if (!format.IsPlanarFormat) {
				Buffer.MemoryCopy((void*)cache, (void*)outBuffer, bufferBytes, lineBytes);
				return;
			}

			var resampler = AudioResampler.GetPackedResampler(format);
			fixed (IntPtr* input = datas) {
				resampler.Resample((IntPtr)input, SampleCount, (IntPtr)(&outBuffer), SampleCount);
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
			FF.av_samples_copy(datas, (IntPtr*)frame->ExtendedData, 0, 0, sampleCount, format.Channels, format.SampleFormat);
		}

		protected override void Setup() {
			frame->NbSamples = sampleCount;
			frame->Format = (int)format.SampleFormat;
			frame->ExtendedData = (byte**)&frame->Data;
			FF.av_samples_fill_arrays(frame->ExtendedData, frame->Linesize, (byte*)cache, format.Channels, sampleCount, format.SampleFormat, 1);
		}

		public void CopyTo(int srcSampleOffset, int srcSampleCount, AudioFrame dstFrame) {
			dstFrame.Resize(format, srcSampleCount);
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
