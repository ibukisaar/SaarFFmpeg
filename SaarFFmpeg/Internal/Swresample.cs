using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Saar.FFmpeg.Internal {
	unsafe public static partial class FFmpeg {
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern AVClass* swr_get_class();
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern SwrContext* swr_alloc();
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_init(SwrContext* s);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_is_initialized(SwrContext* s);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern SwrContext* swr_alloc_set_opts(SwrContext* s, AVChannelLayout out_ch_layout, AVSampleFormat out_sample_fmt, int out_sample_rate, AVChannelLayout in_ch_layout, AVSampleFormat in_sample_fmt, int in_sample_rate, int log_offset, void* log_ctx);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern void swr_free(ref SwrContext* s);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern void swr_close(SwrContext* s);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_convert(SwrContext* s, byte** @out, int out_count, byte** @in, int in_count);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern long swr_next_pts(SwrContext* s, long pts);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_set_compensation(SwrContext* s, int sample_delta, int compensation_distance);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_set_channel_mapping(SwrContext* s, int* channel_map);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_set_matrix(SwrContext* s, double* matrix, int stride);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_drop_output(SwrContext* s, int count);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_inject_silence(SwrContext* s, int count);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern long swr_get_delay(SwrContext* s, long @base);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_get_out_samples(SwrContext* s, int in_samples);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern uint swresample_version();
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern byte* swresample_configuration();
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern byte* swresample_license();
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_convert_frame(SwrContext* swr, AVFrame* output, AVFrame* input);
		[DllImport(Dll_Swresample, CallingConvention = Convention)]
		public static extern int swr_config_frame(SwrContext* swr, AVFrame* @out, AVFrame* @in);
	}
}
