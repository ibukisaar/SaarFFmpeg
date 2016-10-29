using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp.Codecs {
	unsafe public abstract class Decoder : Codec {
		protected Decoder(AVStream *stream) : base(stream) {
			codecContext->Codec = FF.avcodec_find_decoder(codecContext->CodecId);
			int resultCode = FF.avcodec_open2(codecContext, codecContext->Codec, null);
			if (resultCode != 0) throw new Support.FFmpegException(resultCode);
		}

		public abstract bool Decode(Packet packet, Frame outFrame);

		internal static Decoder Create(AVStream* stream) {
			switch (stream->Codec->CodecType) {
				case AVMediaType.Audio: return new AudioDecoder(stream);
				case AVMediaType.Video: return new VideoDecoder(stream);
			}
			return null;
		}
	}
}
