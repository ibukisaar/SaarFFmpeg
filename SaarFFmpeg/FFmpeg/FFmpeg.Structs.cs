using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;
using Saar.FFmpeg.Internal;
using Saar.FFmpeg.Support;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Structs {
#pragma warning disable IDE1006 // 命名样式
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct _iobuf {
		public void* Placeholder;
	}

	/// <summary>
	/// Rational number (pair of numerator and denominator).
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVRational {
		/// <summary>
		/// Numerator
		/// </summary>
		public int Num;
		/// <summary>
		/// Denominator
		/// </summary>
		public int Den;

		public AVRational(int num, int den) {
			Num = num;
			Den = den;
		}

		public double Value => Num / (double)Den;

		public override string ToString() => $"{Num}/{Den}";
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFifoBuffer {
		public byte* Buffer;
		public byte* Rptr;
		public byte* Wptr;
		public byte* End;
		public uint Rndx;
		public uint Wndx;
	}

	/// <summary>
	/// Describe the class of an AVClass context structure. That is an arbitrary struct of which the first field is a pointer to an AVClass struct (e.g. AVCodecContext, AVFormatContext etc.).
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVClass {
		/// <summary>
		/// The name of the class; usually it is the same name as the context structure type to which the AVClass is associated.
		/// </summary>
		public byte* ClassName;
		/// <summary>
		/// A pointer to a function which returns the name of a context instance ctx associated with the class.
		/// </summary>
		public AVClass_ItemName_Func ItemName;
		/// <summary>
		/// a pointer to the first option specified in the class if any or NULL
		/// </summary>
		public AVOption* Option;
		/// <summary>
		/// LIBAVUTIL_VERSION with which this structure was created. This is used to allow fields to be added without requiring major version bumps everywhere.
		/// </summary>
		public int Version;
		/// <summary>
		/// Offset in the structure where log_level_offset is stored. 0 means there is no such variable
		/// </summary>
		public int LogLevelOffsetOffset;
		/// <summary>
		/// Offset in the structure where a pointer to the parent context for logging is stored. For example a decoder could pass its AVCodecContext to eval as such a parent context, which an av_log() implementation could then leverage to display the parent context. The offset can be NULL.
		/// </summary>
		public int ParentLogContextOffset;
		/// <summary>
		/// Return next AVOptions-enabled child or NULL
		/// </summary>
		public AVClass_ChildNext_Func ChildNext;
		/// <summary>
		/// Return an AVClass corresponding to the next potential AVOptions-enabled child.
		/// </summary>
		public AVClass_ChildClassNext_Func ChildClassNext;
		/// <summary>
		/// Category used for visualization (like color) This is only set if the category is equal for all objects using this class. available since version (51 &lt;&lt; 16 | 56 &lt;&lt; 8 | 100)
		/// </summary>
		public AVClassCategory Category;
		/// <summary>
		/// Callback to return the category. available since version (51 &lt;&lt; 16 | 59 &lt;&lt; 8 | 100)
		/// </summary>
		public AVClass_GetCategory_Func GetCategory;
		/// <summary>
		/// Callback to return the supported/allowed ranges. available since version (52.12)
		/// </summary>
		public AVClass_QueryRanges_Func QueryRanges;

		public override string ToString()
			=> "ClassName = " + Marshal.PtrToStringAnsi((IntPtr)ClassName);
	}

	/// <summary>
	/// AVOption
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVOption {
		public byte* Name;
		/// <summary>
		/// short English help text
		/// </summary>
		public byte* Help;
		/// <summary>
		/// The offset relative to the context structure where the option value is stored. It should be 0 for named constants.
		/// </summary>
		public int Offset;
		public AVOptionType Type;
		public AVOption_DefaultVal DefaultVal;
		/// <summary>
		/// minimum valid value for the option
		/// </summary>
		public double Min;
		/// <summary>
		/// maximum valid value for the option
		/// </summary>
		public double Max;
		public int Flags;
		/// <summary>
		/// The logical unit to which the option belongs. Non-constant options and corresponding named constants share the same unit. May be NULL.
		/// </summary>
		public byte* Unit;
	}

	/// <summary>
	/// List of AVOptionRange structs.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVOptionRanges {
		/// <summary>
		/// Array of option ranges.
		/// </summary>
		public AVOptionRange** Range;
		/// <summary>
		/// Number of ranges per component.
		/// </summary>
		public int NbRanges;
		/// <summary>
		/// Number of componentes.
		/// </summary>
		public int NbComponents;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVAudioFifo {
	}

	/// <summary>
	/// This structure describes decoded (raw) audio or video data.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFrame {
		/// <summary>
		/// pointer to the picture/channel planes. This might be different from the first allocated byte
		/// </summary>
		public byte_ptrArray8 Data;
		/// <summary>
		/// For video, size in bytes of each picture line. For audio, size in bytes of each plane.
		/// </summary>
		public fixed int Linesize[8];
		/// <summary>
		/// pointers to the data planes/channels.
		/// </summary>
		public byte** ExtendedData;
		/// <summary>
		/// Video frames only. The coded dimensions (in pixels) of the video frame, i.e. the size of the rectangle that contains some well-defined values.
		/// </summary>
		public int Width;
		/// <summary>
		/// Video frames only. The coded dimensions (in pixels) of the video frame, i.e. the size of the rectangle that contains some well-defined values.
		/// </summary>
		public int Height;
		/// <summary>
		/// number of audio samples (per channel) described by this frame
		/// </summary>
		public int NbSamples;
		/// <summary>
		/// format of the frame, -1 if unknown or unset Values correspond to enum AVPixelFormat for video frames, enum AVSampleFormat for audio)
		/// </summary>
		public int Format;
		/// <summary>
		/// 1 -&gt; keyframe, 0-&gt; not
		/// </summary>
		public int KeyFrame;
		/// <summary>
		/// Picture type of the frame.
		/// </summary>
		public AVPictureType PictType;
		/// <summary>
		/// Sample aspect ratio for the video frame, 0/1 if unknown/unspecified.
		/// </summary>
		public AVRational SampleAspectRatio;
		/// <summary>
		/// Presentation timestamp in time_base units (time when frame should be shown to user).
		/// </summary>
		public long Pts;
		/// <summary>
		/// PTS copied from the AVPacket that was decoded to produce this frame.
		/// </summary>
		public long PktPts;
		/// <summary>
		/// DTS copied from the AVPacket that triggered returning this frame. (if frame threading isn&apos;t used) This is also the Presentation time of this AVFrame calculated from only AVPacket.dts values without pts values.
		/// </summary>
		public long PktDts;
		/// <summary>
		/// picture number in bitstream order
		/// </summary>
		public int CodedPictureNumber;
		/// <summary>
		/// picture number in display order
		/// </summary>
		public int DisplayPictureNumber;
		/// <summary>
		/// quality (between 1 (good) and FF_LAMBDA_MAX (bad))
		/// </summary>
		public int Quality;
		/// <summary>
		/// for some private data of the user
		/// </summary>
		public void* Opaque;
		public ulong_array8 Error;
		/// <summary>
		/// When decoding, this signals how much the picture must be delayed. extra_delay = repeat_pict / (2*fps)
		/// </summary>
		public int RepeatPict;
		/// <summary>
		/// The content of the picture is interlaced.
		/// </summary>
		public int InterlacedFrame;
		/// <summary>
		/// If the content is interlaced, is top field displayed first.
		/// </summary>
		public int TopFieldFirst;
		/// <summary>
		/// Tell user application that palette has changed from previous frame.
		/// </summary>
		public int PaletteHasChanged;
		/// <summary>
		/// reordered opaque 64 bits (generally an integer or a double precision float PTS but can be anything). The user sets AVCodecContext.reordered_opaque to represent the input at that time, the decoder reorders values as needed and sets AVFrame.reordered_opaque to exactly one of the values provided by the user through AVCodecContext.reordered_opaque
		/// </summary>
		public long ReorderedOpaque;
		/// <summary>
		/// Sample rate of the audio data.
		/// </summary>
		public int SampleRate;
		/// <summary>
		/// Channel layout of the audio data.
		/// </summary>
		public ulong ChannelLayout;
		/// <summary>
		/// AVBuffer references backing the data for this frame. If all elements of this array are NULL, then this frame is not reference counted. This array must be filled contiguously -- if buf[i] is non-NULL then buf[j] must also be non-NULL for all j &lt; i.
		/// </summary>
		public AVBufferRef_ptrArray8 Buf;
		/// <summary>
		/// For planar audio which requires more than AV_NUM_DATA_POINTERS AVBufferRef pointers, this array will hold all the references which cannot fit into AVFrame.buf.
		/// </summary>
		public AVBufferRef** ExtendedBuf;
		/// <summary>
		/// Number of elements in extended_buf.
		/// </summary>
		public int NbExtendedBuf;
		public AVFrameSideData** SideData;
		public int NbSideData;
		/// <summary>
		/// Frame flags, a combination of
		/// </summary>
		public int Flags;
		/// <summary>
		/// MPEG vs JPEG YUV range. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorRange ColorRange;
		public AVColorPrimaries ColorPrimaries;
		public AVColorTransferCharacteristic ColorTrc;
		/// <summary>
		/// YUV colorspace type. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorSpace Colorspace;
		public AVChromaLocation ChromaLocation;
		/// <summary>
		/// frame timestamp estimated using various heuristics, in stream time base - encoding: unused - decoding: set by libavcodec, read by user.
		/// </summary>
		public long BestEffortTimestamp;
		/// <summary>
		/// reordered pos from the last AVPacket that has been input into the decoder - encoding: unused - decoding: Read by user.
		/// </summary>
		public long PktPos;
		/// <summary>
		/// duration of the corresponding packet, expressed in AVStream-&gt;time_base units, 0 if unknown. - encoding: unused - decoding: Read by user.
		/// </summary>
		public long PktDuration;
		/// <summary>
		/// metadata. - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public AVDictionary* Metadata;
		/// <summary>
		/// decode error flags of the frame, set to a combination of FF_DECODE_ERROR_xxx flags if the decoder produced a frame, but there were errors during the decoding. - encoding: unused - decoding: set by libavcodec, read by user.
		/// </summary>
		public int DecodeErrorFlags;
		/// <summary>
		/// number of audio channels, only used for audio. - encoding: unused - decoding: Read by user.
		/// </summary>
		public int Channels;
		/// <summary>
		/// size of the corresponding packet containing the compressed frame. It is set to a negative value if unknown. - encoding: unused - decoding: set by libavcodec, read by user.
		/// </summary>
		public int PktSize;
		/// <summary>
		/// QP table
		/// </summary>
		public sbyte* QscaleTable;
		/// <summary>
		/// QP store stride
		/// </summary>
		public int Qstride;
		public int QscaleType;
		public AVBufferRef* QpTableBuf;
		/// <summary>
		/// For hwaccel-format frames, this should be a reference to the AVHWFramesContext describing the frame.
		/// </summary>
		public AVBufferRef* HwFramesCtx;
		/// <summary>
		/// AVBufferRef for free use by the API user. FFmpeg will never check the contents of the buffer ref. FFmpeg calls av_buffer_unref() on it when the frame is unreferenced. av_frame_copy_props() calls create a new reference with av_buffer_ref() for the target frame&apos;s opaque_ref field.
		/// </summary>
		public AVBufferRef* OpaqueRef;
		/// <summary>
		/// cropping Video frames only. The number of pixels to discard from the the top/bottom/left/right border of the frame to obtain the sub-rectangle of the frame intended for presentation. @{
		/// </summary>
		public ulong CropTop;
		public ulong CropBottom;
		public ulong CropLeft;
		public ulong CropRight;
		/// <summary>
		/// AVBufferRef for internal use by a single libav* library. Must not be used to transfer data between libraries. Has to be NULL when ownership of the frame leaves the respective library.
		/// </summary>
		public AVBufferRef* PrivateRef;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBuffer {
	}

	/// <summary>
	/// A reference to a data buffer.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBufferRef {
		public AVBuffer* Buffer;
		/// <summary>
		/// The data buffer. It is considered writable if and only if this is the only reference to the buffer, in which case av_buffer_is_writable() returns 1.
		/// </summary>
		public byte* Data;
		/// <summary>
		/// Size of data in bytes.
		/// </summary>
		public int Size;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDictionary {
	}

	/// <summary>
	/// Structure to hold side data for an AVFrame.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFrameSideData {
		public AVFrameSideDataType Type;
		public byte* Data;
		public int Size;
		public AVDictionary* Metadata;
		public AVBufferRef* Buf;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBPrint {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBufferPool {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDictionaryEntry {
		public byte* Key;
		public byte* Value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVComponentDescriptor {
		/// <summary>
		/// Which of the 4 planes contains the component.
		/// </summary>
		public int Plane;
		/// <summary>
		/// Number of elements between 2 horizontally consecutive pixels. Elements are bits for bitstream formats, bytes otherwise.
		/// </summary>
		public int Step;
		/// <summary>
		/// Number of elements before the component of the first pixel. Elements are bits for bitstream formats, bytes otherwise.
		/// </summary>
		public int Offset;
		/// <summary>
		/// Number of least significant bits that must be shifted away to get the value.
		/// </summary>
		public int Shift;
		/// <summary>
		/// Number of bits in the component.
		/// </summary>
		public int Depth;
		/// <summary>
		/// deprecated, use step instead
		/// </summary>
		public int StepMinus1;
		/// <summary>
		/// deprecated, use depth instead
		/// </summary>
		public int DepthMinus1;
		/// <summary>
		/// deprecated, use offset instead
		/// </summary>
		public int OffsetPlus1;
	}

	/// <summary>
	/// Descriptor that unambiguously describes how the bits of a pixel are stored in the up to 4 data planes of an image. It also stores the subsampling factors and number of components.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPixFmtDescriptor {
		public byte* Name;
		/// <summary>
		/// The number of components each pixel has, (1-4)
		/// </summary>
		public byte NbComponents;
		/// <summary>
		/// Amount to shift the luma width right to find the chroma width. For YV12 this is 1 for example. chroma_width = AV_CEIL_RSHIFT(luma_width, log2_chroma_w) The note above is needed to ensure rounding up. This value only refers to the chroma components.
		/// </summary>
		public byte Log2ChromaW;
		/// <summary>
		/// Amount to shift the luma height right to find the chroma height. For YV12 this is 1 for example. chroma_height= AV_CEIL_RSHIFT(luma_height, log2_chroma_h) The note above is needed to ensure rounding up. This value only refers to the chroma components.
		/// </summary>
		public byte Log2ChromaH;
		/// <summary>
		/// Combination of AV_PIX_FMT_FLAG_... flags.
		/// </summary>
		public ulong Flags;
		/// <summary>
		/// Parameters that describe how pixels are packed. If the format has 1 or 2 components, then luma is 0. If the format has 3 or 4 components: if the RGB flag is set then 0 is red, 1 is green and 2 is blue; otherwise 0 is luma, 1 is chroma-U and 2 is chroma-V.
		/// </summary>
		public AVComponentDescriptor_array4 Comp;
		/// <summary>
		/// Alternative comma-separated names.
		/// </summary>
		public byte* Alias;
	}

	/// <summary>
	/// A single allowed range of values, or a single allowed value.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVOptionRange {
		public byte* Str;
		/// <summary>
		/// Value range. For string ranges this represents the min/max length. For dimensions this represents the min/max pixel count or width/height in multi-component case.
		/// </summary>
		public double ValueMin;
		/// <summary>
		/// Value range. For string ranges this represents the min/max length. For dimensions this represents the min/max pixel count or width/height in multi-component case.
		/// </summary>
		public double ValueMax;
		/// <summary>
		/// Value&apos;s component range. For string this represents the unicode range for chars, 0-127 limits to ASCII.
		/// </summary>
		public double ComponentMin;
		/// <summary>
		/// Value&apos;s component range. For string this represents the unicode range for chars, 0-127 limits to ASCII.
		/// </summary>
		public double ComponentMax;
		/// <summary>
		/// Range flag. If set to 1 the struct encodes a range, if set to 0 a single value.
		/// </summary>
		public int IsRange;
	}

	/// <summary>
	/// the default value for scalar options
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVOption_DefaultVal {
		public long I64;
		public double Dbl;
		public byte* Str;
		public AVRational Q;
	}

	/// <summary>
	/// This struct aggregates all the (hardware/vendor-specific) &quot;high-level&quot; state, i.e. state that is not tied to a concrete processing configuration. E.g., in an API that supports hardware-accelerated encoding and decoding, this struct will (if possible) wrap the state that is common to both encoding and decoding and from which specific instances of encoders or decoders can be derived.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWDeviceContext {
		/// <summary>
		/// A class for logging. Set by av_hwdevice_ctx_alloc().
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// Private data used internally by libavutil. Must not be accessed in any way by the caller.
		/// </summary>
		public AVHWDeviceInternal* Internal;
		/// <summary>
		/// This field identifies the underlying API used for hardware access.
		/// </summary>
		public AVHWDeviceType Type;
		/// <summary>
		/// The format-specific data, allocated and freed by libavutil along with this context.
		/// </summary>
		public void* Hwctx;
		/// <summary>
		/// This field may be set by the caller before calling av_hwdevice_ctx_init().
		/// </summary>
		public AVHWDeviceContext_Free_Func Free;
		/// <summary>
		/// Arbitrary user data, to be used e.g. by the free() callback.
		/// </summary>
		public void* UserOpaque;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWDeviceInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVTimecode {
		/// <summary>
		/// timecode frame start (first base frame number)
		/// </summary>
		public int Start;
		/// <summary>
		/// flags such as drop frame, +24 hours support, ...
		/// </summary>
		public uint Flags;
		/// <summary>
		/// frame rate in rational form
		/// </summary>
		public AVRational Rate;
		/// <summary>
		/// frame per second; must be consistent with the rate field
		/// </summary>
		public uint Fps;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWFramesInternal {
	}

	/// <summary>
	/// This struct describes a set or pool of &quot;hardware&quot; frames (i.e. those with data not located in normal system memory). All the frames in the pool are assumed to be allocated in the same way and interchangeable.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWFramesContext {
		/// <summary>
		/// A class for logging.
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// Private data used internally by libavutil. Must not be accessed in any way by the caller.
		/// </summary>
		public AVHWFramesInternal* Internal;
		/// <summary>
		/// A reference to the parent AVHWDeviceContext. This reference is owned and managed by the enclosing AVHWFramesContext, but the caller may derive additional references from it.
		/// </summary>
		public AVBufferRef* DeviceRef;
		/// <summary>
		/// The parent AVHWDeviceContext. This is simply a pointer to device_ref-&gt;data provided for convenience.
		/// </summary>
		public AVHWDeviceContext* DeviceCtx;
		/// <summary>
		/// The format-specific data, allocated and freed automatically along with this context.
		/// </summary>
		public void* Hwctx;
		/// <summary>
		/// This field may be set by the caller before calling av_hwframe_ctx_init().
		/// </summary>
		public AVHWFramesContext_Free_Func Free;
		/// <summary>
		/// Arbitrary user data, to be used e.g. by the free() callback.
		/// </summary>
		public void* UserOpaque;
		/// <summary>
		/// A pool from which the frames are allocated by av_hwframe_get_buffer(). This field may be set by the caller before calling av_hwframe_ctx_init(). The buffers returned by calling av_buffer_pool_get() on this pool must have the properties described in the documentation in the corresponding hw type&apos;s header (hwcontext_*.h). The pool will be freed strictly before this struct&apos;s free() callback is invoked.
		/// </summary>
		public AVBufferPool* Pool;
		/// <summary>
		/// Initial size of the frame pool. If a device type does not support dynamically resizing the pool, then this is also the maximum pool size.
		/// </summary>
		public int InitialPoolSize;
		/// <summary>
		/// The pixel format identifying the underlying HW surface type.
		/// </summary>
		public AVPixelFormat Format;
		/// <summary>
		/// The pixel format identifying the actual data layout of the hardware frames.
		/// </summary>
		public AVPixelFormat SwFormat;
		/// <summary>
		/// The allocated dimensions of the frames in this pool.
		/// </summary>
		public int Width;
		/// <summary>
		/// The allocated dimensions of the frames in this pool.
		/// </summary>
		public int Height;
	}

	/// <summary>
	/// This struct describes the constraints on hardware frames attached to a given device with a hardware-specific configuration. This is returned by av_hwdevice_get_hwframe_constraints() and must be freed by av_hwframe_constraints_free() after use.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWFramesConstraints {
		/// <summary>
		/// A list of possible values for format in the hw_frames_ctx, terminated by AV_PIX_FMT_NONE. This member will always be filled.
		/// </summary>
		public AVPixelFormat* ValidHwFormats;
		/// <summary>
		/// A list of possible values for sw_format in the hw_frames_ctx, terminated by AV_PIX_FMT_NONE. Can be NULL if this information is not known.
		/// </summary>
		public AVPixelFormat* ValidSwFormats;
		/// <summary>
		/// The minimum size of frames in this hw_frames_ctx. (Zero if not known.)
		/// </summary>
		public int MinWidth;
		public int MinHeight;
		/// <summary>
		/// The maximum size of frames in this hw_frames_ctx. (INT_MAX if not known / no limit.)
		/// </summary>
		public int MaxWidth;
		public int MaxHeight;
	}

	/// <summary>
	/// This struct is allocated as AVHWDeviceContext.hwctx
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDXVA2DeviceContext {
		public IDirect3DDeviceManager9* Devmgr;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirect3DDeviceManager9 {
		public IDirect3DDeviceManager9Vtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirect3DDeviceManager9Vtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* ResetDevice;
		public void* OpenDeviceHandle;
		public void* CloseDeviceHandle;
		public void* TestDevice;
		public void* LockDevice;
		public void* UnlockDevice;
		public void* GetVideoService;
	}

	/// <summary>
	/// This struct is allocated as AVHWFramesContext.hwctx
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDXVA2FramesContext {
		/// <summary>
		/// The surface type (e.g. DXVA2_VideoProcessorRenderTarget or DXVA2_VideoDecoderRenderTarget). Must be set by the caller.
		/// </summary>
		public ulong SurfaceType;
		/// <summary>
		/// The surface pool. When an external pool is not provided by the caller, this will be managed (allocated and filled on init, freed on uninit) by libavutil.
		/// </summary>
		public IDirect3DSurface9** Surfaces;
		public int NbSurfaces;
		/// <summary>
		/// Certain drivers require the decoder to be destroyed before the surfaces. To allow internally managed pools to work properly in such cases, this field is provided.
		/// </summary>
		public IDirectXVideoDecoder* DecoderToRelease;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirect3DSurface9 {
		public IDirect3DSurface9Vtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirect3DSurface9Vtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* SetPrivateData;
		public void* GetPrivateData;
		public void* FreePrivateData;
		public void* SetPriority;
		public void* GetPriority;
		public void* PreLoad;
		public new void* GetType;
		public void* GetContainer;
		public void* GetDesc;
		public void* LockRect;
		public void* UnlockRect;
		public void* GetDC;
		public void* ReleaseDC;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirectXVideoDecoder {
		public IDirectXVideoDecoderVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IDirectXVideoDecoderVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetVideoDecoderService;
		public void* GetCreationParameters;
		public void* GetBuffer;
		public void* ReleaseBuffer;
		public void* BeginFrame;
		public void* EndFrame;
		public void* Execute;
	}

	/// <summary>
	/// This struct is allocated as AVHWDeviceContext.hwctx
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVD3D11VADeviceContext {
		/// <summary>
		/// Device used for texture creation and access. This can also be used to set the libavcodec decoding device.
		/// </summary>
		public ID3D11Device* Device;
		/// <summary>
		/// If unset, this will be set from the device field on init.
		/// </summary>
		public ID3D11DeviceContext* DeviceContext;
		/// <summary>
		/// If unset, this will be set from the device field on init.
		/// </summary>
		public ID3D11VideoDevice* VideoDevice;
		/// <summary>
		/// If unset, this will be set from the device_context field on init.
		/// </summary>
		public ID3D11VideoContext* VideoContext;
		/// <summary>
		/// Callbacks for locking. They protect accesses to device_context and video_context calls. They also protect access to the internal staging texture (for av_hwframe_transfer_data() calls). They do NOT protect access to hwcontext or decoder state in general.
		/// </summary>
		public AVD3D11VADeviceContext_Lock_Func Lock;
		public AVD3D11VADeviceContext_Unlock_Func Unlock;
		public void* LockCtx;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11Device {
		public ID3D11DeviceVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11DeviceVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* CreateBuffer;
		public void* CreateTexture1D;
		public void* CreateTexture2D;
		public void* CreateTexture3D;
		public void* CreateShaderResourceView;
		public void* CreateUnorderedAccessView;
		public void* CreateRenderTargetView;
		public void* CreateDepthStencilView;
		public void* CreateInputLayout;
		public void* CreateVertexShader;
		public void* CreateGeometryShader;
		public void* CreateGeometryShaderWithStreamOutput;
		public void* CreatePixelShader;
		public void* CreateHullShader;
		public void* CreateDomainShader;
		public void* CreateComputeShader;
		public void* CreateClassLinkage;
		public void* CreateBlendState;
		public void* CreateDepthStencilState;
		public void* CreateRasterizerState;
		public void* CreateSamplerState;
		public void* CreateQuery;
		public void* CreatePredicate;
		public void* CreateCounter;
		public void* CreateDeferredContext;
		public void* OpenSharedResource;
		public void* CheckFormatSupport;
		public void* CheckMultisampleQualityLevels;
		public void* CheckCounterInfo;
		public void* CheckCounter;
		public void* CheckFeatureSupport;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public void* GetFeatureLevel;
		public void* GetCreationFlags;
		public void* GetDeviceRemovedReason;
		public void* GetImmediateContext;
		public void* SetExceptionMode;
		public void* GetExceptionMode;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11DeviceContext {
		public ID3D11DeviceContextVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11DeviceContextVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public void* VSSetConstantBuffers;
		public void* PSSetShaderResources;
		public void* PSSetShader;
		public void* PSSetSamplers;
		public void* VSSetShader;
		public void* DrawIndexed;
		public void* Draw;
		public void* Map;
		public void* Unmap;
		public void* PSSetConstantBuffers;
		public void* IASetInputLayout;
		public void* IASetVertexBuffers;
		public void* IASetIndexBuffer;
		public void* DrawIndexedInstanced;
		public void* DrawInstanced;
		public void* GSSetConstantBuffers;
		public void* GSSetShader;
		public void* IASetPrimitiveTopology;
		public void* VSSetShaderResources;
		public void* VSSetSamplers;
		public void* Begin;
		public void* End;
		public void* GetData;
		public void* SetPredication;
		public void* GSSetShaderResources;
		public void* GSSetSamplers;
		public void* OMSetRenderTargets;
		public void* OMSetRenderTargetsAndUnorderedAccessViews;
		public void* OMSetBlendState;
		public void* OMSetDepthStencilState;
		public void* SOSetTargets;
		public void* DrawAuto;
		public void* DrawIndexedInstancedIndirect;
		public void* DrawInstancedIndirect;
		public void* Dispatch;
		public void* DispatchIndirect;
		public void* RSSetState;
		public void* RSSetViewports;
		public void* RSSetScissorRects;
		public void* CopySubresourceRegion;
		public void* CopyResource;
		public void* UpdateSubresource;
		public void* CopyStructureCount;
		public void* ClearRenderTargetView;
		public void* ClearUnorderedAccessViewUint;
		public void* ClearUnorderedAccessViewFloat;
		public void* ClearDepthStencilView;
		public void* GenerateMips;
		public void* SetResourceMinLOD;
		public void* GetResourceMinLOD;
		public void* ResolveSubresource;
		public void* ExecuteCommandList;
		public void* HSSetShaderResources;
		public void* HSSetShader;
		public void* HSSetSamplers;
		public void* HSSetConstantBuffers;
		public void* DSSetShaderResources;
		public void* DSSetShader;
		public void* DSSetSamplers;
		public void* DSSetConstantBuffers;
		public void* CSSetShaderResources;
		public void* CSSetUnorderedAccessViews;
		public void* CSSetShader;
		public void* CSSetSamplers;
		public void* CSSetConstantBuffers;
		public void* VSGetConstantBuffers;
		public void* PSGetShaderResources;
		public void* PSGetShader;
		public void* PSGetSamplers;
		public void* VSGetShader;
		public void* PSGetConstantBuffers;
		public void* IAGetInputLayout;
		public void* IAGetVertexBuffers;
		public void* IAGetIndexBuffer;
		public void* GSGetConstantBuffers;
		public void* GSGetShader;
		public void* IAGetPrimitiveTopology;
		public void* VSGetShaderResources;
		public void* VSGetSamplers;
		public void* GetPredication;
		public void* GSGetShaderResources;
		public void* GSGetSamplers;
		public void* OMGetRenderTargets;
		public void* OMGetRenderTargetsAndUnorderedAccessViews;
		public void* OMGetBlendState;
		public void* OMGetDepthStencilState;
		public void* SOGetTargets;
		public void* RSGetState;
		public void* RSGetViewports;
		public void* RSGetScissorRects;
		public void* HSGetShaderResources;
		public void* HSGetShader;
		public void* HSGetSamplers;
		public void* HSGetConstantBuffers;
		public void* DSGetShaderResources;
		public void* DSGetShader;
		public void* DSGetSamplers;
		public void* DSGetConstantBuffers;
		public void* CSGetShaderResources;
		public void* CSGetUnorderedAccessViews;
		public void* CSGetShader;
		public void* CSGetSamplers;
		public void* CSGetConstantBuffers;
		public void* ClearState;
		public void* Flush;
		public new void* GetType;
		public void* GetContextFlags;
		public void* FinishCommandList;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDevice {
		public ID3D11VideoDeviceVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDeviceVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* CreateVideoDecoder;
		public void* CreateVideoProcessor;
		public void* CreateAuthenticatedChannel;
		public void* CreateCryptoSession;
		public void* CreateVideoDecoderOutputView;
		public void* CreateVideoProcessorInputView;
		public void* CreateVideoProcessorOutputView;
		public void* CreateVideoProcessorEnumerator;
		public void* GetVideoDecoderProfileCount;
		public void* GetVideoDecoderProfile;
		public void* CheckVideoDecoderFormat;
		public void* GetVideoDecoderConfigCount;
		public void* GetVideoDecoderConfig;
		public void* GetContentProtectionCaps;
		public void* CheckCryptoKeyExchange;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoContext {
		public ID3D11VideoContextVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoContextVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public void* GetDecoderBuffer;
		public void* ReleaseDecoderBuffer;
		public void* DecoderBeginFrame;
		public void* DecoderEndFrame;
		public void* SubmitDecoderBuffers;
		public void* DecoderExtension;
		public void* VideoProcessorSetOutputTargetRect;
		public void* VideoProcessorSetOutputBackgroundColor;
		public void* VideoProcessorSetOutputColorSpace;
		public void* VideoProcessorSetOutputAlphaFillMode;
		public void* VideoProcessorSetOutputConstriction;
		public void* VideoProcessorSetOutputStereoMode;
		public void* VideoProcessorSetOutputExtension;
		public void* VideoProcessorGetOutputTargetRect;
		public void* VideoProcessorGetOutputBackgroundColor;
		public void* VideoProcessorGetOutputColorSpace;
		public void* VideoProcessorGetOutputAlphaFillMode;
		public void* VideoProcessorGetOutputConstriction;
		public void* VideoProcessorGetOutputStereoMode;
		public void* VideoProcessorGetOutputExtension;
		public void* VideoProcessorSetStreamFrameFormat;
		public void* VideoProcessorSetStreamColorSpace;
		public void* VideoProcessorSetStreamOutputRate;
		public void* VideoProcessorSetStreamSourceRect;
		public void* VideoProcessorSetStreamDestRect;
		public void* VideoProcessorSetStreamAlpha;
		public void* VideoProcessorSetStreamPalette;
		public void* VideoProcessorSetStreamPixelAspectRatio;
		public void* VideoProcessorSetStreamLumaKey;
		public void* VideoProcessorSetStreamStereoFormat;
		public void* VideoProcessorSetStreamAutoProcessingMode;
		public void* VideoProcessorSetStreamFilter;
		public void* VideoProcessorSetStreamExtension;
		public void* VideoProcessorGetStreamFrameFormat;
		public void* VideoProcessorGetStreamColorSpace;
		public void* VideoProcessorGetStreamOutputRate;
		public void* VideoProcessorGetStreamSourceRect;
		public void* VideoProcessorGetStreamDestRect;
		public void* VideoProcessorGetStreamAlpha;
		public void* VideoProcessorGetStreamPalette;
		public void* VideoProcessorGetStreamPixelAspectRatio;
		public void* VideoProcessorGetStreamLumaKey;
		public void* VideoProcessorGetStreamStereoFormat;
		public void* VideoProcessorGetStreamAutoProcessingMode;
		public void* VideoProcessorGetStreamFilter;
		public void* VideoProcessorGetStreamExtension;
		public void* VideoProcessorBlt;
		public void* NegotiateCryptoSessionKeyExchange;
		public void* EncryptionBlt;
		public void* DecryptionBlt;
		public void* StartSessionKeyRefresh;
		public void* FinishSessionKeyRefresh;
		public void* GetEncryptionBltKey;
		public void* NegotiateAuthenticatedChannelKeyExchange;
		public void* QueryAuthenticatedChannel;
		public void* ConfigureAuthenticatedChannel;
		public void* VideoProcessorSetStreamRotation;
		public void* VideoProcessorGetStreamRotation;
	}

	/// <summary>
	/// D3D11 frame descriptor for pool allocation.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVD3D11FrameDescriptor {
		/// <summary>
		/// The texture in which the frame is located. The reference count is managed by the AVBufferRef, and destroying the reference will release the interface.
		/// </summary>
		public ID3D11Texture2D* Texture;
		/// <summary>
		/// The index into the array texture element representing the frame, or 0 if the texture is not an array texture.
		/// </summary>
		public long Index;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11Texture2D {
		public ID3D11Texture2DVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11Texture2DVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public new void* GetType;
		public void* SetEvictionPriority;
		public void* GetEvictionPriority;
		public void* GetDesc;
	}

	/// <summary>
	/// This struct is allocated as AVHWFramesContext.hwctx
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVD3D11VAFramesContext {
		/// <summary>
		/// The canonical texture used for pool allocation. If this is set to NULL on init, the hwframes implementation will allocate and set an array texture if initial_pool_size &gt; 0.
		/// </summary>
		public ID3D11Texture2D* Texture;
		/// <summary>
		/// D3D11_TEXTURE2D_DESC.BindFlags used for texture creation. The user must at least set D3D11_BIND_DECODER if the frames context is to be used for video decoding. This field is ignored/invalid if a user-allocated texture is provided.
		/// </summary>
		public uint BindFlags;
		/// <summary>
		/// D3D11_TEXTURE2D_DESC.MiscFlags used for texture creation. This field is ignored/invalid if a user-allocated texture is provided.
		/// </summary>
		public uint MiscFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SwrContext {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SwsVector {
		/// <summary>
		/// pointer to the list of coefficients
		/// </summary>
		public double* Coeff;
		/// <summary>
		/// number of coefficients in the vector
		/// </summary>
		public int Length;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SwsFilter {
		public SwsVector* LumH;
		public SwsVector* LumV;
		public SwsVector* ChrH;
		public SwsVector* ChrV;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SwsContext {
	}

	/// <summary>
	/// Callback for checking whether to abort blocking functions. AVERROR_EXIT is returned in this case by the interrupted function. During blocking operations, callback is called with opaque as parameter. If the callback returns 1, the blocking operation will be aborted.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVIOInterruptCB {
		public AVIOInterruptCB_Callback_Func Callback;
		public void* Opaque;
	}

	/// <summary>
	/// Bytestream IO Context. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVIOContext) must not be used outside libav*.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVIOContext {
		/// <summary>
		/// A class for private options.
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// Start of the buffer.
		/// </summary>
		public byte* Buffer;
		/// <summary>
		/// Maximum buffer size
		/// </summary>
		public int BufferSize;
		/// <summary>
		/// Current position in the buffer
		/// </summary>
		public byte* BufPtr;
		/// <summary>
		/// End of the data, may be less than buffer+buffer_size if the read function returned less data than requested, e.g. for streams where no more data has been received yet.
		/// </summary>
		public byte* BufEnd;
		/// <summary>
		/// A private pointer, passed to the read/write/seek/... functions.
		/// </summary>
		public void* Opaque;
		public AVIOContext_ReadPacket_Func ReadPacket;
		public AVIOContext_WritePacket_Func WritePacket;
		public AVIOContext_Seek_Func Seek;
		/// <summary>
		/// position in the file of the current buffer
		/// </summary>
		public long Pos;
		/// <summary>
		/// true if eof reached
		/// </summary>
		public int EofReached;
		/// <summary>
		/// true if open for writing
		/// </summary>
		public int WriteFlag;
		public int MaxPacketSize;
		public ulong Checksum;
		public byte* ChecksumPtr;
		public AVIOContext_UpdateChecksum_Func UpdateChecksum;
		/// <summary>
		/// contains the error code or 0 if no error happened
		/// </summary>
		public int Error;
		/// <summary>
		/// Pause or resume playback for network streaming protocols - e.g. MMS.
		/// </summary>
		public AVIOContext_ReadPause_Func ReadPause;
		/// <summary>
		/// Seek to a given timestamp in stream with the specified stream_index. Needed for some network streaming protocols which don&apos;t support seeking to byte position.
		/// </summary>
		public AVIOContext_ReadSeek_Func ReadSeek;
		/// <summary>
		/// A combination of AVIO_SEEKABLE_ flags or 0 when the stream is not seekable.
		/// </summary>
		public int Seekable;
		/// <summary>
		/// max filesize, used to limit allocations This field is internal to libavformat and access from outside is not allowed.
		/// </summary>
		public long Maxsize;
		/// <summary>
		/// avio_read and avio_write should if possible be satisfied directly instead of going through a buffer, and avio_seek will always call the underlying seek function directly.
		/// </summary>
		public int Direct;
		/// <summary>
		/// Bytes read statistic This field is internal to libavformat and access from outside is not allowed.
		/// </summary>
		public long BytesRead;
		/// <summary>
		/// seek statistic This field is internal to libavformat and access from outside is not allowed.
		/// </summary>
		public int SeekCount;
		/// <summary>
		/// writeout statistic This field is internal to libavformat and access from outside is not allowed.
		/// </summary>
		public int WriteoutCount;
		/// <summary>
		/// Original buffer size used internally after probing and ensure seekback to reset the buffer size This field is internal to libavformat and access from outside is not allowed.
		/// </summary>
		public int OrigBufferSize;
		/// <summary>
		/// Threshold to favor readahead over seek. This is current internal only, do not use from outside.
		/// </summary>
		public int ShortSeekThreshold;
		/// <summary>
		/// &apos;,&apos; separated list of allowed protocols.
		/// </summary>
		public byte* ProtocolWhitelist;
		/// <summary>
		/// &apos;,&apos; separated list of disallowed protocols.
		/// </summary>
		public byte* ProtocolBlacklist;
		/// <summary>
		/// A callback that is used instead of write_packet.
		/// </summary>
		public AVIOContext_WriteDataType_Func WriteDataType;
		/// <summary>
		/// If set, don&apos;t call write_data_type separately for AVIO_DATA_MARKER_BOUNDARY_POINT, but ignore them and treat them as AVIO_DATA_MARKER_UNKNOWN (to avoid needlessly small chunks of data returned from the callback).
		/// </summary>
		public int IgnoreBoundaryPoint;
		/// <summary>
		/// Internal, not meant to be used from outside of AVIOContext.
		/// </summary>
		public AVIODataMarkerType CurrentType;
		public long LastTime;
		/// <summary>
		/// A callback that is used instead of short_seek_threshold. This is current internal only, do not use from outside.
		/// </summary>
		public AVIOContext_ShortSeekGet_Func ShortSeekGet;
		public long Written;
		/// <summary>
		/// Maximum reached position before a backward seek in the write buffer, used keeping track of already written data for a later flush.
		/// </summary>
		public byte* BufPtrMax;
		/// <summary>
		/// Try to buffer at least this amount of data before flushing it
		/// </summary>
		public int MinPacketSize;
	}

	/// <summary>
	/// Structure describes device capabilities.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDeviceCapabilitiesQuery {
		public AVClass* AvClass;
		public AVFormatContext* DeviceContext;
		public AVCodecID Codec;
		public AVSampleFormat SampleFormat;
		public AVPixelFormat PixelFormat;
		public int SampleRate;
		public int Channels;
		public long ChannelLayout;
		public int WindowWidth;
		public int WindowHeight;
		public int FrameWidth;
		public int FrameHeight;
		public AVRational Fps;
	}

	/// <summary>
	/// List of devices.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDeviceInfoList {
		/// <summary>
		/// list of autodetected devices
		/// </summary>
		public AVDeviceInfo** Devices;
		/// <summary>
		/// number of autodetected devices
		/// </summary>
		public int NbDevices;
		/// <summary>
		/// index of default device or -1 if no default
		/// </summary>
		public int DefaultDevice;
	}

	/// <summary>
	/// @{
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVInputFormat {
		/// <summary>
		/// A comma separated list of short names for the format. New names may be appended with a minor bump.
		/// </summary>
		public byte* Name;
		/// <summary>
		/// Descriptive name for the format, meant to be more human-readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.
		/// </summary>
		public byte* LongName;
		/// <summary>
		/// Can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_SHOW_IDS, AVFMT_GENERIC_INDEX, AVFMT_TS_DISCONT, AVFMT_NOBINSEARCH, AVFMT_NOGENSEARCH, AVFMT_NO_BYTE_SEEK, AVFMT_SEEK_TO_PTS.
		/// </summary>
		public int Flags;
		/// <summary>
		/// If extensions are defined, then no probe is done. You should usually not use extension format guessing because it is not reliable enough
		/// </summary>
		public byte* Extensions;
		public AVCodecTag** CodecTag;
		/// <summary>
		/// AVClass for the private context
		/// </summary>
		public AVClass* PrivClass;
		/// <summary>
		/// Comma-separated list of mime types. It is used check for matching mime types while probing.
		/// </summary>
		public byte* MimeType;
		/// <summary>
		/// *************************************************************** No fields below this line are part of the public API. They may not be used outside of libavformat and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public AVInputFormat* Next;
		/// <summary>
		/// Raw demuxers store their codec ID here.
		/// </summary>
		public int RawCodecId;
		/// <summary>
		/// Size of private data so that it can be allocated in the wrapper.
		/// </summary>
		public int PrivDataSize;
		/// <summary>
		/// Tell if a given file has a chance of being parsed as this format. The buffer provided is guaranteed to be AVPROBE_PADDING_SIZE bytes big so you do not have to check for that unless you need more.
		/// </summary>
		public AVInputFormat_ReadProbe_Func ReadProbe;
		/// <summary>
		/// Read the format header and initialize the AVFormatContext structure. Return 0 if OK. &apos;avformat_new_stream&apos; should be called to create new streams.
		/// </summary>
		public AVInputFormat_ReadHeader_Func ReadHeader;
		/// <summary>
		/// Read one packet and put it in &apos;pkt&apos;. pts and flags are also set. &apos;avformat_new_stream&apos; can be called only if the flag AVFMTCTX_NOHEADER is used and only in the calling thread (not in a background thread).
		/// </summary>
		public AVInputFormat_ReadPacket_Func ReadPacket;
		/// <summary>
		/// Close the stream. The AVFormatContext and AVStreams are not freed by this function
		/// </summary>
		public AVInputFormat_ReadClose_Func ReadClose;
		/// <summary>
		/// Seek to a given timestamp relative to the frames in stream component stream_index.
		/// </summary>
		public AVInputFormat_ReadSeek_Func ReadSeek;
		/// <summary>
		/// Get the next timestamp in stream[stream_index].time_base units.
		/// </summary>
		public AVInputFormat_ReadTimestamp_Func ReadTimestamp;
		/// <summary>
		/// Start/resume playing - only meaningful if using a network-based format (RTSP).
		/// </summary>
		public AVInputFormat_ReadPlay_Func ReadPlay;
		/// <summary>
		/// Pause playing - only meaningful if using a network-based format (RTSP).
		/// </summary>
		public AVInputFormat_ReadPause_Func ReadPause;
		/// <summary>
		/// Seek to timestamp ts. Seeking will be done so that the point from which all active streams can be presented successfully will be closest to ts and within min/max_ts. Active streams are all streams that have AVStream.discard &lt; AVDISCARD_ALL.
		/// </summary>
		public AVInputFormat_ReadSeek2_Func ReadSeek2;
		/// <summary>
		/// Returns device list with it properties.
		/// </summary>
		public AVInputFormat_GetDeviceList_Func GetDeviceList;
		/// <summary>
		/// Initialize device capabilities submodule.
		/// </summary>
		public AVInputFormat_CreateDeviceCapabilities_Func CreateDeviceCapabilities;
		/// <summary>
		/// Free device capabilities submodule.
		/// </summary>
		public AVInputFormat_FreeDeviceCapabilities_Func FreeDeviceCapabilities;
	}

	/// <summary>
	/// Format I/O context. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVFormatContext) must not be used outside libav*, use avformat_alloc_context() to create an AVFormatContext.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFormatContext {
		/// <summary>
		/// A class for logging and Exports (de)muxer private options if they exist.
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// The input container format.
		/// </summary>
		public AVInputFormat* Iformat;
		/// <summary>
		/// The output container format.
		/// </summary>
		public AVOutputFormat* Oformat;
		/// <summary>
		/// Format private data. This is an AVOptions-enabled struct if and only if iformat/oformat.priv_class is not NULL.
		/// </summary>
		public void* PrivData;
		/// <summary>
		/// I/O context.
		/// </summary>
		public AVIOContext* Pb;
		/// <summary>
		/// Flags signalling stream properties. A combination of AVFMTCTX_*. Set by libavformat.
		/// </summary>
		public AVFmtctx CtxFlags;
		/// <summary>
		/// Number of elements in AVFormatContext.streams.
		/// </summary>
		public uint NbStreams;
		/// <summary>
		/// A list of all streams in the file. New streams are created with avformat_new_stream().
		/// </summary>
		public AVStream** Streams;
		/// <summary>
		/// input or output filename
		/// </summary>
		public fixed byte Filename[1024];
		/// <summary>
		/// input or output URL. Unlike the old filename field, this field has no length restriction.
		/// </summary>
		public byte* Url;
		/// <summary>
		/// Position of the first frame of the component, in AV_TIME_BASE fractional seconds. NEVER set this value directly: It is deduced from the AVStream values.
		/// </summary>
		public long StartTime;
		/// <summary>
		/// Duration of the stream, in AV_TIME_BASE fractional seconds. Only set this value if you know none of the individual stream durations and also do not set any of them. This is deduced from the AVStream values if not set.
		/// </summary>
		public long Duration;
		/// <summary>
		/// Total stream bitrate in bit/s, 0 if not available. Never set it directly if the file_size and the duration are known as FFmpeg can compute it automatically.
		/// </summary>
		public long BitRate;
		public uint PacketSize;
		public int MaxDelay;
		/// <summary>
		/// Flags modifying the (de)muxer behaviour. A combination of AVFMT_FLAG_*. Set by the user before avformat_open_input() / avformat_write_header().
		/// </summary>
		public AVFmtFlag Flags;
		/// <summary>
		/// Maximum size of the data read from input for determining the input container format. Demuxing only, set by the caller before avformat_open_input().
		/// </summary>
		public long Probesize;
		/// <summary>
		/// Maximum duration (in AV_TIME_BASE units) of the data read from input in avformat_find_stream_info(). Demuxing only, set by the caller before avformat_find_stream_info(). Can be set to 0 to let avformat choose using a heuristic.
		/// </summary>
		public long MaxAnalyzeDuration;
		public byte* Key;
		public int Keylen;
		public uint NbPrograms;
		public AVProgram** Programs;
		/// <summary>
		/// Forced video codec_id. Demuxing: Set by user.
		/// </summary>
		public AVCodecID VideoCodecId;
		/// <summary>
		/// Forced audio codec_id. Demuxing: Set by user.
		/// </summary>
		public AVCodecID AudioCodecId;
		/// <summary>
		/// Forced subtitle codec_id. Demuxing: Set by user.
		/// </summary>
		public AVCodecID SubtitleCodecId;
		/// <summary>
		/// Maximum amount of memory in bytes to use for the index of each stream. If the index exceeds this size, entries will be discarded as needed to maintain a smaller size. This can lead to slower or less accurate seeking (depends on demuxer). Demuxers for which a full in-memory index is mandatory will ignore this. - muxing: unused - demuxing: set by user
		/// </summary>
		public uint MaxIndexSize;
		/// <summary>
		/// Maximum amount of memory in bytes to use for buffering frames obtained from realtime capture devices.
		/// </summary>
		public uint MaxPictureBuffer;
		/// <summary>
		/// Number of chapters in AVChapter array. When muxing, chapters are normally written in the file header, so nb_chapters should normally be initialized before write_header is called. Some muxers (e.g. mov and mkv) can also write chapters in the trailer. To write chapters in the trailer, nb_chapters must be zero when write_header is called and non-zero when write_trailer is called. - muxing: set by user - demuxing: set by libavformat
		/// </summary>
		public uint NbChapters;
		public AVChapter** Chapters;
		/// <summary>
		/// Metadata that applies to the whole file.
		/// </summary>
		public AVDictionary* Metadata;
		/// <summary>
		/// Start time of the stream in real world time, in microseconds since the Unix epoch (00:00 1st January 1970). That is, pts=0 in the stream was captured at this real world time. - muxing: Set by the caller before avformat_write_header(). If set to either 0 or AV_NOPTS_VALUE, then the current wall-time will be used. - demuxing: Set by libavformat. AV_NOPTS_VALUE if unknown. Note that the value may become known after some number of frames have been received.
		/// </summary>
		public long StartTimeRealtime;
		/// <summary>
		/// The number of frames used for determining the framerate in avformat_find_stream_info(). Demuxing only, set by the caller before avformat_find_stream_info().
		/// </summary>
		public int FpsProbeSize;
		/// <summary>
		/// Error recognition; higher values will detect more errors but may misdetect some more or less valid parts as errors. Demuxing only, set by the caller before avformat_open_input().
		/// </summary>
		public int ErrorRecognition;
		/// <summary>
		/// Custom interrupt callbacks for the I/O layer.
		/// </summary>
		public AVIOInterruptCB InterruptCallback;
		/// <summary>
		/// Flags to enable debugging.
		/// </summary>
		public int Debug;
		/// <summary>
		/// Maximum buffering duration for interleaving.
		/// </summary>
		public long MaxInterleaveDelta;
		/// <summary>
		/// Allow non-standard and experimental extension
		/// </summary>
		public int StrictStdCompliance;
		/// <summary>
		/// Flags for the user to detect events happening on the file. Flags must be cleared by the user once the event has been handled. A combination of AVFMT_EVENT_FLAG_*.
		/// </summary>
		public int EventFlags;
		/// <summary>
		/// Maximum number of packets to read while waiting for the first timestamp. Decoding only.
		/// </summary>
		public int MaxTsProbe;
		/// <summary>
		/// Avoid negative timestamps during muxing. Any value of the AVFMT_AVOID_NEG_TS_* constants. Note, this only works when using av_interleaved_write_frame. (interleave_packet_per_dts is in use) - muxing: Set by user - demuxing: unused
		/// </summary>
		public int AvoidNegativeTs;
		/// <summary>
		/// Transport stream id. This will be moved into demuxer private options. Thus no API/ABI compatibility
		/// </summary>
		public int TsId;
		/// <summary>
		/// Audio preload in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused
		/// </summary>
		public int AudioPreload;
		/// <summary>
		/// Max chunk time in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused
		/// </summary>
		public int MaxChunkDuration;
		/// <summary>
		/// Max chunk size in bytes Note, not all formats support this and unpredictable things may happen if it is used when not supported. - encoding: Set by user - decoding: unused
		/// </summary>
		public int MaxChunkSize;
		/// <summary>
		/// forces the use of wallclock timestamps as pts/dts of packets This has undefined results in the presence of B frames. - encoding: unused - decoding: Set by user
		/// </summary>
		public int UseWallclockAsTimestamps;
		/// <summary>
		/// avio flags, used to force AVIO_FLAG_DIRECT. - encoding: unused - decoding: Set by user
		/// </summary>
		public int AvioFlags;
		/// <summary>
		/// The duration field can be estimated through various ways, and this field can be used to know how the duration was estimated. - encoding: unused - decoding: Read by user
		/// </summary>
		public AVDurationEstimationMethod DurationEstimationMethod;
		/// <summary>
		/// Skip initial bytes when opening stream - encoding: unused - decoding: Set by user
		/// </summary>
		public long SkipInitialBytes;
		/// <summary>
		/// Correct single timestamp overflows - encoding: unused - decoding: Set by user
		/// </summary>
		public uint CorrectTsOverflow;
		/// <summary>
		/// Force seeking to any (also non key) frames. - encoding: unused - decoding: Set by user
		/// </summary>
		public int Seek2any;
		/// <summary>
		/// Flush the I/O context after each packet. - encoding: Set by user - decoding: unused
		/// </summary>
		public int FlushPackets;
		/// <summary>
		/// format probing score. The maximal score is AVPROBE_SCORE_MAX, its set when the demuxer probes the format. - encoding: unused - decoding: set by avformat, read by user
		/// </summary>
		public int ProbeScore;
		/// <summary>
		/// number of bytes to read maximally to identify format. - encoding: unused - decoding: set by user
		/// </summary>
		public int FormatProbesize;
		/// <summary>
		/// &apos;,&apos; separated list of allowed decoders. If NULL then all are allowed - encoding: unused - decoding: set by user
		/// </summary>
		public byte* CodecWhitelist;
		/// <summary>
		/// &apos;,&apos; separated list of allowed demuxers. If NULL then all are allowed - encoding: unused - decoding: set by user
		/// </summary>
		public byte* FormatWhitelist;
		/// <summary>
		/// An opaque field for libavformat internal usage. Must not be accessed in any way by callers.
		/// </summary>
		public AVFormatInternal* Internal;
		/// <summary>
		/// IO repositioned flag. This is set by avformat when the underlaying IO context read pointer is repositioned, for example when doing byte based seeking. Demuxers can use the flag to detect such changes.
		/// </summary>
		public int IoRepositioned;
		/// <summary>
		/// Forced video codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user
		/// </summary>
		public AVCodec* VideoCodec;
		/// <summary>
		/// Forced audio codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user
		/// </summary>
		public AVCodec* AudioCodec;
		/// <summary>
		/// Forced subtitle codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user
		/// </summary>
		public AVCodec* SubtitleCodec;
		/// <summary>
		/// Forced data codec. This allows forcing a specific decoder, even when there are multiple with the same codec_id. Demuxing: Set by user
		/// </summary>
		public AVCodec* DataCodec;
		/// <summary>
		/// Number of bytes to be written as padding in a metadata header. Demuxing: Unused. Muxing: Set by user via av_format_set_metadata_header_padding.
		/// </summary>
		public int MetadataHeaderPadding;
		/// <summary>
		/// User data. This is a place for some private data of the user.
		/// </summary>
		public void* Opaque;
		/// <summary>
		/// Callback used by devices to communicate with application.
		/// </summary>
		public AVFormatContext_ControlMessageCb_Func ControlMessageCb;
		/// <summary>
		/// Output timestamp offset, in microseconds. Muxing: set by user
		/// </summary>
		public long OutputTsOffset;
		/// <summary>
		/// dump format separator. can be &quot;, &quot; or &quot; &quot; or anything else - muxing: Set by user. - demuxing: Set by user.
		/// </summary>
		public byte* DumpSeparator;
		/// <summary>
		/// Forced Data codec_id. Demuxing: Set by user.
		/// </summary>
		public AVCodecID DataCodecId;
		/// <summary>
		/// Called to open further IO contexts when needed for demuxing.
		/// </summary>
		public AVFormatContext_OpenCb_Func OpenCb;
		/// <summary>
		/// &apos;,&apos; separated list of allowed protocols. - encoding: unused - decoding: set by user
		/// </summary>
		public byte* ProtocolWhitelist;
		/// <summary>
		/// A callback for opening new IO streams.
		/// </summary>
		public AVFormatContext_IoOpen_Func IoOpen;
		/// <summary>
		/// A callback for closing the streams opened with AVFormatContext.io_open().
		/// </summary>
		public AVFormatContext_IoClose_Func IoClose;
		/// <summary>
		/// &apos;,&apos; separated list of disallowed protocols. - encoding: unused - decoding: set by user
		/// </summary>
		public byte* ProtocolBlacklist;
		/// <summary>
		/// The maximum number of streams. - encoding: unused - decoding: set by user
		/// </summary>
		public int MaxStreams;
		/// <summary>
		/// Skip duration calcuation in estimate_timings_from_pts. - encoding: unused - decoding: set by user
		/// </summary>
		public int SkipEstimateDurationFromPts;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecTag {
	}

	/// <summary>
	/// @{
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe partial struct AVOutputFormat {
		public byte* Name;
		/// <summary>
		/// Descriptive name for the format, meant to be more human-readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.
		/// </summary>
		public byte* LongName;
		public byte* MimeType;
		/// <summary>
		/// comma-separated filename extensions
		/// </summary>
		public byte* Extensions;
		/// <summary>
		/// default audio codec
		/// </summary>
		public AVCodecID AudioCodec;
		/// <summary>
		/// default video codec
		/// </summary>
		public AVCodecID VideoCodec;
		/// <summary>
		/// default subtitle codec
		/// </summary>
		public AVCodecID SubtitleCodec;
		/// <summary>
		/// can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_GLOBALHEADER, AVFMT_NOTIMESTAMPS, AVFMT_VARIABLE_FPS, AVFMT_NODIMENSIONS, AVFMT_NOSTREAMS, AVFMT_ALLOW_FLUSH, AVFMT_TS_NONSTRICT, AVFMT_TS_NEGATIVE
		/// </summary>
		public AVFmt Flags;
		/// <summary>
		/// List of supported codec_id-codec_tag pairs, ordered by &quot;better choice first&quot;. The arrays are all terminated by AV_CODEC_ID_NONE.
		/// </summary>
		public AVCodecTag** CodecTag;
		/// <summary>
		/// AVClass for the private context
		/// </summary>
		public AVClass* PrivClass;
		/// <summary>
		/// *************************************************************** No fields below this line are part of the public API. They may not be used outside of libavformat and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public AVOutputFormat* Next;
		/// <summary>
		/// size of private data so that it can be allocated in the wrapper
		/// </summary>
		public int PrivDataSize;
		public AVOutputFormat_WriteHeader_Func WriteHeader;
		/// <summary>
		/// Write a packet. If AVFMT_ALLOW_FLUSH is set in flags, pkt can be NULL in order to flush data buffered in the muxer. When flushing, return 0 if there still is more data to flush, or 1 if everything was flushed and there is no more buffered data.
		/// </summary>
		public AVOutputFormat_WritePacket_Func WritePacket;
		public AVOutputFormat_WriteTrailer_Func WriteTrailer;
		/// <summary>
		/// Currently only used to set pixel format if not YUV420P.
		/// </summary>
		public AVOutputFormat_InterleavePacket_Func InterleavePacket;
		/// <summary>
		/// Test if the given codec can be stored in this container.
		/// </summary>
		public AVOutputFormat_QueryCodec_Func QueryCodec;
		public AVOutputFormat_GetOutputTimestamp_Func GetOutputTimestamp;
		/// <summary>
		/// Allows sending messages from application to device.
		/// </summary>
		public AVOutputFormat_ControlMessage_Func ControlMessage;
		/// <summary>
		/// Write an uncoded AVFrame.
		/// </summary>
		public AVOutputFormat_WriteUncodedFrame_Func WriteUncodedFrame;
		/// <summary>
		/// Returns device list with it properties.
		/// </summary>
		public AVOutputFormat_GetDeviceList_Func GetDeviceList;
		/// <summary>
		/// Initialize device capabilities submodule.
		/// </summary>
		public AVOutputFormat_CreateDeviceCapabilities_Func CreateDeviceCapabilities;
		/// <summary>
		/// Free device capabilities submodule.
		/// </summary>
		public AVOutputFormat_FreeDeviceCapabilities_Func FreeDeviceCapabilities;
		/// <summary>
		/// default data codec
		/// </summary>
		public AVCodecID DataCodec;
		/// <summary>
		/// Initialize format. May allocate data here, and set any AVFormatContext or AVStream parameters that need to be set before packets are sent. This method must not write output.
		/// </summary>
		public AVOutputFormat_Init_Func Init;
		/// <summary>
		/// Deinitialize format. If present, this is called whenever the muxer is being destroyed, regardless of whether or not the header has been written.
		/// </summary>
		public AVOutputFormat_Deinit_Func Deinit;
		/// <summary>
		/// Set up any necessary bitstream filtering and extract any extra data needed for the global header. Return 0 if more packets from this stream must be checked; 1 if not.
		/// </summary>
		public AVOutputFormat_CheckBitstream_Func CheckBitstream;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFormatInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVChapter {
		/// <summary>
		/// unique ID to identify the chapter
		/// </summary>
		public int Id;
		/// <summary>
		/// time base in which the start/end timestamps are specified
		/// </summary>
		public AVRational TimeBase;
		/// <summary>
		/// chapter start/end time in time_base units
		/// </summary>
		public long Start;
		/// <summary>
		/// chapter start/end time in time_base units
		/// </summary>
		public long End;
		public AVDictionary* Metadata;
	}

	/// <summary>
	/// New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVProgram) must not be used outside libav*.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVProgram {
		public int Id;
		public int Flags;
		/// <summary>
		/// selects which program to discard and which to feed to the caller
		/// </summary>
		public AVDiscard Discard;
		public uint* StreamIndex;
		public uint NbStreamIndexes;
		public AVDictionary* Metadata;
		public int ProgramNum;
		public int PmtPid;
		public int PcrPid;
		public int PmtVersion;
		/// <summary>
		/// *************************************************************** All fields below this line are not part of the public API. They may not be used outside of libavformat and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public long StartTime;
		public long EndTime;
		/// <summary>
		/// reference dts for wrap detection
		/// </summary>
		public long PtsWrapReference;
		/// <summary>
		/// behavior on wrap detection
		/// </summary>
		public int PtsWrapBehavior;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPacketList {
		public AVPacket Pkt;
		public AVPacketList* Next;
	}

	/// <summary>
	/// Stream information used internally by avformat_find_stream_info()
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVStream_Info {
		public long LastDts;
		public long DurationGcd;
		public int DurationCount;
		public long RfpsDurationSum;
		public double_arrayOfArray2* DurationError;
		public long CodecInfoDuration;
		public long CodecInfoDurationFields;
		public int FrameDelayEvidence;
		/// <summary>
		/// 0 -&gt; decoder has not been searched for yet. &gt;0 -&gt; decoder found &lt;0 -&gt; decoder with codec_id == -found_decoder has not been found
		/// </summary>
		public int FoundDecoder;
		public long LastDuration;
		/// <summary>
		/// Those are used for average framerate estimation.
		/// </summary>
		public long FpsFirstDts;
		public int FpsFirstDtsIdx;
		public long FpsLastDts;
		public int FpsLastDtsIdx;
	}

	/// <summary>
	/// Stream structure. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. sizeof(AVStream) must not be used outside libav*.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVStream {
		/// <summary>
		/// stream index in AVFormatContext
		/// </summary>
		public int Index;
		/// <summary>
		/// Format-specific stream ID. decoding: set by libavformat encoding: set by the user, replaced by libavformat if left unset
		/// </summary>
		public int Id;
		public AVCodecContext* Codec;
		public void* PrivData;
		/// <summary>
		/// This is the fundamental unit of time (in seconds) in terms of which frame timestamps are represented.
		/// </summary>
		public AVRational TimeBase;
		/// <summary>
		/// Decoding: pts of the first frame of the stream in presentation order, in stream time base. Only set this if you are absolutely 100% sure that the value you set it to really is the pts of the first frame. This may be undefined (AV_NOPTS_VALUE).
		/// </summary>
		public long StartTime;
		/// <summary>
		/// Decoding: duration of the stream, in stream time base. If a source file does not specify a duration, but does specify a bitrate, this value will be estimated from bitrate and file size.
		/// </summary>
		public long Duration;
		/// <summary>
		/// number of frames in this stream if known or 0
		/// </summary>
		public long NbFrames;
		/// <summary>
		/// AV_DISPOSITION_* bit field
		/// </summary>
		public int Disposition;
		/// <summary>
		/// Selects which packets can be discarded at will and do not need to be demuxed.
		/// </summary>
		public AVDiscard Discard;
		/// <summary>
		/// sample aspect ratio (0 if unknown) - encoding: Set by user. - decoding: Set by libavformat.
		/// </summary>
		public AVRational SampleAspectRatio;
		public AVDictionary* Metadata;
		/// <summary>
		/// Average framerate
		/// </summary>
		public AVRational AvgFrameRate;
		/// <summary>
		/// For streams with AV_DISPOSITION_ATTACHED_PIC disposition, this packet will contain the attached picture.
		/// </summary>
		public AVPacket AttachedPic;
		/// <summary>
		/// An array of side data that applies to the whole stream (i.e. the container does not allow it to change between packets).
		/// </summary>
		public AVPacketSideData* SideData;
		/// <summary>
		/// The number of elements in the AVStream.side_data array.
		/// </summary>
		public int NbSideData;
		/// <summary>
		/// Flags for the user to detect events happening on the stream. Flags must be cleared by the user once the event has been handled. A combination of AVSTREAM_EVENT_FLAG_*.
		/// </summary>
		public int EventFlags;
		/// <summary>
		/// Real base framerate of the stream. This is the lowest framerate with which all timestamps can be represented accurately (it is the least common multiple of all framerates in the stream). Note, this value is just a guess! For example, if the time base is 1/90000 and all frames have either approximately 3600 or 1800 timer ticks, then r_frame_rate will be 50/1.
		/// </summary>
		public AVRational RFrameRate;
		/// <summary>
		/// String containing pairs of key and values describing recommended encoder configuration. Pairs are separated by &apos;,&apos;. Keys are separated from values by &apos;=&apos;.
		/// </summary>
		public byte* RecommendedEncoderConfiguration;
		/// <summary>
		/// Codec parameters associated with this stream. Allocated and freed by libavformat in avformat_new_stream() and avformat_free_context() respectively.
		/// </summary>
		public AVCodecParameters* Codecpar;
		public AVStream_Info* Info;
		/// <summary>
		/// number of bits in pts (used for wrapping control)
		/// </summary>
		public int PtsWrapBits;
		/// <summary>
		/// Timestamp corresponding to the last dts sync point.
		/// </summary>
		public long FirstDts;
		public long CurDts;
		public long LastIpPts;
		public int LastIpDuration;
		/// <summary>
		/// Number of packets to buffer for codec probing
		/// </summary>
		public int ProbePackets;
		/// <summary>
		/// Number of frames that have been demuxed during avformat_find_stream_info()
		/// </summary>
		public int CodecInfoNbFrames;
		public AVStreamParseType NeedParsing;
		public AVCodecParserContext* Parser;
		/// <summary>
		/// last packet in packet_buffer for this stream when muxing.
		/// </summary>
		public AVPacketList* LastInPacketBuffer;
		public AVProbeData ProbeData;
		public long_array17 PtsBuffer;
		/// <summary>
		/// Only used if the format does not support seeking natively.
		/// </summary>
		public AVIndexEntry* IndexEntries;
		public int NbIndexEntries;
		public uint IndexEntriesAllocatedSize;
		/// <summary>
		/// Stream Identifier This is the MPEG-TS stream identifier +1 0 means unknown
		/// </summary>
		public int StreamIdentifier;
		/// <summary>
		/// Details of the MPEG-TS program which created this stream.
		/// </summary>
		public int ProgramNum;
		public int PmtVersion;
		public int PmtStreamIdx;
		public long InterleaverChunkSize;
		public long InterleaverChunkDuration;
		/// <summary>
		/// stream probing state -1 -&gt; probing finished 0 -&gt; no probing requested rest -&gt; perform probing with request_probe being the minimum score to accept. NOT PART OF PUBLIC API
		/// </summary>
		public int RequestProbe;
		/// <summary>
		/// Indicates that everything up to the next keyframe should be discarded.
		/// </summary>
		public int SkipToKeyframe;
		/// <summary>
		/// Number of samples to skip at the start of the frame decoded from the next packet.
		/// </summary>
		public int SkipSamples;
		/// <summary>
		/// If not 0, the number of samples that should be skipped from the start of the stream (the samples are removed from packets with pts==0, which also assumes negative timestamps do not happen). Intended for use with formats such as mp3 with ad-hoc gapless audio support.
		/// </summary>
		public long StartSkipSamples;
		/// <summary>
		/// If not 0, the first audio sample that should be discarded from the stream. This is broken by design (needs global sample count), but can&apos;t be avoided for broken by design formats such as mp3 with ad-hoc gapless audio support.
		/// </summary>
		public long FirstDiscardSample;
		/// <summary>
		/// The sample after last sample that is intended to be discarded after first_discard_sample. Works on frame boundaries only. Used to prevent early EOF if the gapless info is broken (considered concatenated mp3s).
		/// </summary>
		public long LastDiscardSample;
		/// <summary>
		/// Number of internally decoded frames, used internally in libavformat, do not access its lifetime differs from info which is why it is not in that structure.
		/// </summary>
		public int NbDecodedFrames;
		/// <summary>
		/// Timestamp offset added to timestamps before muxing NOT PART OF PUBLIC API
		/// </summary>
		public long MuxTsOffset;
		/// <summary>
		/// Internal data to check for wrapping of the time stamp
		/// </summary>
		public long PtsWrapReference;
		/// <summary>
		/// Options for behavior, when a wrap is detected.
		/// </summary>
		public int PtsWrapBehavior;
		/// <summary>
		/// Internal data to prevent doing update_initial_durations() twice
		/// </summary>
		public int UpdateInitialDurationsDone;
		/// <summary>
		/// Internal data to generate dts from pts
		/// </summary>
		public long_array17 PtsReorderError;
		public byte_array17 PtsReorderErrorCount;
		/// <summary>
		/// Internal data to analyze DTS and detect faulty mpeg streams
		/// </summary>
		public long LastDtsForOrderCheck;
		public byte DtsOrdered;
		public byte DtsMisordered;
		/// <summary>
		/// Internal data to inject global side data
		/// </summary>
		public int InjectGlobalSideData;
		/// <summary>
		/// display aspect ratio (0 if unknown) - encoding: unused - decoding: Set by libavformat to calculate sample_aspect_ratio internally
		/// </summary>
		public AVRational DisplayAspectRatio;
		/// <summary>
		/// An opaque field for libavformat internal usage. Must not be accessed in any way by callers.
		/// </summary>
		public AVStreamInternal* Internal;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVStreamInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVIndexEntry {
		public long Pos;
		/// <summary>
		/// Timestamp in AVStream.time_base units, preferably the time from which on correctly decoded frames are available when seeking to this entry. That means preferable PTS on keyframe based formats. But demuxers can choose to store a different timestamp, if it is more convenient for the implementation or nothing better is known
		/// </summary>
		public long Timestamp;
		/// <summary>
		/// Flag is used to indicate which frame should be discarded after decoding.
		/// </summary>
		public int Flags2Size30;
		/// <summary>
		/// Minimum distance between this and the previous keyframe, used to avoid unneeded searching.
		/// </summary>
		public int MinDistance;
	}

	/// <summary>
	/// This structure contains the data a format has to probe a file.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVProbeData {
		public byte* Filename;
		/// <summary>
		/// Buffer must have AVPROBE_PADDING_SIZE of extra allocated bytes filled with zero.
		/// </summary>
		public byte* Buf;
		/// <summary>
		/// Size of buf except extra allocated bytes
		/// </summary>
		public int BufSize;
		/// <summary>
		/// mime_type, when known.
		/// </summary>
		public byte* MimeType;
	}

	/// <summary>
	/// A linked-list of the inputs/outputs of the filter chain.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterInOut {
		/// <summary>
		/// unique name for this input/output in the list
		/// </summary>
		public byte* Name;
		/// <summary>
		/// filter context associated to this input/output
		/// </summary>
		public AVFilterContext* FilterCtx;
		/// <summary>
		/// index of the filt_ctx pad to use for linking
		/// </summary>
		public int PadIdx;
		/// <summary>
		/// next input/input in the list, NULL if this is the last
		/// </summary>
		public AVFilterInOut* Next;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterCommand {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterGraphInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterGraph {
		public AVClass* AvClass;
		public AVFilterContext** Filters;
		public uint NbFilters;
		/// <summary>
		/// sws options to use for the auto-inserted scale filters
		/// </summary>
		public byte* ScaleSwsOpts;
		/// <summary>
		/// libavresample options to use for the auto-inserted resample filters
		/// </summary>
		public byte* ResampleLavrOpts;
		/// <summary>
		/// Type of multithreading allowed for filters in this graph. A combination of AVFILTER_THREAD_* flags.
		/// </summary>
		public int ThreadType;
		/// <summary>
		/// Maximum number of threads used by filters in this graph. May be set by the caller before adding any filters to the filtergraph. Zero (the default) means that the number of threads is determined automatically.
		/// </summary>
		public int NbThreads;
		/// <summary>
		/// Opaque object for libavfilter internal use.
		/// </summary>
		public AVFilterGraphInternal* Internal;
		/// <summary>
		/// Opaque user data. May be set by the caller to an arbitrary value, e.g. to be used from callbacks like Libavfilter will not touch this field in any way.
		/// </summary>
		public void* Opaque;
		/// <summary>
		/// This callback may be set by the caller immediately after allocating the graph and before adding any filters to it, to provide a custom multithreading implementation.
		/// </summary>
		public AVFilterGraph_Execute_Func Execute;
		/// <summary>
		/// swr options to use for the auto-inserted aresample filters, Access ONLY through AVOptions
		/// </summary>
		public byte* AresampleSwrOpts;
		/// <summary>
		/// Private fields
		/// </summary>
		public AVFilterLink** SinkLinks;
		public int SinkLinksCount;
		public uint DisableAutoConvert;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterChannelLayouts {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterFormats {
	}

	/// <summary>
	/// A link between two filters. This contains pointers to the source and destination filters between which this link exists, and the indexes of the pads involved. In addition, this link also contains the parameters which have been negotiated and agreed upon between the filter, such as image dimensions, format, etc.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterLink {
		/// <summary>
		/// source filter
		/// </summary>
		public AVFilterContext* Src;
		/// <summary>
		/// output pad on the source filter
		/// </summary>
		public AVFilterPad* Srcpad;
		/// <summary>
		/// dest filter
		/// </summary>
		public AVFilterContext* Dst;
		/// <summary>
		/// input pad on the dest filter
		/// </summary>
		public AVFilterPad* Dstpad;
		/// <summary>
		/// filter media type
		/// </summary>
		public AVMediaType Type;
		/// <summary>
		/// agreed upon image width
		/// </summary>
		public int W;
		/// <summary>
		/// agreed upon image height
		/// </summary>
		public int H;
		/// <summary>
		/// agreed upon sample aspect ratio
		/// </summary>
		public AVRational SampleAspectRatio;
		/// <summary>
		/// channel layout of current buffer (see libavutil/channel_layout.h)
		/// </summary>
		public ulong ChannelLayout;
		/// <summary>
		/// samples per second
		/// </summary>
		public int SampleRate;
		/// <summary>
		/// agreed upon media format
		/// </summary>
		public int Format;
		/// <summary>
		/// Define the time base used by the PTS of the frames/samples which will pass through this link. During the configuration stage, each filter is supposed to change only the output timebase, while the timebase of the input link is assumed to be an unchangeable property.
		/// </summary>
		public AVRational TimeBase;
		/// <summary>
		/// *************************************************************** All fields below this line are not part of the public API. They may not be used outside of libavfilter and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public AVFilterFormats* InFormats;
		public AVFilterFormats* OutFormats;
		/// <summary>
		/// Lists of channel layouts and sample rates used for automatic negotiation.
		/// </summary>
		public AVFilterFormats* InSamplerates;
		public AVFilterFormats* OutSamplerates;
		public AVFilterChannelLayouts* InChannelLayouts;
		public AVFilterChannelLayouts* OutChannelLayouts;
		/// <summary>
		/// Audio only, the destination filter sets this to a non-zero value to request that buffers with the given number of samples should be sent to it. AVFilterPad.needs_fifo must also be set on the corresponding input pad. Last buffer before EOF will be padded with silence.
		/// </summary>
		public int RequestSamples;
		public AVFilterLink_InitState InitState;
		/// <summary>
		/// Graph the filter belongs to.
		/// </summary>
		public AVFilterGraph* Graph;
		/// <summary>
		/// Current timestamp of the link, as defined by the most recent frame(s), in link time_base units.
		/// </summary>
		public long CurrentPts;
		/// <summary>
		/// Current timestamp of the link, as defined by the most recent frame(s), in AV_TIME_BASE units.
		/// </summary>
		public long CurrentPtsUs;
		/// <summary>
		/// Index in the age array.
		/// </summary>
		public int AgeIndex;
		/// <summary>
		/// Frame rate of the stream on the link, or 1/0 if unknown or variable; if left to 0/0, will be automatically copied from the first input of the source filter if it exists.
		/// </summary>
		public AVRational FrameRate;
		/// <summary>
		/// Buffer partially filled with samples to achieve a fixed/minimum size.
		/// </summary>
		public AVFrame* PartialBuf;
		/// <summary>
		/// Size of the partial buffer to allocate. Must be between min_samples and max_samples.
		/// </summary>
		public int PartialBufSize;
		/// <summary>
		/// Minimum number of samples to filter at once. If filter_frame() is called with fewer samples, it will accumulate them in partial_buf. This field and the related ones must not be changed after filtering has started. If 0, all related fields are ignored.
		/// </summary>
		public int MinSamples;
		/// <summary>
		/// Maximum number of samples to filter at once. If filter_frame() is called with more samples, it will split them.
		/// </summary>
		public int MaxSamples;
		/// <summary>
		/// Number of channels.
		/// </summary>
		public int Channels;
		/// <summary>
		/// Link processing flags.
		/// </summary>
		public uint Flags;
		/// <summary>
		/// Number of past frames sent through the link.
		/// </summary>
		public long FrameCountIn;
		/// <summary>
		/// Number of past frames sent through the link.
		/// </summary>
		public long FrameCountOut;
		/// <summary>
		/// A pointer to a FFFramePool struct.
		/// </summary>
		public void* FramePool;
		/// <summary>
		/// True if a frame is currently wanted on the output of this filter. Set when ff_request_frame() is called by the output, cleared when a frame is filtered.
		/// </summary>
		public int FrameWantedOut;
		/// <summary>
		/// For hwaccel pixel formats, this should be a reference to the AVHWFramesContext describing the frames.
		/// </summary>
		public AVBufferRef* HwFramesCtx;
		/// <summary>
		/// Internal structure members. The fields below this limit are internal for libavfilter&apos;s use and must in no way be accessed by applications.
		/// </summary>
		public byte_array61440 Reserved;
	}

	/// <summary>
	/// Filter definition. This defines the pads a filter contains, and all the callback functions used to interact with the filter.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilter {
		/// <summary>
		/// Filter name. Must be non-NULL and unique among filters.
		/// </summary>
		public byte* Name;
		/// <summary>
		/// A description of the filter. May be NULL.
		/// </summary>
		public byte* Description;
		/// <summary>
		/// List of inputs, terminated by a zeroed element.
		/// </summary>
		public AVFilterPad* Inputs;
		/// <summary>
		/// List of outputs, terminated by a zeroed element.
		/// </summary>
		public AVFilterPad* Outputs;
		/// <summary>
		/// A class for the private data, used to declare filter private AVOptions. This field is NULL for filters that do not declare any options.
		/// </summary>
		public AVClass* PrivClass;
		/// <summary>
		/// A combination of AVFILTER_FLAG_*
		/// </summary>
		public int Flags;
		/// <summary>
		/// Filter pre-initialization function
		/// </summary>
		public AVFilter_Preinit_Func Preinit;
		/// <summary>
		/// Filter initialization function.
		/// </summary>
		public AVFilter_Init_Func Init;
		/// <summary>
		/// Should be set instead of want to pass a dictionary of AVOptions to nested contexts that are allocated during init.
		/// </summary>
		public AVFilter_InitDict_Func InitDict;
		/// <summary>
		/// Filter uninitialization function.
		/// </summary>
		public AVFilter_Uninit_Func Uninit;
		/// <summary>
		/// Query formats supported by the filter on its inputs and outputs.
		/// </summary>
		public AVFilter_QueryFormats_Func QueryFormats;
		/// <summary>
		/// size of private data to allocate for the filter
		/// </summary>
		public int PrivSize;
		/// <summary>
		/// Additional flags for avfilter internal use only.
		/// </summary>
		public int FlagsInternal;
		/// <summary>
		/// Used by the filter registration system. Must not be touched by any other code.
		/// </summary>
		public AVFilter* Next;
		/// <summary>
		/// Make the filter instance process a command.
		/// </summary>
		public AVFilter_ProcessCommand_Func ProcessCommand;
		/// <summary>
		/// Filter initialization function, alternative to the init() callback. Args contains the user-supplied parameters, opaque is used for providing binary data.
		/// </summary>
		public AVFilter_InitOpaque_Func InitOpaque;
		/// <summary>
		/// Filter activation function.
		/// </summary>
		public AVFilter_Activate_Func Activate;
	}

	/// <summary>
	/// An instance of a filter
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterContext {
		/// <summary>
		/// needed for av_log() and filters common options
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// the AVFilter of which this is an instance
		/// </summary>
		public AVFilter* Filter;
		/// <summary>
		/// name of this filter instance
		/// </summary>
		public byte* Name;
		/// <summary>
		/// array of input pads
		/// </summary>
		public AVFilterPad* InputPads;
		/// <summary>
		/// array of pointers to input links
		/// </summary>
		public AVFilterLink** Inputs;
		/// <summary>
		/// number of input pads
		/// </summary>
		public uint NbInputs;
		/// <summary>
		/// array of output pads
		/// </summary>
		public AVFilterPad* OutputPads;
		/// <summary>
		/// array of pointers to output links
		/// </summary>
		public AVFilterLink** Outputs;
		/// <summary>
		/// number of output pads
		/// </summary>
		public uint NbOutputs;
		/// <summary>
		/// private data for use by the filter
		/// </summary>
		public void* Priv;
		/// <summary>
		/// filtergraph this filter belongs to
		/// </summary>
		public AVFilterGraph* Graph;
		/// <summary>
		/// Type of multithreading being allowed/used. A combination of AVFILTER_THREAD_* flags.
		/// </summary>
		public int ThreadType;
		/// <summary>
		/// An opaque struct for libavfilter internal use.
		/// </summary>
		public AVFilterInternal* Internal;
		public AVFilterCommand* CommandQueue;
		/// <summary>
		/// enable expression string
		/// </summary>
		public byte* EnableStr;
		/// <summary>
		/// parsed expression (AVExpr*)
		/// </summary>
		public void* Enable;
		/// <summary>
		/// variable values for the enable expression
		/// </summary>
		public double* VarValues;
		/// <summary>
		/// the enabled state from the last expression evaluation
		/// </summary>
		public int IsDisabled;
		/// <summary>
		/// For filters which will create hardware frames, sets the device the filter should create them in. All other filters will ignore this field: in particular, a filter which consumes or processes hardware frames will instead use the hw_frames_ctx field in AVFilterLink to carry the hardware context information.
		/// </summary>
		public AVBufferRef* HwDeviceCtx;
		/// <summary>
		/// Max number of threads allowed in this filter instance. If &lt;= 0, its value is ignored. Overrides global number of threads set per filter graph.
		/// </summary>
		public int NbThreads;
		/// <summary>
		/// Ready status of the filter. A non-0 value means that the filter needs activating; a higher value suggests a more urgent activation.
		/// </summary>
		public uint Ready;
		/// <summary>
		/// Sets the number of extra hardware frames which the filter will allocate on its output links for use in following filters or by the caller.
		/// </summary>
		public int ExtraHwFrames;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVFilterPad {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDecoderOutputViewVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public void* GetResource;
		public void* GetDesc;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDecoderOutputView {
		public ID3D11VideoDecoderOutputViewVtbl* LpVtbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct _GUID {
		public ulong _1;
		public ushort _2;
		public ushort _3;
		public byte_array8 _4;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct D3D11_VIDEO_DECODER_CONFIG {
		public _GUID GuidConfigBitstreamEncryption;
		public _GUID GuidConfigMBcontrolEncryption;
		public _GUID GuidConfigResidDiffEncryption;
		public uint ConfigBitstreamRaw;
		public uint ConfigMBcontrolRasterOrder;
		public uint ConfigResidDiffHost;
		public uint ConfigSpatialResid8;
		public uint ConfigResid8Subtraction;
		public uint ConfigSpatialHost8or9Clipping;
		public uint ConfigSpatialResidInterleaved;
		public uint ConfigIntraResidUnsigned;
		public uint ConfigResidDiffAccelerator;
		public uint ConfigHostInverseScan;
		public uint ConfigSpecificIDCT;
		public uint Config4GroupedCoefs;
		public ushort ConfigMinRenderTargetBuffCount;
		public ushort ConfigDecoderSpecific;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDecoderVtbl {
		public void* QueryInterface;
		public void* AddRef;
		public void* Release;
		public void* GetDevice;
		public void* GetPrivateData;
		public void* SetPrivateData;
		public void* SetPrivateDataInterface;
		public void* GetCreationParameters;
		public void* GetDriverHandle;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct ID3D11VideoDecoder {
		public ID3D11VideoDecoderVtbl* LpVtbl;
	}

	/// <summary>
	/// This structure is used to provides the necessary configurations and data to the Direct3D11 FFmpeg HWAccel implementation.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVD3D11VAContext {
		/// <summary>
		/// D3D11 decoder object
		/// </summary>
		public ID3D11VideoDecoder* Decoder;
		/// <summary>
		/// D3D11 VideoContext
		/// </summary>
		public ID3D11VideoContext* VideoContext;
		/// <summary>
		/// D3D11 configuration used to create the decoder
		/// </summary>
		public D3D11_VIDEO_DECODER_CONFIG* Cfg;
		/// <summary>
		/// The number of surface in the surface array
		/// </summary>
		public uint SurfaceCount;
		/// <summary>
		/// The array of Direct3D surfaces used to create the decoder
		/// </summary>
		public ID3D11VideoDecoderOutputView** Surface;
		/// <summary>
		/// A bit field configuring the workarounds needed for using the decoder
		/// </summary>
		public ulong Workaround;
		/// <summary>
		/// Private to the FFmpeg AVHWAccel implementation
		/// </summary>
		public uint ReportId;
		/// <summary>
		/// Mutex to access video_context
		/// </summary>
		public void* ContextMutex;
	}

	/// <summary>
	/// This struct describes the properties of a single codec described by an AVCodecID.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecDescriptor {
		public AVCodecID Id;
		public AVMediaType Type;
		/// <summary>
		/// Name of the codec described by this descriptor. It is non-empty and unique for each codec descriptor. It should contain alphanumeric characters and &apos;_&apos; only.
		/// </summary>
		public byte* Name;
		/// <summary>
		/// A more descriptive name for this codec. May be NULL.
		/// </summary>
		public byte* LongName;
		/// <summary>
		/// Codec properties, a combination of AV_CODEC_PROP_* flags.
		/// </summary>
		public int Props;
		/// <summary>
		/// MIME type(s) associated with the codec. May be NULL; if not, a NULL-terminated array of MIME types. The first item is always non-NULL and is the preferred MIME type.
		/// </summary>
		public byte** MimeTypes;
		/// <summary>
		/// If non-NULL, an array of profiles recognized for this codec. Terminated with FF_PROFILE_UNKNOWN.
		/// </summary>
		public AVProfile* Profiles;
	}

	/// <summary>
	/// AVProfile.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVProfile {
		public int Profile;
		/// <summary>
		/// short name for the profile
		/// </summary>
		public byte* Name;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct RcOverride {
		public int StartFrame;
		public int EndFrame;
		public int Qscale;
		public float QualityFactor;
	}

	/// <summary>
	/// Pan Scan area. This specifies the area which should be displayed. Note there may be multiple such areas for one frame.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPanScan {
		/// <summary>
		/// id - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public int Id;
		/// <summary>
		/// width and height in 1/16 pel - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public int Width;
		public int Height;
		/// <summary>
		/// position of the top left corner in 1/16 pel for up to 3 fields/frames - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public short_arrayOfArray3 Position;
	}

	/// <summary>
	/// This structure describes the bitrate properties of an encoded bitstream. It roughly corresponds to a subset the VBV parameters for MPEG-2 or HRD parameters for H.264/HEVC.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCPBProperties {
		/// <summary>
		/// Maximum bitrate of the stream, in bits per second. Zero if unknown or unspecified.
		/// </summary>
		public int MaxBitrate;
		/// <summary>
		/// Minimum bitrate of the stream, in bits per second. Zero if unknown or unspecified.
		/// </summary>
		public int MinBitrate;
		/// <summary>
		/// Average bitrate of the stream, in bits per second. Zero if unknown or unspecified.
		/// </summary>
		public int AvgBitrate;
		/// <summary>
		/// The size of the buffer to which the ratecontrol is applied, in bits. Zero if unknown or unspecified.
		/// </summary>
		public int BufferSize;
		/// <summary>
		/// The delay between the time the packet this structure is associated with is received and the time when it should be decoded, in periods of a 27MHz clock.
		/// </summary>
		public ulong VbvDelay;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPacketSideData {
		public byte* Data;
		public int Size;
		public AVPacketSideDataType Type;
	}

	/// <summary>
	/// This structure stores compressed data. It is typically exported by demuxers and then passed as input to decoders, or received as output from encoders and then passed to muxers.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPacket {
		/// <summary>
		/// A reference to the reference-counted buffer where the packet data is stored. May be NULL, then the packet data is not reference-counted.
		/// </summary>
		public AVBufferRef* Buf;
		/// <summary>
		/// Presentation timestamp in AVStream-&gt;time_base units; the time at which the decompressed packet will be presented to the user. Can be AV_NOPTS_VALUE if it is not stored in the file. pts MUST be larger or equal to dts as presentation cannot happen before decompression, unless one wants to view hex dumps. Some formats misuse the terms dts and pts/cts to mean something different. Such timestamps must be converted to true pts/dts before they are stored in AVPacket.
		/// </summary>
		public long Pts;
		/// <summary>
		/// Decompression timestamp in AVStream-&gt;time_base units; the time at which the packet is decompressed. Can be AV_NOPTS_VALUE if it is not stored in the file.
		/// </summary>
		public long Dts;
		public byte* Data;
		public int Size;
		public int StreamIndex;
		/// <summary>
		/// A combination of AV_PKT_FLAG values
		/// </summary>
		public AVPktFlag Flags;
		/// <summary>
		/// Additional packet data that can be provided by the container. Packet can contain several types of side information.
		/// </summary>
		public AVPacketSideData* SideData;
		public int SideDataElems;
		/// <summary>
		/// Duration of this packet in AVStream-&gt;time_base units, 0 if unknown. Equals next_pts - this_pts in presentation order.
		/// </summary>
		public long Duration;
		/// <summary>
		/// byte position in stream, -1 if unknown
		/// </summary>
		public long Pos;
		public long ConvergenceDuration;
	}

	/// <summary>
	/// main external API structure. New fields can be added to the end with minor version bumps. Removal, reordering and changes to existing fields require a major version bump. You can use AVOptions (av_opt* / av_set/get*()) to access these fields from user applications. The name string for AVOptions options matches the associated command line parameter name and can be found in libavcodec/options_table.h The AVOption/command line parameter names differ in some cases from the C structure field names for historic reasons or brevity. sizeof(AVCodecContext) must not be used outside libav*.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecContext {
		/// <summary>
		/// information on struct for av_log - set by avcodec_alloc_context3
		/// </summary>
		public AVClass* AvClass;
		public int LogLevelOffset;
		public AVMediaType CodecType;
		public AVCodec* Codec;
		public AVCodecID CodecId;
		/// <summary>
		/// fourcc (LSB first, so &quot;ABCD&quot; -&gt; (&apos;D&apos;&lt;&lt;24) + (&apos;C&apos;&lt;&lt;16) + (&apos;B&apos;&lt;&lt;8) + &apos;A&apos;). This is used to work around some encoder bugs. A demuxer should set this to what is stored in the field used to identify the codec. If there are multiple such fields in a container then the demuxer should choose the one which maximizes the information about the used codec. If the codec tag field in a container is larger than 32 bits then the demuxer should remap the longer ID to 32 bits with a table or other structure. Alternatively a new extra_codec_tag + size could be added but for this a clear advantage must be demonstrated first. - encoding: Set by user, if not then the default based on codec_id will be used. - decoding: Set by user, will be converted to uppercase by libavcodec during init.
		/// </summary>
		public uint CodecTag;
		public void* PrivData;
		/// <summary>
		/// Private context used for internal data.
		/// </summary>
		public AVCodecInternal* Internal;
		/// <summary>
		/// Private data of the user, can be used to carry app specific stuff. - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public void* Opaque;
		/// <summary>
		/// the average bitrate - encoding: Set by user; unused for constant quantizer encoding. - decoding: Set by user, may be overwritten by libavcodec if this info is available in the stream
		/// </summary>
		public long BitRate;
		/// <summary>
		/// number of bits the bitstream is allowed to diverge from the reference. the reference can be CBR (for CBR pass1) or VBR (for pass2) - encoding: Set by user; unused for constant quantizer encoding. - decoding: unused
		/// </summary>
		public int BitRateTolerance;
		/// <summary>
		/// Global quality for codecs which cannot change it per frame. This should be proportional to MPEG-1/2/4 qscale. - encoding: Set by user. - decoding: unused
		/// </summary>
		public int GlobalQuality;
		/// <summary>
		/// - encoding: Set by user. - decoding: unused
		/// </summary>
		public int CompressionLevel;
		/// <summary>
		/// AV_CODEC_FLAG_*. - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public AVCodecFlag Flags;
		/// <summary>
		/// AV_CODEC_FLAG2_* - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public AVCodecFlag2 Flags2;
		/// <summary>
		/// some codecs need / can use extradata like Huffman tables. MJPEG: Huffman tables rv10: additional flags MPEG-4: global headers (they can be in the bitstream or here) The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger than extradata_size to avoid problems if it is read with the bitstream reader. The bytewise contents of extradata must not depend on the architecture or CPU endianness. Must be allocated with the av_malloc() family of functions. - encoding: Set/allocated/freed by libavcodec. - decoding: Set/allocated/freed by user.
		/// </summary>
		public byte* Extradata;
		public int ExtradataSize;
		/// <summary>
		/// This is the fundamental unit of time (in seconds) in terms of which frame timestamps are represented. For fixed-fps content, timebase should be 1/framerate and timestamp increments should be identically 1. This often, but not always is the inverse of the frame rate or field rate for video. 1/time_base is not the average frame rate if the frame rate is not constant.
		/// </summary>
		public AVRational TimeBase;
		/// <summary>
		/// For some codecs, the time base is closer to the field rate than the frame rate. Most notably, H.264 and MPEG-2 specify time_base as half of frame duration if no telecine is used ...
		/// </summary>
		public int TicksPerFrame;
		/// <summary>
		/// Codec delay.
		/// </summary>
		public int Delay;
		/// <summary>
		/// picture width / height.
		/// </summary>
		public int Width;
		/// <summary>
		/// picture width / height.
		/// </summary>
		public int Height;
		/// <summary>
		/// Bitstream width / height, may be different from width/height e.g. when the decoded frame is cropped before being output or lowres is enabled.
		/// </summary>
		public int CodedWidth;
		/// <summary>
		/// Bitstream width / height, may be different from width/height e.g. when the decoded frame is cropped before being output or lowres is enabled.
		/// </summary>
		public int CodedHeight;
		/// <summary>
		/// the number of pictures in a group of pictures, or 0 for intra_only - encoding: Set by user. - decoding: unused
		/// </summary>
		public int GopSize;
		/// <summary>
		/// Pixel format, see AV_PIX_FMT_xxx. May be set by the demuxer if known from headers. May be overridden by the decoder if it knows better.
		/// </summary>
		public AVPixelFormat PixFmt;
		/// <summary>
		/// If non NULL, &apos;draw_horiz_band&apos; is called by the libavcodec decoder to draw a horizontal band. It improves cache usage. Not all codecs can do that. You must check the codec capabilities beforehand. When multithreading is used, it may be called from multiple threads at the same time; threads might draw different parts of the same AVFrame, or multiple AVFrames, and there is no guarantee that slices will be drawn in order. The function is also used by hardware acceleration APIs. It is called at least once during frame decoding to pass the data needed for hardware render. In that mode instead of pixel data, AVFrame points to a structure specific to the acceleration API. The application reads the structure and can change some fields to indicate progress or mark state. - encoding: unused - decoding: Set by user.
		/// </summary>
		public AVCodecContext_DrawHorizBand_Func DrawHorizBand;
		/// <summary>
		/// callback to negotiate the pixelFormat
		/// </summary>
		public AVCodecContext_GetFormat_Func GetFormat;
		/// <summary>
		/// maximum number of B-frames between non-B-frames Note: The output will be delayed by max_b_frames+1 relative to the input. - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MaxBFrames;
		/// <summary>
		/// qscale factor between IP and B-frames If &gt; 0 then the last P-frame quantizer will be used (q= lastp_q*factor+offset). If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset). - encoding: Set by user. - decoding: unused
		/// </summary>
		public float BQuantFactor;
		public int BFrameStrategy;
		/// <summary>
		/// qscale offset between IP and B-frames - encoding: Set by user. - decoding: unused
		/// </summary>
		public float BQuantOffset;
		/// <summary>
		/// Size of the frame reordering buffer in the decoder. For MPEG-2 it is 1 IPB or 0 low delay IP. - encoding: Set by libavcodec. - decoding: Set by libavcodec.
		/// </summary>
		public int HasBFrames;
		public int MpegQuant;
		/// <summary>
		/// qscale factor between P- and I-frames If &gt; 0 then the last P-frame quantizer will be used (q = lastp_q * factor + offset). If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset). - encoding: Set by user. - decoding: unused
		/// </summary>
		public float IQuantFactor;
		/// <summary>
		/// qscale offset between P and I-frames - encoding: Set by user. - decoding: unused
		/// </summary>
		public float IQuantOffset;
		/// <summary>
		/// luminance masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused
		/// </summary>
		public float LumiMasking;
		/// <summary>
		/// temporary complexity masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused
		/// </summary>
		public float TemporalCplxMasking;
		/// <summary>
		/// spatial complexity masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused
		/// </summary>
		public float SpatialCplxMasking;
		/// <summary>
		/// p block masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused
		/// </summary>
		public float PMasking;
		/// <summary>
		/// darkness masking (0-&gt; disabled) - encoding: Set by user. - decoding: unused
		/// </summary>
		public float DarkMasking;
		/// <summary>
		/// slice count - encoding: Set by libavcodec. - decoding: Set by user (or 0).
		/// </summary>
		public int SliceCount;
		public int PredictionMethod;
		/// <summary>
		/// slice offsets in the frame in bytes - encoding: Set/allocated by libavcodec. - decoding: Set/allocated by user (or NULL).
		/// </summary>
		public int* SliceOffset;
		/// <summary>
		/// sample aspect ratio (0 if unknown) That is the width of a pixel divided by the height of the pixel. Numerator and denominator must be relatively prime and smaller than 256 for some video standards. - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public AVRational SampleAspectRatio;
		/// <summary>
		/// motion estimation comparison function - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MeCmp;
		/// <summary>
		/// subpixel motion estimation comparison function - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MeSubCmp;
		/// <summary>
		/// macroblock comparison function (not supported yet) - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MbCmp;
		/// <summary>
		/// interlaced DCT comparison function - encoding: Set by user. - decoding: unused
		/// </summary>
		public int IldctCmp;
		/// <summary>
		/// ME diamond size &amp; shape - encoding: Set by user. - decoding: unused
		/// </summary>
		public int DiaSize;
		/// <summary>
		/// amount of previous MV predictors (2a+1 x 2a+1 square) - encoding: Set by user. - decoding: unused
		/// </summary>
		public int LastPredictorCount;
		public int PreMe;
		/// <summary>
		/// motion estimation prepass comparison function - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MePreCmp;
		/// <summary>
		/// ME prepass diamond size &amp; shape - encoding: Set by user. - decoding: unused
		/// </summary>
		public int PreDiaSize;
		/// <summary>
		/// subpel ME quality - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MeSubpelQuality;
		/// <summary>
		/// maximum motion estimation search range in subpel units If 0 then no limit.
		/// </summary>
		public int MeRange;
		/// <summary>
		/// slice flags - encoding: unused - decoding: Set by user.
		/// </summary>
		public int SliceFlags;
		/// <summary>
		/// macroblock decision mode - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MbDecision;
		/// <summary>
		/// custom intra quantization matrix - encoding: Set by user, can be NULL. - decoding: Set by libavcodec.
		/// </summary>
		public ushort* IntraMatrix;
		/// <summary>
		/// custom inter quantization matrix - encoding: Set by user, can be NULL. - decoding: Set by libavcodec.
		/// </summary>
		public ushort* InterMatrix;
		public int ScenechangeThreshold;
		public int NoiseReduction;
		/// <summary>
		/// precision of the intra DC coefficient - 8 - encoding: Set by user. - decoding: Set by libavcodec
		/// </summary>
		public int IntraDcPrecision;
		/// <summary>
		/// Number of macroblock rows at the top which are skipped. - encoding: unused - decoding: Set by user.
		/// </summary>
		public int SkipTop;
		/// <summary>
		/// Number of macroblock rows at the bottom which are skipped. - encoding: unused - decoding: Set by user.
		/// </summary>
		public int SkipBottom;
		/// <summary>
		/// minimum MB Lagrange multiplier - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MbLmin;
		/// <summary>
		/// maximum MB Lagrange multiplier - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MbLmax;
		public int MePenaltyCompensation;
		/// <summary>
		/// - encoding: Set by user. - decoding: unused
		/// </summary>
		public int BidirRefine;
		public int BrdScale;
		/// <summary>
		/// minimum GOP size - encoding: Set by user. - decoding: unused
		/// </summary>
		public int KeyintMin;
		/// <summary>
		/// number of reference frames - encoding: Set by user. - decoding: Set by lavc.
		/// </summary>
		public int Refs;
		public int Chromaoffset;
		/// <summary>
		/// Note: Value depends upon the compare function used for fullpel ME. - encoding: Set by user. - decoding: unused
		/// </summary>
		public int Mv0Threshold;
		public int BSensitivity;
		/// <summary>
		/// Chromaticity coordinates of the source primaries. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorPrimaries ColorPrimaries;
		/// <summary>
		/// Color Transfer Characteristic. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorTransferCharacteristic ColorTrc;
		/// <summary>
		/// YUV colorspace type. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorSpace Colorspace;
		/// <summary>
		/// MPEG vs JPEG YUV range. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVColorRange ColorRange;
		/// <summary>
		/// This defines the location of chroma samples. - encoding: Set by user - decoding: Set by libavcodec
		/// </summary>
		public AVChromaLocation ChromaSampleLocation;
		/// <summary>
		/// Number of slices. Indicates number of picture subdivisions. Used for parallelized decoding. - encoding: Set by user - decoding: unused
		/// </summary>
		public int Slices;
		/// <summary>
		/// Field order - encoding: set by libavcodec - decoding: Set by user.
		/// </summary>
		public AVFieldOrder FieldOrder;
		/// <summary>
		/// samples per second
		/// </summary>
		public int SampleRate;
		/// <summary>
		/// number of audio channels
		/// </summary>
		public int Channels;
		/// <summary>
		/// sample format
		/// </summary>
		public AVSampleFormat SampleFmt;
		/// <summary>
		/// Number of samples per channel in an audio frame.
		/// </summary>
		public int FrameSize;
		/// <summary>
		/// Frame counter, set by libavcodec.
		/// </summary>
		public int FrameNumber;
		/// <summary>
		/// number of bytes per packet if constant and known or 0 Used by some WAV based audio codecs.
		/// </summary>
		public int BlockAlign;
		/// <summary>
		/// Audio cutoff bandwidth (0 means &quot;automatic&quot;) - encoding: Set by user. - decoding: unused
		/// </summary>
		public int Cutoff;
		/// <summary>
		/// Audio channel layout. - encoding: set by user. - decoding: set by user, may be overwritten by libavcodec.
		/// </summary>
		public AVChannelLayout ChannelLayout;
		/// <summary>
		/// Request decoder to use this channel layout if it can (0 for default) - encoding: unused - decoding: Set by user.
		/// </summary>
		public AVChannelLayout RequestChannelLayout;
		/// <summary>
		/// Type of service that the audio stream conveys. - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public AVAudioServiceType AudioServiceType;
		/// <summary>
		/// desired sample format - encoding: Not used. - decoding: Set by user. Decoder will decode to this format if it can.
		/// </summary>
		public AVSampleFormat RequestSampleFmt;
		/// <summary>
		/// This callback is called at the beginning of each frame to get data buffer(s) for it. There may be one contiguous buffer for all the data or there may be a buffer per each data plane or anything in between. What this means is, you may set however many entries in buf[] you feel necessary. Each buffer must be reference-counted using the AVBuffer API (see description of buf[] below).
		/// </summary>
		public AVCodecContext_GetBuffer2_Func GetBuffer2;
		/// <summary>
		/// If non-zero, the decoded audio and video frames returned from avcodec_decode_video2() and avcodec_decode_audio4() are reference-counted and are valid indefinitely. The caller must free them with av_frame_unref() when they are not needed anymore. Otherwise, the decoded frames must not be freed by the caller and are only valid until the next decode call.
		/// </summary>
		public int RefcountedFrames;
		/// <summary>
		/// amount of qscale change between easy &amp; hard scenes (0.0-1.0)
		/// </summary>
		public float Qcompress;
		/// <summary>
		/// amount of qscale smoothing over time (0.0-1.0)
		/// </summary>
		public float Qblur;
		/// <summary>
		/// minimum quantizer - encoding: Set by user. - decoding: unused
		/// </summary>
		public int Qmin;
		/// <summary>
		/// maximum quantizer - encoding: Set by user. - decoding: unused
		/// </summary>
		public int Qmax;
		/// <summary>
		/// maximum quantizer difference between frames - encoding: Set by user. - decoding: unused
		/// </summary>
		public int MaxQdiff;
		/// <summary>
		/// decoder bitstream buffer size - encoding: Set by user. - decoding: unused
		/// </summary>
		public int RcBufferSize;
		/// <summary>
		/// ratecontrol override, see RcOverride - encoding: Allocated/set/freed by user. - decoding: unused
		/// </summary>
		public int RcOverrideCount;
		public RcOverride* RcOverride;
		/// <summary>
		/// maximum bitrate - encoding: Set by user. - decoding: Set by user, may be overwritten by libavcodec.
		/// </summary>
		public long RcMaxRate;
		/// <summary>
		/// minimum bitrate - encoding: Set by user. - decoding: unused
		/// </summary>
		public long RcMinRate;
		/// <summary>
		/// Ratecontrol attempt to use, at maximum, &lt;value&gt; of what can be used without an underflow. - encoding: Set by user. - decoding: unused.
		/// </summary>
		public float RcMaxAvailableVbvUse;
		/// <summary>
		/// Ratecontrol attempt to use, at least, &lt;value&gt; times the amount needed to prevent a vbv overflow. - encoding: Set by user. - decoding: unused.
		/// </summary>
		public float RcMinVbvOverflowUse;
		/// <summary>
		/// Number of bits which should be loaded into the rc buffer before decoding starts. - encoding: Set by user. - decoding: unused
		/// </summary>
		public int RcInitialBufferOccupancy;
		public int CoderType;
		public int ContextModel;
		public int FrameSkipThreshold;
		public int FrameSkipFactor;
		public int FrameSkipExp;
		public int FrameSkipCmp;
		/// <summary>
		/// trellis RD quantization - encoding: Set by user. - decoding: unused
		/// </summary>
		public int Trellis;
		public int MinPredictionOrder;
		public int MaxPredictionOrder;
		public long TimecodeFrameStart;
		public AVCodecContext_RtpCallback_Func RtpCallback;
		public int RtpPayloadSize;
		public int MvBits;
		public int HeaderBits;
		public int ITexBits;
		public int PTexBits;
		public int ICount;
		public int PCount;
		public int SkipCount;
		public int MiscBits;
		public int FrameBits;
		/// <summary>
		/// pass1 encoding statistics output buffer - encoding: Set by libavcodec. - decoding: unused
		/// </summary>
		public byte* StatsOut;
		/// <summary>
		/// pass2 encoding statistics input buffer Concatenated stuff from stats_out of pass1 should be placed here. - encoding: Allocated/set/freed by user. - decoding: unused
		/// </summary>
		public byte* StatsIn;
		/// <summary>
		/// Work around bugs in encoders which sometimes cannot be detected automatically. - encoding: Set by user - decoding: Set by user
		/// </summary>
		public int WorkaroundBugs;
		/// <summary>
		/// strictly follow the standard (MPEG-4, ...). - encoding: Set by user. - decoding: Set by user. Setting this to STRICT or higher means the encoder and decoder will generally do stupid things, whereas setting it to unofficial or lower will mean the encoder might produce output that is not supported by all spec-compliant decoders. Decoders don&apos;t differentiate between normal, unofficial and experimental (that is, they always try to decode things when they can) unless they are explicitly asked to behave stupidly (=strictly conform to the specs)
		/// </summary>
		public int StrictStdCompliance;
		/// <summary>
		/// error concealment flags - encoding: unused - decoding: Set by user.
		/// </summary>
		public int ErrorConcealment;
		/// <summary>
		/// debug - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public int Debug;
		/// <summary>
		/// Error recognition; may misdetect some more or less valid parts as errors. - encoding: unused - decoding: Set by user.
		/// </summary>
		public int ErrRecognition;
		/// <summary>
		/// opaque 64-bit number (generally a PTS) that will be reordered and output in AVFrame.reordered_opaque - encoding: unused - decoding: Set by user.
		/// </summary>
		public long ReorderedOpaque;
		/// <summary>
		/// Hardware accelerator in use - encoding: unused. - decoding: Set by libavcodec
		/// </summary>
		public AVHWAccel* Hwaccel;
		/// <summary>
		/// Hardware accelerator context. For some hardware accelerators, a global context needs to be provided by the user. In that case, this holds display-dependent data FFmpeg cannot instantiate itself. Please refer to the FFmpeg HW accelerator documentation to know how to fill this is. e.g. for VA API, this is a struct vaapi_context. - encoding: unused - decoding: Set by user
		/// </summary>
		public void* HwaccelContext;
		/// <summary>
		/// error - encoding: Set by libavcodec if flags &amp; AV_CODEC_FLAG_PSNR. - decoding: unused
		/// </summary>
		public ulong_array8 Error;
		/// <summary>
		/// DCT algorithm, see FF_DCT_* below - encoding: Set by user. - decoding: unused
		/// </summary>
		public int DctAlgo;
		/// <summary>
		/// IDCT algorithm, see FF_IDCT_* below. - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public int IdctAlgo;
		/// <summary>
		/// bits per sample/pixel from the demuxer (needed for huffyuv). - encoding: Set by libavcodec. - decoding: Set by user.
		/// </summary>
		public int BitsPerCodedSample;
		/// <summary>
		/// Bits per sample/pixel of internal libavcodec pixel/sample format. - encoding: set by user. - decoding: set by libavcodec.
		/// </summary>
		public int BitsPerRawSample;
		/// <summary>
		/// low resolution decoding, 1-&gt; 1/2 size, 2-&gt;1/4 size - encoding: unused - decoding: Set by user.
		/// </summary>
		public int Lowres;
		/// <summary>
		/// the picture in the bitstream - encoding: Set by libavcodec. - decoding: unused
		/// </summary>
		public AVFrame* CodedFrame;
		/// <summary>
		/// thread count is used to decide how many independent tasks should be passed to execute() - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public int ThreadCount;
		/// <summary>
		/// Which multithreading methods to use. Use of FF_THREAD_FRAME will increase decoding delay by one frame per thread, so clients which cannot provide future frames should not use it.
		/// </summary>
		public int ThreadType;
		/// <summary>
		/// Which multithreading methods are in use by the codec. - encoding: Set by libavcodec. - decoding: Set by libavcodec.
		/// </summary>
		public int ActiveThreadType;
		/// <summary>
		/// Set by the client if its custom get_buffer() callback can be called synchronously from another thread, which allows faster multithreaded decoding. draw_horiz_band() will be called from other threads regardless of this setting. Ignored if the default get_buffer() is used. - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public int ThreadSafeCallbacks;
		/// <summary>
		/// The codec may call this to execute several independent things. It will return only after finishing all tasks. The user may replace this with some multithreaded implementation, the default implementation will execute the parts serially.
		/// </summary>
		public AVCodecContext_Execute_Func Execute;
		/// <summary>
		/// The codec may call this to execute several independent things. It will return only after finishing all tasks. The user may replace this with some multithreaded implementation, the default implementation will execute the parts serially. Also see avcodec_thread_init and e.g. the --enable-pthread configure option.
		/// </summary>
		public AVCodecContext_Execute2_Func Execute2;
		/// <summary>
		/// noise vs. sse weight for the nsse comparison function - encoding: Set by user. - decoding: unused
		/// </summary>
		public int NsseWeight;
		/// <summary>
		/// profile - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public int Profile;
		/// <summary>
		/// level - encoding: Set by user. - decoding: Set by libavcodec.
		/// </summary>
		public int Level;
		/// <summary>
		/// Skip loop filtering for selected frames. - encoding: unused - decoding: Set by user.
		/// </summary>
		public AVDiscard SkipLoopFilter;
		/// <summary>
		/// Skip IDCT/dequantization for selected frames. - encoding: unused - decoding: Set by user.
		/// </summary>
		public AVDiscard SkipIdct;
		/// <summary>
		/// Skip decoding for selected frames. - encoding: unused - decoding: Set by user.
		/// </summary>
		public AVDiscard SkipFrame;
		/// <summary>
		/// Header containing style information for text subtitles. For SUBTITLE_ASS subtitle type, it should contain the whole ASS [Script Info] and [V4+ Styles] section, plus the [Events] line and the Format line following. It shouldn&apos;t include any Dialogue line. - encoding: Set/allocated/freed by user (before avcodec_open2()) - decoding: Set/allocated/freed by libavcodec (by avcodec_open2())
		/// </summary>
		public byte* SubtitleHeader;
		public int SubtitleHeaderSize;
		/// <summary>
		/// VBV delay coded in the last frame (in periods of a 27 MHz clock). Used for compliant TS muxing. - encoding: Set by libavcodec. - decoding: unused.
		/// </summary>
		public ulong VbvDelay;
		/// <summary>
		/// Encoding only and set by default. Allow encoders to output packets that do not contain any encoded data, only side data.
		/// </summary>
		public int SideDataOnlyPackets;
		/// <summary>
		/// Audio only. The number of &quot;priming&quot; samples (padding) inserted by the encoder at the beginning of the audio. I.e. this number of leading decoded samples must be discarded by the caller to get the original audio without leading padding.
		/// </summary>
		public int InitialPadding;
		/// <summary>
		/// - decoding: For codecs that store a framerate value in the compressed bitstream, the decoder may export it here. { 0, 1} when unknown. - encoding: May be used to signal the framerate of CFR content to an encoder.
		/// </summary>
		public AVRational Framerate;
		/// <summary>
		/// Nominal unaccelerated pixel format, see AV_PIX_FMT_xxx. - encoding: unused. - decoding: Set by libavcodec before calling get_format()
		/// </summary>
		public AVPixelFormat SwPixFmt;
		/// <summary>
		/// Timebase in which pkt_dts/pts and AVPacket.dts/pts are. - encoding unused. - decoding set by user.
		/// </summary>
		public AVRational PktTimebase;
		/// <summary>
		/// AVCodecDescriptor - encoding: unused. - decoding: set by libavcodec.
		/// </summary>
		public AVCodecDescriptor* CodecDescriptor;
		/// <summary>
		/// Current statistics for PTS correction. - decoding: maintained and used by libavcodec, not intended to be used by user apps - encoding: unused
		/// </summary>
		public long PtsCorrectionNumFaultyPts;
		/// <summary>
		/// Number of incorrect PTS values so far
		/// </summary>
		public long PtsCorrectionNumFaultyDts;
		/// <summary>
		/// Number of incorrect DTS values so far
		/// </summary>
		public long PtsCorrectionLastPts;
		/// <summary>
		/// PTS of the last frame
		/// </summary>
		public long PtsCorrectionLastDts;
		/// <summary>
		/// Character encoding of the input subtitles file. - decoding: set by user - encoding: unused
		/// </summary>
		public byte* SubCharenc;
		/// <summary>
		/// Subtitles character encoding mode. Formats or codecs might be adjusting this setting (if they are doing the conversion themselves for instance). - decoding: set by libavcodec - encoding: unused
		/// </summary>
		public int SubCharencMode;
		/// <summary>
		/// Skip processing alpha if supported by codec. Note that if the format uses pre-multiplied alpha (common with VP6, and recommended due to better video quality/compression) the image will look as if alpha-blended onto a black background. However for formats that do not use pre-multiplied alpha there might be serious artefacts (though e.g. libswscale currently assumes pre-multiplied alpha anyway).
		/// </summary>
		public int SkipAlpha;
		/// <summary>
		/// Number of samples to skip after a discontinuity - decoding: unused - encoding: set by libavcodec
		/// </summary>
		public int SeekPreroll;
		/// <summary>
		/// debug motion vectors - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public int DebugMv;
		/// <summary>
		/// custom intra quantization matrix - encoding: Set by user, can be NULL. - decoding: unused.
		/// </summary>
		public ushort* ChromaIntraMatrix;
		/// <summary>
		/// dump format separator. can be &quot;, &quot; or &quot; &quot; or anything else - encoding: Set by user. - decoding: Set by user.
		/// </summary>
		public byte* DumpSeparator;
		/// <summary>
		/// &apos;,&apos; separated list of allowed decoders. If NULL then all are allowed - encoding: unused - decoding: set by user
		/// </summary>
		public byte* CodecWhitelist;
		/// <summary>
		/// Properties of the stream that gets decoded - encoding: unused - decoding: set by libavcodec
		/// </summary>
		public uint Properties;
		/// <summary>
		/// Additional data associated with the entire coded stream.
		/// </summary>
		public AVPacketSideData* CodedSideData;
		public int NbCodedSideData;
		/// <summary>
		/// A reference to the AVHWFramesContext describing the input (for encoding) or output (decoding) frames. The reference is set by the caller and afterwards owned (and freed) by libavcodec - it should never be read by the caller after being set.
		/// </summary>
		public AVBufferRef* HwFramesCtx;
		/// <summary>
		/// Control the form of AVSubtitle.rects[N]-&gt;ass - decoding: set by user - encoding: unused
		/// </summary>
		public int SubTextFormat;
		/// <summary>
		/// Audio only. The amount of padding (in samples) appended by the encoder to the end of the audio. I.e. this number of decoded samples must be discarded by the caller from the end of the stream to get the original audio without any trailing padding.
		/// </summary>
		public int TrailingPadding;
		/// <summary>
		/// The number of pixels per image to maximally accept.
		/// </summary>
		public long MaxPixels;
		/// <summary>
		/// A reference to the AVHWDeviceContext describing the device which will be used by a hardware encoder/decoder. The reference is set by the caller and afterwards owned (and freed) by libavcodec.
		/// </summary>
		public AVBufferRef* HwDeviceCtx;
		/// <summary>
		/// Bit set of AV_HWACCEL_FLAG_* flags, which affect hardware accelerated decoding (if active). - encoding: unused - decoding: Set by user (either before avcodec_open2(), or in the AVCodecContext.get_format callback)
		/// </summary>
		public int HwaccelFlags;
		/// <summary>
		/// Video decoding only. Certain video codecs support cropping, meaning that only a sub-rectangle of the decoded frame is intended for display. This option controls how cropping is handled by libavcodec.
		/// </summary>
		public int ApplyCropping;
		public int ExtraHwFrames;
	}

	/// <summary>
	/// AVCodec.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodec {
		/// <summary>
		/// Name of the codec implementation. The name is globally unique among encoders and among decoders (but an encoder and a decoder can share the same name). This is the primary way to find a codec from the user perspective.
		/// </summary>
		public byte* Name;
		/// <summary>
		/// Descriptive name for the codec, meant to be more human readable than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.
		/// </summary>
		public byte* LongName;
		public AVMediaType Type;
		public AVCodecID Id;
		/// <summary>
		/// Codec capabilities. see AV_CODEC_CAP_*
		/// </summary>
		public int Capabilities;
		/// <summary>
		/// array of supported framerates, or NULL if any, array is terminated by {0,0}
		/// </summary>
		public AVRational* SupportedFramerates;
		/// <summary>
		/// array of supported pixel formats, or NULL if unknown, array is terminated by -1
		/// </summary>
		public AVPixelFormat* PixFmts;
		/// <summary>
		/// array of supported audio samplerates, or NULL if unknown, array is terminated by 0
		/// </summary>
		public int* SupportedSamplerates;
		/// <summary>
		/// array of supported sample formats, or NULL if unknown, array is terminated by -1
		/// </summary>
		public AVSampleFormat* SampleFmts;
		/// <summary>
		/// array of support channel layouts, or NULL if unknown. array is terminated by 0
		/// </summary>
		public AVChannelLayout* ChannelLayouts;
		/// <summary>
		/// maximum value for lowres supported by the decoder
		/// </summary>
		public byte MaxLowres;
		/// <summary>
		/// AVClass for the private context
		/// </summary>
		public AVClass* PrivClass;
		/// <summary>
		/// array of recognized profiles, or NULL if unknown, array is terminated by {FF_PROFILE_UNKNOWN}
		/// </summary>
		public AVProfile* Profiles;
		/// <summary>
		/// Group name of the codec implementation. This is a short symbolic name of the wrapper backing this codec. A wrapper uses some kind of external implementation for the codec, such as an external library, or a codec implementation provided by the OS or the hardware. If this field is NULL, this is a builtin, libavcodec native codec. If non-NULL, this will be the suffix in AVCodec.name in most cases (usually AVCodec.name will be of the form &quot;&lt;codec_name&gt;_&lt;wrapper_name&gt;&quot;).
		/// </summary>
		public byte* WrapperName;
		/// <summary>
		/// *************************************************************** No fields below this line are part of the public API. They may not be used outside of libavcodec and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public int PrivDataSize;
		public AVCodec* Next;
		/// <summary>
		/// @{
		/// </summary>
		public AVCodec_InitThreadCopy_Func InitThreadCopy;
		/// <summary>
		/// Copy necessary context variables from a previous thread context to the current one. If not defined, the next thread will start automatically; otherwise, the codec must call ff_thread_finish_setup().
		/// </summary>
		public AVCodec_UpdateThreadContext_Func UpdateThreadContext;
		/// <summary>
		/// Private codec-specific defaults.
		/// </summary>
		public AVCodecDefault* Defaults;
		/// <summary>
		/// Initialize codec static data, called from avcodec_register().
		/// </summary>
		public AVCodec_InitStaticData_Func InitStaticData;
		public AVCodec_Init_Func Init;
		public AVCodec_EncodeSub_Func EncodeSub;
		/// <summary>
		/// Encode data to an AVPacket.
		/// </summary>
		public AVCodec_Encode2_Func Encode2;
		public AVCodec_Decode_Func Decode;
		public AVCodec_Close_Func Close;
		/// <summary>
		/// Encode API with decoupled packet/frame dataflow. The API is the same as the avcodec_ prefixed APIs (avcodec_send_frame() etc.), except that: - never called if the codec is closed or the wrong type, - if AV_CODEC_CAP_DELAY is not set, drain frames are never sent, - only one drain frame is ever passed down,
		/// </summary>
		public AVCodec_SendFrame_Func SendFrame;
		public AVCodec_ReceivePacket_Func ReceivePacket;
		/// <summary>
		/// Decode API with decoupled packet/frame dataflow. This function is called to get one output frame. It should call ff_decode_get_packet() to obtain input data.
		/// </summary>
		public AVCodec_ReceiveFrame_Func ReceiveFrame;
		/// <summary>
		/// Flush buffers. Will be called when seeking
		/// </summary>
		public AVCodec_Flush_Func Flush;
		/// <summary>
		/// Internal codec capabilities. See FF_CODEC_CAP_* in internal.h
		/// </summary>
		public int CapsInternal;
		/// <summary>
		/// Decoding only, a comma-separated list of bitstream filters to apply to packets before decoding.
		/// </summary>
		public byte* Bsfs;
		/// <summary>
		/// Array of pointers to hardware configurations supported by the codec, or NULL if no hardware supported. The array is terminated by a NULL pointer.
		/// </summary>
		public AVCodecHWConfigInternal** HwConfigs;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecDefault {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVSubtitle {
		public ushort Format;
		public uint StartDisplayTime;
		public uint EndDisplayTime;
		public uint NumRects;
		public AVSubtitleRect** Rects;
		/// <summary>
		/// Same as packet pts, in AV_TIME_BASE
		/// </summary>
		public long Pts;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVSubtitleRect {
		/// <summary>
		/// top left corner of pict, undefined when pict is not set
		/// </summary>
		public int X;
		/// <summary>
		/// top left corner of pict, undefined when pict is not set
		/// </summary>
		public int Y;
		/// <summary>
		/// width of pict, undefined when pict is not set
		/// </summary>
		public int W;
		/// <summary>
		/// height of pict, undefined when pict is not set
		/// </summary>
		public int H;
		/// <summary>
		/// number of colors in pict, undefined when pict is not set
		/// </summary>
		public int NbColors;
		public AVPicture Pict;
		/// <summary>
		/// data+linesize for the bitmap of this subtitle. Can be set for text/ass as well once they are rendered.
		/// </summary>
		public byte_ptrArray4 Data;
		public int_array4 Linesize;
		public AVSubtitleType Type;
		/// <summary>
		/// 0 terminated plain UTF-8 text
		/// </summary>
		public byte* Text;
		/// <summary>
		/// 0 terminated ASS/SSA compatible event line. The presentation of this is unaffected by the other values in this struct.
		/// </summary>
		public byte* Ass;
		public int Flags;
	}

	/// <summary>
	/// Picture data structure.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVPicture {
		/// <summary>
		/// pointers to the image data planes
		/// </summary>
		public byte_ptrArray8 Data;
		/// <summary>
		/// number of bytes per line
		/// </summary>
		public int_array8 Linesize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecHWConfigInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecInternal {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVHWAccel {
		/// <summary>
		/// Name of the hardware accelerated codec. The name is globally unique among encoders and among decoders (but an encoder and a decoder can share the same name).
		/// </summary>
		public byte* Name;
		/// <summary>
		/// Type of codec implemented by the hardware accelerator.
		/// </summary>
		public AVMediaType Type;
		/// <summary>
		/// Codec implemented by the hardware accelerator.
		/// </summary>
		public AVCodecID Id;
		/// <summary>
		/// Supported pixel format.
		/// </summary>
		public AVPixelFormat PixFmt;
		/// <summary>
		/// Hardware accelerated codec capabilities. see AV_HWACCEL_CODEC_CAP_*
		/// </summary>
		public int Capabilities;
		/// <summary>
		/// Allocate a custom buffer
		/// </summary>
		public AVHWAccel_AllocFrame_Func AllocFrame;
		/// <summary>
		/// Called at the beginning of each frame or field picture.
		/// </summary>
		public AVHWAccel_StartFrame_Func StartFrame;
		/// <summary>
		/// Callback for parameter data (SPS/PPS/VPS etc).
		/// </summary>
		public AVHWAccel_DecodeParams_Func DecodeParams;
		/// <summary>
		/// Callback for each slice.
		/// </summary>
		public AVHWAccel_DecodeSlice_Func DecodeSlice;
		/// <summary>
		/// Called at the end of each frame or field picture.
		/// </summary>
		public AVHWAccel_EndFrame_Func EndFrame;
		/// <summary>
		/// Size of per-frame hardware accelerator private data.
		/// </summary>
		public int FramePrivDataSize;
		/// <summary>
		/// Called for every Macroblock in a slice.
		/// </summary>
		public AVHWAccel_DecodeMb_Func DecodeMb;
		/// <summary>
		/// Initialize the hwaccel private data.
		/// </summary>
		public AVHWAccel_Init_Func Init;
		/// <summary>
		/// Uninitialize the hwaccel private data.
		/// </summary>
		public AVHWAccel_Uninit_Func Uninit;
		/// <summary>
		/// Size of the private data to allocate in AVCodecInternal.hwaccel_priv_data.
		/// </summary>
		public int PrivDataSize;
		/// <summary>
		/// Internal hwaccel capabilities.
		/// </summary>
		public int CapsInternal;
		/// <summary>
		/// Fill the given hw_frames context with current codec parameters. Called from get_format. Refer to avcodec_get_hw_frames_parameters() for details.
		/// </summary>
		public AVHWAccel_FrameParams_Func FrameParams;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct MpegEncContext {
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecHWConfig {
		/// <summary>
		/// A hardware pixel format which the codec can use.
		/// </summary>
		public AVPixelFormat PixFmt;
		/// <summary>
		/// Bit set of AV_CODEC_HW_CONFIG_METHOD_* flags, describing the possible setup methods which can be used with this configuration.
		/// </summary>
		public int Methods;
		/// <summary>
		/// The device type associated with the configuration.
		/// </summary>
		public AVHWDeviceType DeviceType;
	}

	/// <summary>
	/// This struct describes the properties of an encoded stream.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecParameters {
		/// <summary>
		/// General type of the encoded data.
		/// </summary>
		public AVMediaType CodecType;
		/// <summary>
		/// Specific type of the encoded data (the codec used).
		/// </summary>
		public AVCodecID CodecId;
		/// <summary>
		/// Additional information about the codec (corresponds to the AVI FOURCC).
		/// </summary>
		public uint CodecTag;
		/// <summary>
		/// Extra binary data needed for initializing the decoder, codec-dependent.
		/// </summary>
		public byte* Extradata;
		/// <summary>
		/// Size of the extradata content in bytes.
		/// </summary>
		public int ExtradataSize;
		/// <summary>
		/// - video: the pixel format, the value corresponds to enum AVPixelFormat. - audio: the sample format, the value corresponds to enum AVSampleFormat.
		/// </summary>
		public int Format;
		/// <summary>
		/// The average bitrate of the encoded data (in bits per second).
		/// </summary>
		public long BitRate;
		/// <summary>
		/// The number of bits per sample in the codedwords.
		/// </summary>
		public int BitsPerCodedSample;
		/// <summary>
		/// This is the number of valid bits in each output sample. If the sample format has more bits, the least significant bits are additional padding bits, which are always 0. Use right shifts to reduce the sample to its actual size. For example, audio formats with 24 bit samples will have bits_per_raw_sample set to 24, and format set to AV_SAMPLE_FMT_S32. To get the original sample use &quot;(int32_t)sample &gt;&gt; 8&quot;.&quot;
		/// </summary>
		public int BitsPerRawSample;
		/// <summary>
		/// Codec-specific bitstream restrictions that the stream conforms to.
		/// </summary>
		public int Profile;
		public int Level;
		/// <summary>
		/// Video only. The dimensions of the video frame in pixels.
		/// </summary>
		public int Width;
		public int Height;
		/// <summary>
		/// Video only. The aspect ratio (width / height) which a single pixel should have when displayed.
		/// </summary>
		public AVRational SampleAspectRatio;
		/// <summary>
		/// Video only. The order of the fields in interlaced video.
		/// </summary>
		public AVFieldOrder FieldOrder;
		/// <summary>
		/// Video only. Additional colorspace characteristics.
		/// </summary>
		public AVColorRange ColorRange;
		public AVColorPrimaries ColorPrimaries;
		public AVColorTransferCharacteristic ColorTrc;
		public AVColorSpace ColorSpace;
		public AVChromaLocation ChromaLocation;
		/// <summary>
		/// Video only. Number of delayed frames.
		/// </summary>
		public int VideoDelay;
		/// <summary>
		/// Audio only. The channel layout bitmask. May be 0 if the channel layout is unknown or unspecified, otherwise the number of bits set must be equal to the channels field.
		/// </summary>
		public ulong ChannelLayout;
		/// <summary>
		/// Audio only. The number of audio channels.
		/// </summary>
		public int Channels;
		/// <summary>
		/// Audio only. The number of audio samples per second.
		/// </summary>
		public int SampleRate;
		/// <summary>
		/// Audio only. The number of bytes per coded audio frame, required by some formats.
		/// </summary>
		public int BlockAlign;
		/// <summary>
		/// Audio only. Audio frame size, if known. Required by some formats to be static.
		/// </summary>
		public int FrameSize;
		/// <summary>
		/// Audio only. The amount of padding (in samples) inserted by the encoder at the beginning of the audio. I.e. this number of leading decoded samples must be discarded by the caller to get the original audio without leading padding.
		/// </summary>
		public int InitialPadding;
		/// <summary>
		/// Audio only. The amount of padding (in samples) appended by the encoder to the end of the audio. I.e. this number of decoded samples must be discarded by the caller from the end of the stream to get the original audio without any trailing padding.
		/// </summary>
		public int TrailingPadding;
		/// <summary>
		/// Audio only. Number of samples to skip after a discontinuity.
		/// </summary>
		public int SeekPreroll;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecParserContext {
		public void* PrivData;
		public AVCodecParser* Parser;
		public long FrameOffset;
		public long CurOffset;
		public long NextFrameOffset;
		public int PictType;
		/// <summary>
		/// This field is used for proper frame duration computation in lavf. It signals, how much longer the frame duration of the current frame is compared to normal frame duration.
		/// </summary>
		public int RepeatPict;
		public long Pts;
		public long Dts;
		public long LastPts;
		public long LastDts;
		public int FetchTimestamp;
		public int CurFrameStartIndex;
		public long_array4 CurFrameOffset;
		public long_array4 CurFramePts;
		public long_array4 CurFrameDts;
		public int Flags;
		/// <summary>
		/// byte offset from starting packet start
		/// </summary>
		public long Offset;
		public long_array4 CurFrameEnd;
		/// <summary>
		/// Set by parser to 1 for key frames and 0 for non-key frames. It is initialized to -1, so if the parser doesn&apos;t set this flag, old-style fallback using AV_PICTURE_TYPE_I picture type as key frames will be used.
		/// </summary>
		public int KeyFrame;
		public long ConvergenceDuration;
		/// <summary>
		/// Synchronization point for start of timestamp generation.
		/// </summary>
		public int DtsSyncPoint;
		/// <summary>
		/// Offset of the current timestamp against last timestamp sync point in units of AVCodecContext.time_base.
		/// </summary>
		public int DtsRefDtsDelta;
		/// <summary>
		/// Presentation delay of current frame in units of AVCodecContext.time_base.
		/// </summary>
		public int PtsDtsDelta;
		/// <summary>
		/// Position of the packet in file.
		/// </summary>
		public long_array4 CurFramePos;
		/// <summary>
		/// Byte position of currently parsed frame in stream.
		/// </summary>
		public long Pos;
		/// <summary>
		/// Previous frame byte position.
		/// </summary>
		public long LastPos;
		/// <summary>
		/// Duration of the current frame. For audio, this is in units of 1 / AVCodecContext.sample_rate. For all other types, this is in units of AVCodecContext.time_base.
		/// </summary>
		public int Duration;
		public AVFieldOrder FieldOrder;
		/// <summary>
		/// Indicate whether a picture is coded as a frame, top field or bottom field.
		/// </summary>
		public AVPictureStructure PictureStructure;
		/// <summary>
		/// Picture number incremented in presentation or output order. This field may be reinitialized at the first picture of a new sequence.
		/// </summary>
		public int OutputPictureNumber;
		/// <summary>
		/// Dimensions of the decoded video intended for presentation.
		/// </summary>
		public int Width;
		public int Height;
		/// <summary>
		/// Dimensions of the coded video.
		/// </summary>
		public int CodedWidth;
		public int CodedHeight;
		/// <summary>
		/// The format of the coded data, corresponds to enum AVPixelFormat for video and for enum AVSampleFormat for audio.
		/// </summary>
		public int Format;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVCodecParser {
		public int_array5 CodecIds;
		public int PrivDataSize;
		public AVCodecParser_ParserInit_Func ParserInit;
		public AVCodecParser_ParserParse_Func ParserParse;
		public AVCodecParser_ParserClose_Func ParserClose;
		public AVCodecParser_Split_Func Split;
		public AVCodecParser* Next;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBSFInternal {
	}

	/// <summary>
	/// The bitstream filter state.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBSFContext {
		/// <summary>
		/// A class for logging and AVOptions
		/// </summary>
		public AVClass* AvClass;
		/// <summary>
		/// The bitstream filter this context is an instance of.
		/// </summary>
		public AVBitStreamFilter* Filter;
		/// <summary>
		/// Opaque libavcodec internal data. Must not be touched by the caller in any way.
		/// </summary>
		public AVBSFInternal* Internal;
		/// <summary>
		/// Opaque filter-specific private data. If filter-&gt;priv_class is non-NULL, this is an AVOptions-enabled struct.
		/// </summary>
		public void* PrivData;
		/// <summary>
		/// Parameters of the input stream. This field is allocated in av_bsf_alloc(), it needs to be filled by the caller before av_bsf_init().
		/// </summary>
		public AVCodecParameters* ParIn;
		/// <summary>
		/// Parameters of the output stream. This field is allocated in av_bsf_alloc(), it is set by the filter in av_bsf_init().
		/// </summary>
		public AVCodecParameters* ParOut;
		/// <summary>
		/// The timebase used for the timestamps of the input packets. Set by the caller before av_bsf_init().
		/// </summary>
		public AVRational TimeBaseIn;
		/// <summary>
		/// The timebase used for the timestamps of the output packets. Set by the filter in av_bsf_init().
		/// </summary>
		public AVRational TimeBaseOut;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBitStreamFilter {
		public byte* Name;
		/// <summary>
		/// A list of codec ids supported by the filter, terminated by AV_CODEC_ID_NONE. May be NULL, in that case the bitstream filter works with any codec id.
		/// </summary>
		public AVCodecID* CodecIds;
		/// <summary>
		/// A class for the private data, used to declare bitstream filter private AVOptions. This field is NULL for bitstream filters that do not declare any options.
		/// </summary>
		public AVClass* PrivClass;
		/// <summary>
		/// *************************************************************** No fields below this line are part of the public API. They may not be used outside of libavcodec and can be changed and removed at will. New public fields should be added right above. ****************************************************************
		/// </summary>
		public int PrivDataSize;
		public AVBitStreamFilter_Init_Func Init;
		public AVBitStreamFilter_Filter_Func Filter;
		public AVBitStreamFilter_Close_Func Close;
		public AVBitStreamFilter_Flush_Func Flush;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBitStreamFilterContext {
		public void* PrivData;
		public AVBitStreamFilter* Filter;
		public AVCodecParserContext* Parser;
		public AVBitStreamFilterContext* Next;
		/// <summary>
		/// Internal default arguments, used if NULL is passed to av_bitstream_filter_filter(). Not for access by library users.
		/// </summary>
		public byte* Args;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBSFList {
	}

	/// <summary>
	/// Describes single entry of the directory.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVIODirEntry {
		/// <summary>
		/// Filename
		/// </summary>
		public byte* Name;
		/// <summary>
		/// Type of the entry
		/// </summary>
		public int Type;
		/// <summary>
		/// Set to 1 when name is encoded with UTF-8, 0 otherwise. Name can be encoded with UTF-8 even though 0 is set.
		/// </summary>
		public int Utf8;
		/// <summary>
		/// File size in bytes, -1 if unknown.
		/// </summary>
		public long Size;
		/// <summary>
		/// Time of last modification in microseconds since unix epoch, -1 if unknown.
		/// </summary>
		public long ModificationTimestamp;
		/// <summary>
		/// Time of last access in microseconds since unix epoch, -1 if unknown.
		/// </summary>
		public long AccessTimestamp;
		/// <summary>
		/// Time of last status change in microseconds since unix epoch, -1 if unknown.
		/// </summary>
		public long StatusChangeTimestamp;
		/// <summary>
		/// User ID of owner, -1 if unknown.
		/// </summary>
		public long UserId;
		/// <summary>
		/// Group ID of owner, -1 if unknown.
		/// </summary>
		public long GroupId;
		/// <summary>
		/// Unix file mode, -1 if unknown.
		/// </summary>
		public long Filemode;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVIODirContext {
		public URLContext* UrlContext;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct URLContext {
	}

	/// <summary>
	/// This structure contains the parameters describing the frames that will be passed to this filter.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBufferSrcParameters {
		/// <summary>
		/// video: the pixel format, value corresponds to enum AVPixelFormat audio: the sample format, value corresponds to enum AVSampleFormat
		/// </summary>
		public int Format;
		/// <summary>
		/// The timebase to be used for the timestamps on the input frames.
		/// </summary>
		public AVRational TimeBase;
		/// <summary>
		/// Video only, the display dimensions of the input frames.
		/// </summary>
		public int Width;
		/// <summary>
		/// Video only, the display dimensions of the input frames.
		/// </summary>
		public int Height;
		/// <summary>
		/// Video only, the sample (pixel) aspect ratio.
		/// </summary>
		public AVRational SampleAspectRatio;
		/// <summary>
		/// Video only, the frame rate of the input video. This field must only be set to a non-zero value if input stream has a known constant framerate and should be left at its initial value if the framerate is variable or unknown.
		/// </summary>
		public AVRational FrameRate;
		/// <summary>
		/// Video with a hwaccel pixel format only. This should be a reference to an AVHWFramesContext instance describing the input frames.
		/// </summary>
		public AVBufferRef* HwFramesCtx;
		/// <summary>
		/// Audio only, the audio sampling rate in samples per second.
		/// </summary>
		public int SampleRate;
		/// <summary>
		/// Audio only, the audio channel layout
		/// </summary>
		public ulong ChannelLayout;
	}

	/// <summary>
	/// Struct to use for initializing a buffersink context.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVBufferSinkParams {
		/// <summary>
		/// list of allowed pixel formats, terminated by AV_PIX_FMT_NONE
		/// </summary>
		public AVPixelFormat* PixelFmts;
	}

	/// <summary>
	/// Struct to use for initializing an abuffersink context.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVABufferSinkParams {
		/// <summary>
		/// list of allowed sample formats, terminated by AV_SAMPLE_FMT_NONE
		/// </summary>
		public AVSampleFormat* SampleFmts;
		/// <summary>
		/// list of allowed channel layouts, terminated by -1
		/// </summary>
		public long* ChannelLayouts;
		/// <summary>
		/// list of allowed channel counts, terminated by -1
		/// </summary>
		public int* ChannelCounts;
		/// <summary>
		/// if not 0, accept any channel count or layout
		/// </summary>
		public int AllChannelCounts;
		/// <summary>
		/// list of allowed sample rates, terminated by -1
		/// </summary>
		public int* SampleRates;
	}

	/// <summary>
	/// Structure describes basic parameters of the device.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDeviceInfo {
		/// <summary>
		/// device name, format depends on device
		/// </summary>
		public byte* Name;
		/// <summary>
		/// human friendly name
		/// </summary>
		public byte* Description;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVDeviceRect {
		/// <summary>
		/// x coordinate of top left corner
		/// </summary>
		public int X;
		/// <summary>
		/// y coordinate of top left corner
		/// </summary>
		public int Y;
		/// <summary>
		/// width
		/// </summary>
		public int Width;
		/// <summary>
		/// height
		/// </summary>
		public int Height;
	}

#pragma warning restore IDE1006 // 命名样式
}
