using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;

namespace Saar.FFmpeg.Internal
{
    #pragma warning disable IDE1006 // 命名样式
    public unsafe static partial class FFmpeg
    {
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_bitstream_filter_close(AVBitStreamFilterContext* bsf);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bitstream_filter_filter(AVBitStreamFilterContext* bsfc, AVCodecContext* avctx, [MarshalAs(UnmanagedType.LPStr)] string args, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size, int keyframe);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBitStreamFilterContext* av_bitstream_filter_init([MarshalAs(UnmanagedType.LPStr)] string name);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBitStreamFilter* av_bitstream_filter_next(AVBitStreamFilter* f);
        
        /// <summary>
        /// Allocate a context for a given bitstream filter. The caller must fill in the context parameters as described in the documentation and then call av_bsf_init() before sending any data to the filter.
        /// </summary>
        /// <param name="filter">the filter for which to allocate an instance.</param>
        /// <param name="ctx">a pointer into which the pointer to the newly-allocated context will be written. It must be freed with av_bsf_free() after the filtering is done.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_alloc(AVBitStreamFilter* filter, AVBSFContext** ctx);
        
        /// <summary>
        /// Reset the internal bitstream filter state / flush internal buffers.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_bsf_flush(AVBSFContext* ctx);
        
        /// <summary>
        /// Free a bitstream filter context and everything associated with it; write NULL into the supplied pointer.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_bsf_free(AVBSFContext** ctx);
        
        /// <summary>
        /// Returns a bitstream filter with the specified name or NULL if no such bitstream filter exists.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBitStreamFilter* av_bsf_get_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Get the AVClass for AVBSFContext. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVClass* av_bsf_get_class();
        
        /// <summary>
        /// Get null/pass-through bitstream filter.
        /// </summary>
        /// <param name="bsf">Pointer to be set to new instance of pass-through bitstream filter</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_get_null_filter(AVBSFContext** bsf);
        
        /// <summary>
        /// Prepare the filter for use, after all the parameters and options have been set.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_init(AVBSFContext* ctx);
        
        /// <summary>
        /// Iterate over all registered bitstream filters.
        /// </summary>
        /// <param name="opaque">a pointer where libavcodec will store the iteration state. Must point to NULL to start the iteration.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBitStreamFilter* av_bsf_iterate(void** opaque);
        
        /// <summary>
        /// Allocate empty list of bitstream filters. The list must be later freed by av_bsf_list_free() or finalized by av_bsf_list_finalize().
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBSFList* av_bsf_list_alloc();
        
        /// <summary>
        /// Append bitstream filter to the list of bitstream filters.
        /// </summary>
        /// <param name="lst">List to append to</param>
        /// <param name="bsf">Filter context to be appended</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_list_append(AVBSFList* lst, AVBSFContext* bsf);
        
        /// <summary>
        /// Construct new bitstream filter context given it&apos;s name and options and append it to the list of bitstream filters.
        /// </summary>
        /// <param name="lst">List to append to</param>
        /// <param name="bsf_name">Name of the bitstream filter</param>
        /// <param name="options">Options for the bitstream filter, can be set to NULL</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_list_append2(AVBSFList* lst, [MarshalAs(UnmanagedType.LPStr)] string bsf_name, AVDictionary** options);
        
        /// <summary>
        /// Finalize list of bitstream filters.
        /// </summary>
        /// <param name="lst">Filter list structure to be transformed</param>
        /// <param name="bsf">Pointer to be set to newly created</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_list_finalize(AVBSFList** lst, AVBSFContext** bsf);
        
        /// <summary>
        /// Free list of bitstream filters.
        /// </summary>
        /// <param name="lst">Pointer to pointer returned by av_bsf_list_alloc()</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_bsf_list_free(AVBSFList** lst);
        
        /// <summary>
        /// Parse string describing list of bitstream filters and create single Resulting allocated by av_bsf_alloc().
        /// </summary>
        /// <param name="str">String describing chain of bitstream filters in format `bsf1[=opt1=val1:opt2=val2][,bsf2]`</param>
        /// <param name="bsf">Pointer to be set to newly created</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_list_parse_str([MarshalAs(UnmanagedType.LPStr)] string str, AVBSFContext** bsf);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVBitStreamFilter* av_bsf_next(void** opaque);
        
        /// <summary>
        /// Retrieve a filtered packet.
        /// </summary>
        /// <param name="pkt">this struct will be filled with the contents of the filtered packet. It is owned by the caller and must be freed using av_packet_unref() when it is no longer needed. This parameter should be &quot;clean&quot; (i.e. freshly allocated with av_packet_alloc() or unreffed with av_packet_unref()) when this function is called. If this function returns successfully, the contents of pkt will be completely overwritten by the returned data. On failure, pkt is not touched.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_receive_packet(AVBSFContext* ctx, AVPacket* pkt);
        
