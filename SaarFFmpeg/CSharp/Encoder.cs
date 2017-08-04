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
		protected long outputFrames;
		protected long encodeFrames;

		public long InputFrames => inputFrames;
		public long OutputFrames => outputFrames;
		public long EncodeFrames => encodeFrames;
		public virtual TimeSpan InputTimestamp => TimeSpan.FromSeconds(inputFrames * codecContext->TimeBase.Value);
		public virtual TimeSpan OutputTimestamp => TimeSpan.FromSeconds(outputFrames * codecContext->TimeBase.Value);

		public Encoder(AVCodecID codecID) : base(codecID) { }

		public Encoder(AVStream* stream) : base(stream) { }

		public abstract bool Encode(Frame frame, Packet outPacket);

		internal void ConfigPakcet(Packet packet) {
			var frame = codecContext->CodedFrame;
			if (stream != null) {
				packet.packet->Pts = FF.av_rescale_q(packet.packet->Pts, codecContext->TimeBase, stream->TimeBase);
				packet.packet->Dts = FF.av_rescale_q(packet.packet->Dts, codecContext->TimeBase, stream->TimeBase);
				packet.packet->Duration = FF.av_rescale_q(packet.packet->Duration, codecContext->TimeBase, stream->TimeBase);
				packet.packet->StreamIndex = stream->Index;
			}

			if (frame->KeyFrame != 0) {
				packet.packet->Flags |= AVPktFlag.Key;
			}
			packet.packet->Pos = -1;
		}
	}
}
