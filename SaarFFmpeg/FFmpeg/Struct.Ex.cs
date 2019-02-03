using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Saar.FFmpeg.Structs {
	unsafe partial struct AVOutputFormat {
		public string Debug_Name => Marshal.PtrToStringAnsi((IntPtr)this.Name);
		public string Debug_LongName => Marshal.PtrToStringAnsi((IntPtr)this.LongName);
		public string Debug_MimeType => Marshal.PtrToStringAnsi((IntPtr)this.MimeType);
		public string Debug_Extensions => Marshal.PtrToStringAnsi((IntPtr)this.Extensions);
	}
}