        /// <summary>
        /// Submit a packet for filtering.
        /// </summary>
        /// <param name="pkt">the packet to filter. The bitstream filter will take ownership of the packet and reset the contents of pkt. pkt is not touched if an error occurs. This parameter may be NULL, which signals the end of the stream (i.e. no more packets will be sent). That will cause the filter to output any packets it may have buffered internally.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_bsf_send_packet(AVBSFContext* ctx, AVPacket* pkt);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static ushort* av_codec_get_chroma_intra_matrix(AVCodecContext* avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecDescriptor* av_codec_get_codec_descriptor(AVCodecContext* avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static uint av_codec_get_codec_properties(AVCodecContext* avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_codec_get_lowres(AVCodecContext* avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_codec_get_max_lowres(AVCodec* codec);
        
        /// <summary>
        /// Accessors for some AVCodecContext fields. These used to be provided for ABI compatibility, and do not need to be used anymore.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVRational av_codec_get_pkt_timebase(AVCodecContext* avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_codec_get_seek_preroll(AVCodecContext* avctx);
        
        /// <summary>
        /// Returns a non-zero number if codec is a decoder, zero otherwise
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_codec_is_decoder(AVCodec* codec);
        
        /// <summary>
        /// Returns a non-zero number if codec is an encoder, zero otherwise
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_codec_is_encoder(AVCodec* codec);
        
        /// <summary>
        /// Iterate over all registered codecs.
        /// </summary>
        /// <param name="opaque">a pointer where libavcodec will store the iteration state. Must point to NULL to start the iteration.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* av_codec_iterate(void** opaque);
        
        /// <summary>
        /// If c is NULL, returns the first registered codec, if c is non-NULL, returns the next registered codec after c, or NULL if c is the last one.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* av_codec_next(AVCodec* c);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_codec_set_chroma_intra_matrix(AVCodecContext* avctx, ushort* val);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_codec_set_codec_descriptor(AVCodecContext* avctx, AVCodecDescriptor* desc);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_codec_set_lowres(AVCodecContext* avctx, int val);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_codec_set_pkt_timebase(AVCodecContext* avctx, AVRational val);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_codec_set_seek_preroll(AVCodecContext* avctx, int val);
        
        /// <summary>
        /// Copy packet, including contents
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_copy_packet(AVPacket* dst, AVPacket* src);
        
        /// <summary>
        /// Copy packet side data
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_copy_packet_side_data(AVPacket* dst, AVPacket* src);
        
        /// <summary>
        /// Allocate a CPB properties structure and initialize its fields to default values.
        /// </summary>
        /// <param name="size">if non-NULL, the size of the allocated struct will be written here. This is useful for embedding it in side data.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCPBProperties* av_cpb_properties_alloc(ulong* size);
        
        /// <summary>
        /// Allocate an AVD3D11VAContext.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVD3D11VAContext* av_d3d11va_alloc_context();
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_dup_packet(AVPacket* pkt);
        
        /// <summary>
        /// Same behaviour av_fast_malloc but the buffer has additional AV_INPUT_BUFFER_PADDING_SIZE at the end which will always be 0.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_fast_padded_malloc(void* ptr, uint* size, IntPtr min_size);
        
        /// <summary>
        /// Same behaviour av_fast_padded_malloc except that buffer will always be 0-initialized after call.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_fast_padded_mallocz(void* ptr, uint* size, IntPtr min_size);
        
        /// <summary>
        /// Free a packet.
        /// </summary>
        /// <param name="pkt">packet to free</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_free_packet(AVPacket* pkt);
        
        /// <summary>
        /// Return audio frame duration.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="frame_bytes">size of the frame, or 0 if unknown</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_get_audio_frame_duration(AVCodecContext* avctx, int frame_bytes);
        
        /// <summary>
        /// This function is the same as av_get_audio_frame_duration(), except it works with AVCodecParameters instead of an AVCodecContext.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_get_audio_frame_duration2(AVCodecParameters* par, int frame_bytes);
        
        /// <summary>
        /// Return codec bits per sample.
        /// </summary>
        /// <param name="codec_id">the codec</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_get_bits_per_sample(AVCodecID codec_id);
        
        /// <summary>
        /// Put a string representing the codec tag codec_tag in buf.
        /// </summary>
        /// <param name="buf">buffer to place codec tag in</param>
        /// <param name="buf_size">size in bytes of buf</param>
        /// <param name="codec_tag">codec tag to assign</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static IntPtr av_get_codec_tag_string(byte* buf, IntPtr buf_size, uint codec_tag);
        
        /// <summary>
        /// Return codec bits per sample. Only return non-zero if the bits per sample is exactly correct, not an approximation.
        /// </summary>
        /// <param name="codec_id">the codec</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_get_exact_bits_per_sample(AVCodecID codec_id);
        
        /// <summary>
        /// Return the PCM codec associated with a sample format.
        /// </summary>
        /// <param name="be">endianness, 0 for little, 1 for big, -1 (or anything else) for native</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecID av_get_pcm_codec(AVSampleFormat fmt, int be);
        
        /// <summary>
        /// Return a name for the specified profile, if available.
        /// </summary>
        /// <param name="codec">the codec that is searched for the given profile</param>
        /// <param name="profile">the profile value for which a name is requested</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string av_get_profile_name(AVCodec* codec, int profile);
        
        /// <summary>
        /// Increase packet size, correctly zeroing padding
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="grow_by">number of bytes by which to increase the size of the packet</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_grow_packet(AVPacket* pkt, int grow_by);
        
