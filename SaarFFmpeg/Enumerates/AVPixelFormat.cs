namespace Saar.FFmpeg.CSharp {
	public enum AVPixelFormat : int {
		None = -1,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, (1 Cr &amp; Cb sample per 2x2 Y samples)
		/// </summary>
		Yuv420p,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr
		/// </summary>
		Yuyv422,
		/// <summary>
		/// packed RGB 8:8:8, 24bpp, RGBRGB...
		/// </summary>
		Rgb24,
		/// <summary>
		/// packed RGB 8:8:8, 24bpp, BGRBGR...
		/// </summary>
		Bgr24,
		/// <summary>
		/// planar YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)
		/// </summary>
		Yuv422p,
		/// <summary>
		/// planar YUV 4:4:4, 24bpp, (1 Cr &amp; Cb sample per 1x1 Y samples)
		/// </summary>
		Yuv444p,
		/// <summary>
		/// planar YUV 4:1:0,  9bpp, (1 Cr &amp; Cb sample per 4x4 Y samples)
		/// </summary>
		Yuv410p,
		/// <summary>
		/// planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples)
		/// </summary>
		Yuv411p,
		/// <summary>
		///        Y        ,  8bpp
		/// </summary>
		Gray8,
		/// <summary>
		///        Y        ,  1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb
		/// </summary>
		Monowhite,
		/// <summary>
		///        Y        ,  1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb
		/// </summary>
		Monoblack,
		/// <summary>
		/// 8 bits with AV_PIX_FMT_RGB32 palette
		/// </summary>
		Pal8,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV420P and setting color_range
		/// </summary>
		Yuvj420p,
		/// <summary>
		/// planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV422P and setting color_range
		/// </summary>
		Yuvj422p,
		/// <summary>
		/// planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV444P and setting color_range
		/// </summary>
		Yuvj444p,
		/// <summary>
		/// XVideo Motion Acceleration via common packet passing
		/// </summary>
		XvmcMpeg2Mc,
		XvmcMpeg2Idct,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1
		/// </summary>
		Uyvy422,
		/// <summary>
		/// packed YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3
		/// </summary>
		Uyyvyy411,
		/// <summary>
		/// packed RGB 3:3:2,  8bpp, (msb)2B 3G 3R(lsb)
		/// </summary>
		Bgr8,
		/// <summary>
		/// packed RGB 1:2:1 bitstream,  4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
		/// </summary>
		Bgr4,
		/// <summary>
		/// packed RGB 1:2:1,  8bpp, (msb)1B 2G 1R(lsb)
		/// </summary>
		Bgr4Byte,
		/// <summary>
		/// packed RGB 3:3:2,  8bpp, (msb)2R 3G 3B(lsb)
		/// </summary>
		Rgb8,
		/// <summary>
		/// packed RGB 1:2:1 bitstream,  4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
		/// </summary>
		Rgb4,
		/// <summary>
		/// packed RGB 1:2:1,  8bpp, (msb)1R 2G 1B(lsb)
		/// </summary>
		Rgb4Byte,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)
		/// </summary>
		Nv12,
		/// <summary>
		/// as above, but U and V bytes are swapped
		/// </summary>
		Nv21,
		/// <summary>
		/// packed ARGB 8:8:8:8, 32bpp, ARGBARGB...
		/// </summary>
		Argb,
		/// <summary>
		/// packed RGBA 8:8:8:8, 32bpp, RGBARGBA...
		/// </summary>
		Rgba,
		/// <summary>
		/// packed ABGR 8:8:8:8, 32bpp, ABGRABGR...
		/// </summary>
		Abgr,
		/// <summary>
		/// packed BGRA 8:8:8:8, 32bpp, BGRABGRA...
		/// </summary>
		Bgra,
		/// <summary>
		///        Y        , 16bpp, big-endian
		/// </summary>
		Gray16be,
		/// <summary>
		///        Y        , 16bpp, little-endian
		/// </summary>
		Gray16le,
		/// <summary>
		/// planar YUV 4:4:0 (1 Cr &amp; Cb sample per 1x2 Y samples)
		/// </summary>
		Yuv440p,
		/// <summary>
		/// planar YUV 4:4:0 full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV440P and setting color_range
		/// </summary>
		Yuvj440p,
		/// <summary>
		/// planar YUV 4:2:0, 20bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples)
		/// </summary>
		Yuva420p,
		/// <summary>
		/// H.264 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauH264,
		/// <summary>
		/// MPEG-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauMpeg1,
		/// <summary>
		/// MPEG-2 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauMpeg2,
		/// <summary>
		/// WMV3 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauWmv3,
		/// <summary>
		/// VC-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauVc1,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian
		/// </summary>
		Rgb48be,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian
		/// </summary>
		Rgb48le,
		/// <summary>
		/// packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), big-endian
		/// </summary>
		Rgb565be,
		/// <summary>
		/// packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), little-endian
		/// </summary>
		Rgb565le,
		/// <summary>
		/// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), big-endian   , X=unused/undefined
		/// </summary>
		Rgb555be,
		/// <summary>
		/// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), little-endian, X=unused/undefined
		/// </summary>
		Rgb555le,
		/// <summary>
		/// packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), big-endian
		/// </summary>
		Bgr565be,
		/// <summary>
		/// packed BGR 5:6:5, 16bpp, (msb)   5B 6G 5R(lsb), little-endian
		/// </summary>
		Bgr565le,
		/// <summary>
		/// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), big-endian   , X=unused/undefined
		/// </summary>
		Bgr555be,
		/// <summary>
		/// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), little-endian, X=unused/undefined
		/// </summary>
		Bgr555le,
		/// <summary>
		/// HW acceleration through VA API at motion compensation entry-point, Picture.data[3] contains a vaapi_render_state struct which contains macroblocks as well as various fields extracted from headers
		/// </summary>
		VaapiMoco,
		/// <summary>
		/// HW acceleration through VA API at IDCT entry-point, Picture.data[3] contains a vaapi_render_state struct which contains fields extracted from headers
		/// </summary>
		VaapiIdct,
		/// <summary>
		/// HW decoding through VA API, Picture.data[3] contains a VASurfaceID
		/// </summary>
		VaapiVld,
		Vaapi = VaapiVld,
		/// <summary>
		/// planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p16le,
		/// <summary>
		/// planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p16be,
		/// <summary>
		/// planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p16le,
		/// <summary>
		/// planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p16be,
		/// <summary>
		/// planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p16le,
		/// <summary>
		/// planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p16be,
		/// <summary>
		/// MPEG-4 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers
		/// </summary>
		VdpauMpeg4,
		/// <summary>
		/// HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer
		/// </summary>
		Dxva2Vld,
		/// <summary>
		/// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), little-endian, X=unused/undefined
		/// </summary>
		Rgb444le,
		/// <summary>
		/// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), big-endian,    X=unused/undefined
		/// </summary>
		Rgb444be,
		/// <summary>
		/// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), little-endian, X=unused/undefined
		/// </summary>
		Bgr444le,
		/// <summary>
		/// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), big-endian,    X=unused/undefined
		/// </summary>
		Bgr444be,
		/// <summary>
		/// 8 bits gray, 8 bits alpha
		/// </summary>
		Ya8,
		/// <summary>
		/// alias for AV_PIX_FMT_YA8
		/// </summary>
		Y400a = Ya8,
		/// <summary>
		/// alias for AV_PIX_FMT_YA8
		/// </summary>
		Gray8a = Ya8,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian
		/// </summary>
		Bgr48be,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian
		/// </summary>
		Bgr48le,
		/// <summary>
		/// planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p9be,
		/// <summary>
		/// planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p9le,
		/// <summary>
		/// planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p10be,
		/// <summary>
		/// planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p10le,
		/// <summary>
		/// planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p10be,
		/// <summary>
		/// planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p10le,
		/// <summary>
		/// planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p9be,
		/// <summary>
		/// planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p9le,
		/// <summary>
		/// planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p10be,
		/// <summary>
		/// planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p10le,
		/// <summary>
		/// planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p9be,
		/// <summary>
		/// planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p9le,
		/// <summary>
		/// hardware decoding through VDA
		/// </summary>
		VdaVld,
		/// <summary>
		/// planar GBR 4:4:4 24bpp
		/// </summary>
		Gbrp,
		/// <summary>
		/// planar GBR 4:4:4 27bpp, big-endian
		/// </summary>
		Gbrp9be,
		/// <summary>
		/// planar GBR 4:4:4 27bpp, little-endian
		/// </summary>
		Gbrp9le,
		/// <summary>
		/// planar GBR 4:4:4 30bpp, big-endian
		/// </summary>
		Gbrp10be,
		/// <summary>
		/// planar GBR 4:4:4 30bpp, little-endian
		/// </summary>
		Gbrp10le,
		/// <summary>
		/// planar GBR 4:4:4 48bpp, big-endian
		/// </summary>
		Gbrp16be,
		/// <summary>
		/// planar GBR 4:4:4 48bpp, little-endian
		/// </summary>
		Gbrp16le,
		/// <summary>
		/// planar YUV 4:2:2 24bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples)
		/// </summary>
		Yuva422p,
		/// <summary>
		/// planar YUV 4:4:4 32bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples)
		/// </summary>
		Yuva444p,
		/// <summary>
		/// planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), big-endian
		/// </summary>
		Yuva420p9be,
		/// <summary>
		/// planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), little-endian
		/// </summary>
		Yuva420p9le,
		/// <summary>
		/// planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), big-endian
		/// </summary>
		Yuva422p9be,
		/// <summary>
		/// planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), little-endian
		/// </summary>
		Yuva422p9le,
		/// <summary>
		/// planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian
		/// </summary>
		Yuva444p9be,
		/// <summary>
		/// planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian
		/// </summary>
		Yuva444p9le,
		/// <summary>
		/// planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva420p10be,
		/// <summary>
		/// planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva420p10le,
		/// <summary>
		/// planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva422p10be,
		/// <summary>
		/// planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva422p10le,
		/// <summary>
		/// planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva444p10be,
		/// <summary>
		/// planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva444p10le,
		/// <summary>
		/// planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva420p16be,
		/// <summary>
		/// planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva420p16le,
		/// <summary>
		/// planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva422p16be,
		/// <summary>
		/// planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva422p16le,
		/// <summary>
		/// planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva444p16be,
		/// <summary>
		/// planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva444p16le,
		/// <summary>
		/// HW acceleration through VDPAU, Picture.data[3] contains a VdpVideoSurface
		/// </summary>
		Vdpau,
		/// <summary>
		/// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as little-endian, the 4 lower bits are set to 0
		/// </summary>
		Xyz12le,
		/// <summary>
		/// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as big-endian, the 4 lower bits are set to 0
		/// </summary>
		Xyz12be,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)
		/// </summary>
		Nv16,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Nv20le,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Nv20be,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
		/// </summary>
		Rgba64be,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
		/// </summary>
		Rgba64le,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
		/// </summary>
		Bgra64be,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
		/// </summary>
		Bgra64le,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Y0 Cr Y1 Cb
		/// </summary>
		Yvyu422,
		/// <summary>
		/// HW acceleration through VDA, data[3] contains a CVPixelBufferRef
		/// </summary>
		Vda,
		/// <summary>
		/// 16 bits gray, 16 bits alpha (big-endian)
		/// </summary>
		Ya16be,
		/// <summary>
		/// 16 bits gray, 16 bits alpha (little-endian)
		/// </summary>
		Ya16le,
		/// <summary>
		/// planar GBRA 4:4:4:4 32bpp
		/// </summary>
		Gbrap,
		/// <summary>
		/// planar GBRA 4:4:4:4 64bpp, big-endian
		/// </summary>
		Gbrap16be,
		/// <summary>
		/// planar GBRA 4:4:4:4 64bpp, little-endian
		/// </summary>
		Gbrap16le,
		Qsv,
		Mmal,
		/// <summary>
		/// HW decoding through Direct3D11, Picture.data[3] contains a ID3D11VideoDecoderOutputView pointer
		/// </summary>
		D3d11vaVld,
		Cuda,
		/// <summary>
		/// packed RGB 8:8:8, 32bpp, XRGBXRGB...   X=unused/undefined
		/// </summary>
		_0rgb = 291 + 4,
		/// <summary>
		/// packed RGB 8:8:8, 32bpp, RGBXRGBX...   X=unused/undefined
		/// </summary>
		Rgb0,
		/// <summary>
		/// packed BGR 8:8:8, 32bpp, XBGRXBGR...   X=unused/undefined
		/// </summary>
		_0bgr,
		/// <summary>
		/// packed BGR 8:8:8, 32bpp, BGRXBGRX...   X=unused/undefined
		/// </summary>
		Bgr0,
		/// <summary>
		/// planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p12be,
		/// <summary>
		/// planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p12le,
		/// <summary>
		/// planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p14be,
		/// <summary>
		/// planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p14le,
		/// <summary>
		/// planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p12be,
		/// <summary>
		/// planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p12le,
		/// <summary>
		/// planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p14be,
		/// <summary>
		/// planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p14le,
		/// <summary>
		/// planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p12be,
		/// <summary>
		/// planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p12le,
		/// <summary>
		/// planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p14be,
		/// <summary>
		/// planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p14le,
		/// <summary>
		/// planar GBR 4:4:4 36bpp, big-endian
		/// </summary>
		Gbrp12be,
		/// <summary>
		/// planar GBR 4:4:4 36bpp, little-endian
		/// </summary>
		Gbrp12le,
		/// <summary>
		/// planar GBR 4:4:4 42bpp, big-endian
		/// </summary>
		Gbrp14be,
		/// <summary>
		/// planar GBR 4:4:4 42bpp, little-endian
		/// </summary>
		Gbrp14le,
		/// <summary>
		/// planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples) full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV411P and setting color_range
		/// </summary>
		Yuvj411p,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 8-bit samples */
		/// </summary>
		BayerBggr8,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 8-bit samples */
		/// </summary>
		BayerRggb8,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 8-bit samples */
		/// </summary>
		BayerGbrg8,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 8-bit samples */
		/// </summary>
		BayerGrbg8,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerBggr16le,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerBggr16be,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerRggb16le,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerRggb16be,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerGbrg16le,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerGbrg16be,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerGrbg16le,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerGrbg16be,
		/// <summary>
		/// planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian
		/// </summary>
		Yuv440p10le,
		/// <summary>
		/// planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian
		/// </summary>
		Yuv440p10be,
		/// <summary>
		/// planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian
		/// </summary>
		Yuv440p12le,
		/// <summary>
		/// planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian
		/// </summary>
		Yuv440p12be,
		/// <summary>
		/// packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian
		/// </summary>
		Ayuv64le,
		/// <summary>
		/// packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian
		/// </summary>
		Ayuv64be,
		/// <summary>
		/// hardware decoding through Videotoolbox
		/// </summary>
		Videotoolbox,
		/// <summary>
		/// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, little-endian
		/// </summary>
		P010le,
		/// <summary>
		/// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, big-endian
		/// </summary>
		P010be,
		/// <summary>
		/// planar GBR 4:4:4:4 48bpp, big-endian
		/// </summary>
		Gbrap12be,
		/// <summary>
		/// planar GBR 4:4:4:4 48bpp, little-endian
		/// </summary>
		Gbrap12le,
		/// <summary>
		/// planar GBR 4:4:4:4 40bpp, big-endian
		/// </summary>
		Gbrap10be,
		/// <summary>
		/// planar GBR 4:4:4:4 40bpp, little-endian
		/// </summary>
		Gbrap10le,
		/// <summary>
		/// hardware decoding through MediaCodec
		/// </summary>
		Mediacodec,
		/// <summary>
		/// number of pixel formats, DO NOT USE THIS if you want to link with shared libav* because the number of formats might differ between versions
		/// </summary>
		Nb,
	}
}