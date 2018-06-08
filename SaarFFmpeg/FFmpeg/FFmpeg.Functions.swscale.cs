using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;

namespace Saar.FFmpeg.Internal {
#pragma warning disable IDE1006 // 命名样式
	public unsafe static partial class FFmpeg {
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_addVec(SwsVector* a, SwsVector* b);

		/// <summary>
		/// Allocate an empty SwsContext. This must be filled and passed to sws_init_context(). For filling see AVOptions, options.c and sws_setColorspaceDetails().
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsContext* sws_alloc_context();

		/// <summary>
		/// Allocate and return an uninitialized vector with length coefficients.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsVector* sws_allocVec(int length);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsVector* sws_cloneVec(SwsVector* a);

		/// <summary>
		/// Convert an 8-bit paletted frame into a frame with a color depth of 24 bits.
		/// </summary>
		/// <param name="src">source frame buffer</param>
		/// <param name="dst">destination frame buffer</param>
		/// <param name="num_pixels">number of pixels to convert</param>
		/// <param name="palette">array with [256] entries, which must match color arrangement (RGB or BGR) of src</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_convertPalette8ToPacked24(byte* src, byte* dst, int num_pixels, byte* palette);

		/// <summary>
		/// Convert an 8-bit paletted frame into a frame with a color depth of 32 bits.
		/// </summary>
		/// <param name="src">source frame buffer</param>
		/// <param name="dst">destination frame buffer</param>
		/// <param name="num_pixels">number of pixels to convert</param>
		/// <param name="palette">array with [256] entries, which must match color arrangement (RGB or BGR) of src</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_convertPalette8ToPacked32(byte* src, byte* dst, int num_pixels, byte* palette);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_convVec(SwsVector* a, SwsVector* b);

		/// <summary>
		/// Free the swscaler context swsContext. If swsContext is NULL, then does nothing.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_freeContext(SwsContext* swsContext);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_freeFilter(SwsFilter* filter);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_freeVec(SwsVector* a);

		/// <summary>
		/// Get the AVClass for swsContext. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static AVClass* sws_get_class();

		/// <summary>
		/// Check if context can be reused, otherwise reallocate a new one.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsContext* sws_getCachedContext(SwsContext* context, int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param);

		/// <summary>
		/// Return a pointer to yuv&lt;-&gt;rgb coefficients for the given colorspace suitable for sws_setColorspaceDetails().
		/// </summary>
		/// <param name="colorspace">One of the SWS_CS_* macros. If invalid, SWS_CS_DEFAULT is used.</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int* sws_getCoefficients(int colorspace);

		/// <summary>
		/// Returns -1 if not supported
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_getColorspaceDetails(SwsContext* c, int** inv_table, int* srcRange, int** table, int* dstRange, int* brightness, int* contrast, int* saturation);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsVector* sws_getConstVec(double c, int length);

		/// <summary>
		/// Allocate and return an SwsContext. You need it to perform scaling/conversion operations using sws_scale().
		/// </summary>
		/// <param name="srcW">the width of the source image</param>
		/// <param name="srcH">the height of the source image</param>
		/// <param name="srcFormat">the source image format</param>
		/// <param name="dstW">the width of the destination image</param>
		/// <param name="dstH">the height of the destination image</param>
		/// <param name="dstFormat">the destination image format</param>
		/// <param name="flags">specify which algorithm and options to use for rescaling</param>
		/// <param name="param">extra parameters to tune the used scaler For SWS_BICUBIC param[0] and [1] tune the shape of the basis function, param[0] tunes f(1) and param[1] f´(1) For SWS_GAUSS param[0] tunes the exponent and thus cutoff frequency For SWS_LANCZOS param[0] tunes the width of the window function</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsContext* sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, SwsFlags flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsFilter* sws_getDefaultFilter(float lumaGBlur, float chromaGBlur, float lumaSharpen, float chromaSharpen, float chromaHShift, float chromaVShift, int verbose);

