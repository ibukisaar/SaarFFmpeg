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
			if (data == IntPtr.Zero) {
				data = Marshal.AllocHGlobal(capacity = newSize);
			} else if (capacity < newSize) {
				data = Marshal.ReAllocHGlobal(data, (IntPtr) (capacity = newSize));
			}
		}

		public static explicit operator IntPtr(AutoCache @this) {
			return @this.data;
		}

		unsafe public static explicit operator void* (AutoCache @this) {
			return (void*) @this.data;
		}

		unsafe public void Free() {
			Marshal.FreeHGlobal(data);
		}
	}
}
