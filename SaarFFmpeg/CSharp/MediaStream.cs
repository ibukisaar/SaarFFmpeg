﻿using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;
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
		private const int bufferLength = 4096;

#if !NETCORE
		private readonly byte[] tempBuffer = new byte[bufferLength];
#endif
		internal protected AVIOContext* ioContext;
		internal protected AVFormatContext* formatContext;
		protected Stream baseStream;

		private readonly avio_alloc_context_read_packet procRead = null;
		private readonly avio_alloc_context_write_packet procWrite = null;
		private readonly avio_alloc_context_seek procSeek = null;

		public int StreamCount => (int)formatContext->NbStreams;

		public MediaStream(Stream baseStream, bool write = false, AVOutputFormat* outputFormat = null) {
			if (write && !baseStream.CanWrite)
				throw new ArgumentException($"流不能被写入，请确保Stream.CanWrite为true");

			if (baseStream.CanRead) procRead = Read;
			if (write && baseStream.CanWrite) procWrite = Write;
			if (baseStream.CanSeek) procSeek = Seek;
			this.baseStream = baseStream;

			try {
				formatContext = FF.avformat_alloc_context();
				var buffer = (byte*)FF.av_malloc((IntPtr)bufferLength);
				ioContext = FF.avio_alloc_context(buffer, bufferLength, write, null, procRead, procWrite, procSeek);
				if (write) {
					formatContext->Oformat = outputFormat;
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
		private int Read(void* opaque, byte* buffer, int bufferLength) {
#if !NETCORE
			bufferLength = Math.Min(bufferLength, MediaStream.bufferLength);
			int length = baseStream.Read(tempBuffer, 0, bufferLength);
			Marshal.Copy(tempBuffer, 0, (IntPtr)buffer, length);
			return length;
#else
			return baseStream.Read(new Span<byte>(buffer, bufferLength));
#endif
		}

		[AllowReversePInvokeCalls]
		private int Write(void* opaque, byte* buffer, int bufferLength) {
#if !NETCORE
			bufferLength = Math.Min(bufferLength, tempBuffer.Length);
			Marshal.Copy((IntPtr)buffer, tempBuffer, 0, bufferLength);
			baseStream.Write(tempBuffer, 0, bufferLength);
#else
			baseStream.Write(new ReadOnlySpan<byte>(buffer, bufferLength));
#endif
			return bufferLength;
		}

		[AllowReversePInvokeCalls]
		private long Seek(void* opaque, long offset, AVSeek whence) {
			if (whence == AVSeek.Size) {
				return baseStream.Length;
			} else if ((int)whence < 3) {
				return baseStream.Seek(offset, (SeekOrigin)whence);
			} else {
				return -1;
			}
		}

		protected void InternalWrite(Packet packet) {
			if (packet.Size > 0) {
				FF.av_interleaved_write_frame(formatContext, packet.packet).CheckFFmpegCode();
			}
		}
	}
}