		/// <summary>
		/// Return a normalized Gaussian curve used to filter stuff quality = 3 is high quality, lower is lower quality.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsVector* sws_getGaussianVec(double variance, double quality);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static SwsVector* sws_getIdentityVec();

		/// <summary>
		/// Initialize the swscaler context sws_context.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_init_context(SwsContext* sws_context, SwsFilter* srcFilter, SwsFilter* dstFilter);

		/// <summary>
		/// Returns a positive value if an endianness conversion for pix_fmt is supported, 0 otherwise.
		/// </summary>
		/// <param name="pix_fmt">the pixel format</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_isSupportedEndiannessConversion(AVPixelFormat pix_fmt);

		/// <summary>
		/// Return a positive value if pix_fmt is a supported input format, 0 otherwise.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_isSupportedInput(AVPixelFormat pix_fmt);

		/// <summary>
		/// Return a positive value if pix_fmt is a supported output format, 0 otherwise.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_isSupportedOutput(AVPixelFormat pix_fmt);

		/// <summary>
		/// Scale all the coefficients of a so that their sum equals height.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_normalizeVec(SwsVector* a, double height);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_printVec2(SwsVector* a, AVClass* log_ctx, int log_level);

		/// <summary>
		/// Scale the image slice in srcSlice and put the resulting scaled slice in the image in dst. A slice is a sequence of consecutive rows in an image.
		/// </summary>
		/// <param name="c">the scaling context previously created with sws_getContext()</param>
		/// <param name="srcSlice">the array containing the pointers to the planes of the source slice</param>
		/// <param name="srcStride">the array containing the strides for each plane of the source image</param>
		/// <param name="srcSliceY">the position in the source image of the slice to process, that is the number (counted starting from zero) in the image of the first row of the slice</param>
		/// <param name="srcSliceH">the height of the source slice, that is the number of rows in the slice</param>
		/// <param name="dst">the array containing the pointers to the planes of the destination image</param>
		/// <param name="dstStride">the array containing the strides for each plane of the destination image</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_scale(SwsContext* c, byte** srcSlice, int* srcStride, int srcSliceY, int srcSliceH, byte** dst, int* dstStride);

		/// <summary>
		/// Scale all the coefficients of a by the scalar value.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_scaleVec(SwsVector* a, double scalar);

		/// <summary>
		/// Returns -1 if not supported
		/// </summary>
		/// <param name="inv_table">the yuv2rgb coefficients describing the input yuv space, normally ff_yuv2rgb_coeffs[x]</param>
		/// <param name="srcRange">flag indicating the while-black range of the input (1=jpeg / 0=mpeg)</param>
		/// <param name="table">the yuv2rgb coefficients describing the output yuv space, normally ff_yuv2rgb_coeffs[x]</param>
		/// <param name="dstRange">flag indicating the while-black range of the output (1=jpeg / 0=mpeg)</param>
		/// <param name="brightness">16.16 fixed point brightness correction</param>
		/// <param name="contrast">16.16 fixed point contrast correction</param>
		/// <param name="saturation">16.16 fixed point saturation correction</param>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static int sws_setColorspaceDetails(SwsContext* c, int_array4 inv_table, int srcRange, int_array4 table, int dstRange, int brightness, int contrast, int saturation);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_shiftVec(SwsVector* a, int shift);

		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static void sws_subVec(SwsVector* a, SwsVector* b);

		/// <summary>
		/// Return the libswscale build-time configuration.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static string swscale_configuration();

		/// <summary>
		/// Return the libswscale license.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static string swscale_license();

		/// <summary>
		/// Color conversion and scaling library.
		/// </summary>
		[DllImport(Dll_SwScale, CallingConvention = Convention)]
		public extern static uint swscale_version();

	}
#pragma warning restore IDE1006 // 命名样式
}
