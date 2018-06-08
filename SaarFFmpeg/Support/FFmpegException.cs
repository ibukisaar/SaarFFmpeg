using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	public class FFmpegException : Exception {
		public int ErrorCode { get; }

		public FFmpegException(int errorCode) : base(GetErrorString(errorCode)) {
			ErrorCode = errorCode;
		}

		public FFmpegException(int errorCode, string message) : base(message + "。FFmpeg错误消息：" + GetErrorString(errorCode)) {
			ErrorCode = errorCode;
		}

		unsafe public static string GetErrorString(int errorCode) {
			byte* buffer = stackalloc byte[Internal.Constant.AV_ERROR_MAX_STRING_SIZE];
			FF.av_strerror(errorCode, buffer, (IntPtr)Internal.Constant.AV_ERROR_MAX_STRING_SIZE);
			return Marshal.PtrToStringAnsi((IntPtr)buffer);
		}
	}
}
