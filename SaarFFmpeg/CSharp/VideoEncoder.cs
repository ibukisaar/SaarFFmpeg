﻿using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FF = Saar.FFmpeg.Internal.FFmpeg;

namespace Saar.FFmpeg.CSharp {
	unsafe public sealed class VideoEncoder : Encoder {
		private VideoResampler resampler;
		private VideoFrame tempFrame;
		private VideoFormat outFormat;
		private Fraction framePerSecond;

		public VideoFormat InFormat { get; }
		public VideoFormat OutFormat => outFormat;
		public VideoResampler Resampler => resampler;
		public double FramesPerSecond => framePerSecond.Value;

		public override TimeSpan InputTimestamp
			=> TimeSpan.FromTicks(inputFrames * 10000000 * framePerSecond.Den / framePerSecond.Num);

		public VideoEncoder(AVCodecID codecID, VideoFormat format, VideoEncoderParameters encoderParams = null) : base(codecID) {
			encoderParams = encoderParams ?? VideoEncoderParameters.Default;
			if (codec->Type != AVMediaType.Video)
				throw new ArgumentException($"{codecID}不是视频格式", nameof(codecID));

			codecContext = FF.avcodec_alloc_context3(codec);
			if (codecContext == null) throw new Exception("无法分配编码器上下文");

			InFormat = format;
			Init(encoderParams);
		}

		internal VideoEncoder(AVStream* stream, VideoFormat format, VideoEncoderParameters encoderParams = null) : base(stream) {
			encoderParams = encoderParams ?? VideoEncoderParameters.Default;

			InFormat = format;
			Init(encoderParams);
		}

		private void Init(VideoEncoderParameters encoderParams) {
			var pixelFormats = GetSupportedPixelFormats(codec);
			if (pixelFormats != null && !pixelFormats.Contains(InFormat.PixelFormat)) {
				outFormat = new VideoFormat(InFormat.Width, InFormat.Height, pixelFormats[0]);
				resampler = new VideoResampler(InFormat, OutFormat, encoderParams.ResampleFlags);
				tempFrame = new VideoFrame();
			} else {
				outFormat = InFormat;
			}

			framePerSecond = encoderParams.FrameRate;

			try {
				codecContext->PixFmt = OutFormat.PixelFormat;
				codecContext->Width = OutFormat.Width;
				codecContext->Height = OutFormat.Height;
				codecContext->BitRate = encoderParams.BitRate.Value;
				codecContext->TimeBase = encoderParams.FrameRate.Reciprocal;
				codecContext->Framerate = encoderParams.FrameRate;
				if (encoderParams.GopSize != 0)
					codecContext->GopSize = encoderParams.GopSize;
				if (encoderParams.MaxBFrames != 0)
					codecContext->MaxBFrames = encoderParams.MaxBFrames;
				if (encoderParams.MbDecision != 0)
					codecContext->MbDecision = encoderParams.MbDecision;
				if (encoderParams.Qmin != 0)
					codecContext->Qmin = encoderParams.Qmin;
				if (encoderParams.Qmax != 0)
					codecContext->Qmax = encoderParams.Qmax;

				var result = FF.avcodec_open2(codecContext, codec, null);
				if (result < 0) throw new CSharp.FFmpegException(result);
			} catch {
				Dispose();
				throw;
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				resampler?.Dispose();
				resampler = null;
				tempFrame?.Dispose();
				tempFrame = null;
			}
			base.Dispose(disposing);
		}

		private static AVCodec* CheckCodec(AVCodec* codec) {
			if (codec->Type != AVMediaType.Video)
				throw new ArgumentException($"{codec->Id}不是视频格式");

			return codec;
		}

		public static bool IsSupportedFormat(AVCodecID codecID, AVPixelFormat pixelFormat, AVRational frameRate) {
			var codec = GetEncoder(codecID);
			var pixelFormats = GetSupportedPixelFormats(codec);
			var frameRates = GetSupportedFrameRates(codec);

			return (pixelFormats?.Contains(pixelFormat) ?? true)
				&& (frameRates?.Contains(frameRate) ?? true);
		}

