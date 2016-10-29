using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public abstract class MediaStream : DisposableObject {
		protected const int bufferLength = 4096;

		protected AVIOContext* ioContext;
		public AVFormatContext* formatContext;
		protected byte[] tempBuffer = new byte[bufferLength];
		protected byte* buffer;
		protected Stream baseStream;

		private Internal.Delegates.IOBufferDelegate procRead = null;
		private Internal.Delegates.IOBufferDelegate procWrite = null;
		private Internal.Delegates.SeekBufferDelegate procSeek = null;

		public int StreamCount => (int) formatContext->NbStreams;

		public MediaStream(Stream baseStream, bool write = false, AVOutputFormat* outputFormat = null) {
			if (write && !baseStream.CanWrite)
				throw new ArgumentException($"流不能被写入，请确保{nameof(Stream)}.{nameof(baseStream.CanWrite)}为true");

			if (baseStream.CanRead) procRead = Read;
			if (write && baseStream.CanWrite) procWrite = Write;
			if (baseStream.CanSeek) procSeek = Seek;
			this.baseStream = baseStream;

			try {
				formatContext = FF.avformat_alloc_context();
				buffer = (byte*) FF.av_malloc((IntPtr) bufferLength);
				ioContext = FF.avio_alloc_context(buffer, bufferLength, write, null, procRead, procWrite, procSeek);
				if (write) {
					formatContext->Oformat = outputFormat;
					formatContext->Flags = AVFmtFlag.CustomIO;
				}
				formatContext->Pb = ioContext;
			} catch {
				Dispose();
				throw;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (baseStream != null)
					baseStream.Dispose();
			}

			if (formatContext != null) {
				FF.avformat_close_input(ref formatContext);
			}

			if (ioContext != null) {
				FF.av_freep(&ioContext->Buffer);
				FF.av_free(ioContext);
				ioContext = null;
			}
		}

		[AllowReversePInvokeCalls]
		private int Read(void* opaque, IntPtr buffer, int bufferLength) {
			bufferLength = Math.Min(bufferLength, tempBuffer.Length);
			int length = baseStream.Read(tempBuffer, 0, bufferLength);
			Marshal.Copy(tempBuffer, 0, buffer, length);
			return length;
		}

		[AllowReversePInvokeCalls]
		private int Write(void* opaque, IntPtr buffer, int bufferLength) {
			bufferLength = Math.Min(bufferLength, tempBuffer.Length);
			Marshal.Copy(buffer, tempBuffer, 0, bufferLength);
			baseStream.Write(tempBuffer, 0, bufferLength);
			return bufferLength;
		}

		[AllowReversePInvokeCalls]
		private long Seek(void* opaque, long offset, AVSeek whence) {
			if (whence == AVSeek.Size) {
				return baseStream.Length;
			} else if ((int) whence < 3) {
				return baseStream.Seek(offset, (SeekOrigin) whence);
			} else {
				return -1;
			}
		}
	}
}
