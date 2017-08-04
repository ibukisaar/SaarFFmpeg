using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Saar.FFmpeg.Internal {
	[SuppressUnmanagedCodeSecurity]
	unsafe public static partial class FFmpeg {

#if !ANDROID
		const string Dll_AVUtil = "avutil-55";
		const string Dll_AVCodec = "avcodec-57";
		const string Dll_AVFormat = "avformat-57";
		const string Dll_Swscale = "swscale-4";
		const string Dll_Swresample = "swresample-2";
#else
		const string Dll_AVUtil = "avutil";
		const string Dll_AVCodec = "avcodec";
		const string Dll_AVFormat = "avformat";
		const string Dll_Swscale = "swscale";
		const string Dll_Swresample = "swresample";
#endif

		const CallingConvention Convention = CallingConvention.Cdecl;

		const string RequestVersion = "N-81626-g7c5fed1";

		public static string Version { get; }

		static FFmpeg() {
			av_register_all();

			Version = Marshal.PtrToStringAnsi((IntPtr) av_version_info());

			//if (Version != RequestVersion) {
			//	throw new BadImageFormatException("ffmpeg dll版本必须是" + RequestVersion);
			//}
		}
	}
}
