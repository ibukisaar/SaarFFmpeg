using Saar.FFmpeg.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Internal {
	unsafe public static class Delegates {
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int IOBufferDelegate(void* opaque, IntPtr buffer, int bufferLength);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate long SeekBufferDelegate(void* opaque, long offset, AVSeek whence);


	}
}