        /// <summary>
        /// If hwaccel is NULL, returns the first registered hardware accelerator, if hwaccel is non-NULL, returns the next registered hardware accelerator after hwaccel, or NULL if hwaccel is the last one.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVHWAccel* av_hwaccel_next(AVHWAccel* hwaccel);
        
        /// <summary>
        /// Initialize optional fields of a packet with default values.
        /// </summary>
        /// <param name="pkt">packet</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_init_packet(AVPacket* pkt);
        
        /// <summary>
        /// Register a user provided lock manager supporting the operations specified by AVLockOp. The &quot;mutex&quot; argument to the function points to a (void *) where the lockmgr should store/get a pointer to a user allocated mutex. It is NULL upon AV_LOCK_CREATE and equal to the value left by the last call for all other ops. If the lock manager is unable to perform the op then it should leave the mutex in the same state as when it was called and return a non-zero value. However, when called with AV_LOCK_DESTROY the mutex will always be assumed to have been successfully destroyed. If av_lockmgr_register succeeds it will return a non-negative value, if it fails it will return a negative value and destroy all mutex and unregister all callbacks. av_lockmgr_register is not thread-safe, it must be called from a single thread before any calls which make use of locking are used.
        /// </summary>
        /// <param name="cb">User defined callback. av_lockmgr_register invokes calls to this callback and the previously registered callback. The callback will be used to create more than one mutex each of which must be backed by its own underlying locking mechanism (i.e. do not use a single static object to implement your lock manager). If cb is set to NULL the lockmgr will be unregistered.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_lockmgr_register(av_lockmgr_register_cb cb);
        
        /// <summary>
        /// Allocate the payload of a packet and initialize its fields with default values.
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="size">wanted payload size</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_new_packet(AVPacket* pkt, int size);
        
        /// <summary>
        /// Wrap an existing array as a packet side data.
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="type">side information type</param>
        /// <param name="data">the side data array. It must be allocated with the av_malloc() family of functions. The ownership of the data is transferred to pkt.</param>
        /// <param name="size">side information size</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_add_side_data(AVPacket* pkt, AVPacketSideDataType type, byte* data, IntPtr size);
        
        /// <summary>
        /// Allocate an AVPacket and set its fields to default values. The resulting struct must be freed using av_packet_free().
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPacket* av_packet_alloc();
        
        /// <summary>
        /// Create a new packet that references the same data as src.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPacket* av_packet_clone(AVPacket* src);
        
        /// <summary>
        /// Copy only &quot;properties&quot; fields from src to dst.
        /// </summary>
        /// <param name="dst">Destination packet</param>
        /// <param name="src">Source packet</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_copy_props(AVPacket* dst, AVPacket* src);
        
        /// <summary>
        /// Free the packet, if the packet is reference counted, it will be unreferenced first.
        /// </summary>
        /// <param name="pkt">packet to be freed. The pointer will be set to NULL.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_packet_free(ref AVPacket* pkt);
        
        /// <summary>
        /// Convenience function to free all the side data stored. All the other fields stay untouched.
        /// </summary>
        /// <param name="pkt">packet</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_packet_free_side_data(AVPacket* pkt);
        
        /// <summary>
        /// Initialize a reference-counted packet from av_malloc()ed data.
        /// </summary>
        /// <param name="pkt">packet to be initialized. This function will set the data, size, buf and destruct fields, all others are left untouched.</param>
        /// <param name="data">Data allocated by av_malloc() to be used as packet data. If this function returns successfully, the data is owned by the underlying AVBuffer. The caller may not access the data through other means.</param>
        /// <param name="size">size of data in bytes, without the padding. I.e. the full buffer size is assumed to be size + AV_INPUT_BUFFER_PADDING_SIZE.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_from_data(AVPacket* pkt, byte* data, int size);
        
        /// <summary>
        /// Get side information from packet.
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="type">desired side information type</param>
        /// <param name="size">pointer for side information size to store (optional)</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static byte* av_packet_get_side_data(AVPacket* pkt, AVPacketSideDataType type, int* size);
        
        /// <summary>
        /// Ensure the data described by a given packet is reference counted.
        /// </summary>
        /// <param name="pkt">packet whose data should be made reference counted.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_make_refcounted(AVPacket* pkt);
        
        /// <summary>
        /// Create a writable reference for the data described by a given packet, avoiding data copy if possible.
        /// </summary>
        /// <param name="pkt">Packet whose data should be made writable.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_make_writable(AVPacket* pkt);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_merge_side_data(AVPacket* pkt);
        
        /// <summary>
        /// Move every field in src to dst and reset src.
        /// </summary>
        /// <param name="dst">Destination packet</param>
        /// <param name="src">Source packet, will be reset</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_packet_move_ref(AVPacket* dst, AVPacket* src);
        
        /// <summary>
        /// Allocate new information of a packet.
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="type">side information type</param>
        /// <param name="size">side information size</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static byte* av_packet_new_side_data(AVPacket* pkt, AVPacketSideDataType type, int size);
        
