using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	/// <summary>
	/// 音频重采样器
	/// </summary>
	unsafe public sealed class AudioResampler : AudioConverter {
		private static readonly Dictionary<AudioFormat, AudioResampler> planarResamplers = new Dictionary<AudioFormat, AudioResampler>();
		private static AutoCache packedCache = new AutoCache();

		private SwrContext* ctx;

		public AudioFormat Source { get; }
		public AudioFormat Destination { get; }

		public AudioResampler(AudioFormat src, AudioFormat dst) {
			Source = src;
			Destination = dst;

			try {
				ctx = FF.swr_alloc_set_opts(null,
					Destination.ChannelLayout, Destination.SampleFormat, Destination.SampleRate,
					Source.ChannelLayout, Source.SampleFormat, Source.SampleRate,
					0, null);
				Reset();
			} catch {
				Dispose();
				throw;
			}
		}

		/// <summary>
		/// 获得可以容纳输出的采样点数
		/// </summary>
		/// <param name="inSampleCount">该值为0可以获得重采样器的延迟采样点数</param>
		/// <returns></returns>
		public int GetOutSampleCount(int inSampleCount) {
			long delaySampleCount = FF.swr_get_delay(ctx, Source.SampleRate);
			return (int) FF.av_rescale_rnd(delaySampleCount + inSampleCount, Destination.SampleRate, Source.SampleRate, AVRounding.Up);
		}

		public int GetOutBytes(int outSampleCount) {
			return Destination.GetBytes(outSampleCount);
		}

		/// <summary>
		/// 重采样
		/// </summary>
		/// <param name="inDatas">输入PCM数据缓冲区的数组。当此参数为<see cref="IntPtr.Zero"/>时，将输出重采样器中剩余的采样点。</param>
		/// <param name="inSampleCount">输入缓冲区存放的采样个数（多声道只计算一个）</param>
		/// <param name="outDatas">输出PCM数据缓冲区的数组。</param>
		/// <param name="outSampleCount">输出缓冲区能够容纳的采样个数（多声道只计算一个）</param>
		/// <returns>返回输出的采样个数</returns>
		public int Resample(IntPtr inDatas, int inSampleCount, IntPtr outDatas, int outSampleCount) {
			int resultSampleCount = FF.swr_convert(ctx, (byte**) outDatas, outSampleCount, (byte**) inDatas, inSampleCount);
			if (resultSampleCount < 0) throw new FFmpegException(resultSampleCount);
			return resultSampleCount;
		}

		/// <summary>
		/// 重采样
		/// <para>参考：<see cref="Resample(IntPtr, int, IntPtr, int)"/></para>
		/// </summary>
		/// <param name="inDatas"></param>
		/// <param name="inSampleCount"></param>
		/// <param name="outDatas"></param>
		/// <param name="outSampleCount"></param>
		/// <returns></returns>
		public int Resample(IntPtr[] inDatas, int inSampleCount, IntPtr[] outDatas, int outSampleCount) {
			if (inDatas != null) {
				fixed (IntPtr* pInDatas = inDatas)
				fixed (IntPtr* pOutDatas = outDatas) {
					return Resample((IntPtr) pInDatas, inSampleCount, (IntPtr) pOutDatas, outSampleCount);
				}
			} else {
				fixed (IntPtr* pOutDatas = outDatas) {
					return Resample(IntPtr.Zero, 0, (IntPtr) pOutDatas, outSampleCount);
				}
			}
		}

		/// <summary>
		/// 重采样
		/// <para>参考：<see cref="Resample(IntPtr, int, IntPtr, int)"/></para>
		/// </summary>
		/// <param name="inArrays"></param>
		/// <param name="inSampleCount"></param>
		/// <param name="outArrays"></param>
		/// <param name="outSampleCount"></param>
		/// <returns></returns>
		public int Resample(Array[] inArrays, int inSampleCount, Array[] outArrays, int outSampleCount) {
			if (inArrays != null && inArrays.Length > 8) throw new ArgumentException("输入数组数量不能大于8", nameof(inArrays));
			if (outArrays.Length > 8) throw new ArgumentException("输出数组数量不能大于8", nameof(outArrays));

			if (inArrays != null) {
				var inHandles = stackalloc GCHandle[inArrays.Length];
				var outHandles = stackalloc GCHandle[outArrays.Length];
				var inputs = stackalloc IntPtr[inArrays.Length];
				var outputs = stackalloc IntPtr[outArrays.Length];

				try {
					for (int i = 0; i < inArrays.Length; i++)
						inHandles[i] = GCHandle.Alloc(inArrays[i], GCHandleType.Pinned);
					for (int i = 0; i < outArrays.Length; i++)
						outHandles[i] = GCHandle.Alloc(outArrays[i], GCHandleType.Pinned);
					for (int i = 0; i < inArrays.Length; i++)
						inputs[i] = inHandles[i].AddrOfPinnedObject();
					for (int i = 0; i < outArrays.Length; i++)
						outputs[i] = outHandles[i].AddrOfPinnedObject();

					return Resample((IntPtr) inputs, inSampleCount, (IntPtr) outputs, outSampleCount);
				} finally {
					for (int i = 0; i < inArrays.Length; i++)
						if (inHandles[i].IsAllocated) inHandles[i].Free();
					for (int i = 0; i < outArrays.Length; i++)
						if (outHandles[i].IsAllocated) outHandles[i].Free();
				}
			} else {
				var outHandles = stackalloc GCHandle[outArrays.Length];
				var outputs = stackalloc IntPtr[outArrays.Length];

				try {
					for (int i = 0; i < outArrays.Length; i++)
						outHandles[i] = GCHandle.Alloc(outArrays[i], GCHandleType.Pinned);
					for (int i = 0; i < outArrays.Length; i++)
						outputs[i] = outHandles[i].AddrOfPinnedObject();

					return Resample(IntPtr.Zero, 0, (IntPtr) outputs, outSampleCount);
				} finally {
					for (int i = 0; i < outArrays.Length; i++)
						if (outHandles[i].IsAllocated) outHandles[i].Free();
				}
			}
		}

		internal void InternalResample(AudioFrame frame) {
			int inSamples = frame.frame->NbSamples;
			int outSamples = GetOutSampleCount(inSamples);

			frame.format = Destination;
			frame.Resize(outSamples);
			fixed (IntPtr* output = frame.datas) {
				outSamples = Resample((IntPtr) frame.frame->ExtendedData, inSamples, (IntPtr) output, outSamples);
			}
			frame.sampleCount = outSamples;
		}

		public void ResampleFinal(AudioFrame outFrame) {
			int outSamples = GetOutSampleCount(0);
			outFrame.format = Destination;
			outFrame.Resize(outSamples);
			outSamples = Resample(null, 0, outFrame.datas, outSamples);
			outFrame.sampleCount = outSamples;
		}

		public void Resample(AudioFrame inFrame, AudioFrame outFrame) {
			if (inFrame == null) {
				ResampleFinal(outFrame);
				return;
			}

			if (!Source.Equals(inFrame.format))
				throw new ArgumentException("输入帧的格式和重采样器的源格式不一致", nameof(inFrame));

			int inSamples = inFrame.SampleCount;
			int outSamples = GetOutSampleCount(inSamples);
			outFrame.format = Destination;
			outFrame.Resize(outSamples);
			outSamples = Resample(inFrame.datas, inSamples, outFrame.datas, outSamples);
			outFrame.sampleCount = outSamples;
		}

		public static void ToPacked(AudioFrame inOutFrame) {
			AudioResampler resampler = GetPackedResampler(inOutFrame.format);
			if (resampler == null) return;

			var samples = inOutFrame.SampleCount;
			int bytes = resampler.GetOutBytes(samples);
			packedCache.Resize(bytes);
			var data = packedCache.data;
			fixed (IntPtr* input = inOutFrame.datas) {
				resampler.Resample((IntPtr) input, samples, (IntPtr) (&data), samples);
			}
			inOutFrame.format = resampler.Destination;
			inOutFrame.Update(samples, packedCache.data);
		}

		public static void ToPlanar(AudioFrame inOutFrame) {
			AudioResampler resampler = GetPlanarResampler(inOutFrame.format);
			if (resampler == null) return;

			var samples = inOutFrame.SampleCount;
			int bytes = resampler.GetOutBytes(samples);
			packedCache.Resize(bytes);
			var data = packedCache.data;
			Buffer.MemoryCopy((void*) inOutFrame.datas[0], (void*) data, bytes, bytes);
			int lineBytes = resampler.Destination.GetLineBytes(samples);
			inOutFrame.format = resampler.Destination;
			inOutFrame.Resize(samples);
			fixed (IntPtr* input = inOutFrame.datas) {
				resampler.Resample((IntPtr) (&data), samples, (IntPtr) input, samples);
			}
			inOutFrame.sampleCount = samples;
		}

		public void Reset() {
			int result = FF.swr_init(ctx);
			if (result != 0) throw new CSharp.FFmpegException(result);
		}

		protected override void Dispose(bool disposing) {
			if (ctx == null) return;

			FF.swr_free(ref ctx);
		}

		public static AudioResampler GetPackedResampler(AudioFormat planarFormat) {
			if (!planarFormat.IsPlanarFormat) return null;

			if (planarResamplers.TryGetValue(planarFormat, out AudioResampler resampler)) {
				return resampler;
			}
			resampler = new AudioResampler(planarFormat, planarFormat.ToPacked());
			planarResamplers.Add(planarFormat, resampler);
			return resampler;
		}

		public static AudioResampler GetPlanarResampler(AudioFormat packedFormat) {
			if (packedFormat.IsPlanarFormat) return null;

			if (planarResamplers.TryGetValue(packedFormat, out AudioResampler resampler)) {
				return resampler;
			}
			resampler = new AudioResampler(packedFormat, packedFormat.ToPlanar());
			planarResamplers.Add(packedFormat, resampler);
			return resampler;
		}

		public override void Convert(AudioFrame inFrame, AudioFrame outFrame) {
			if (!inFrame.IsEmpty) {
				Resample(inFrame, outFrame);
			} else {
				ResampleFinal(outFrame);
			}
		}
	}
}
