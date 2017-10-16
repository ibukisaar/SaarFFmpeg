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
		private Timestamp presentTimestamp;
		private Timestamp decodeTimestamp;
		private Timestamp duration;

		public IntPtr Data => (IntPtr) packet->Data;
		public int Size => packet->Size;
		public int StreamIndex {
			get => packet->StreamIndex;
			set => packet->StreamIndex = value;
		}

		public Timestamp PresentTimestamp => presentTimestamp;
		public Timestamp DecodeTimestamp => decodeTimestamp;
		public Timestamp Duration => duration;
		public long Position => packet->Pos;

		public Packet() {
			packet = FF.av_packet_alloc();
			FF.av_init_packet(packet);
			packet->Data = null;
			packet->Size = 0;
		}

		internal void ReleaseNativeBuffer() {
			FF.av_packet_unref(packet);
		}

		protected override void Dispose(bool disposing) {
			if (packet == null) return;

			ReleaseNativeBuffer();

			FF.av_packet_free(ref packet);
		}

		internal void UpdateTimestampFromNative(Fraction timeBase) {
			presentTimestamp = new Timestamp(packet->Pts, timeBase);
			decodeTimestamp = new Timestamp(packet->Dts, timeBase);
			duration = new Timestamp(packet->Duration, timeBase);
		}

		internal void TransformTimestamp(Fraction timeBase) {
			presentTimestamp.Transform(timeBase);
			decodeTimestamp.Transform(timeBase);
			duration.Transform(timeBase);
		}

		internal void UpdateTimestampToNative() {
			packet->Pts = presentTimestamp.Value;
			packet->Dts = decodeTimestamp.Value;
			packet->Duration = duration.Value;
		}
	}
}