        /// <summary>
        /// Pack a dictionary for use in side_data.
        /// </summary>
        /// <param name="dict">The dictionary to pack.</param>
        /// <param name="size">pointer to store the size of the returned data</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static byte* av_packet_pack_dictionary(AVDictionary* dict, int* size);
        
        /// <summary>
        /// Setup a new reference to the data described by a given packet
        /// </summary>
        /// <param name="dst">Destination packet</param>
        /// <param name="src">Source packet</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_ref(AVPacket* dst, AVPacket* src);
        
        /// <summary>
        /// Convert valid timing fields (timestamps / durations) in a packet from one timebase to another. Timestamps with unknown values (AV_NOPTS_VALUE) will be ignored.
        /// </summary>
        /// <param name="pkt">packet on which the conversion will be performed</param>
        /// <param name="tb_src">source timebase, in which the timing fields in pkt are expressed</param>
        /// <param name="tb_dst">destination timebase, to which the timing fields will be converted</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_packet_rescale_ts(AVPacket* pkt, AVRational tb_src, AVRational tb_dst);
        
        /// <summary>
        /// Shrink the already allocated side data buffer
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="type">side information type</param>
        /// <param name="size">new side information size</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_shrink_side_data(AVPacket* pkt, AVPacketSideDataType type, int size);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string av_packet_side_data_name(AVPacketSideDataType type);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_split_side_data(AVPacket* pkt);
        
        /// <summary>
        /// Unpack a dictionary from side_data.
        /// </summary>
        /// <param name="data">data from side_data</param>
        /// <param name="size">size of the data</param>
        /// <param name="dict">the metadata storage dictionary</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_packet_unpack_dictionary(byte* data, int size, AVDictionary** dict);
        
        /// <summary>
        /// Wipe the packet.
        /// </summary>
        /// <param name="pkt">The packet to be unreferenced.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_packet_unref(AVPacket* pkt);
        
        /// <summary>
        /// Returns 0 if the output buffer is a subset of the input, 1 if it is allocated and must be freed use AVBitStreamFilter
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_parser_change(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size, int keyframe);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_parser_close(AVCodecParserContext* s);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecParserContext* av_parser_init(int codec_id);
        
        /// <summary>
        /// Iterate over all registered codec parsers.
        /// </summary>
        /// <param name="opaque">a pointer where libavcodec will store the iteration state. Must point to NULL to start the iteration.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecParser* av_parser_iterate(void** opaque);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecParser* av_parser_next(AVCodecParser* c);
        
        /// <summary>
        /// Parse a packet.
        /// </summary>
        /// <param name="s">parser context.</param>
        /// <param name="avctx">codec context.</param>
        /// <param name="poutbuf">set to pointer to parsed buffer or NULL if not yet finished.</param>
        /// <param name="poutbuf_size">set to size of parsed buffer or zero if not yet finished.</param>
        /// <param name="buf">input buffer.</param>
        /// <param name="buf_size">buffer size in bytes without the padding. I.e. the full buffer size is assumed to be buf_size + AV_INPUT_BUFFER_PADDING_SIZE. To signal EOF, this should be 0 (so that the last frame can be output).</param>
        /// <param name="pts">input presentation timestamp.</param>
        /// <param name="dts">input decoding timestamp.</param>
        /// <param name="pos">input byte position in stream.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_parser_parse2(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size, long pts, long dts, long pos);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_picture_copy(AVPicture* dst, AVPicture* src, AVPixelFormat pix_fmt, int width, int height);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_picture_crop(AVPicture* dst, AVPicture* src, AVPixelFormat pix_fmt, int top_band, int left_band);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int av_picture_pad(AVPicture* dst, AVPicture* src, int height, int width, AVPixelFormat pix_fmt, int padtop, int padbottom, int padleft, int padright, int* color);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_register_bitstream_filter(AVBitStreamFilter* bsf);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_register_codec_parser(AVCodecParser* parser);
        
        /// <summary>
        /// Register the hardware accelerator hwaccel.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_register_hwaccel(AVHWAccel* hwaccel);
        
        /// <summary>
        /// Reduce packet size, correctly zeroing padding
        /// </summary>
        /// <param name="pkt">packet</param>
        /// <param name="size">new size</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void av_shrink_packet(AVPacket* pkt, int size);
        
        /// <summary>
        /// Encode extradata length to a buffer. Used by xiph codecs.
        /// </summary>
        /// <param name="s">buffer to write to; must be at least (v/255+1) bytes long</param>
        /// <param name="v">size of extradata in bytes</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static uint av_xiphlacing(byte* s, uint v);
        
        /// <summary>
        /// Modify width and height values so that they will result in a memory buffer that is acceptable for the codec if you do not use any horizontal padding.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_align_dimensions(AVCodecContext* s, int* width, int* height);
        
        /// <summary>
        /// Modify width and height values so that they will result in a memory buffer that is acceptable for the codec if you also ensure that all line sizes are a multiple of the respective linesize_align[i].
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_align_dimensions2(AVCodecContext* s, int* width, int* height, ref int_array8 linesize_align);
        
