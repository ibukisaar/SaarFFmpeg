using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.Support {
	public sealed class FFmpegException : Exception {
		public int ErrorCode { get; }

		public FFmpegException(int errorCode) : base(GetErrorString(errorCode)) {
			ErrorCode = errorCode;
		}

		public FFmpegException(int errorCode, string message) : base(message + "。FFmpeg错误消息：" + GetErrorString(errorCode)) {
			ErrorCode = errorCode;
		}

		private static string GetErrorString(int errorCode) {
			StringBuilder buffer = new StringBuilder(1000);
			FF.av_strerror(errorCode, buffer, (IntPtr) 1000);
			return buffer.ToString();
		}
	}
}
