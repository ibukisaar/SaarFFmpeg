using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Saar.FFmpeg.Internal {
	[SuppressUnmanagedCodeSecurity]
	unsafe public static partial class FFmpeg {
#if !ANDROID
		const string Dll_AVUtil = "avutil-56";
		const string Dll_AVCodec = "avcodec-58";
		const string Dll_AVFormat = "avformat-58";
		const string Dll_SwScale = "swscale-5";
		const string Dll_SwResample = "swresample-3";
		const string Dll_AVDevice = "avdevice-58";
		const string Dll_AVFilter = "avfilter-7";
		const string Dll_PostProc = "postproc-55";
#else
		const string Dll_AVUtil = "avutil";
		const string Dll_AVCodec = "avcodec";
		const string Dll_AVFormat = "avformat";
		const string Dll_SwScale = "swscale";
		const string Dll_SwResample = "swresample";
		const string Dll_AVDevice = "avdevice";
		const string Dll_AVFilter = "avfilter";
		const string Dll_PostProc = "postproc";
#endif

		const CallingConvention Convention = CallingConvention.Cdecl;

		public static string Version => Marshal.PtrToStringAnsi(av_version_info());

		static FFmpeg() {
			av_register_all();

			System.Diagnostics.Debug.WriteLine("FFmpeg Version: " + Version);
		}
	}
}
