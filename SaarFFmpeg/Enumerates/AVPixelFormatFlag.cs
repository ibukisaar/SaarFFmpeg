using System;

namespace Saar.FFmpeg.CSharp {
	[Flags]
	public enum AVPixelFormatFlag : ulong {
		/// <summary>
		/// Pixel format is big-endian.
		/// </summary>
		Be = 1 << 0,
		/// <summary>
		/// Pixel format has a palette in data[1], values are indexes in this palette.
		/// </summary>
		Pal = 1 << 1,
		/// <summary>
		/// All values of a component are bit-wise packed end to end.
		/// </summary>
		BitStream = 1 << 2,
		/// <summary>
		/// Pixel format is an HW accelerated format.
		/// </summary>
		HWAccel = 1 << 3,
		/// <summary>
		/// At least one pixel component is not in the first data plane.
		/// </summary>
		Planar = 1 << 4,
		/// <summary>
		/// The pixel format contains RGB-like data (as opposed to YUV/grayscale).
		/// </summary>
		Rgb = 1 << 5,
		/// <summary>
		/// The pixel format is "pseudo-paletted". This means that it contains a
		/// fixed palette in the 2nd plane but the palette is fixed/constant for each
		/// PIX_FMT. This allows interpreting the data as if it was PAL8, which can
		/// in some cases be simpler. Or the data can be interpreted purely based on
		/// the pixel format without using the palette.
		/// 
		/// <para>An example of a pseudo-paletted format is AV_PIX_FMT_GRAY8</para>
		/// </summary>
		PseudoPal = 1 << 6,
		/// <summary>
		/// The pixel format has an alpha channel. This is set on all formats that
		/// support alpha in some way. The exception is AV_PIX_FMT_PAL8, which can
		/// carry alpha as part of the palette. Details are explained in the
		/// AVPixelFormat enum, and are also encoded in the corresponding
		/// AVPixFmtDescriptor.
		/// 
		/// <para>The alpha is always straight, never pre-multiplied.</para>
		/// 
		/// <para>If a codec or a filter does not support alpha, it should set all alpha to
		/// opaque, or use the equivalent pixel formats without alpha component, e.g.
		/// AV_PIX_FMT_RGB0 (or AV_PIX_FMT_RGB24 etc.) instead of AV_PIX_FMT_RGBA.</para>
		/// </summary>
		Alpha = 1 << 7,
		/// <summary>
		/// The pixel format is following a Bayer pattern
		/// </summary>
		Bayer = 1 << 8,
	}
}