        /// <summary>
        /// Allocate an AVCodecContext and set its fields to default values. The resulting struct should be freed with avcodec_free_context().
        /// </summary>
        /// <param name="codec">if non-NULL, allocate private data and initialize defaults for the given codec. It is illegal to then call avcodec_open2() with a different codec. If NULL, then the codec-specific defaults won&apos;t be initialized, which may result in suboptimal default settings (this is important mainly for encoders, e.g. libx264).</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecContext* avcodec_alloc_context3(AVCodec* codec);
        
        /// <summary>
        /// Converts swscale x/y chroma position to AVChromaLocation.
        /// </summary>
        /// <param name="xpos">horizontal chroma sample position</param>
        /// <param name="ypos">vertical   chroma sample position</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVChromaLocation avcodec_chroma_pos_to_enum(int xpos, int ypos);
        
        /// <summary>
        /// Close a given AVCodecContext and free all the data associated with it (but not the AVCodecContext itself).
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_close(AVCodecContext* avctx);
        
        /// <summary>
        /// Return the libavcodec build-time configuration.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string avcodec_configuration();
        
        /// <summary>
        /// Copy the settings of the source AVCodecContext into the destination AVCodecContext. The resulting destination codec context will be unopened, i.e. you are required to call avcodec_open2() before you can use this AVCodecContext to decode/encode video/audio data.
        /// </summary>
        /// <param name="dest">target codec context, should be initialized with avcodec_alloc_context3(NULL), but otherwise uninitialized</param>
        /// <param name="src">source codec context</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_copy_context(AVCodecContext* dest, AVCodecContext* src);
        
        /// <summary>
        /// Decode the audio frame of size avpkt-&gt;size from avpkt-&gt;data into frame.
        /// </summary>
        /// <param name="avctx">the codec context</param>
        /// <param name="frame">The AVFrame in which to store decoded audio samples. The decoder will allocate a buffer for the decoded frame by calling the AVCodecContext.get_buffer2() callback. When AVCodecContext.refcounted_frames is set to 1, the frame is reference counted and the returned reference belongs to the caller. The caller must release the frame using av_frame_unref() when the frame is no longer needed. The caller may safely write to the frame if av_frame_is_writable() returns 1. When AVCodecContext.refcounted_frames is set to 0, the returned reference belongs to the decoder and is valid only until the next call to this function or until closing or flushing the decoder. The caller may not write to it.</param>
        /// <param name="got_frame_ptr">Zero if no frame could be decoded, otherwise it is non-zero. Note that this field being set to zero does not mean that an error has occurred. For decoders with AV_CODEC_CAP_DELAY set, no given decode call is guaranteed to produce a frame.</param>
        /// <param name="avpkt">The input AVPacket containing the input buffer. At least avpkt-&gt;data and avpkt-&gt;size should be set. Some decoders might also require additional fields to be set.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_decode_audio4(AVCodecContext* avctx, AVFrame* frame, int* got_frame_ptr, AVPacket* avpkt);
        
        /// <summary>
        /// Decode a subtitle message. Return a negative value on error, otherwise return the number of bytes used. If no subtitle could be decompressed, got_sub_ptr is zero. Otherwise, the subtitle is stored in *sub. Note that AV_CODEC_CAP_DR1 is not available for subtitle codecs. This is for simplicity, because the performance difference is expect to be negligible and reusing a get_buffer written for video codecs would probably perform badly due to a potentially very different allocation pattern.
        /// </summary>
        /// <param name="avctx">the codec context</param>
        /// <param name="sub">The Preallocated AVSubtitle in which the decoded subtitle will be stored, must be freed with avsubtitle_free if *got_sub_ptr is set.</param>
        /// <param name="got_sub_ptr">Zero if no subtitle could be decompressed, otherwise, it is nonzero.</param>
        /// <param name="avpkt">The input AVPacket containing the input buffer.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_decode_subtitle2(AVCodecContext* avctx, AVSubtitle* sub, int* got_sub_ptr, AVPacket* avpkt);
        
        /// <summary>
        /// Decode the video frame of size avpkt-&gt;size from avpkt-&gt;data into picture. Some decoders may support multiple frames in a single AVPacket, such decoders would then just decode the first frame.
        /// </summary>
        /// <param name="avctx">the codec context</param>
        /// <param name="picture">The AVFrame in which the decoded video frame will be stored. Use av_frame_alloc() to get an AVFrame. The codec will allocate memory for the actual bitmap by calling the AVCodecContext.get_buffer2() callback. When AVCodecContext.refcounted_frames is set to 1, the frame is reference counted and the returned reference belongs to the caller. The caller must release the frame using av_frame_unref() when the frame is no longer needed. The caller may safely write to the frame if av_frame_is_writable() returns 1. When AVCodecContext.refcounted_frames is set to 0, the returned reference belongs to the decoder and is valid only until the next call to this function or until closing or flushing the decoder. The caller may not write to it.</param>
        /// <param name="got_picture_ptr">Zero if no frame could be decompressed, otherwise, it is nonzero.</param>
        /// <param name="avpkt">The input AVPacket containing the input buffer. You can create such packet with av_init_packet() and by then setting data and size, some decoders might in addition need other fields like flags &amp;AV _PKT_FLAG_KEY. All decoders are designed to use the least fields possible.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_decode_video2(AVCodecContext* avctx, AVFrame* picture, int* got_picture_ptr, AVPacket* avpkt);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_default_execute(AVCodecContext* c, avcodec_default_execute_func func, void* arg, int* ret, int count, int size);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_default_execute2(AVCodecContext* c, avcodec_default_execute2_func func, void* arg, int* ret, int count);
        
