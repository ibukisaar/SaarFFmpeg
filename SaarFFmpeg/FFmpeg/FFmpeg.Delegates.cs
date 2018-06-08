using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Internal;

namespace Saar.FFmpeg.Delegates
{
    #pragma warning disable IDE1006 // 命名样式
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_fifo_generic_write_func(void* p0, void* p1, int p2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_fifo_generic_read_func(void* p0, void* p1, int p2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_fifo_generic_peek_func(void* p0, void* p1, int p2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_fifo_generic_peek_at_func(void* p0, void* p1, int p2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate string AVClass_ItemName(void* ctx);
    public unsafe struct AVClass_ItemName_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string Invoke(void* ctx) => Marshal.GetDelegateForFunctionPointer<AVClass_ItemName>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVClass_ItemName_Func(AVClass_ItemName func) => new AVClass_ItemName_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* AVClass_ChildNext(void* obj, void* prev);
    public unsafe struct AVClass_ChildNext_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void* Invoke(void* obj, void* prev) => Marshal.GetDelegateForFunctionPointer<AVClass_ChildNext>(Pointer)(obj, prev);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVClass_ChildNext_Func(AVClass_ChildNext func) => new AVClass_ChildNext_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVClass* AVClass_ChildClassNext(AVClass* prev);
    public unsafe struct AVClass_ChildClassNext_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AVClass* Invoke(AVClass* prev) => Marshal.GetDelegateForFunctionPointer<AVClass_ChildClassNext>(Pointer)(prev);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVClass_ChildClassNext_Func(AVClass_ChildClassNext func) => new AVClass_ChildClassNext_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVClassCategory AVClass_GetCategory(void* ctx);
    public unsafe struct AVClass_GetCategory_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AVClassCategory Invoke(void* ctx) => Marshal.GetDelegateForFunctionPointer<AVClass_GetCategory>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVClass_GetCategory_Func(AVClass_GetCategory func) => new AVClass_GetCategory_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVClass_QueryRanges(AVOptionRanges** p0, void* obj, [MarshalAs(UnmanagedType.LPStr)] string key, int flags);
    public unsafe struct AVClass_QueryRanges_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVOptionRanges** p0, void* obj, [MarshalAs(UnmanagedType.LPStr)] string key, int flags) => Marshal.GetDelegateForFunctionPointer<AVClass_QueryRanges>(Pointer)(p0, obj, key, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVClass_QueryRanges_Func(AVClass_QueryRanges func) => new AVClass_QueryRanges_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_log_set_callback_callback(void* p0, int p1, [MarshalAs(UnmanagedType.LPStr)] string p2, byte* p3);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_buffer_create_free(void* opaque, byte* data);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVBufferRef* av_buffer_pool_init_alloc(int size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVBufferRef* av_buffer_pool_init2_alloc(void* opaque, int size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_buffer_pool_init2_pool_free(void* opaque);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVHWDeviceContext_Free(AVHWDeviceContext* ctx);
    public unsafe struct AVHWDeviceContext_Free_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVHWDeviceContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVHWDeviceContext_Free>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWDeviceContext_Free_Func(AVHWDeviceContext_Free func) => new AVHWDeviceContext_Free_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVHWFramesContext_Free(AVHWFramesContext* ctx);
    public unsafe struct AVHWFramesContext_Free_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVHWFramesContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVHWFramesContext_Free>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWFramesContext_Free_Func(AVHWFramesContext_Free func) => new AVHWFramesContext_Free_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVD3D11VADeviceContext_Lock(void* lock_ctx);
    public unsafe struct AVD3D11VADeviceContext_Lock_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(void* lock_ctx) => Marshal.GetDelegateForFunctionPointer<AVD3D11VADeviceContext_Lock>(Pointer)(lock_ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVD3D11VADeviceContext_Lock_Func(AVD3D11VADeviceContext_Lock func) => new AVD3D11VADeviceContext_Lock_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVD3D11VADeviceContext_Unlock(void* lock_ctx);
    public unsafe struct AVD3D11VADeviceContext_Unlock_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(void* lock_ctx) => Marshal.GetDelegateForFunctionPointer<AVD3D11VADeviceContext_Unlock>(Pointer)(lock_ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVD3D11VADeviceContext_Unlock_Func(AVD3D11VADeviceContext_Unlock func) => new AVD3D11VADeviceContext_Unlock_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_format_set_open_cb_callback(AVFormatContext* s, AVIOContext** pb, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOpenCallback(AVFormatContext* s, AVIOContext** pb, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_format_set_control_message_cb_callback(AVFormatContext* s, int type, void* data, IntPtr data_size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_format_control_message(AVFormatContext* s, int type, void* data, IntPtr data_size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_CheckBitstream(AVFormatContext* p0, AVPacket* pkt);
    public unsafe struct AVOutputFormat_CheckBitstream_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, AVPacket* pkt) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_CheckBitstream>(Pointer)(p0, pkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_CheckBitstream_Func(AVOutputFormat_CheckBitstream func) => new AVOutputFormat_CheckBitstream_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVOutputFormat_Deinit(AVFormatContext* p0);
    public unsafe struct AVOutputFormat_Deinit_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_Deinit>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_Deinit_Func(AVOutputFormat_Deinit func) => new AVOutputFormat_Deinit_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_Init(AVFormatContext* p0);
    public unsafe struct AVOutputFormat_Init_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_Init>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_Init_Func(AVOutputFormat_Init func) => new AVOutputFormat_Init_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_FreeDeviceCapabilities(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps);
    public unsafe struct AVOutputFormat_FreeDeviceCapabilities_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_FreeDeviceCapabilities>(Pointer)(s, caps);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_FreeDeviceCapabilities_Func(AVOutputFormat_FreeDeviceCapabilities func) => new AVOutputFormat_FreeDeviceCapabilities_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_CreateDeviceCapabilities(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps);
    public unsafe struct AVOutputFormat_CreateDeviceCapabilities_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_CreateDeviceCapabilities>(Pointer)(s, caps);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_CreateDeviceCapabilities_Func(AVOutputFormat_CreateDeviceCapabilities func) => new AVOutputFormat_CreateDeviceCapabilities_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_GetDeviceList(AVFormatContext* s, AVDeviceInfoList* device_list);
    public unsafe struct AVOutputFormat_GetDeviceList_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceInfoList* device_list) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_GetDeviceList>(Pointer)(s, device_list);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_GetDeviceList_Func(AVOutputFormat_GetDeviceList func) => new AVOutputFormat_GetDeviceList_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_WriteUncodedFrame(AVFormatContext* p0, int stream_index, AVFrame** frame, uint flags);
    public unsafe struct AVOutputFormat_WriteUncodedFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, int stream_index, AVFrame** frame, uint flags) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_WriteUncodedFrame>(Pointer)(p0, stream_index, frame, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_WriteUncodedFrame_Func(AVOutputFormat_WriteUncodedFrame func) => new AVOutputFormat_WriteUncodedFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_ControlMessage(AVFormatContext* s, int type, void* data, IntPtr data_size);
    public unsafe struct AVOutputFormat_ControlMessage_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, int type, void* data, IntPtr data_size) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_ControlMessage>(Pointer)(s, type, data, data_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_ControlMessage_Func(AVOutputFormat_ControlMessage func) => new AVOutputFormat_ControlMessage_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVOutputFormat_GetOutputTimestamp(AVFormatContext* s, int stream, long* dts, long* wall);
    public unsafe struct AVOutputFormat_GetOutputTimestamp_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVFormatContext* s, int stream, long* dts, long* wall) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_GetOutputTimestamp>(Pointer)(s, stream, dts, wall);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_GetOutputTimestamp_Func(AVOutputFormat_GetOutputTimestamp func) => new AVOutputFormat_GetOutputTimestamp_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_QueryCodec(AVCodecID id, int std_compliance);
    public unsafe struct AVOutputFormat_QueryCodec_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecID id, int std_compliance) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_QueryCodec>(Pointer)(id, std_compliance);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_QueryCodec_Func(AVOutputFormat_QueryCodec func) => new AVOutputFormat_QueryCodec_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_InterleavePacket(AVFormatContext* p0, AVPacket* @out, AVPacket* @in, int flush);
    public unsafe struct AVOutputFormat_InterleavePacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, AVPacket* @out, AVPacket* @in, int flush) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_InterleavePacket>(Pointer)(p0, @out, @in, flush);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_InterleavePacket_Func(AVOutputFormat_InterleavePacket func) => new AVOutputFormat_InterleavePacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_WriteTrailer(AVFormatContext* p0);
    public unsafe struct AVOutputFormat_WriteTrailer_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_WriteTrailer>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_WriteTrailer_Func(AVOutputFormat_WriteTrailer func) => new AVOutputFormat_WriteTrailer_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_WritePacket(AVFormatContext* p0, AVPacket* pkt);
    public unsafe struct AVOutputFormat_WritePacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, AVPacket* pkt) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_WritePacket>(Pointer)(p0, pkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_WritePacket_Func(AVOutputFormat_WritePacket func) => new AVOutputFormat_WritePacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVOutputFormat_WriteHeader(AVFormatContext* p0);
    public unsafe struct AVOutputFormat_WriteHeader_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVOutputFormat_WriteHeader>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVOutputFormat_WriteHeader_Func(AVOutputFormat_WriteHeader func) => new AVOutputFormat_WriteHeader_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVFormatContext_IoClose(AVFormatContext* s, AVIOContext* pb);
    public unsafe struct AVFormatContext_IoClose_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVFormatContext* s, AVIOContext* pb) => Marshal.GetDelegateForFunctionPointer<AVFormatContext_IoClose>(Pointer)(s, pb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFormatContext_IoClose_Func(AVFormatContext_IoClose func) => new AVFormatContext_IoClose_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFormatContext_IoOpen(AVFormatContext* s, AVIOContext** pb, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVDictionary** options);
    public unsafe struct AVFormatContext_IoOpen_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVIOContext** pb, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVDictionary** options) => Marshal.GetDelegateForFunctionPointer<AVFormatContext_IoOpen>(Pointer)(s, pb, url, flags, options);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFormatContext_IoOpen_Func(AVFormatContext_IoOpen func) => new AVFormatContext_IoOpen_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFormatContext_OpenCb(AVFormatContext* s, AVIOContext** p, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options);
    public unsafe struct AVFormatContext_OpenCb_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVIOContext** p, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options) => Marshal.GetDelegateForFunctionPointer<AVFormatContext_OpenCb>(Pointer)(s, p, url, flags, int_cb, options);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFormatContext_OpenCb_Func(AVFormatContext_OpenCb func) => new AVFormatContext_OpenCb_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFormatContext_ControlMessageCb(AVFormatContext* s, int type, void* data, IntPtr data_size);
    public unsafe struct AVFormatContext_ControlMessageCb_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, int type, void* data, IntPtr data_size) => Marshal.GetDelegateForFunctionPointer<AVFormatContext_ControlMessageCb>(Pointer)(s, type, data, data_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFormatContext_ControlMessageCb_Func(AVFormatContext_ControlMessageCb func) => new AVFormatContext_ControlMessageCb_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOInterruptCB_Callback(void* p0);
    public unsafe struct AVIOInterruptCB_Callback_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* p0) => Marshal.GetDelegateForFunctionPointer<AVIOInterruptCB_Callback>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOInterruptCB_Callback_Func(AVIOInterruptCB_Callback func) => new AVIOInterruptCB_Callback_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_ShortSeekGet(void* opaque);
    public unsafe struct AVIOContext_ShortSeekGet_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* opaque) => Marshal.GetDelegateForFunctionPointer<AVIOContext_ShortSeekGet>(Pointer)(opaque);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_ShortSeekGet_Func(AVIOContext_ShortSeekGet func) => new AVIOContext_ShortSeekGet_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_WriteDataType(void* opaque, byte* buf, int buf_size, AVIODataMarkerType type, long time);
    public unsafe struct AVIOContext_WriteDataType_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* opaque, byte* buf, int buf_size, AVIODataMarkerType type, long time) => Marshal.GetDelegateForFunctionPointer<AVIOContext_WriteDataType>(Pointer)(opaque, buf, buf_size, type, time);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_WriteDataType_Func(AVIOContext_WriteDataType func) => new AVIOContext_WriteDataType_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long AVIOContext_ReadSeek(void* opaque, int stream_index, long timestamp, int flags);
    public unsafe struct AVIOContext_ReadSeek_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke(void* opaque, int stream_index, long timestamp, int flags) => Marshal.GetDelegateForFunctionPointer<AVIOContext_ReadSeek>(Pointer)(opaque, stream_index, timestamp, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_ReadSeek_Func(AVIOContext_ReadSeek func) => new AVIOContext_ReadSeek_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_ReadPause(void* opaque, int pause);
    public unsafe struct AVIOContext_ReadPause_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* opaque, int pause) => Marshal.GetDelegateForFunctionPointer<AVIOContext_ReadPause>(Pointer)(opaque, pause);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_ReadPause_Func(AVIOContext_ReadPause func) => new AVIOContext_ReadPause_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate ulong AVIOContext_UpdateChecksum(ulong checksum, byte* buf, uint size);
    public unsafe struct AVIOContext_UpdateChecksum_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Invoke(ulong checksum, byte* buf, uint size) => Marshal.GetDelegateForFunctionPointer<AVIOContext_UpdateChecksum>(Pointer)(checksum, buf, size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_UpdateChecksum_Func(AVIOContext_UpdateChecksum func) => new AVIOContext_UpdateChecksum_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long AVIOContext_Seek(void* opaque, long offset, int whence);
    public unsafe struct AVIOContext_Seek_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke(void* opaque, long offset, int whence) => Marshal.GetDelegateForFunctionPointer<AVIOContext_Seek>(Pointer)(opaque, offset, whence);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_Seek_Func(AVIOContext_Seek func) => new AVIOContext_Seek_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_WritePacket(void* opaque, byte* buf, int buf_size);
    public unsafe struct AVIOContext_WritePacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* opaque, byte* buf, int buf_size) => Marshal.GetDelegateForFunctionPointer<AVIOContext_WritePacket>(Pointer)(opaque, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_WritePacket_Func(AVIOContext_WritePacket func) => new AVIOContext_WritePacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_ReadPacket(void* opaque, byte* buf, int buf_size);
    public unsafe struct AVIOContext_ReadPacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(void* opaque, byte* buf, int buf_size) => Marshal.GetDelegateForFunctionPointer<AVIOContext_ReadPacket>(Pointer)(opaque, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVIOContext_ReadPacket_Func(AVIOContext_ReadPacket func) => new AVIOContext_ReadPacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_FreeDeviceCapabilities(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps);
    public unsafe struct AVInputFormat_FreeDeviceCapabilities_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_FreeDeviceCapabilities>(Pointer)(s, caps);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_FreeDeviceCapabilities_Func(AVInputFormat_FreeDeviceCapabilities func) => new AVInputFormat_FreeDeviceCapabilities_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_CreateDeviceCapabilities(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps);
    public unsafe struct AVInputFormat_CreateDeviceCapabilities_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceCapabilitiesQuery* caps) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_CreateDeviceCapabilities>(Pointer)(s, caps);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_CreateDeviceCapabilities_Func(AVInputFormat_CreateDeviceCapabilities func) => new AVInputFormat_CreateDeviceCapabilities_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_GetDeviceList(AVFormatContext* s, AVDeviceInfoList* device_list);
    public unsafe struct AVInputFormat_GetDeviceList_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, AVDeviceInfoList* device_list) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_GetDeviceList>(Pointer)(s, device_list);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_GetDeviceList_Func(AVInputFormat_GetDeviceList func) => new AVInputFormat_GetDeviceList_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadSeek2(AVFormatContext* s, int stream_index, long min_ts, long ts, long max_ts, int flags);
    public unsafe struct AVInputFormat_ReadSeek2_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* s, int stream_index, long min_ts, long ts, long max_ts, int flags) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadSeek2>(Pointer)(s, stream_index, min_ts, ts, max_ts, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadSeek2_Func(AVInputFormat_ReadSeek2 func) => new AVInputFormat_ReadSeek2_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadPause(AVFormatContext* p0);
    public unsafe struct AVInputFormat_ReadPause_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadPause>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadPause_Func(AVInputFormat_ReadPause func) => new AVInputFormat_ReadPause_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadPlay(AVFormatContext* p0);
    public unsafe struct AVInputFormat_ReadPlay_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadPlay>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadPlay_Func(AVInputFormat_ReadPlay func) => new AVInputFormat_ReadPlay_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long AVInputFormat_ReadTimestamp(AVFormatContext* s, int stream_index, long* pos, long pos_limit);
    public unsafe struct AVInputFormat_ReadTimestamp_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long Invoke(AVFormatContext* s, int stream_index, long* pos, long pos_limit) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadTimestamp>(Pointer)(s, stream_index, pos, pos_limit);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadTimestamp_Func(AVInputFormat_ReadTimestamp func) => new AVInputFormat_ReadTimestamp_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadSeek(AVFormatContext* p0, int stream_index, long timestamp, int flags);
    public unsafe struct AVInputFormat_ReadSeek_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, int stream_index, long timestamp, int flags) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadSeek>(Pointer)(p0, stream_index, timestamp, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadSeek_Func(AVInputFormat_ReadSeek func) => new AVInputFormat_ReadSeek_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadClose(AVFormatContext* p0);
    public unsafe struct AVInputFormat_ReadClose_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadClose>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadClose_Func(AVInputFormat_ReadClose func) => new AVInputFormat_ReadClose_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadPacket(AVFormatContext* p0, AVPacket* pkt);
    public unsafe struct AVInputFormat_ReadPacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0, AVPacket* pkt) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadPacket>(Pointer)(p0, pkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadPacket_Func(AVInputFormat_ReadPacket func) => new AVInputFormat_ReadPacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadHeader(AVFormatContext* p0);
    public unsafe struct AVInputFormat_ReadHeader_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFormatContext* p0) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadHeader>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadHeader_Func(AVInputFormat_ReadHeader func) => new AVInputFormat_ReadHeader_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_ReadProbe(AVProbeData* p0);
    public unsafe struct AVInputFormat_ReadProbe_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVProbeData* p0) => Marshal.GetDelegateForFunctionPointer<AVInputFormat_ReadProbe>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVInputFormat_ReadProbe_Func(AVInputFormat_ReadProbe func) => new AVInputFormat_ReadProbe_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilterGraph_Execute(AVFilterContext* ctx, func func, void* arg, int* ret, int nb_jobs);
    public unsafe struct AVFilterGraph_Execute_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx, func func, void* arg, int* ret, int nb_jobs) => Marshal.GetDelegateForFunctionPointer<AVFilterGraph_Execute>(Pointer)(ctx, func, arg, ret, nb_jobs);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilterGraph_Execute_Func(AVFilterGraph_Execute func) => new AVFilterGraph_Execute_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_Activate(AVFilterContext* ctx);
    public unsafe struct AVFilter_Activate_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVFilter_Activate>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_Activate_Func(AVFilter_Activate func) => new AVFilter_Activate_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_InitOpaque(AVFilterContext* ctx, void* opaque);
    public unsafe struct AVFilter_InitOpaque_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx, void* opaque) => Marshal.GetDelegateForFunctionPointer<AVFilter_InitOpaque>(Pointer)(ctx, opaque);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_InitOpaque_Func(AVFilter_InitOpaque func) => new AVFilter_InitOpaque_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_ProcessCommand(AVFilterContext* p0, [MarshalAs(UnmanagedType.LPStr)] string cmd, [MarshalAs(UnmanagedType.LPStr)] string arg, byte* res, int res_len, int flags);
    public unsafe struct AVFilter_ProcessCommand_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* p0, [MarshalAs(UnmanagedType.LPStr)] string cmd, [MarshalAs(UnmanagedType.LPStr)] string arg, byte* res, int res_len, int flags) => Marshal.GetDelegateForFunctionPointer<AVFilter_ProcessCommand>(Pointer)(p0, cmd, arg, res, res_len, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_ProcessCommand_Func(AVFilter_ProcessCommand func) => new AVFilter_ProcessCommand_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_QueryFormats(AVFilterContext* p0);
    public unsafe struct AVFilter_QueryFormats_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* p0) => Marshal.GetDelegateForFunctionPointer<AVFilter_QueryFormats>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_QueryFormats_Func(AVFilter_QueryFormats func) => new AVFilter_QueryFormats_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVFilter_Uninit(AVFilterContext* ctx);
    public unsafe struct AVFilter_Uninit_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVFilterContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVFilter_Uninit>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_Uninit_Func(AVFilter_Uninit func) => new AVFilter_Uninit_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_InitDict(AVFilterContext* ctx, AVDictionary** options);
    public unsafe struct AVFilter_InitDict_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx, AVDictionary** options) => Marshal.GetDelegateForFunctionPointer<AVFilter_InitDict>(Pointer)(ctx, options);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_InitDict_Func(AVFilter_InitDict func) => new AVFilter_InitDict_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_Init(AVFilterContext* ctx);
    public unsafe struct AVFilter_Init_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVFilter_Init>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_Init_Func(AVFilter_Init func) => new AVFilter_Init_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_Preinit(AVFilterContext* ctx);
    public unsafe struct AVFilter_Preinit_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVFilterContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVFilter_Preinit>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVFilter_Preinit_Func(AVFilter_Preinit func) => new AVFilter_Preinit_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_InitThreadCopy(AVCodecContext* p0);
    public unsafe struct AVCodec_InitThreadCopy_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* p0) => Marshal.GetDelegateForFunctionPointer<AVCodec_InitThreadCopy>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_InitThreadCopy_Func(AVCodec_InitThreadCopy func) => new AVCodec_InitThreadCopy_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_UpdateThreadContext(AVCodecContext* dst, AVCodecContext* src);
    public unsafe struct AVCodec_UpdateThreadContext_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* dst, AVCodecContext* src) => Marshal.GetDelegateForFunctionPointer<AVCodec_UpdateThreadContext>(Pointer)(dst, src);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_UpdateThreadContext_Func(AVCodec_UpdateThreadContext func) => new AVCodec_UpdateThreadContext_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodec_InitStaticData(AVCodec* codec);
    public unsafe struct AVCodec_InitStaticData_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVCodec* codec) => Marshal.GetDelegateForFunctionPointer<AVCodec_InitStaticData>(Pointer)(codec);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_InitStaticData_Func(AVCodec_InitStaticData func) => new AVCodec_InitStaticData_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_Init(AVCodecContext* p0);
    public unsafe struct AVCodec_Init_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* p0) => Marshal.GetDelegateForFunctionPointer<AVCodec_Init>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_Init_Func(AVCodec_Init func) => new AVCodec_Init_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_EncodeSub(AVCodecContext* p0, byte* buf, int buf_size, AVSubtitle* sub);
    public unsafe struct AVCodec_EncodeSub_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* p0, byte* buf, int buf_size, AVSubtitle* sub) => Marshal.GetDelegateForFunctionPointer<AVCodec_EncodeSub>(Pointer)(p0, buf, buf_size, sub);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_EncodeSub_Func(AVCodec_EncodeSub func) => new AVCodec_EncodeSub_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_Encode2(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr);
    public unsafe struct AVCodec_Encode2_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr) => Marshal.GetDelegateForFunctionPointer<AVCodec_Encode2>(Pointer)(avctx, avpkt, frame, got_packet_ptr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_Encode2_Func(AVCodec_Encode2 func) => new AVCodec_Encode2_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_Decode(AVCodecContext* p0, void* outdata, int* outdata_size, AVPacket* avpkt);
    public unsafe struct AVCodec_Decode_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* p0, void* outdata, int* outdata_size, AVPacket* avpkt) => Marshal.GetDelegateForFunctionPointer<AVCodec_Decode>(Pointer)(p0, outdata, outdata_size, avpkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_Decode_Func(AVCodec_Decode func) => new AVCodec_Decode_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_Close(AVCodecContext* p0);
    public unsafe struct AVCodec_Close_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* p0) => Marshal.GetDelegateForFunctionPointer<AVCodec_Close>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_Close_Func(AVCodec_Close func) => new AVCodec_Close_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_SendFrame(AVCodecContext* avctx, AVFrame* frame);
    public unsafe struct AVCodec_SendFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVFrame* frame) => Marshal.GetDelegateForFunctionPointer<AVCodec_SendFrame>(Pointer)(avctx, frame);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_SendFrame_Func(AVCodec_SendFrame func) => new AVCodec_SendFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_ReceivePacket(AVCodecContext* avctx, AVPacket* avpkt);
    public unsafe struct AVCodec_ReceivePacket_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVPacket* avpkt) => Marshal.GetDelegateForFunctionPointer<AVCodec_ReceivePacket>(Pointer)(avctx, avpkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_ReceivePacket_Func(AVCodec_ReceivePacket func) => new AVCodec_ReceivePacket_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodec_ReceiveFrame(AVCodecContext* avctx, AVFrame* frame);
    public unsafe struct AVCodec_ReceiveFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVFrame* frame) => Marshal.GetDelegateForFunctionPointer<AVCodec_ReceiveFrame>(Pointer)(avctx, frame);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_ReceiveFrame_Func(AVCodec_ReceiveFrame func) => new AVCodec_ReceiveFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodec_Flush(AVCodecContext* p0);
    public unsafe struct AVCodec_Flush_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVCodecContext* p0) => Marshal.GetDelegateForFunctionPointer<AVCodec_Flush>(Pointer)(p0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodec_Flush_Func(AVCodec_Flush func) => new AVCodec_Flush_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodecContext_DrawHorizBand(AVCodecContext* s, AVFrame* src, ref int_array8 offset, int y, int type, int height);
    public unsafe struct AVCodecContext_DrawHorizBand_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVCodecContext* s, AVFrame* src, ref int_array8 offset, int y, int type, int height) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_DrawHorizBand>(Pointer)(s, src, ref offset, y, type, height);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_DrawHorizBand_Func(AVCodecContext_DrawHorizBand func) => new AVCodecContext_DrawHorizBand_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVPixelFormat AVCodecContext_GetFormat(AVCodecContext* s, AVPixelFormat* fmt);
    public unsafe struct AVCodecContext_GetFormat_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AVPixelFormat Invoke(AVCodecContext* s, AVPixelFormat* fmt) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_GetFormat>(Pointer)(s, fmt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_GetFormat_Func(AVCodecContext_GetFormat func) => new AVCodecContext_GetFormat_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_GetBuffer2(AVCodecContext* s, AVFrame* frame, int flags);
    public unsafe struct AVCodecContext_GetBuffer2_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* s, AVFrame* frame, int flags) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_GetBuffer2>(Pointer)(s, frame, flags);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_GetBuffer2_Func(AVCodecContext_GetBuffer2 func) => new AVCodecContext_GetBuffer2_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodecContext_RtpCallback(AVCodecContext* avctx, void* data, int size, int mb_nb);
    public unsafe struct AVCodecContext_RtpCallback_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVCodecContext* avctx, void* data, int size, int mb_nb) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_RtpCallback>(Pointer)(avctx, data, size, mb_nb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_RtpCallback_Func(AVCodecContext_RtpCallback func) => new AVCodecContext_RtpCallback_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_AllocFrame(AVCodecContext* avctx, AVFrame* frame);
    public unsafe struct AVHWAccel_AllocFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVFrame* frame) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_AllocFrame>(Pointer)(avctx, frame);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_AllocFrame_Func(AVHWAccel_AllocFrame func) => new AVHWAccel_AllocFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_StartFrame(AVCodecContext* avctx, byte* buf, uint buf_size);
    public unsafe struct AVHWAccel_StartFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, byte* buf, uint buf_size) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_StartFrame>(Pointer)(avctx, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_StartFrame_Func(AVHWAccel_StartFrame func) => new AVHWAccel_StartFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_DecodeParams(AVCodecContext* avctx, int type, byte* buf, uint buf_size);
    public unsafe struct AVHWAccel_DecodeParams_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, int type, byte* buf, uint buf_size) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_DecodeParams>(Pointer)(avctx, type, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_DecodeParams_Func(AVHWAccel_DecodeParams func) => new AVHWAccel_DecodeParams_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_DecodeSlice(AVCodecContext* avctx, byte* buf, uint buf_size);
    public unsafe struct AVHWAccel_DecodeSlice_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, byte* buf, uint buf_size) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_DecodeSlice>(Pointer)(avctx, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_DecodeSlice_Func(AVHWAccel_DecodeSlice func) => new AVHWAccel_DecodeSlice_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_EndFrame(AVCodecContext* avctx);
    public unsafe struct AVHWAccel_EndFrame_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_EndFrame>(Pointer)(avctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_EndFrame_Func(AVHWAccel_EndFrame func) => new AVHWAccel_EndFrame_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVHWAccel_DecodeMb(MpegEncContext* s);
    public unsafe struct AVHWAccel_DecodeMb_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(MpegEncContext* s) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_DecodeMb>(Pointer)(s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_DecodeMb_Func(AVHWAccel_DecodeMb func) => new AVHWAccel_DecodeMb_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_Init(AVCodecContext* avctx);
    public unsafe struct AVHWAccel_Init_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_Init>(Pointer)(avctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_Init_Func(AVHWAccel_Init func) => new AVHWAccel_Init_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_Uninit(AVCodecContext* avctx);
    public unsafe struct AVHWAccel_Uninit_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_Uninit>(Pointer)(avctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_Uninit_Func(AVHWAccel_Uninit func) => new AVHWAccel_Uninit_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_FrameParams(AVCodecContext* avctx, AVBufferRef* hw_frames_ctx);
    public unsafe struct AVHWAccel_FrameParams_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, AVBufferRef* hw_frames_ctx) => Marshal.GetDelegateForFunctionPointer<AVHWAccel_FrameParams>(Pointer)(avctx, hw_frames_ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVHWAccel_FrameParams_Func(AVHWAccel_FrameParams func) => new AVHWAccel_FrameParams_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int func(AVFilterContext* ctx, void* arg, int jobnr, int nb_jobs);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_Execute(AVCodecContext* c, func func, void* arg2, int* ret, int count, int size);
    public unsafe struct AVCodecContext_Execute_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* c, func func, void* arg2, int* ret, int count, int size) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_Execute>(Pointer)(c, func, arg2, ret, count, size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_Execute_Func(AVCodecContext_Execute func) => new AVCodecContext_Execute_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_Execute2(AVCodecContext* c, func func, void* arg2, int* ret, int count);
    public unsafe struct AVCodecContext_Execute2_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* c, func func, void* arg2, int* ret, int count) => Marshal.GetDelegateForFunctionPointer<AVCodecContext_Execute2>(Pointer)(c, func, arg2, ret, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecContext_Execute2_Func(AVCodecContext_Execute2 func) => new AVCodecContext_Execute2_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecParser_ParserInit(AVCodecParserContext* s);
    public unsafe struct AVCodecParser_ParserInit_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecParserContext* s) => Marshal.GetDelegateForFunctionPointer<AVCodecParser_ParserInit>(Pointer)(s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecParser_ParserInit_Func(AVCodecParser_ParserInit func) => new AVCodecParser_ParserInit_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecParser_ParserParse(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size);
    public unsafe struct AVCodecParser_ParserParse_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size) => Marshal.GetDelegateForFunctionPointer<AVCodecParser_ParserParse>(Pointer)(s, avctx, poutbuf, poutbuf_size, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecParser_ParserParse_Func(AVCodecParser_ParserParse func) => new AVCodecParser_ParserParse_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodecParser_ParserClose(AVCodecParserContext* s);
    public unsafe struct AVCodecParser_ParserClose_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVCodecParserContext* s) => Marshal.GetDelegateForFunctionPointer<AVCodecParser_ParserClose>(Pointer)(s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecParser_ParserClose_Func(AVCodecParser_ParserClose func) => new AVCodecParser_ParserClose_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecParser_Split(AVCodecContext* avctx, byte* buf, int buf_size);
    public unsafe struct AVCodecParser_Split_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVCodecContext* avctx, byte* buf, int buf_size) => Marshal.GetDelegateForFunctionPointer<AVCodecParser_Split>(Pointer)(avctx, buf, buf_size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVCodecParser_Split_Func(AVCodecParser_Split func) => new AVCodecParser_Split_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVBitStreamFilter_Init(AVBSFContext* ctx);
    public unsafe struct AVBitStreamFilter_Init_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVBSFContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVBitStreamFilter_Init>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVBitStreamFilter_Init_Func(AVBitStreamFilter_Init func) => new AVBitStreamFilter_Init_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVBitStreamFilter_Filter(AVBSFContext* ctx, AVPacket* pkt);
    public unsafe struct AVBitStreamFilter_Filter_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Invoke(AVBSFContext* ctx, AVPacket* pkt) => Marshal.GetDelegateForFunctionPointer<AVBitStreamFilter_Filter>(Pointer)(ctx, pkt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVBitStreamFilter_Filter_Func(AVBitStreamFilter_Filter func) => new AVBitStreamFilter_Filter_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVBitStreamFilter_Close(AVBSFContext* ctx);
    public unsafe struct AVBitStreamFilter_Close_Func
    {
        public IntPtr Pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Invoke(AVBSFContext* ctx) => Marshal.GetDelegateForFunctionPointer<AVBitStreamFilter_Close>(Pointer)(ctx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator AVBitStreamFilter_Close_Func(AVBitStreamFilter_Close func) => new AVBitStreamFilter_Close_Func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avcodec_default_execute_func(AVCodecContext* c2, void* arg2);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avcodec_default_execute2_func(AVCodecContext* c2, void* arg2, int p2, int p3);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_lockmgr_register_cb(void** mutex, AVLockOp op);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avio_alloc_context_read_packet(void* opaque, IntPtr buf, int buf_size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avio_alloc_context_write_packet(void* opaque, IntPtr buf, int buf_size);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long avio_alloc_context_seek(void* opaque, long offset, AVSeek whence);
    
    #pragma warning restore IDE1006 // 命名样式
}
