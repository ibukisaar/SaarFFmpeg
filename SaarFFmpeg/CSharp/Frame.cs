using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public abstract class Frame : DisposableObject {
		internal AVFrame* frame;
		internal AutoCache cache = new AutoCache();

		public abstract AVMediaType Type { get; }

		protected Frame() {
			frame = FF.av_frame_alloc();
		}

		internal abstract void UpdateFromNative();

		internal void ReleaseNativeBuffer() {
			FF.av_frame_unref(frame);
		}

		protected abstract void Setup();

		internal void SetupToNative() {
			if (frame->ExtendedData != null) {
				ReleaseNativeBuffer();
			}
			Setup();
		}

		internal void ReleaseSetup() {
			frame->ExtendedData = null;
		}

		protected override void Dispose(bool disposing) {
			if (frame == null) return;

			cache.Free();

			FF.av_frame_free(ref frame);
		}
	}
}