        /// <summary>
        /// The default callback for AVCodecContext.get_buffer2(). It is made public so it can be called by custom get_buffer2() implementations for decoders without AV_CODEC_CAP_DR1 set.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_default_get_buffer2(AVCodecContext* s, AVFrame* frame, int flags);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPixelFormat avcodec_default_get_format(AVCodecContext* s, AVPixelFormat* fmt);
        
        /// <summary>
        /// Returns descriptor for given codec ID or NULL if no descriptor exists.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecDescriptor* avcodec_descriptor_get(AVCodecID id);
        
        /// <summary>
        /// Returns codec descriptor with the given name or NULL if no such descriptor exists.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecDescriptor* avcodec_descriptor_get_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Iterate over all codec descriptors known to libavcodec.
        /// </summary>
        /// <param name="prev">previous descriptor. NULL to get the first descriptor.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecDescriptor* avcodec_descriptor_next(AVCodecDescriptor* prev);
        
        /// <summary>
        /// Encode a frame of audio.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="avpkt">output AVPacket. The user can supply an output buffer by setting avpkt-&gt;data and avpkt-&gt;size prior to calling the function, but if the size of the user-provided data is not large enough, encoding will fail. If avpkt-&gt;data and avpkt-&gt;size are set, avpkt-&gt;destruct must also be set. All other AVPacket fields will be reset by the encoder using av_init_packet(). If avpkt-&gt;data is NULL, the encoder will allocate it. The encoder will set avpkt-&gt;size to the size of the output packet.</param>
        /// <param name="frame">AVFrame containing the raw audio data to be encoded. May be NULL when flushing an encoder that has the AV_CODEC_CAP_DELAY capability set. If AV_CODEC_CAP_VARIABLE_FRAME_SIZE is set, then each frame can have any number of samples. If it is not set, frame-&gt;nb_samples must be equal to avctx-&gt;frame_size for all frames except the last. The final frame may be smaller than avctx-&gt;frame_size.</param>
        /// <param name="got_packet_ptr">This field is set to 1 by libavcodec if the output packet is non-empty, and to 0 if it is empty. If the function returns an error, the packet can be assumed to be invalid, and the value of got_packet_ptr is undefined and should not be used.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_encode_audio2(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_encode_subtitle(AVCodecContext* avctx, byte* buf, int buf_size, AVSubtitle* sub);
        
        /// <summary>
        /// Encode a frame of video.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="avpkt">output AVPacket. The user can supply an output buffer by setting avpkt-&gt;data and avpkt-&gt;size prior to calling the function, but if the size of the user-provided data is not large enough, encoding will fail. All other AVPacket fields will be reset by the encoder using av_init_packet(). If avpkt-&gt;data is NULL, the encoder will allocate it. The encoder will set avpkt-&gt;size to the size of the output packet. The returned data (if any) belongs to the caller, he is responsible for freeing it.</param>
        /// <param name="frame">AVFrame containing the raw video data to be encoded. May be NULL when flushing an encoder that has the AV_CODEC_CAP_DELAY capability set.</param>
        /// <param name="got_packet_ptr">This field is set to 1 by libavcodec if the output packet is non-empty, and to 0 if it is empty. If the function returns an error, the packet can be assumed to be invalid, and the value of got_packet_ptr is undefined and should not be used.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_encode_video2(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr);
        
        /// <summary>
        /// Converts AVChromaLocation to swscale x/y chroma position.
        /// </summary>
        /// <param name="xpos">horizontal chroma sample position</param>
        /// <param name="ypos">vertical   chroma sample position</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_enum_to_chroma_pos(int* xpos, int* ypos, AVChromaLocation pos);
        
        /// <summary>
        /// Fill AVFrame audio data and linesize pointers.
        /// </summary>
        /// <param name="frame">the AVFrame frame-&gt;nb_samples must be set prior to calling the function. This function fills in frame-&gt;data, frame-&gt;extended_data, frame-&gt;linesize[0].</param>
        /// <param name="nb_channels">channel count</param>
        /// <param name="sample_fmt">sample format</param>
        /// <param name="buf">buffer to use for frame data</param>
        /// <param name="buf_size">size of buffer</param>
        /// <param name="align">plane size sample alignment (0 = default)</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_fill_audio_frame(AVFrame* frame, int nb_channels, AVSampleFormat sample_fmt, byte* buf, int buf_size, int align);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPixelFormat avcodec_find_best_pix_fmt_of_2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, bool has_alpha, int* loss_ptr);
        
