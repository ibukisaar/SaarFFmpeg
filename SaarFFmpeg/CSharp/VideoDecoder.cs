﻿using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public class VideoDecoder : Decoder {
		private VideoResampler resampler;

		public VideoFormat InFormat { get; }

		/// <summary>
		/// 获取或设置输出格式。如果设置为null或和<see cref="InFormat"/>的值一致 ，则不使用重采样。
		/// </summary>
		public VideoFormat OutFormat {
			get { return resampler?.Destination ?? InFormat; }
			set {
				if (value == null || InFormat.Equals(value)) {
					resampler?.Dispose();
					resampler = null;
				} else {
					if (resampler == null || !OutFormat.Equals(value)) {
						resampler?.Dispose();
						resampler = new VideoResampler(InFormat, value);
					}
				}
			}
		}

		public VideoResampler Resampler => resampler;


		public VideoDecoder(AVStream* stream) : base(stream) {
			InFormat = new VideoFormat(codecContext->Width, codecContext->Height, codecContext->PixFmt);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				resampler = null;
			}

			base.Dispose(disposing);
		}

		public override bool Decode(Packet packet, Frame outFrame) {
			if (!(outFrame is VideoFrame videoFrame)) {
				throw new ArgumentException($"{nameof(outFrame)}必须是{nameof(VideoFrame)}类型且不为null。");
			}
			if (packet == null) return false;

			int gotPicture = 0;
			FF.avcodec_decode_video2(codecContext, outFrame.frame, &gotPicture, packet.packet).CheckFFmpegCode("视频解码发生错误");

			if (gotPicture == 0) return false;

			if (stream != null) outFrame.presentTimestamp = new Timestamp(outFrame.frame->Pts, stream->TimeBase);
			videoFrame.pictureType = outFrame.frame->PictType;
			videoFrame.format = InFormat;
			if (resampler != null) {
				resampler.InternalResample(videoFrame);
			} else {
				videoFrame.UpdateFromNative();
			}

			return true;
		}

		public override string ToString()
			=> $"{FullName}, 输入:{InFormat}, 输出:{OutFormat}";
	}
}
