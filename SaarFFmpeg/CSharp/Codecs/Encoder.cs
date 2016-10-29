using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp.Codecs {
	unsafe public abstract class Encoder : Codec {
		protected long inputFrames;
		protected long encodeFrames;

		public long InputFrames => inputFrames;
		public TimeSpan InputTimestamp => TimeSpan.FromSeconds(inputFrames * codecContext->TimeBase.Value);

		public Encoder(AVCodecID codecID) : base(codecID) { }

		public Encoder(AVStream* stream) : base(stream) { }

		public abstract bool Encode(Frame frame, Packet outPacket);

		internal void ConfigPakcet(Packet packet) {
			var frame = codecContext->CodedFrame;
			if (stream != null) {
				packet.packet->Pts = FF.av_rescale_q(inputFrames, codecContext->TimeBase, stream->TimeBase);
				packet.packet->Duration = FF.av_rescale_q(encodeFrames, codecContext->TimeBase, stream->TimeBase);
				packet.packet->StreamIndex = stream->Index;
			} else {
				packet.packet->Pts = inputFrames * codecContext->TimeBase.Num / codecContext->TimeBase.Den;
				packet.packet->Duration = encodeFrames * codecContext->TimeBase.Num / codecContext->TimeBase.Den;
			}

			if (frame->KeyFrame != 0) {
				packet.packet->Flags |= AVPktFlag.Key;
			}
			packet.packet->Pos = -1;
		}
	}
}