        /// <summary>
        /// Find the best pixel format to convert to given a certain source pixel format. When converting from one pixel format to another, information loss may occur. For example, when converting from RGB24 to GRAY, the color information will be lost. Similarly, other losses occur when converting from some formats to other formats. avcodec_find_best_pix_fmt_of_2() searches which of the given pixel formats should be used to suffer the least amount of loss. The pixel formats from which it chooses one, are determined by the pix_fmt_list parameter.
        /// </summary>
        /// <param name="pix_fmt_list">AV_PIX_FMT_NONE terminated array of pixel formats to choose from</param>
        /// <param name="src_pix_fmt">source pixel format</param>
        /// <param name="has_alpha">Whether the source pixel format alpha channel is used.</param>
        /// <param name="loss_ptr">Combination of flags informing you what kind of losses will occur.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPixelFormat avcodec_find_best_pix_fmt_of_list(AVPixelFormat* pix_fmt_list, AVPixelFormat src_pix_fmt, bool has_alpha, int* loss_ptr);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVPixelFormat avcodec_find_best_pix_fmt2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, bool has_alpha, int* loss_ptr);
        
        /// <summary>
        /// Find a registered decoder with a matching codec ID.
        /// </summary>
        /// <param name="id">AVCodecID of the requested decoder</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* avcodec_find_decoder(AVCodecID id);
        
        /// <summary>
        /// Find a registered decoder with the specified name.
        /// </summary>
        /// <param name="name">name of the requested decoder</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* avcodec_find_decoder_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Find a registered encoder with a matching codec ID.
        /// </summary>
        /// <param name="id">AVCodecID of the requested encoder</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* avcodec_find_encoder(AVCodecID id);
        
        /// <summary>
        /// Find a registered encoder with the specified name.
        /// </summary>
        /// <param name="name">name of the requested encoder</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodec* avcodec_find_encoder_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Reset the internal decoder state / flush internal buffers. Should be called e.g. when seeking or when switching to a different stream.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_flush_buffers(AVCodecContext* avctx);
        
        /// <summary>
        /// Free the codec context and everything associated with it and write NULL to the provided pointer.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_free_context(AVCodecContext** avctx);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_get_chroma_sub_sample(AVPixelFormat pix_fmt, int* h_shift, int* v_shift);
        
        /// <summary>
        /// Get the AVClass for AVCodecContext. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVClass* avcodec_get_class();
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_get_context_defaults3(AVCodecContext* s, AVCodec* codec);
        
        /// <summary>
        /// Get the AVClass for AVFrame. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVClass* avcodec_get_frame_class();
        
        /// <summary>
        /// Retrieve supported hardware configurations for a codec.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecHWConfig* avcodec_get_hw_config(AVCodec* codec, int index);
        
        /// <summary>
        /// Create and return a AVHWFramesContext with values adequate for hardware decoding. This is meant to get called from the get_format callback, and is a helper for preparing a AVHWFramesContext for AVCodecContext.hw_frames_ctx. This API is for decoding with certain hardware acceleration modes/APIs only.
        /// </summary>
        /// <param name="avctx">The context which is currently calling get_format, and which implicitly contains all state needed for filling the returned AVHWFramesContext properly.</param>
        /// <param name="device_ref">A reference to the AVHWDeviceContext describing the device which will be used by the hardware decoder.</param>
        /// <param name="hw_pix_fmt">The hwaccel format you are going to return from get_format.</param>
        /// <param name="out_frames_ref">On success, set to a reference to an _uninitialized_ AVHWFramesContext, created from the given device_ref. Fields will be set to values required for decoding. Not changed if an error is returned.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_get_hw_frames_parameters(AVCodecContext* avctx, AVBufferRef* device_ref, AVPixelFormat hw_pix_fmt, AVBufferRef** out_frames_ref);
        
        /// <summary>
        /// Get the name of a codec.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string avcodec_get_name(AVCodecID id);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_get_pix_fmt_loss(AVPixelFormat dst_pix_fmt, AVPixelFormat src_pix_fmt, bool has_alpha);
        
        /// <summary>
        /// Get the AVClass for AVSubtitleRect. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVClass* avcodec_get_subtitle_rect_class();
        
        /// <summary>
        /// Get the type of the given codec.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVMediaType avcodec_get_type(AVCodecID codec_id);
        
        /// <summary>
        /// Returns a positive value if s is open (i.e. avcodec_open2() was called on it with no corresponding avcodec_close()), 0 otherwise.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_is_open(AVCodecContext* s);
        
        /// <summary>
        /// Return the libavcodec license.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string avcodec_license();
        
        /// <summary>
        /// Initialize the AVCodecContext to use the given AVCodec. Prior to using this function the context has to be allocated with avcodec_alloc_context3().
        /// </summary>
        /// <param name="avctx">The context to initialize.</param>
        /// <param name="codec">The codec to open this context for. If a non-NULL codec has been previously passed to avcodec_alloc_context3() or for this context, then this parameter MUST be either NULL or equal to the previously passed codec.</param>
        /// <param name="options">A dictionary filled with AVCodecContext and codec-private options. On return this object will be filled with options that were not found.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_open2(AVCodecContext* avctx, AVCodec* codec, AVDictionary** options);
        
        /// <summary>
        /// Allocate a new AVCodecParameters and set its fields to default values (unknown/invalid/0). The returned struct must be freed with avcodec_parameters_free().
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static AVCodecParameters* avcodec_parameters_alloc();
        
