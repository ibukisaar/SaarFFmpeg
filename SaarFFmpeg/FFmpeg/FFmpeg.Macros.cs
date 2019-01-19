using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Internal {
#pragma warning disable IDE1006 // 命名样式
	public unsafe static class Constant {
		/// <summary>
		/// _WIN32_WINNT = 0x0602
		/// </summary>
		public const int _WIN32_WINNT = 0x602;
		// public readonly static attribute_deprecated = __declspec(deprecated);
		// public readonly static av_alias = __attribute__((may_alias));
		// public readonly static av_always_inline = __forceinline;
		/// <summary>
		/// AV_BUFFER_FLAG_READONLY = (1 &lt;&lt; 0)
		/// </summary>
		public const int AV_BUFFER_FLAG_READONLY = 0x1 << 0x0;
		// public readonly static av_builtin_constant_p = __builtin_constant_p;
		// public readonly static av_ceil_log2 = av_ceil_log2_c;
		// public readonly static av_clip = av_clip_c;
		// public readonly static av_clip_int16 = av_clip_int16_c;
		// public readonly static av_clip_int8 = av_clip_int8_c;
		// public readonly static av_clip_intp2 = av_clip_intp2_c;
		// public readonly static av_clip_uint16 = av_clip_uint16_c;
		// public readonly static av_clip_uint8 = av_clip_uint8_c;
		// public readonly static av_clip_uintp2 = av_clip_uintp2_c;
		// public readonly static av_clip64 = av_clip64_c;
		// public readonly static av_clipd = av_clipd_c;
		// public readonly static av_clipf = av_clipf_c;
		// public readonly static av_clipl_int32 = av_clipl_int32_c;
		/// <summary>
		/// AV_CODEC_FLAG_PASS2 = (1 &lt;&lt; 10)
		/// </summary>
		public const int AV_CODEC_FLAG_PASS2 = (1 << 10);
		/// <summary>
		/// AV_CODEC_FLAG_PSNR = (1 &lt;&lt; 15)
		/// </summary>
		public const int AV_CODEC_FLAG_PSNR = (1 << 15);
		/// <summary>
		/// AV_CODEC_FLAG_QPEL = (1 &lt;&lt;  4)
		/// </summary>
		public const int AV_CODEC_FLAG_QPEL = (1 << 4);
		/// <summary>
		/// AV_CODEC_FLAG_QSCALE = (1 &lt;&lt;  1)
		/// </summary>
		public const int AV_CODEC_FLAG_QSCALE = (1 << 1);
		/// <summary>
		/// AV_CODEC_FLAG_TRUNCATED = (1 &lt;&lt; 16)
		/// </summary>
		public const int AV_CODEC_FLAG_TRUNCATED = (1 << 16);
		/// <summary>
		/// AV_CODEC_FLAG_UNALIGNED = (1 &lt;&lt;  0)
		/// </summary>
		public const int AV_CODEC_FLAG_UNALIGNED = (1 << 0);
		// public readonly static av_cold = __attribute__((cold));
		// public readonly static av_const = __attribute__((const));
		/// <summary>
		/// AV_ERROR_MAX_STRING_SIZE = 64
		/// </summary>
		public const int AV_ERROR_MAX_STRING_SIZE = 0x40;
		// public readonly static av_extern_inline = inline;
		/// <summary>
		/// AV_FOURCC_MAX_STRING_SIZE = 32
		/// </summary>
		public const int AV_FOURCC_MAX_STRING_SIZE = 0x20;
		/// <summary>
		/// AV_FRAME_FILENAME_FLAGS_MULTIPLE = 1
		/// </summary>
		public const int AV_FRAME_FILENAME_FLAGS_MULTIPLE = 0x1;
		/// <summary>
		/// AV_GET_BUFFER_FLAG_REF = (1 &lt;&lt; 0)
		/// </summary>
		public const int AV_GET_BUFFER_FLAG_REF = 0x1 << 0x0;
		// public readonly static av_mod_uintp2 = av_mod_uintp2_c;
		// public readonly static av_noinline = __declspec(noinline);
		/// <summary>
		/// AV_NOPTS_VALUE = ((int64_t)UINT64_C(0x8000000000000000))
		/// </summary>
		public readonly static long AV_NOPTS_VALUE = unchecked((long)0x8000000000000000L);
		// public readonly static av_noreturn = __attribute__((noreturn));
		/// <summary>
		/// AV_NUM_DATA_POINTERS = 8
		/// </summary>
		public const int AV_NUM_DATA_POINTERS = 0x8;
		// public readonly static av_parity = av_parity_c;
		/// <summary>
		/// AV_PARSER_PTS_NB = 4
		/// </summary>
		public const int AV_PARSER_PTS_NB = 0x4;
		// public readonly static AV_PIX_FMT_0BGR32 = AV_PIX_FMT_NE(0BGR, RGB0);
		// public readonly static AV_PIX_FMT_0RGB32 = AV_PIX_FMT_NE(0RGB, BGR0);
		// public readonly static AV_PIX_FMT_AYUV64 = AV_PIX_FMT_NE(AYUV64BE, AYUV64LE);
		// public readonly static AV_PIX_FMT_BAYER_BGGR16 = AV_PIX_FMT_NE(BAYER_BGGR16BE,    BAYER_BGGR16LE);
		// public readonly static AV_PIX_FMT_BAYER_GBRG16 = AV_PIX_FMT_NE(BAYER_GBRG16BE,    BAYER_GBRG16LE);
		// public readonly static AV_PIX_FMT_BAYER_GRBG16 = AV_PIX_FMT_NE(BAYER_GRBG16BE,    BAYER_GRBG16LE);
		// public readonly static AV_PIX_FMT_BAYER_RGGB16 = AV_PIX_FMT_NE(BAYER_RGGB16BE,    BAYER_RGGB16LE);
		// public readonly static AV_PIX_FMT_BGR32 = AV_PIX_FMT_NE(ABGR, RGBA);
		// public readonly static AV_PIX_FMT_BGR32_1 = AV_PIX_FMT_NE(BGRA, ARGB);
		// public readonly static AV_PIX_FMT_BGR444 = AV_PIX_FMT_NE(BGR444BE, BGR444LE);
		// public readonly static AV_PIX_FMT_BGR48 = AV_PIX_FMT_NE(BGR48BE,  BGR48LE);
		// public readonly static AV_PIX_FMT_BGR555 = AV_PIX_FMT_NE(BGR555BE, BGR555LE);
		// public readonly static AV_PIX_FMT_BGR565 = AV_PIX_FMT_NE(BGR565BE, BGR565LE);
		// public readonly static AV_PIX_FMT_BGRA64 = AV_PIX_FMT_NE(BGRA64BE, BGRA64LE);
		// public readonly static AV_PIX_FMT_GBRAP10 = AV_PIX_FMT_NE(GBRAP10BE,   GBRAP10LE);
		// public readonly static AV_PIX_FMT_GBRAP12 = AV_PIX_FMT_NE(GBRAP12BE,   GBRAP12LE);
		// public readonly static AV_PIX_FMT_GBRAP16 = AV_PIX_FMT_NE(GBRAP16BE,   GBRAP16LE);
		// public readonly static AV_PIX_FMT_GBRAPF32 = AV_PIX_FMT_NE(GBRAPF32BE, GBRAPF32LE);
		// public readonly static AV_PIX_FMT_GBRP10 = AV_PIX_FMT_NE(GBRP10BE,    GBRP10LE);
		// public readonly static AV_PIX_FMT_GBRP12 = AV_PIX_FMT_NE(GBRP12BE,    GBRP12LE);
		// public readonly static AV_PIX_FMT_GBRP14 = AV_PIX_FMT_NE(GBRP14BE,    GBRP14LE);
		// public readonly static AV_PIX_FMT_GBRP16 = AV_PIX_FMT_NE(GBRP16BE,    GBRP16LE);
		// public readonly static AV_PIX_FMT_GBRP9 = AV_PIX_FMT_NE(GBRP9BE ,    GBRP9LE);
		// public readonly static AV_PIX_FMT_GBRPF32 = AV_PIX_FMT_NE(GBRPF32BE,  GBRPF32LE);
		// public readonly static AV_PIX_FMT_GRAY10 = AV_PIX_FMT_NE(GRAY10BE, GRAY10LE);
		// public readonly static AV_PIX_FMT_GRAY12 = AV_PIX_FMT_NE(GRAY12BE, GRAY12LE);
		// public readonly static AV_PIX_FMT_GRAY14 = AV_PIX_FMT_NE(GRAY14BE, GRAY14LE);
		// public readonly static AV_PIX_FMT_GRAY16 = AV_PIX_FMT_NE(GRAY16BE, GRAY16LE);
		// public readonly static AV_PIX_FMT_GRAY9 = AV_PIX_FMT_NE(GRAY9BE,  GRAY9LE);
		// public readonly static AV_PIX_FMT_GRAYF32 = AV_PIX_FMT_NE(GRAYF32BE, GRAYF32LE);
		// public readonly static AV_PIX_FMT_NV20 = AV_PIX_FMT_NE(NV20BE,  NV20LE);
		// public readonly static AV_PIX_FMT_P010 = AV_PIX_FMT_NE(P010BE,  P010LE);
		// public readonly static AV_PIX_FMT_P016 = AV_PIX_FMT_NE(P016BE,  P016LE);
		// public readonly static AV_PIX_FMT_RGB32 = AV_PIX_FMT_NE(ARGB, BGRA);
		// public readonly static AV_PIX_FMT_RGB32_1 = AV_PIX_FMT_NE(RGBA, ABGR);
		// public readonly static AV_PIX_FMT_RGB444 = AV_PIX_FMT_NE(RGB444BE, RGB444LE);
		// public readonly static AV_PIX_FMT_RGB48 = AV_PIX_FMT_NE(RGB48BE,  RGB48LE);
		// public readonly static AV_PIX_FMT_RGB555 = AV_PIX_FMT_NE(RGB555BE, RGB555LE);
		// public readonly static AV_PIX_FMT_RGB565 = AV_PIX_FMT_NE(RGB565BE, RGB565LE);
		// public readonly static AV_PIX_FMT_RGBA64 = AV_PIX_FMT_NE(RGBA64BE, RGBA64LE);
		// public readonly static AV_PIX_FMT_XYZ12 = AV_PIX_FMT_NE(XYZ12BE, XYZ12LE);
		// public readonly static AV_PIX_FMT_YA16 = AV_PIX_FMT_NE(YA16BE,   YA16LE);
		// public readonly static AV_PIX_FMT_YUV420P10 = AV_PIX_FMT_NE(YUV420P10BE, YUV420P10LE);
		// public readonly static AV_PIX_FMT_YUV420P12 = AV_PIX_FMT_NE(YUV420P12BE, YUV420P12LE);
		// public readonly static AV_PIX_FMT_YUV420P14 = AV_PIX_FMT_NE(YUV420P14BE, YUV420P14LE);
		// public readonly static AV_PIX_FMT_YUV420P16 = AV_PIX_FMT_NE(YUV420P16BE, YUV420P16LE);
		// public readonly static AV_PIX_FMT_YUV420P9 = AV_PIX_FMT_NE(YUV420P9BE , YUV420P9LE);
		// public readonly static AV_PIX_FMT_YUV422P10 = AV_PIX_FMT_NE(YUV422P10BE, YUV422P10LE);
		// public readonly static AV_PIX_FMT_YUV422P12 = AV_PIX_FMT_NE(YUV422P12BE, YUV422P12LE);
		// public readonly static AV_PIX_FMT_YUV422P14 = AV_PIX_FMT_NE(YUV422P14BE, YUV422P14LE);
		// public readonly static AV_PIX_FMT_YUV422P16 = AV_PIX_FMT_NE(YUV422P16BE, YUV422P16LE);
		// public readonly static AV_PIX_FMT_YUV422P9 = AV_PIX_FMT_NE(YUV422P9BE , YUV422P9LE);
		// public readonly static AV_PIX_FMT_YUV440P10 = AV_PIX_FMT_NE(YUV440P10BE, YUV440P10LE);
		// public readonly static AV_PIX_FMT_YUV440P12 = AV_PIX_FMT_NE(YUV440P12BE, YUV440P12LE);
		// public readonly static AV_PIX_FMT_YUV444P10 = AV_PIX_FMT_NE(YUV444P10BE, YUV444P10LE);
		// public readonly static AV_PIX_FMT_YUV444P12 = AV_PIX_FMT_NE(YUV444P12BE, YUV444P12LE);
		// public readonly static AV_PIX_FMT_YUV444P14 = AV_PIX_FMT_NE(YUV444P14BE, YUV444P14LE);
		// public readonly static AV_PIX_FMT_YUV444P16 = AV_PIX_FMT_NE(YUV444P16BE, YUV444P16LE);
		// public readonly static AV_PIX_FMT_YUV444P9 = AV_PIX_FMT_NE(YUV444P9BE , YUV444P9LE);
		// public readonly static AV_PIX_FMT_YUVA420P10 = AV_PIX_FMT_NE(YUVA420P10BE, YUVA420P10LE);
		// public readonly static AV_PIX_FMT_YUVA420P16 = AV_PIX_FMT_NE(YUVA420P16BE, YUVA420P16LE);
		// public readonly static AV_PIX_FMT_YUVA420P9 = AV_PIX_FMT_NE(YUVA420P9BE , YUVA420P9LE);
		// public readonly static AV_PIX_FMT_YUVA422P10 = AV_PIX_FMT_NE(YUVA422P10BE, YUVA422P10LE);
		// public readonly static AV_PIX_FMT_YUVA422P16 = AV_PIX_FMT_NE(YUVA422P16BE, YUVA422P16LE);
		// public readonly static AV_PIX_FMT_YUVA422P9 = AV_PIX_FMT_NE(YUVA422P9BE , YUVA422P9LE);
		// public readonly static AV_PIX_FMT_YUVA444P10 = AV_PIX_FMT_NE(YUVA444P10BE, YUVA444P10LE);
		// public readonly static AV_PIX_FMT_YUVA444P16 = AV_PIX_FMT_NE(YUVA444P16BE, YUVA444P16LE);
		// public readonly static AV_PIX_FMT_YUVA444P9 = AV_PIX_FMT_NE(YUVA444P9BE , YUVA444P9LE);
		// public readonly static AV_PKT_DATA_QUALITY_FACTOR = AV_PKT_DATA_QUALITY_STATS;
		// public readonly static av_popcount = av_popcount_c;
		// public readonly static av_popcount64 = av_popcount64_c;
		/// <summary>
		/// AV_PROGRAM_RUNNING = 1
		/// </summary>
		public const int AV_PROGRAM_RUNNING = 0x1;
		// public readonly static av_pure = __attribute__((pure));
		// public readonly static av_sat_add32 = av_sat_add32_c;
		// public readonly static av_sat_dadd32 = av_sat_dadd32_c;
		// public readonly static av_sat_dsub32 = av_sat_dsub32_c;
		// public readonly static av_sat_sub32 = av_sat_sub32_c;
		/// <summary>
		/// AV_SUBTITLE_FLAG_FORCED = 0x00000001
		/// </summary>
		public const int AV_SUBTITLE_FLAG_FORCED = 0x1;
		/// <summary>
		/// AV_TIME_BASE = 1000000
		/// </summary>
		public const int AV_TIME_BASE = 1000000;
		// public readonly static AV_TIME_BASE_Q = (AVRational){1, AV_TIME_BASE};
		/// <summary>
		/// AV_TIMECODE_STR_SIZE = 23
		/// </summary>
		public const int AV_TIMECODE_STR_SIZE = 0x17;
		// public readonly static av_unused = __attribute__((unused));
		// public readonly static av_used = __attribute__((used));
		/// <summary>
		/// AVFILTER_CMD_FLAG_FAST = 2
		/// </summary>
		public const int AVFILTER_CMD_FLAG_FAST = 2;
		/// <summary>
		/// AVFILTER_CMD_FLAG_ONE = 1
		/// </summary>
		public const int AVFILTER_CMD_FLAG_ONE = 1;
		/// <summary>
		/// AVFILTER_FLAG_DYNAMIC_INPUTS = (1 &lt;&lt; 0)
		/// </summary>
		public const int AVFILTER_FLAG_DYNAMIC_INPUTS = (1 << 0);
		/// <summary>
		/// AVFILTER_FLAG_DYNAMIC_OUTPUTS = (1 &lt;&lt; 1)
		/// </summary>
		public const int AVFILTER_FLAG_DYNAMIC_OUTPUTS = (1 << 1);
		/// <summary>
		/// AVFILTER_FLAG_SLICE_THREADS = (1 &lt;&lt; 2)
		/// </summary>
		public const int AVFILTER_FLAG_SLICE_THREADS = (1 << 2);
		/// <summary>
		/// AVFILTER_FLAG_SUPPORT_TIMELINE = (AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC | AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL)
		/// </summary>
		public const int AVFILTER_FLAG_SUPPORT_TIMELINE = (AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC | AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL);
		/// <summary>
		/// AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC = (1 &lt;&lt; 16)
		/// </summary>
		public const int AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC = (1 << 16);
		/// <summary>
		/// AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL = (1 &lt;&lt; 17)
		/// </summary>
		public const int AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL = (1 << 17);
		/// <summary>
		/// AVFILTER_THREAD_SLICE = (1 &lt;&lt; 0)
		/// </summary>
		public const int AVFILTER_THREAD_SLICE = (1 << 0);
		/// <summary>
		/// AVSTREAM_EVENT_FLAG_METADATA_UPDATED = 0x0001
		/// </summary>
		public const int AVSTREAM_EVENT_FLAG_METADATA_UPDATED = 0x0001;
		/// <summary>
		/// AVSTREAM_INIT_IN_INIT_OUTPUT = 1
		/// </summary>
		public const int AVSTREAM_INIT_IN_INIT_OUTPUT = 1;
		/// <summary>
		/// AVSTREAM_INIT_IN_WRITE_HEADER = 0
		/// </summary>
		public const int AVSTREAM_INIT_IN_WRITE_HEADER = 0;
		/// <summary>
		/// FF_API_ASS_TIMING = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_ASS_TIMING = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_AVCTX_TIMEBASE = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_AVCTX_TIMEBASE = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_AVPACKET_OLD_API = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_AVPACKET_OLD_API = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_AVPICTURE = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_AVPICTURE = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_CODEC_GET_SET = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_CODEC_GET_SET = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_CODED_FRAME = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_CODED_FRAME = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_CODER_TYPE = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_CODER_TYPE = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_COMPUTE_PKT_FIELDS2 = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_COMPUTE_PKT_FIELDS2 = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_CONVERGENCE_DURATION = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_CONVERGENCE_DURATION = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_COPY_CONTEXT = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_COPY_CONTEXT = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_CRYPTO_SIZE_T = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_CRYPTO_SIZE_T = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_DASH_MIN_SEG_DURATION = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_DASH_MIN_SEG_DURATION = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_DEBUG_MV = (LIBAVCODEC_VERSION_MAJOR &lt; 58)
		/// </summary>
		public const bool FF_API_DEBUG_MV = (LIBAVCODEC_VERSION_MAJOR < 58);
		/// <summary>
		/// FF_API_ERROR_FRAME = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_ERROR_FRAME = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_FILTER_GET_SET = (LIBAVFILTER_VERSION_MAJOR &lt; 8)
		/// </summary>
		public const bool FF_API_FILTER_GET_SET = (LIBAVFILTER_VERSION_MAJOR < 8);
		/// <summary>
		/// FF_API_FORMAT_FILENAME = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_FORMAT_FILENAME = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_FORMAT_GET_SET = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_FORMAT_GET_SET = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_FRAME_GET_SET = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_FRAME_GET_SET = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_FRAME_QP = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_FRAME_QP = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_GET_CONTEXT_DEFAULTS = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_GET_CONTEXT_DEFAULTS = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_GETCHROMA = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_GETCHROMA = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_HLS_USE_LOCALTIME = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_HLS_USE_LOCALTIME = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_HLS_WRAP = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_HLS_WRAP = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_HTTP_USER_AGENT = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_HTTP_USER_AGENT = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LAVF_AVCTX = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LAVF_AVCTX = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LAVF_FFSERVER = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LAVF_FFSERVER = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LAVF_KEEPSIDE_FLAG = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LAVF_KEEPSIDE_FLAG = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LAVF_MP4A_LATM = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LAVF_MP4A_LATM = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LAVR_OPTS = (LIBAVFILTER_VERSION_MAJOR &lt; 8)
		/// </summary>
		public const bool FF_API_LAVR_OPTS = (LIBAVFILTER_VERSION_MAJOR < 8);
		/// <summary>
		/// FF_API_LOCKMGR = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LOCKMGR = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_LOWRES = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_LOWRES = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_MERGE_SD_API = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_MERGE_SD_API = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_NEXT = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_NEXT = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_NVENC_OLD_NAME = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_NVENC_OLD_NAME = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_OLD_AVIO_EOF_0 = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_OLD_AVIO_EOF_0 = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_OLD_BSF = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_OLD_BSF = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_OLD_FILTER_OPTS_ERROR = (LIBAVFILTER_VERSION_MAJOR &lt; 8)
		/// </summary>
		public const bool FF_API_OLD_FILTER_OPTS_ERROR = (LIBAVFILTER_VERSION_MAJOR < 8);
		/// <summary>
		/// FF_API_OLD_OPEN_CALLBACKS = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_OLD_OPEN_CALLBACKS = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_OLD_ROTATE_API = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_OLD_ROTATE_API = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_OLD_RTSP_OPTIONS = (LIBAVFORMAT_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_OLD_RTSP_OPTIONS = (LIBAVFORMAT_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_PKT_PTS = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_PKT_PTS = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_PLUS1_MINUS1 = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_PLUS1_MINUS1 = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_PRIVATE_OPT = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_PRIVATE_OPT = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_PSEUDOPAL = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_PSEUDOPAL = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_R_FRAME_RATE = 1
		/// </summary>
		public const int FF_API_R_FRAME_RATE = 1;
		/// <summary>
		/// FF_API_RTP_CALLBACK = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_RTP_CALLBACK = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_SIDEDATA_ONLY_PKT = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_SIDEDATA_ONLY_PKT = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_STAT_BITS = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_STAT_BITS = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_STRUCT_VAAPI_CONTEXT = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_STRUCT_VAAPI_CONTEXT = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_SWS_VECTOR = (LIBSWSCALE_VERSION_MAJOR &lt; 6)
		/// </summary>
		public const bool FF_API_SWS_VECTOR = LIBSWSCALE_VERSION_MAJOR < 0x6;
		/// <summary>
		/// FF_API_TAG_STRING = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_TAG_STRING = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_USER_VISIBLE_AVHWACCEL = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_USER_VISIBLE_AVHWACCEL = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_VAAPI = (LIBAVUTIL_VERSION_MAJOR &lt; 57)
		/// </summary>
		public const bool FF_API_VAAPI = (LIBAVUTIL_VERSION_MAJOR < 57);
		/// <summary>
		/// FF_API_VBV_DELAY = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_VBV_DELAY = (LIBAVCODEC_VERSION_MAJOR < 59);
		/// <summary>
		/// FF_API_VDPAU_PROFILE = (LIBAVCODEC_VERSION_MAJOR &lt; 59)
		/// </summary>
		public const bool FF_API_VDPAU_PROFILE = (LIBAVCODEC_VERSION_MAJOR < 59);
		// public readonly static FF_CEIL_RSHIFT = AV_CEIL_RSHIFT;
		/// <summary>
		/// FF_COMPRESSION_DEFAULT = -1
		/// </summary>
		public const int FF_COMPRESSION_DEFAULT = -0x1;
		/// <summary>
		/// FF_FDEBUG_TS = 0x0001
		/// </summary>
		public const int FF_FDEBUG_TS = 0x1;
		/// <summary>
		/// FF_LAMBDA_MAX = (256*128-1)
		/// </summary>
		public const int FF_LAMBDA_MAX = (256 * 128 - 1);
		/// <summary>
		/// FF_LAMBDA_SCALE = (1&lt;&lt;FF_LAMBDA_SHIFT)
		/// </summary>
		public const int FF_LAMBDA_SCALE = (1 << FF_LAMBDA_SHIFT);
		/// <summary>
		/// FF_LAMBDA_SHIFT = 7
		/// </summary>
		public const int FF_LAMBDA_SHIFT = 7;
		/// <summary>
		/// FF_LEVEL_UNKNOWN = -99
		/// </summary>
		public const int FF_LEVEL_UNKNOWN = -0x63;
		/// <summary>
		/// FF_QP2LAMBDA = 118
		/// </summary>
		public const int FF_QP2LAMBDA = 0x76;
		/// <summary>
		/// FF_QUALITY_SCALE = FF_LAMBDA_SCALE
		/// </summary>
		public const int FF_QUALITY_SCALE = FF_LAMBDA_SCALE;
		/// <summary>
		/// LIBAVCODEC_BUILD = LIBAVCODEC_VERSION_INT
		/// </summary>
		public readonly static int LIBAVCODEC_BUILD = LIBAVCODEC_VERSION_INT;
		/// <summary>
		/// LIBAVCODEC_IDENT = &quot;Lavc&quot; AV_STRINGIFY(LIBAVCODEC_VERSION)
		/// </summary>
		public const string LIBAVCODEC_IDENT = "Lavc";
		/// <summary>
		/// LIBAVCODEC_VERSION = AV_VERSION(LIBAVCODEC_VERSION_MAJOR,    \
		///                                            LIBAVCODEC_VERSION_MINOR,    \
		///                                            LIBAVCODEC_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBAVCODEC_VERSION = $"{LIBAVCODEC_VERSION_MAJOR}.{LIBAVCODEC_VERSION_MINOR}.{LIBAVCODEC_VERSION_MICRO}";
		/// <summary>
		/// LIBAVCODEC_VERSION_INT = AV_VERSION_INT(LIBAVCODEC_VERSION_MAJOR, \
		///                                                LIBAVCODEC_VERSION_MINOR, \
		///                                                LIBAVCODEC_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBAVCODEC_VERSION_INT = ((LIBAVCODEC_VERSION_MAJOR << 16) | (LIBAVCODEC_VERSION_MINOR << 8) | LIBAVCODEC_VERSION_MICRO);
		/// <summary>
		/// LIBAVCODEC_VERSION_MAJOR = 58
		/// </summary>
		public const int LIBAVCODEC_VERSION_MAJOR = 0x3a;
		/// <summary>
		/// LIBAVCODEC_VERSION_MICRO = 100
		/// </summary>
		public const int LIBAVCODEC_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBAVCODEC_VERSION_MINOR = 35
		/// </summary>
		public const int LIBAVCODEC_VERSION_MINOR = 0x23;
		/// <summary>
		/// LIBAVDEVICE_BUILD = LIBAVDEVICE_VERSION_INT
		/// </summary>
		public readonly static int LIBAVDEVICE_BUILD = LIBAVDEVICE_VERSION_INT;
		/// <summary>
		/// LIBAVDEVICE_IDENT = &quot;Lavd&quot; AV_STRINGIFY(LIBAVDEVICE_VERSION)
		/// </summary>
		public const string LIBAVDEVICE_IDENT = "Lavd";
		/// <summary>
		/// LIBAVDEVICE_VERSION = AV_VERSION(LIBAVDEVICE_VERSION_MAJOR, \
		///                                            LIBAVDEVICE_VERSION_MINOR, \
		///                                            LIBAVDEVICE_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBAVDEVICE_VERSION = $"{LIBAVDEVICE_VERSION_MAJOR}.{LIBAVDEVICE_VERSION_MINOR}.{LIBAVDEVICE_VERSION_MICRO}";
		/// <summary>
		/// LIBAVDEVICE_VERSION_INT = AV_VERSION_INT(LIBAVDEVICE_VERSION_MAJOR, \
		///                                                LIBAVDEVICE_VERSION_MINOR, \
		///                                                LIBAVDEVICE_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBAVDEVICE_VERSION_INT = ((LIBAVDEVICE_VERSION_MAJOR << 16) | (LIBAVDEVICE_VERSION_MINOR << 8) | LIBAVDEVICE_VERSION_MICRO);
		/// <summary>
		/// LIBAVDEVICE_VERSION_MAJOR = 58
		/// </summary>
		public const int LIBAVDEVICE_VERSION_MAJOR = 0x3a;
		/// <summary>
		/// LIBAVDEVICE_VERSION_MICRO = 100
		/// </summary>
		public const int LIBAVDEVICE_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBAVDEVICE_VERSION_MINOR = 5
		/// </summary>
		public const int LIBAVDEVICE_VERSION_MINOR = 0x5;
		/// <summary>
		/// LIBAVFILTER_BUILD = LIBAVFILTER_VERSION_INT
		/// </summary>
		public readonly static int LIBAVFILTER_BUILD = LIBAVFILTER_VERSION_INT;
		/// <summary>
		/// LIBAVFILTER_IDENT = &quot;Lavfi&quot; AV_STRINGIFY(LIBAVFILTER_VERSION)
		/// </summary>
		public const string LIBAVFILTER_IDENT = "Lavfi";
		/// <summary>
		/// LIBAVFILTER_VERSION = AV_VERSION(LIBAVFILTER_VERSION_MAJOR,   \
		///                                            LIBAVFILTER_VERSION_MINOR,   \
		///                                            LIBAVFILTER_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBAVFILTER_VERSION = $"{LIBAVFILTER_VERSION_MAJOR}.{LIBAVFILTER_VERSION_MINOR}.{LIBAVFILTER_VERSION_MICRO}";
		/// <summary>
		/// LIBAVFILTER_VERSION_INT = AV_VERSION_INT(LIBAVFILTER_VERSION_MAJOR, \
		///                                                LIBAVFILTER_VERSION_MINOR, \
		///                                                LIBAVFILTER_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBAVFILTER_VERSION_INT = ((LIBAVFILTER_VERSION_MAJOR << 16) | (LIBAVFILTER_VERSION_MINOR << 8) | LIBAVFILTER_VERSION_MICRO);
		/// <summary>
		/// LIBAVFILTER_VERSION_MAJOR = 7
		/// </summary>
		public const int LIBAVFILTER_VERSION_MAJOR = 0x7;
		/// <summary>
		/// LIBAVFILTER_VERSION_MICRO = 101
		/// </summary>
		public const int LIBAVFILTER_VERSION_MICRO = 0x65;
		/// <summary>
		/// LIBAVFILTER_VERSION_MINOR = 40
		/// </summary>
		public const int LIBAVFILTER_VERSION_MINOR = 0x28;
		/// <summary>
		/// LIBAVFORMAT_BUILD = LIBAVFORMAT_VERSION_INT
		/// </summary>
		public readonly static int LIBAVFORMAT_BUILD = LIBAVFORMAT_VERSION_INT;
		/// <summary>
		/// LIBAVFORMAT_IDENT = &quot;Lavf&quot; AV_STRINGIFY(LIBAVFORMAT_VERSION)
		/// </summary>
		public const string LIBAVFORMAT_IDENT = "Lavf";
		/// <summary>
		/// LIBAVFORMAT_VERSION = AV_VERSION(LIBAVFORMAT_VERSION_MAJOR,   \
		///                                            LIBAVFORMAT_VERSION_MINOR,   \
		///                                            LIBAVFORMAT_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBAVFORMAT_VERSION = $"{LIBAVFORMAT_VERSION_MAJOR}.{LIBAVFORMAT_VERSION_MINOR}.{LIBAVFORMAT_VERSION_MICRO}";
		/// <summary>
		/// LIBAVFORMAT_VERSION_INT = AV_VERSION_INT(LIBAVFORMAT_VERSION_MAJOR, \
		///                                                LIBAVFORMAT_VERSION_MINOR, \
		///                                                LIBAVFORMAT_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBAVFORMAT_VERSION_INT = ((LIBAVFORMAT_VERSION_MAJOR << 16) | (LIBAVFORMAT_VERSION_MINOR << 8) | LIBAVFORMAT_VERSION_MICRO);
		/// <summary>
		/// LIBAVFORMAT_VERSION_MAJOR = 58
		/// </summary>
		public const int LIBAVFORMAT_VERSION_MAJOR = 0x3a;
		/// <summary>
		/// LIBAVFORMAT_VERSION_MICRO = 100
		/// </summary>
		public const int LIBAVFORMAT_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBAVFORMAT_VERSION_MINOR = 20
		/// </summary>
		public const int LIBAVFORMAT_VERSION_MINOR = 0x14;
		/// <summary>
		/// LIBAVUTIL_BUILD = LIBAVUTIL_VERSION_INT
		/// </summary>
		public readonly static int LIBAVUTIL_BUILD = LIBAVUTIL_VERSION_INT;
		/// <summary>
		/// LIBAVUTIL_IDENT = &quot;Lavu&quot; AV_STRINGIFY(LIBAVUTIL_VERSION)
		/// </summary>
		public const string LIBAVUTIL_IDENT = "Lavu";
		/// <summary>
		/// LIBAVUTIL_VERSION = AV_VERSION(LIBAVUTIL_VERSION_MAJOR,     \
		///                                            LIBAVUTIL_VERSION_MINOR,     \
		///                                            LIBAVUTIL_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBAVUTIL_VERSION = $"{LIBAVUTIL_VERSION_MAJOR}.{LIBAVUTIL_VERSION_MINOR}.{LIBAVUTIL_VERSION_MICRO}";
		/// <summary>
		/// LIBAVUTIL_VERSION_INT = AV_VERSION_INT(LIBAVUTIL_VERSION_MAJOR, \
		///                                                LIBAVUTIL_VERSION_MINOR, \
		///                                                LIBAVUTIL_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBAVUTIL_VERSION_INT = ((LIBAVUTIL_VERSION_MAJOR << 16) | (LIBAVUTIL_VERSION_MINOR << 8) | LIBAVUTIL_VERSION_MICRO);
		/// <summary>
		/// LIBAVUTIL_VERSION_MAJOR = 56
		/// </summary>
		public const int LIBAVUTIL_VERSION_MAJOR = 0x38;
		/// <summary>
		/// LIBAVUTIL_VERSION_MICRO = 100
		/// </summary>
		public const int LIBAVUTIL_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBAVUTIL_VERSION_MINOR = 22
		/// </summary>
		public const int LIBAVUTIL_VERSION_MINOR = 0x16;
		/// <summary>
		/// LIBPOSTPROC_BUILD = LIBPOSTPROC_VERSION_INT
		/// </summary>
		public readonly static int LIBPOSTPROC_BUILD = LIBPOSTPROC_VERSION_INT;
		/// <summary>
		/// LIBPOSTPROC_IDENT = &quot;postproc&quot; AV_STRINGIFY(LIBPOSTPROC_VERSION)
		/// </summary>
		public const string LIBPOSTPROC_IDENT = "postproc";
		/// <summary>
		/// LIBPOSTPROC_VERSION = AV_VERSION(LIBPOSTPROC_VERSION_MAJOR, \
		///                                            LIBPOSTPROC_VERSION_MINOR, \
		///                                            LIBPOSTPROC_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBPOSTPROC_VERSION = $"{LIBPOSTPROC_VERSION_MAJOR}.{LIBPOSTPROC_VERSION_MINOR}.{LIBPOSTPROC_VERSION_MICRO}";
		/// <summary>
		/// LIBPOSTPROC_VERSION_INT = AV_VERSION_INT(LIBPOSTPROC_VERSION_MAJOR, \
		///                                                LIBPOSTPROC_VERSION_MINOR, \
		///                                                LIBPOSTPROC_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBPOSTPROC_VERSION_INT = ((LIBPOSTPROC_VERSION_MAJOR << 16) | (LIBPOSTPROC_VERSION_MINOR << 8) | LIBPOSTPROC_VERSION_MICRO);
		/// <summary>
		/// LIBPOSTPROC_VERSION_MAJOR = 55
		/// </summary>
		public const int LIBPOSTPROC_VERSION_MAJOR = 0x37;
		/// <summary>
		/// LIBPOSTPROC_VERSION_MICRO = 100
		/// </summary>
		public const int LIBPOSTPROC_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBPOSTPROC_VERSION_MINOR = 3
		/// </summary>
		public const int LIBPOSTPROC_VERSION_MINOR = 0x3;
		/// <summary>
		/// LIBSWRESAMPLE_BUILD = LIBSWRESAMPLE_VERSION_INT
		/// </summary>
		public readonly static int LIBSWRESAMPLE_BUILD = LIBSWRESAMPLE_VERSION_INT;
		/// <summary>
		/// LIBSWRESAMPLE_IDENT = &quot;SwR&quot; AV_STRINGIFY(LIBSWRESAMPLE_VERSION)
		/// </summary>
		public const string LIBSWRESAMPLE_IDENT = "SwR";
		/// <summary>
		/// LIBSWRESAMPLE_VERSION = AV_VERSION(LIBSWRESAMPLE_VERSION_MAJOR, \
		///                                               LIBSWRESAMPLE_VERSION_MINOR, \
		///                                               LIBSWRESAMPLE_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBSWRESAMPLE_VERSION = $"{LIBSWRESAMPLE_VERSION_MAJOR}.{LIBSWRESAMPLE_VERSION_MINOR}.{LIBSWRESAMPLE_VERSION_MICRO}";
		/// <summary>
		/// LIBSWRESAMPLE_VERSION_INT = AV_VERSION_INT(LIBSWRESAMPLE_VERSION_MAJOR, \
		///                                                   LIBSWRESAMPLE_VERSION_MINOR, \
		///                                                   LIBSWRESAMPLE_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBSWRESAMPLE_VERSION_INT = ((LIBSWRESAMPLE_VERSION_MAJOR << 16) | (LIBSWRESAMPLE_VERSION_MINOR << 8) | LIBSWRESAMPLE_VERSION_MICRO);
		/// <summary>
		/// LIBSWRESAMPLE_VERSION_MAJOR = 3
		/// </summary>
		public const int LIBSWRESAMPLE_VERSION_MAJOR = 0x3;
		/// <summary>
		/// LIBSWRESAMPLE_VERSION_MICRO = 100
		/// </summary>
		public const int LIBSWRESAMPLE_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBSWRESAMPLE_VERSION_MINOR = 3
		/// </summary>
		public const int LIBSWRESAMPLE_VERSION_MINOR = 0x3;
		/// <summary>
		/// LIBSWSCALE_BUILD = LIBSWSCALE_VERSION_INT
		/// </summary>
		public readonly static int LIBSWSCALE_BUILD = LIBSWSCALE_VERSION_INT;
		/// <summary>
		/// LIBSWSCALE_IDENT = &quot;SwS&quot; AV_STRINGIFY(LIBSWSCALE_VERSION)
		/// </summary>
		public const string LIBSWSCALE_IDENT = "SwS";
		/// <summary>
		/// LIBSWSCALE_VERSION = AV_VERSION(LIBSWSCALE_VERSION_MAJOR, \
		///                                            LIBSWSCALE_VERSION_MINOR, \
		///                                            LIBSWSCALE_VERSION_MICRO)
		/// </summary>
		public readonly static string LIBSWSCALE_VERSION = $"{LIBSWSCALE_VERSION_MAJOR}.{LIBSWSCALE_VERSION_MINOR}.{LIBSWSCALE_VERSION_MICRO}";
		/// <summary>
		/// LIBSWSCALE_VERSION_INT = AV_VERSION_INT(LIBSWSCALE_VERSION_MAJOR, \
		///                                                LIBSWSCALE_VERSION_MINOR, \
		///                                                LIBSWSCALE_VERSION_MICRO)
		/// </summary>
		public readonly static int LIBSWSCALE_VERSION_INT = ((LIBSWSCALE_VERSION_MAJOR << 16) | (LIBSWSCALE_VERSION_MINOR << 8) | LIBSWSCALE_VERSION_MICRO);
		/// <summary>
		/// LIBSWSCALE_VERSION_MAJOR = 5
		/// </summary>
		public const int LIBSWSCALE_VERSION_MAJOR = 0x5;
		/// <summary>
		/// LIBSWSCALE_VERSION_MICRO = 100
		/// </summary>
		public const int LIBSWSCALE_VERSION_MICRO = 0x64;
		/// <summary>
		/// LIBSWSCALE_VERSION_MINOR = 3
		/// </summary>
		public const int LIBSWSCALE_VERSION_MINOR = 0x3;
		/// <summary>
		/// M_E = 2.7182818284590452354
		/// </summary>
		public const double M_E = 2.71828182845905D;
		/// <summary>
		/// M_LN10 = 2.30258509299404568402
		/// </summary>
		public const double M_LN10 = 2.30258509299405D;
		/// <summary>
		/// M_LN2 = 0.69314718055994530942
		/// </summary>
		public const double M_LN2 = 0.693147180559945D;
		/// <summary>
		/// M_LOG2_10 = 3.32192809488736234787
		/// </summary>
		public const double M_LOG2_10 = 3.32192809488736D;
		/// <summary>
		/// M_PHI = 1.61803398874989484820
		/// </summary>
		public const double M_PHI = 1.61803398874989D;
		/// <summary>
		/// M_PI = 3.14159265358979323846
		/// </summary>
		public const double M_PI = 3.14159265358979D;
		/// <summary>
		/// M_PI_2 = 1.57079632679489661923
		/// </summary>
		public const double M_PI_2 = 1.5707963267949D;
		/// <summary>
		/// M_SQRT1_2 = 0.70710678118654752440
		/// </summary>
		public const double M_SQRT1_2 = 0.707106781186548D;
		/// <summary>
		/// M_SQRT2 = 1.41421356237309504880
		/// </summary>
		public const double M_SQRT2 = 1.4142135623731D;
		/// <summary>
		/// PP_CPU_CAPS_3DNOW = 0x40000000
		/// </summary>
		public const int PP_CPU_CAPS_3DNOW = 0x40000000;
		/// <summary>
		/// PP_CPU_CAPS_ALTIVEC = 0x10000000
		/// </summary>
		public const int PP_CPU_CAPS_ALTIVEC = 0x10000000;
		/// <summary>
		/// PP_CPU_CAPS_AUTO = 0x00080000
		/// </summary>
		public const int PP_CPU_CAPS_AUTO = 0x80000;
		/// <summary>
		/// PP_CPU_CAPS_MMX = 0x80000000
		/// </summary>
		public const uint PP_CPU_CAPS_MMX = 0x80000000U;
		/// <summary>
		/// PP_CPU_CAPS_MMX2 = 0x20000000
		/// </summary>
		public const int PP_CPU_CAPS_MMX2 = 0x20000000;
		/// <summary>
		/// PP_FORMAT = 0x00000008
		/// </summary>
		public const int PP_FORMAT = 0x8;
		/// <summary>
		/// PP_FORMAT_411 = (0x00000002|PP_FORMAT)
		/// </summary>
		public const int PP_FORMAT_411 = 0x2 | PP_FORMAT;
		/// <summary>
		/// PP_FORMAT_420 = (0x00000011|PP_FORMAT)
		/// </summary>
		public const int PP_FORMAT_420 = 0x11 | PP_FORMAT;
		/// <summary>
		/// PP_FORMAT_422 = (0x00000001|PP_FORMAT)
		/// </summary>
		public const int PP_FORMAT_422 = 0x1 | PP_FORMAT;
		/// <summary>
		/// PP_FORMAT_440 = (0x00000010|PP_FORMAT)
		/// </summary>
		public const int PP_FORMAT_440 = 0x10 | PP_FORMAT;
		/// <summary>
		/// PP_FORMAT_444 = (0x00000000|PP_FORMAT)
		/// </summary>
		public const int PP_FORMAT_444 = 0x0 | PP_FORMAT;
		/// <summary>
		/// PP_PICT_TYPE_QP2 = 0x00000010
		/// </summary>
		public const int PP_PICT_TYPE_QP2 = 0x10;
		/// <summary>
		/// PP_QUALITY_MAX = 6
		/// </summary>
		public const int PP_QUALITY_MAX = 0x6;
		/// <summary>
		/// SWR_FLAG_RESAMPLE = 1
		/// </summary>
		public const int SWR_FLAG_RESAMPLE = 0x1;
	}
#pragma warning restore IDE1006 // 命名样式
}
