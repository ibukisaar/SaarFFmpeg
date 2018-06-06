using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public sealed class FixedAudioFrameQueue : DisposableObject {
		private AudioFrame main = new AudioFrame(), minor = new AudioFrame();
		private AudioFrame result = new AudioFrame();

		public int FixedCount { get; }
		public AudioFormat Format {
			get => main.format;
			private set {
				if (value == null) return;
				minor.Resize(value, 0);
				main.Resize(value, 0);
			}
		}

		public FixedAudioFrameQueue(int fixedCount, AudioFormat format = null) {
			FixedCount = fixedCount;
			Format = format;
		}

		private void SwapFrame() {
			var temp = minor;
			minor = main;
			main = temp;
		}

		public void Enqueue(AudioFrame inFrame) {
			if (inFrame.format == null) throw new InvalidOperationException("无效的帧");

			if (Format == null) {
				Format = inFrame.format;
			} else {
				if (Format != inFrame.format) throw new InvalidOperationException("格式不一致");
			}

			if (inFrame.sampleCount == 0) return;

			var oldSamples = main.sampleCount;
			minor.Resize(oldSamples + inFrame.sampleCount);
			main.CopyToNoResize(0, oldSamples, minor);
			inFrame.CopyToNoResize(0, inFrame.sampleCount, minor, oldSamples);
			SwapFrame();
		}

		public AudioFrame Dequeue(bool isFixed = true) {
			if (main.format == null) return null;

			if (main.sampleCount >= FixedCount) {
				main.CopyTo(0, FixedCount, result);
				main.CopyTo(FixedCount, main.sampleCount - FixedCount, minor);
				SwapFrame();
				return result;
			} else if (!isFixed && main.sampleCount > 0) {
				main.CopyTo(0, main.sampleCount, result);
				main.Resize(0);
				return result;
			}
			return null;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				main?.Dispose();
				main = null;
				minor?.Dispose();
				minor = null;
				result?.Dispose();
				result = null;
			}
		}
	}
}
