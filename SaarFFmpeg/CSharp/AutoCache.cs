using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public struct AutoCache {
		internal IntPtr data;
		private int capacity;

		public IntPtr Data => data;

		public AutoCache(int capacity) {
			this = new AutoCache();
			Resize(capacity);
		}

		public void Resize(int newSize) {
			data = FF.av_fast_realloc(data, ref capacity, (IntPtr) newSize);
		}

		public static explicit operator IntPtr(AutoCache @this) {
			return @this.data;
		}

		unsafe public static explicit operator void* (AutoCache @this) {
			return (void*) @this.data;
		}

		unsafe public void Free() {
			FF.av_free((void*) data);
		}
	}
}