		public static void MatchSupportedFormat(AVCodecID codecID, ref AVPixelFormat pixelFormat, ref AVRational frameRate) {
			var codec = GetEncoder(codecID);
			var pixelFormats = GetSupportedPixelFormats(codec);
			var frameRates = GetSupportedFrameRates(codec);

			if (pixelFormats != null && !pixelFormats.Contains(pixelFormat)) {
				pixelFormat = pixelFormats.First();
			}

			if (frameRates != null && !frameRates.Contains(frameRate)) {
				foreach (var fr in frameRates.OrderBy(fr => (Fraction)fr)) {
					frameRate = fr;
					if (((Fraction)fr).CompareTo(frameRate) >= 0) {
						break;
					}
				}
			}
		}

		private static List<AVPixelFormat> GetSupportedPixelFormats(AVCodec* codec) {
			if (codec->PixFmts == null) return null;

			var result = new List<AVPixelFormat>();
			for (var p = codec->PixFmts; *p != AVPixelFormat.None; p++) {
				result.Add(*p);
			}
			return result;
		}

		private static List<AVRational> GetSupportedFrameRates(AVCodec* codec) {
			if (codec->SupportedFramerates == null) return null;

			var result = new List<AVRational>();
			for (var p = codec->SupportedFramerates; p->Num != 0; p++) {
				result.Add(*p);
			}
			return result;
		}

		public static List<AVPixelFormat> GetSupportedPixelFormats(AVCodecID codecID) {
			return GetSupportedPixelFormats(GetEncoder(codecID));
		}

		public static List<AVRational> GetSupportedFrameRates(AVCodecID codecID) {
			return GetSupportedFrameRates(GetEncoder(codecID));
		}

		public override bool Encode(Frame frame, Packet outPacket) {
			if (frame != null) {
				if (!(frame is VideoFrame)) throw new ArgumentException($"{nameof(frame)}必须是{nameof(VideoFrame)}类型", nameof(frame));
				if (!(frame as VideoFrame).format.Equals(InFormat)) throw new ArgumentException("输入帧的格式和编码器输入格式不同");
			}

			if (resampler != null) {
				if (frame != null) {
					resampler.Resample(frame as VideoFrame, tempFrame);
					frame = tempFrame;
				}
			}

			encodeFrames = 0;
			outPacket.ReleaseNativeBuffer();
			int gotPicture = 0;
			if (frame != null) {
				try {
					frame.SetupToNative();
					frame.presentTimestamp = new Timestamp(inputFrames, framePerSecond.Reciprocal);
					frame.presentTimestamp.Transform(codecContext->TimeBase);
					frame.frame->Pts = frame.presentTimestamp.Value;
					FF.avcodec_encode_video2(codecContext, outPacket.packet, frame.frame, &gotPicture).CheckFFmpegCode("视频编码发生错误");

					//int ret = FF.avcodec_send_frame(codecContext, frame.frame).CheckFFmpegCode("视频编码发生错误");
					//while (ret >= 0) {
					//	ret = FF.avcodec_receive_packet(codecContext, outPacket.packet);
					//	if (ret == Error.EAGAIN.AVError() || ret == (int)AVError.Eof) {
					//		break;
					//	} else if (ret < 0) {
					//		throw new FFmpegException(ret);
					//	}
					//}
				} finally {
					frame.ReleaseSetup();
				}

				inputFrames++;
				encodeFrames = 1;
			} else {
				FF.avcodec_encode_video2(codecContext, outPacket.packet, null, &gotPicture).CheckFFmpegCode("视频编码发生错误");
				//int ret = FF.avcodec_send_frame(codecContext, null).CheckFFmpegCode("视频编码发生错误");
				//while (ret >= 0) {
				//	ret = FF.avcodec_receive_packet(codecContext, outPacket.packet);
				//	if (ret == Error.EAGAIN.AVError() || ret == (int)AVError.Eof) {
				//		break;
				//	} else if (ret < 0) {
				//		throw new FFmpegException(ret);
				//	}
				//}
			}

			if (gotPicture != 0) {
				ConfigPakcet(outPacket);
				return true;
			}
			return false;
		}

		public override string ToString()
			=> $"{FullName}, 输出:{OutFormat}";
	}
}
