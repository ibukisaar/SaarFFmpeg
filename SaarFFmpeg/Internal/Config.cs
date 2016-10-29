using System;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Internal {
	unsafe public static partial class FFmpeg {
		const string Dll_AVUtil = "avutil-55";
		const string Dll_AVCodec = "avcodec-57";
		const string Dll_AVFormat = "avformat-57";
		const string Dll_Swscale = "swscale-4";
		const string Dll_Swresample = "swresample-2";

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