        /// <summary>
        /// Copy the contents of src to dst. Any allocated fields in dst are freed and replaced with newly allocated duplicates of the corresponding fields in src.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_parameters_copy(AVCodecParameters* dst, AVCodecParameters* src);
        
        /// <summary>
        /// Free an AVCodecParameters instance and everything associated with it and write NULL to the supplied pointer.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_parameters_free(AVCodecParameters** par);
        
        /// <summary>
        /// Fill the parameters struct based on the values from the supplied codec context. Any allocated fields in par are freed and replaced with duplicates of the corresponding fields in codec.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_parameters_from_context(AVCodecParameters* par, AVCodecContext* codec);
        
        /// <summary>
        /// Fill the codec context based on the values from the supplied codec parameters. Any allocated fields in codec that have a corresponding field in par are freed and replaced with duplicates of the corresponding field in par. Fields in codec that do not have a counterpart in par are not touched.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_parameters_to_context(AVCodecContext* codec, AVCodecParameters* par);
        
        /// <summary>
        /// Return a value representing the fourCC code associated to the pixel format pix_fmt, or 0 if no associated fourCC code can be found.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static uint avcodec_pix_fmt_to_codec_tag(AVPixelFormat pix_fmt);
        
        /// <summary>
        /// Return a name for the specified profile, if available.
        /// </summary>
        /// <param name="codec_id">the ID of the codec to which the requested profile belongs</param>
        /// <param name="profile">the profile value for which a name is requested</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static string avcodec_profile_name(AVCodecID codec_id, int profile);
        
        /// <summary>
        /// Return decoded output data from a decoder.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="frame">This will be set to a reference-counted video or audio frame (depending on the decoder type) allocated by the decoder. Note that the function will always call av_frame_unref(frame) before doing anything else.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_receive_frame(AVCodecContext* avctx, AVFrame* frame);
        
        /// <summary>
        /// Read encoded data from the encoder.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="avpkt">This will be set to a reference-counted packet allocated by the encoder. Note that the function will always call av_frame_unref(frame) before doing anything else.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_receive_packet(AVCodecContext* avctx, AVPacket* avpkt);
        
        /// <summary>
        /// Register the codec codec and initialize libavcodec.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_register(AVCodec* codec);
        
        /// <summary>
        /// Register all the codecs, parsers and bitstream filters which were enabled at configuration time. If you do not call this function you can select exactly which formats you want to support, by using the individual registration functions.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_register_all();
        
        /// <summary>
        /// Supply a raw video or audio frame to the encoder. Use avcodec_receive_packet() to retrieve buffered output packets.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="frame">AVFrame containing the raw audio or video frame to be encoded. Ownership of the frame remains with the caller, and the encoder will not write to the frame. The encoder may create a reference to the frame data (or copy it if the frame is not reference-counted). It can be NULL, in which case it is considered a flush packet.  This signals the end of the stream. If the encoder still has packets buffered, it will return them after this call. Once flushing mode has been entered, additional flush packets are ignored, and sending frames will return AVERROR_EOF.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_send_frame(AVCodecContext* avctx, AVFrame* frame);
        
        /// <summary>
        /// Supply raw packet data as input to a decoder.
        /// </summary>
        /// <param name="avctx">codec context</param>
        /// <param name="avpkt">The input AVPacket. Usually, this will be a single video frame, or several complete audio frames. Ownership of the packet remains with the caller, and the decoder will not write to the packet. The decoder may create a reference to the packet data (or copy it if the packet is not reference-counted). Unlike with older APIs, the packet is always fully consumed, and if it contains multiple frames (e.g. some audio codecs), will require you to call avcodec_receive_frame() multiple times afterwards before you can send a new packet. It can be NULL (or an AVPacket with data set to NULL and size set to 0); in this case, it is considered a flush packet, which signals the end of the stream. Sending the first flush packet will return success. Subsequent ones are unnecessary and will return AVERROR_EOF. If the decoder still has frames buffered, it will return them after sending a flush packet.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avcodec_send_packet(AVCodecContext* avctx, AVPacket* avpkt);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avcodec_string(byte* buf, int buf_size, AVCodecContext* enc, int encode);
        
        /// <summary>
        /// Return the LIBAVCODEC_VERSION_INT constant.
        /// </summary>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static uint avcodec_version();
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avpicture_alloc(AVPicture* picture, AVPixelFormat pix_fmt, int width, int height);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avpicture_fill(AVPicture* picture, byte* ptr, AVPixelFormat pix_fmt, int width, int height);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avpicture_free(AVPicture* picture);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avpicture_get_size(AVPixelFormat pix_fmt, int width, int height);
        
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static int avpicture_layout(AVPicture* src, AVPixelFormat pix_fmt, int width, int height, byte* dest, int dest_size);
        
        /// <summary>
        /// Free all allocated data in the given subtitle struct.
        /// </summary>
        /// <param name="sub">AVSubtitle to free.</param>
        [DllImport(Dll_AVCodec, CallingConvention = Convention)]
        public extern static void avsubtitle_free(AVSubtitle* sub);
        
    }
    #pragma warning restore IDE1006 // 命名样式
}
