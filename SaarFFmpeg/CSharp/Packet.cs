using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	/// <summary>
	/// 解码前或编码后的包。
	/// </summary>
	unsafe public class Packet : DisposableObject {
		internal AVPacket* packet;
		internal TimeSpan timestamp;
		internal TimeSpan codecTimestamp;

		public IntPtr Data => (IntPtr) packet->Data;
		public int Size => packet->Size;
		public int StreamIndex => packet->StreamIndex;
		public TimeSpan Timestamp => timestamp;
		public TimeSpan CodecTimestamp => codecTimestamp;
		public long Position => packet->Pos;

		public Packet() {
			packet = FF.av_packet_alloc();
			FF.av_init_packet(packet);
			packet->Data = null;
			packet->Size = 0;
		}

		internal void Unref() {
			FF.av_packet_unref(packet);
		}

		protected override void Dispose(bool disposing) {
			if (packet == null) return;

			Unref();

			FF.av_packet_free(ref packet);
		}
	}
}
