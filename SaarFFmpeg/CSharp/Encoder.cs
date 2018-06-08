using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public abstract class Encoder : Codec {
		protected long inputFrames;
		protected long encodeFrames;

		public long InputFrames => inputFrames;
		public long EncodeFrames => encodeFrames;
		public virtual TimeSpan InputTimestamp => TimeSpan.FromSeconds(inputFrames * (double)codecContext->TimeBase.Num / codecContext->TimeBase.Den);

		public Encoder(AVCodecID codecID) : base(codecID) { }

		public Encoder(AVStream* stream) : base(stream) { }

		public abstract bool Encode(Frame frame, Packet outPacket);

		internal void ConfigPakcet(Packet packet) {
			var frame = codecContext->CodedFrame;
			if (stream != null) {
				packet.UpdateTimestampFromNative(codecContext->TimeBase);
				packet.TransformTimestamp(stream->TimeBase);
				packet.UpdateTimestampToNative();
				packet.packet->StreamIndex = stream->Index;
			}

			if (frame->KeyFrame != 0) {
				packet.packet->Flags |= AVPktFlag.Key;
			}
			packet.packet->Pos = -1;
		}
	}
}
