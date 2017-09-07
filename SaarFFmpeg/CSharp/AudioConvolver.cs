using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp.DSP;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp {
	/// <summary>
	/// 未测试
	/// </summary>
	unsafe public sealed class AudioConvolver : AudioConverter {
		private int kernelCount, kernelSize;
		private AudioResampler resampler;
		private AudioFrame tempInput = new AudioFrame();
		private Convolver[] convs;

		public AudioConvolver(params double[][] kernels) {
			kernelCount = kernels.Length;
			if (kernelCount == 0) throw new ArgumentException("至少要有一个卷积核", nameof(kernels));

			kernelSize = kernels[0].Length;
			if (kernelSize == 0) throw new ArgumentException("卷积核大小不能为0", nameof(kernels));
			for (int i = 1; i < kernelCount; i++) {
				if (kernels[i].Length != kernelSize) throw new ArgumentException("所有卷积核的大小要一致", nameof(kernels));
			}

			convs = kernels.Select(k => new Convolver(k)).ToArray();
		}

		public override void Convert(AudioFrame inFrame, AudioFrame outFrame) {
			if (kernelCount > 1 && kernelCount != inFrame.format.Channels)
				throw new ArgumentException($"{nameof(inFrame)}的数据行数和卷积核个数不一致", nameof(inFrame));

			var inFormat = inFrame.format;
			var inSamples = inFrame.sampleCount;
			var outSamples = convs[0].GetOutLength(inSamples);
			var outFormat = inFormat;

			if (resampler == null && inFormat.SampleFormat != AVSampleFormat.DoublePlanar) {
				outFormat = new AudioFormat(inFormat.SampleRate, inFormat.ChannelLayout, inFormat.SampleFormat.ToPlanar());
				resampler = new AudioResampler(inFormat, outFormat);
			}
			if (resampler != null) {
				resampler.Resample(inFrame, tempInput);
				inFrame = tempInput;
			}

			outFrame.Resize(outFormat, outSamples);

			for (int i = 0; i < kernelCount; i++) {
				convs[kernelCount == 1 ? 0 : i].Convolve((double*) inFrame.datas[i], inSamples, (double*) outFrame.datas[i], outSamples);
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				tempInput.Dispose();
				if (convs != null) Array.ForEach(convs, conv => conv.Dispose());
				resampler = null;
				tempInput = null;
				convs = null;
			}
		}
	}
}
