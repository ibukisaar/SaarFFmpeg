using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.CSharp {
	public abstract class AudioDelayConverter : AudioConverter {
		private AudioFrame delay;
		private AudioFrame newInFrame;

		public int Delay => delay?.sampleCount ?? 0;

		protected override void Dispose(bool disposing) {
			if (disposing) {
				delay?.Dispose();
				newInFrame?.Dispose();
				delay = null;
				newInFrame = null;
			}
		}

		/*
			[delay data], [in data]
			          ↓(merge)
			[new in data(+new delay data)]
			          ↓(convert)
			[out data]
		*/
		public sealed override void Convert(AudioFrame inFrame, AudioFrame outFrame) {
			if (delay == null) delay = new AudioFrame(inFrame.format);
			if (!delay.IsEmpty) {
				if (newInFrame == null) newInFrame = new AudioFrame();
				AudioFrame.Merge(newInFrame, delay, inFrame);
				inFrame = newInFrame;
			}

			InternalConvert(inFrame, outFrame, out int delaySampleCount);
			delay.sampleCount = delaySampleCount;
			inFrame.CopyTo(inFrame.sampleCount - delaySampleCount, delaySampleCount, delay);
		}

		protected abstract void InternalConvert(AudioFrame inFrame, AudioFrame outFrame, out int delay);
	}
}
