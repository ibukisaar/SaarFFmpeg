using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using System.Runtime.InteropServices;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public struct CodecDescription {
		public AVCodec* Codec { get; }

		public CodecDescription(AVCodec* codec) => Codec = codec;

		public string Name => Marshal.PtrToStringAnsi((IntPtr)Codec->Name);

		public string FullName => Marshal.PtrToStringAnsi((IntPtr)Codec->LongName);

		public string Dir {
			get {
				return
					FF.av_codec_is_decoder(Codec) != 0 ? "[D]" :
					FF.av_codec_is_encoder(Codec) != 0 ? "[E]" :
					"[?]";
			}
		}

		public string Type {
			get {
				switch (Codec->Type) {
					case AVMediaType.Audio: return "音频";
					case AVMediaType.Video: return "视频";
					case AVMediaType.Subtitle: return "字幕";
					case AVMediaType.Data: return "数据";
					case AVMediaType.Attachment: return "附件";
					default: return "未知";
				}
			}
		}

		public override string ToString() => $"{Dir}[{Type}] {FullName ?? Name}";
	}
}
