using Saar.FFmpeg.Enumerates;
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
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint av_int_list_length_for_size(uint elsize, void* list, ulong term);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_fopen_utf8(byte* path, byte* mode);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVRational av_get_time_base_q();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint swscale_version();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* swscale_configuration();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* swscale_license();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int* sws_getCoefficients(int colorspace);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_isSupportedInput(AVPixelFormat pix_fmt);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_isSupportedOutput(AVPixelFormat pix_fmt);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_isSupportedEndiannessConversion(AVPixelFormat pix_fmt);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsContext* sws_alloc_context();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_init_context(SwsContext* sws_context, SwsFilter* srcFilter, SwsFilter* dstFilter);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_freeContext(SwsContext* swsContext);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsContext* sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, SwsFlags flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_scale(SwsContext* c, byte** srcSlice, int* srcStride, int srcSliceY, int srcSliceH, byte** dst, int* dstStride);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_setColorspaceDetails(SwsContext* c, int inv_table, int srcRange, int table, int dstRange, int brightness, int contrast, int saturation);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int sws_getColorspaceDetails(SwsContext* c, int** inv_table, int* srcRange, int** table, int* dstRange, int* brightness, int* contrast, int* saturation);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsVector* sws_allocVec(int length);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsVector* sws_getGaussianVec(double variance, double quality);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_scaleVec(SwsVector* a, double scalar);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_normalizeVec(SwsVector* a, double height);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsVector* sws_getConstVec(double c, int length);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsVector* sws_getIdentityVec();
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_convVec(SwsVector* a, SwsVector* b);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_addVec(SwsVector* a, SwsVector* b);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_subVec(SwsVector* a, SwsVector* b);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_shiftVec(SwsVector* a, int shift);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsVector* sws_cloneVec(SwsVector* a);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_printVec2(SwsVector* a, AVClass* log_ctx, int log_level);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_freeVec(SwsVector* a);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsFilter* sws_getDefaultFilter(float lumaGBlur, float chromaGBlur, float lumaSharpen, float chromaSharpen, float chromaHShift, float chromaVShift, int verbose);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_freeFilter(SwsFilter* filter);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern SwsContext* sws_getCachedContext(SwsContext* context, int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_convertPalette8ToPacked32(byte* src, byte* dst, int num_pixels, byte* palette);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void sws_convertPalette8ToPacked24(byte* src, byte* dst, int num_pixels, byte* palette);
		[DllImport(Dll_Swscale, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* sws_get_class();
	}
}
