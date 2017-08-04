using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class AudioDecoder : Decoder {
		private AudioResampler resampler;

		public AudioFormat InFormat { get; }

		/// <summary>
		/// 获取或设置输出格式。如果设置为null或和<see cref="InFormat"/>的值一致 ，则不使用重采样。
		/// </summary>
		public AudioFormat OutFormat {
			get { return resampler?.Target ?? InFormat; }
			set {
				if (value == null || InFormat.Equals(value)) {
					resampler?.Dispose();
					resampler = null;
				} else {
					if (resampler == null || !OutFormat.Equals(value)) {
						resampler?.Dispose();
						resampler = new AudioResampler(InFormat, value);
					}
				}
			}
		}

		public AudioResampler Resampler => resampler;

		internal AudioDecoder(AVStream* stream) : base(stream) {
			InFormat = new AudioFormat(codecContext->SampleRate, codecContext->ChannelLayout, codecContext->SampleFmt);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				resampler = null;
			}
			base.Dispose(disposing);
		}

		public override bool Decode(Packet packet, Frame outFrame) {
			var audioFrame = outFrame as AudioFrame;
			if (audioFrame == null) {
				throw new ArgumentException($"{nameof(outFrame)}必须是{nameof(AudioFrame)}类型且不为null。");
			}

			if (packet != null) {
				if (packet.StreamIndex != StreamIndex) {
					throw new ArgumentException($"无法解码该{nameof(packet)}，原因是流编号和解码器不一致。");
				}

				int gotPicture = 0;
				int resultCode = FF.avcodec_decode_audio4(codecContext, outFrame.frame, &gotPicture, packet.packet);
				if (resultCode < 0) throw new CSharp.FFmpegException(resultCode, "音频解码发生错误");

				if (gotPicture == 0) return false;

				audioFrame.format = InFormat;
				if (resampler != null) {
					resampler.InternalResample(audioFrame); // resample and update
				} else {
					outFrame.UpdateFromNative();
				}
			} else if (resampler != null) {
				resampler.ResampleFinal(audioFrame);
				if (audioFrame.LineDataBytes == 0) return false;
			} else {
				return false;
			}

			return true;
		}

		public override string ToString()
			=> $"{FullName}, 输入:{InFormat}, 输出:{OutFormat}";
	}
}
