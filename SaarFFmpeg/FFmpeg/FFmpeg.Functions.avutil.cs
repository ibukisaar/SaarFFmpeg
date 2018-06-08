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
		/// <summary>
		/// Add two rationals.
		/// </summary>
		/// <param name="b">First rational</param>
		/// <param name="c">Second rational</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_add_q(AVRational b, AVRational c);

		/// <summary>
		/// Add a value to a timestamp.
		/// </summary>
		/// <param name="ts_tb">Input timestamp time base</param>
		/// <param name="ts">Input timestamp</param>
		/// <param name="inc_tb">Time base of `inc`</param>
		/// <param name="inc">Value to be added</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_add_stable(AVRational ts_tb, long ts, AVRational inc_tb, long inc);

		/// <summary>
		/// Allocate an AVAudioFifo.
		/// </summary>
		/// <param name="sample_fmt">sample format</param>
		/// <param name="channels">number of channels</param>
		/// <param name="nb_samples">initial allocation size, in samples</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVAudioFifo* av_audio_fifo_alloc(AVSampleFormat sample_fmt, int channels, int nb_samples);

		/// <summary>
		/// Drain data from an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to drain</param>
		/// <param name="nb_samples">number of samples to drain</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_drain(AVAudioFifo* af, int nb_samples);

		/// <summary>
		/// Free an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to free</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_audio_fifo_free(AVAudioFifo* af);

		/// <summary>
		/// Peek data from an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to read from</param>
		/// <param name="data">audio data plane pointers</param>
		/// <param name="nb_samples">number of samples to peek</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_peek(AVAudioFifo* af, void** data, int nb_samples);

		/// <summary>
		/// Peek data from an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to read from</param>
		/// <param name="data">audio data plane pointers</param>
		/// <param name="nb_samples">number of samples to peek</param>
		/// <param name="offset">offset from current read position</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_peek_at(AVAudioFifo* af, void** data, int nb_samples, int offset);

		/// <summary>
		/// Read data from an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to read from</param>
		/// <param name="data">audio data plane pointers</param>
		/// <param name="nb_samples">number of samples to read</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_read(AVAudioFifo* af, void** data, int nb_samples);

		/// <summary>
		/// Reallocate an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to reallocate</param>
		/// <param name="nb_samples">new allocation size, in samples</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_realloc(AVAudioFifo* af, int nb_samples);

		/// <summary>
		/// Reset the AVAudioFifo buffer.
		/// </summary>
		/// <param name="af">AVAudioFifo to reset</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_audio_fifo_reset(AVAudioFifo* af);

		/// <summary>
		/// Get the current number of samples in the AVAudioFifo available for reading.
		/// </summary>
		/// <param name="af">the AVAudioFifo to query</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_size(AVAudioFifo* af);

		/// <summary>
		/// Get the current number of samples in the AVAudioFifo available for writing.
		/// </summary>
		/// <param name="af">the AVAudioFifo to query</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_space(AVAudioFifo* af);

		/// <summary>
		/// Write data to an AVAudioFifo.
		/// </summary>
		/// <param name="af">AVAudioFifo to write to</param>
		/// <param name="data">audio data plane pointers</param>
		/// <param name="nb_samples">number of samples to write</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_audio_fifo_write(AVAudioFifo* af, void** data, int nb_samples);

		/// <summary>
		/// Append a description of a channel layout to a bprint buffer.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_bprint_channel_layout(AVBPrint* bp, int nb_channels, AVChannelLayout channel_layout);

		/// <summary>
		/// Allocate an AVBuffer of the given size using av_malloc().
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_buffer_alloc(int size);

		/// <summary>
		/// Same as av_buffer_alloc(), except the returned buffer will be initialized to zero.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_buffer_allocz(int size);

		/// <summary>
		/// Create an AVBuffer from an existing array.
		/// </summary>
		/// <param name="data">data array</param>
		/// <param name="size">size of data in bytes</param>
		/// <param name="free">a callback for freeing this buffer&apos;s data</param>
		/// <param name="opaque">parameter to be got for processing or passed to free</param>
		/// <param name="flags">a combination of AV_BUFFER_FLAG_*</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_buffer_create(byte* data, int size, av_buffer_create_free free, void* opaque, int flags);

		/// <summary>
		/// Default free callback, which calls av_free() on the buffer data. This function is meant to be passed to av_buffer_create(), not called directly.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_buffer_default_free(void* opaque, byte* data);

		/// <summary>
		/// Returns the opaque parameter set by av_buffer_create.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_buffer_get_opaque(AVBufferRef* buf);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_buffer_get_ref_count(AVBufferRef* buf);

		/// <summary>
		/// Returns 1 if the caller may write to the data referred to by buf (which is true if and only if buf is the only reference to the underlying AVBuffer). Return 0 otherwise. A positive answer is valid until av_buffer_ref() is called on buf.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_buffer_is_writable(AVBufferRef* buf);

		/// <summary>
		/// Create a writable reference from a given buffer reference, avoiding data copy if possible.
		/// </summary>
		/// <param name="buf">buffer reference to make writable. On success, buf is either left untouched, or it is unreferenced and a new writable AVBufferRef is written in its place. On failure, buf is left untouched.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_buffer_make_writable(AVBufferRef** buf);

		/// <summary>
		/// Allocate a new AVBuffer, reusing an old buffer from the pool when available. This function may be called simultaneously from multiple threads.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_buffer_pool_get(AVBufferPool* pool);

		/// <summary>
		/// Allocate and initialize a buffer pool.
		/// </summary>
		/// <param name="size">size of each buffer in this pool</param>
		/// <param name="alloc">a function that will be used to allocate new buffers when the pool is empty. May be NULL, then the default allocator will be used (av_buffer_alloc()).</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferPool* av_buffer_pool_init(int size, av_buffer_pool_init_alloc alloc);

		/// <summary>
		/// Allocate and initialize a buffer pool with a more complex allocator.
		/// </summary>
		/// <param name="size">size of each buffer in this pool</param>
		/// <param name="opaque">arbitrary user data used by the allocator</param>
		/// <param name="alloc">a function that will be used to allocate new buffers when the pool is empty.</param>
		/// <param name="pool_free">a function that will be called immediately before the pool is freed. I.e. after av_buffer_pool_uninit() is called by the caller and all the frames are returned to the pool and freed. It is intended to uninitialize the user opaque data.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferPool* av_buffer_pool_init2(int size, void* opaque, av_buffer_pool_init2_alloc alloc, av_buffer_pool_init2_pool_free pool_free);

		/// <summary>
		/// Mark the pool as being available for freeing. It will actually be freed only once all the allocated buffers associated with the pool are released. Thus it is safe to call this function while some of the allocated buffers are still in use.
		/// </summary>
		/// <param name="pool">pointer to the pool to be freed. It will be set to NULL.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_buffer_pool_uninit(AVBufferPool** pool);

		/// <summary>
		/// Reallocate a given buffer.
		/// </summary>
		/// <param name="buf">a buffer reference to reallocate. On success, buf will be unreferenced and a new reference with the required size will be written in its place. On failure buf will be left untouched. *buf may be NULL, then a new buffer is allocated.</param>
		/// <param name="size">required new buffer size.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_buffer_realloc(AVBufferRef** buf, int size);

		/// <summary>
		/// Create a new reference to an AVBuffer.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_buffer_ref(AVBufferRef* buf);

		/// <summary>
		/// Free a given reference and automatically free the buffer if there are no more references to it.
		/// </summary>
		/// <param name="buf">the reference to be freed. The pointer is set to NULL on return.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_buffer_unref(AVBufferRef** buf);

		/// <summary>
		/// Non-inlined equivalent of av_mallocz_array().
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_calloc(IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Get the channel with the given index in channel_layout.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVChannelLayout av_channel_layout_extract_channel(AVChannelLayout channel_layout, int index);

		/// <summary>
		/// Returns the AVChromaLocation value for name or an AVError if not found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_chroma_location_from_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Returns the name for provided chroma location or NULL if unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_chroma_location_name(AVChromaLocation location);

		/// <summary>
		/// Returns the AVColorPrimaries value for name or an AVError if not found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_color_primaries_from_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Returns the name for provided color primaries or NULL if unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_color_primaries_name(AVColorPrimaries primaries);

		/// <summary>
		/// Returns the AVColorRange value for name or an AVError if not found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_color_range_from_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Returns the name for provided color range or NULL if unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_color_range_name(AVColorRange range);

		/// <summary>
		/// Returns the AVColorSpace value for name or an AVError if not found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_color_space_from_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Returns the name for provided color space or NULL if unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_color_space_name(AVColorSpace space);

		/// <summary>
		/// Returns the AVColorTransferCharacteristic value for name or an AVError if not found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_color_transfer_from_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Returns the name for provided color transfer or NULL if unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_color_transfer_name(AVColorTransferCharacteristic transfer);

		/// <summary>
		/// Compare the remainders of two integer operands divided by a common divisor.
		/// </summary>
		/// <param name="mod">Divisor; must be a power of 2</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_compare_mod(ulong a, ulong b, ulong mod);

		/// <summary>
		/// Compare two timestamps each in its own time base.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_compare_ts(long ts_a, AVRational tb_a, long ts_b, AVRational tb_b);

		/// <summary>
		/// Returns the number of logical CPU cores present.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_cpu_count();

		/// <summary>
		/// Get the maximum data alignment that may be required by FFmpeg.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static IntPtr av_cpu_max_align();

		/// <summary>
		/// Convert a double precision floating point number to a rational.
		/// </summary>
		/// <param name="d">`double` to convert</param>
		/// <param name="max">Maximum allowed numerator and denominator</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_d2q(double d, int max);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVClassCategory av_default_get_category(void* ptr);

		/// <summary>
		/// Return the context name
		/// </summary>
		/// <param name="ctx">The AVClass context</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_default_item_name(void* ctx);

		/// <summary>
		/// Copy entries from one AVDictionary struct into another.
		/// </summary>
		/// <param name="dst">pointer to a pointer to a AVDictionary struct. If *dst is NULL, this function will allocate a struct for you and put it in *dst</param>
		/// <param name="src">pointer to source AVDictionary struct</param>
		/// <param name="flags">flags to use when setting entries in *dst</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_copy(AVDictionary** dst, AVDictionary* src, int flags);

		/// <summary>
		/// Get number of entries in dictionary.
		/// </summary>
		/// <param name="m">dictionary</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_count(AVDictionary* m);

		/// <summary>
		/// Free all the memory allocated for an AVDictionary struct and all keys and values.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_dict_free(AVDictionary** m);

		/// <summary>
		/// Get a dictionary entry with matching key.
		/// </summary>
		/// <param name="key">matching key</param>
		/// <param name="prev">Set to the previous matching element to find the next. If set to NULL the first matching element is returned.</param>
		/// <param name="flags">a collection of AV_DICT_* flags controlling how the entry is retrieved</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVDictionaryEntry* av_dict_get(AVDictionary* m, [MarshalAs(UnmanagedType.LPStr)] string key, AVDictionaryEntry* prev, int flags);

		/// <summary>
		/// Get dictionary entries as a string.
		/// </summary>
		/// <param name="m">dictionary</param>
		/// <param name="buffer">Pointer to buffer that will be allocated with string containg entries. Buffer must be freed by the caller when is no longer needed.</param>
		/// <param name="key_val_sep">character used to separate key from value</param>
		/// <param name="pairs_sep">character used to separate two pairs from each other</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_get_string(AVDictionary* m, byte** buffer, byte key_val_sep, byte pairs_sep);

		/// <summary>
		/// Parse the key/value pairs list and add the parsed entries to a dictionary.
		/// </summary>
		/// <param name="key_val_sep">a 0-terminated list of characters used to separate key from value</param>
		/// <param name="pairs_sep">a 0-terminated list of characters used to separate two pairs from each other</param>
		/// <param name="flags">flags to use when adding to dictionary. AV_DICT_DONT_STRDUP_KEY and AV_DICT_DONT_STRDUP_VAL are ignored since the key/value tokens will always be duplicated.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_parse_string(AVDictionary** pm, [MarshalAs(UnmanagedType.LPStr)] string str, [MarshalAs(UnmanagedType.LPStr)] string key_val_sep, [MarshalAs(UnmanagedType.LPStr)] string pairs_sep, int flags);

		/// <summary>
		/// Set the given entry in *pm, overwriting an existing entry.
		/// </summary>
		/// <param name="pm">pointer to a pointer to a dictionary struct. If *pm is NULL a dictionary struct is allocated and put in *pm.</param>
		/// <param name="key">entry key to add to *pm (will either be av_strduped or added as a new key depending on flags)</param>
		/// <param name="value">entry value to add to *pm (will be av_strduped or added as a new key depending on flags). Passing a NULL value will cause an existing entry to be deleted.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_set(AVDictionary** pm, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value, int flags);

		/// <summary>
		/// Convenience wrapper for av_dict_set that converts the value to a string and stores it.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dict_set_int(AVDictionary** pm, [MarshalAs(UnmanagedType.LPStr)] string key, long value, int flags);

		/// <summary>
		/// Divide one rational by another.
		/// </summary>
		/// <param name="b">First rational</param>
		/// <param name="c">Second rational</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_div_q(AVRational b, AVRational c);

		/// <summary>
		/// Add the pointer to an element to a dynamic array.
		/// </summary>
		/// <param name="tab_ptr">Pointer to the array to grow</param>
		/// <param name="nb_ptr">Pointer to the number of elements in the array</param>
		/// <param name="elem">Element to add</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_dynarray_add(void* tab_ptr, int* nb_ptr, void* elem);

		/// <summary>
		/// Add an element to a dynamic array.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_dynarray_add_nofree(void* tab_ptr, int* nb_ptr, void* elem);

		/// <summary>
		/// Add an element of size `elem_size` to a dynamic array.
		/// </summary>
		/// <param name="tab_ptr">Pointer to the array to grow</param>
		/// <param name="nb_ptr">Pointer to the number of elements in the array</param>
		/// <param name="elem_size">Size in bytes of an element in the array</param>
		/// <param name="elem_data">Pointer to the data of the element to add. If `NULL`, the space of the newly added element is allocated but left uninitialized.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_dynarray2_add(void** tab_ptr, int* nb_ptr, IntPtr elem_size, byte* elem_data);

		/// <summary>
		/// Allocate a buffer, reusing the given one if large enough.
		/// </summary>
		/// <param name="ptr">Pointer to pointer to an already allocated buffer. `*ptr` will be overwritten with pointer to new buffer on success or `NULL` on failure</param>
		/// <param name="size">Pointer to current size of buffer `*ptr`. `*size` is changed to `min_size` in case of success or 0 in case of failure</param>
		/// <param name="min_size">New size of buffer `*ptr`</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fast_malloc(void* ptr, uint* size, IntPtr min_size);

		/// <summary>
		/// Allocate and clear a buffer, reusing the given one if large enough.
		/// </summary>
		/// <param name="ptr">Pointer to pointer to an already allocated buffer. `*ptr` will be overwritten with pointer to new buffer on success or `NULL` on failure</param>
		/// <param name="size">Pointer to current size of buffer `*ptr`. `*size` is changed to `min_size` in case of success or 0 in case of failure</param>
		/// <param name="min_size">New size of buffer `*ptr`</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fast_mallocz(void* ptr, uint* size, IntPtr min_size);

		/// <summary>
		/// Reallocate the given buffer if it is not large enough, otherwise do nothing.
		/// </summary>
		/// <param name="ptr">Already allocated buffer, or `NULL`</param>
		/// <param name="size">Pointer to current size of buffer `ptr`. `*size` is changed to `min_size` in case of success or 0 in case of failure</param>
		/// <param name="min_size">New size of buffer `ptr`</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_fast_realloc(void* ptr, uint* size, IntPtr min_size);

		/// <summary>
		/// Initialize an AVFifoBuffer.
		/// </summary>
		/// <param name="size">of FIFO</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFifoBuffer* av_fifo_alloc(uint size);

		/// <summary>
		/// Initialize an AVFifoBuffer.
		/// </summary>
		/// <param name="nmemb">number of elements</param>
		/// <param name="size">size of the single element</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFifoBuffer* av_fifo_alloc_array(IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Read and discard the specified amount of data from an AVFifoBuffer.
		/// </summary>
		/// <param name="f">AVFifoBuffer to read from</param>
		/// <param name="size">amount of data to read in bytes</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fifo_drain(AVFifoBuffer* f, int size);

		/// <summary>
		/// Free an AVFifoBuffer.
		/// </summary>
		/// <param name="f">AVFifoBuffer to free</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fifo_free(AVFifoBuffer* f);

		/// <summary>
		/// Free an AVFifoBuffer and reset pointer to NULL.
		/// </summary>
		/// <param name="f">AVFifoBuffer to free</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fifo_freep(AVFifoBuffer** f);

		/// <summary>
		/// Feed data from an AVFifoBuffer to a user-supplied callback. Similar as av_fifo_gereric_read but without discarding data.
		/// </summary>
		/// <param name="f">AVFifoBuffer to read from</param>
		/// <param name="dest">data destination</param>
		/// <param name="buf_size">number of bytes to read</param>
		/// <param name="func">generic read function</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_generic_peek(AVFifoBuffer* f, void* dest, int buf_size, av_fifo_generic_peek_func func);

		/// <summary>
		/// Feed data at specific position from an AVFifoBuffer to a user-supplied callback. Similar as av_fifo_gereric_read but without discarding data.
		/// </summary>
		/// <param name="f">AVFifoBuffer to read from</param>
		/// <param name="dest">data destination</param>
		/// <param name="offset">offset from current read position</param>
		/// <param name="buf_size">number of bytes to read</param>
		/// <param name="func">generic read function</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_generic_peek_at(AVFifoBuffer* f, void* dest, int offset, int buf_size, av_fifo_generic_peek_at_func func);

		/// <summary>
		/// Feed data from an AVFifoBuffer to a user-supplied callback.
		/// </summary>
		/// <param name="f">AVFifoBuffer to read from</param>
		/// <param name="dest">data destination</param>
		/// <param name="buf_size">number of bytes to read</param>
		/// <param name="func">generic read function</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_generic_read(AVFifoBuffer* f, void* dest, int buf_size, av_fifo_generic_read_func func);

		/// <summary>
		/// Feed data from a user-supplied callback to an AVFifoBuffer.
		/// </summary>
		/// <param name="f">AVFifoBuffer to write to</param>
		/// <param name="src">data source; non-const since it may be used as a modifiable context by the function defined in func</param>
		/// <param name="size">number of bytes to write</param>
		/// <param name="func">generic write function; the first parameter is src, the second is dest_buf, the third is dest_buf_size. func must return the number of bytes written to dest_buf, or &lt; = 0 to indicate no more data available to write. If func is NULL, src is interpreted as a simple byte array for source data.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_generic_write(AVFifoBuffer* f, void* src, int size, av_fifo_generic_write_func func);

		/// <summary>
		/// Enlarge an AVFifoBuffer. In case of reallocation failure, the old FIFO is kept unchanged. The new fifo size may be larger than the requested size.
		/// </summary>
		/// <param name="f">AVFifoBuffer to resize</param>
		/// <param name="additional_space">the amount of space in bytes to allocate in addition to av_fifo_size()</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_grow(AVFifoBuffer* f, uint additional_space);

		/// <summary>
		/// Resize an AVFifoBuffer. In case of reallocation failure, the old FIFO is kept unchanged.
		/// </summary>
		/// <param name="f">AVFifoBuffer to resize</param>
		/// <param name="size">new AVFifoBuffer size in bytes</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_realloc2(AVFifoBuffer* f, uint size);

		/// <summary>
		/// Reset the AVFifoBuffer to the state right after av_fifo_alloc, in particular it is emptied.
		/// </summary>
		/// <param name="f">AVFifoBuffer to reset</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_fifo_reset(AVFifoBuffer* f);

		/// <summary>
		/// Return the amount of data in bytes in the AVFifoBuffer, that is the amount of data you can read from it.
		/// </summary>
		/// <param name="f">AVFifoBuffer to read from</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_size(AVFifoBuffer* f);

		/// <summary>
		/// Return the amount of space in bytes in the AVFifoBuffer, that is the amount of data you can write into it.
		/// </summary>
		/// <param name="f">AVFifoBuffer to write into</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_fifo_space(AVFifoBuffer* f);

		/// <summary>
		/// Compute what kind of losses will occur when converting from one specific pixel format to another. When converting from one pixel format to another, information loss may occur. For example, when converting from RGB24 to GRAY, the color information will be lost. Similarly, other losses occur when converting from some formats to other formats. These losses can involve loss of chroma, but also loss of resolution, loss of color depth, loss due to the color space conversion, loss of the alpha bits or loss due to color quantization. av_get_fix_fmt_loss() informs you about the various types of losses which will occur when converting from one pixel format to another.
		/// </summary>
		/// <param name="src_pix_fmt">source pixel format</param>
		/// <param name="has_alpha">Whether the source pixel format alpha channel is used.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixelFormat av_find_best_pix_fmt_of_2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, bool has_alpha, int* loss_ptr);

		/// <summary>
		/// Find the value in a list of rationals nearest a given reference rational.
		/// </summary>
		/// <param name="q">Reference rational</param>
		/// <param name="q_list">Array of rationals terminated by `{0, 0}`</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_find_nearest_q_idx(AVRational q, AVRational* q_list);

		/// <summary>
		/// Open a file using a UTF-8 filename. The API of this function matches POSIX fopen(), errors are returned through errno.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static _iobuf* av_fopen_utf8([MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.LPStr)] string mode);

		/// <summary>
		/// Disables cpu detection and forces the specified flags. -1 is a special case that disables forcing of specific flags.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_force_cpu_flags(int flags);

		/// <summary>
		/// Fill the provided buffer with a string containing a FourCC (four-character code) representation.
		/// </summary>
		/// <param name="buf">a buffer with size in bytes of at least AV_FOURCC_MAX_STRING_SIZE</param>
		/// <param name="fourcc">the fourcc to represent</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_fourcc_make_string(byte* buf, uint fourcc);

		/// <summary>
		/// Allocate an AVFrame and set its fields to default values. The resulting struct must be freed using av_frame_free().
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFrame* av_frame_alloc();

		/// <summary>
		/// Crop the given video AVFrame according to its crop_left/crop_top/crop_right/ crop_bottom fields. If cropping is successful, the function will adjust the data pointers and the width/height fields, and set the crop fields to 0.
		/// </summary>
		/// <param name="frame">the frame which should be cropped</param>
		/// <param name="flags">Some combination of AV_FRAME_CROP_* flags, or 0.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_apply_cropping(AVFrame* frame, int flags);

		/// <summary>
		/// Create a new frame that references the same data as src.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFrame* av_frame_clone(AVFrame* src);

		/// <summary>
		/// Copy the frame data from src to dst.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_copy(AVFrame* dst, AVFrame* src);

		/// <summary>
		/// Copy only &quot;metadata&quot; fields from src to dst.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_copy_props(AVFrame* dst, AVFrame* src);

		/// <summary>
		/// Free the frame and any dynamically allocated objects in it, e.g. extended_data. If the frame is reference counted, it will be unreferenced first.
		/// </summary>
		/// <param name="frame">frame to be freed. The pointer will be set to NULL.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_free(AVFrame** frame);

		/// <summary>
		/// Free the frame and any dynamically allocated objects in it, e.g. extended_data. If the frame is reference counted, it will be unreferenced first.
		/// </summary>
		/// <param name="frame">frame to be freed. The pointer will be set to NULL.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_free(ref AVFrame* frame);

		/// <summary>
		/// Accessors for some AVFrame fields. These used to be provided for ABI compatibility, and do not need to be used anymore.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_frame_get_best_effort_timestamp(AVFrame* frame);

		/// <summary>
		/// Allocate new buffer(s) for audio or video data.
		/// </summary>
		/// <param name="frame">frame in which to store the new buffers.</param>
		/// <param name="align">Required buffer size alignment. If equal to 0, alignment will be chosen automatically for the current CPU. It is highly recommended to pass 0 here unless you know what you are doing.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_get_buffer(AVFrame* frame, int align);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVChannelLayout av_frame_get_channel_layout(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_get_channels(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVColorRange av_frame_get_color_range(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVColorSpace av_frame_get_colorspace(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_get_decode_error_flags(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVDictionary* av_frame_get_metadata(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_frame_get_pkt_duration(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_frame_get_pkt_pos(AVFrame* frame);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_get_pkt_size(AVFrame* frame);

		/// <summary>
		/// Get the buffer reference a given data plane is stored in.
		/// </summary>
		/// <param name="plane">index of the data plane of interest in frame-&gt;extended_data.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_frame_get_plane_buffer(AVFrame* frame, int plane);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static sbyte* av_frame_get_qp_table(AVFrame* f, int* stride, int* type);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_get_sample_rate(AVFrame* frame);

		/// <summary>
		/// Returns a pointer to the side data of a given type on success, NULL if there is no side data with such type in this frame.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFrameSideData* av_frame_get_side_data(AVFrame* frame, AVFrameSideDataType type);

		/// <summary>
		/// Check if the frame data is writable.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_is_writable(AVFrame* frame);

		/// <summary>
		/// Ensure that the frame data is writable, avoiding data copy if possible.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_make_writable(AVFrame* frame);

		/// <summary>
		/// Move everything contained in src to dst and reset src.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_move_ref(AVFrame* dst, AVFrame* src);

		/// <summary>
		/// Add a new side data to a frame.
		/// </summary>
		/// <param name="frame">a frame to which the side data should be added</param>
		/// <param name="type">type of the added side data</param>
		/// <param name="size">size of the side data</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFrameSideData* av_frame_new_side_data(AVFrame* frame, AVFrameSideDataType type, int size);

		/// <summary>
		/// Add a new side data to a frame from an existing AVBufferRef
		/// </summary>
		/// <param name="frame">a frame to which the side data should be added</param>
		/// <param name="type">the type of the added side data</param>
		/// <param name="buf">an AVBufferRef to add as side data. The ownership of the reference is transferred to the frame.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVFrameSideData* av_frame_new_side_data_from_buf(AVFrame* frame, AVFrameSideDataType type, AVBufferRef* buf);

		/// <summary>
		/// Set up a new reference to the data described by the source frame.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_ref(AVFrame* dst, AVFrame* src);

		/// <summary>
		/// If side data of the supplied type exists in the frame, free it and remove it from the frame.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_remove_side_data(AVFrame* frame, AVFrameSideDataType type);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_best_effort_timestamp(AVFrame* frame, long val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_channel_layout(AVFrame* frame, AVChannelLayout val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_channels(AVFrame* frame, int val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_color_range(AVFrame* frame, AVColorRange val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_colorspace(AVFrame* frame, AVColorSpace val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_decode_error_flags(AVFrame* frame, int val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_metadata(AVFrame* frame, AVDictionary* val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_pkt_duration(AVFrame* frame, long val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_pkt_pos(AVFrame* frame, long val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_pkt_size(AVFrame* frame, int val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_frame_set_qp_table(AVFrame* f, AVBufferRef* buf, int stride, int type);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_set_sample_rate(AVFrame* frame, int val);

		/// <summary>
		/// Returns a string identifying the side data type
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_frame_side_data_name(AVFrameSideDataType type);

		/// <summary>
		/// Unreference all the buffers referenced by frame and reset the frame fields.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_frame_unref(AVFrame* frame);

		/// <summary>
		/// Free a memory block which has been allocated with a function of av_malloc() or av_realloc() family.
		/// </summary>
		/// <param name="ptr">Pointer to the memory block which should be freed.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_free(void* ptr);

		/// <summary>
		/// Free a memory block which has been allocated with a function of av_malloc() or av_realloc() family, and set the pointer pointing to it to `NULL`.
		/// </summary>
		/// <param name="ptr">Pointer to the pointer to the memory block which should be freed</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_freep(void* ptr);

		/// <summary>
		/// Compute the greatest common divisor of two integer operands.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_gcd(long a, long b);

		/// <summary>
		/// Return the planar&lt;-&gt;packed alternative form of the given sample format, or AV_SAMPLE_FMT_NONE on error. If the passed sample_fmt is already in the requested planar/packed format, the format returned is the same as the input.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVSampleFormat av_get_alt_sample_fmt(AVSampleFormat sample_fmt, int planar);

		/// <summary>
		/// Return the number of bits per pixel used by the pixel format described by pixdesc. Note that this is not the same as the number of bits per sample.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_bits_per_pixel(AVPixFmtDescriptor* pixdesc);

		/// <summary>
		/// Return number of bytes per sample.
		/// </summary>
		/// <param name="sample_fmt">the sample format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_bytes_per_sample(AVSampleFormat sample_fmt);

		/// <summary>
		/// Get the description of a given channel.
		/// </summary>
		/// <param name="channel">a channel layout with a single channel</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_channel_description(AVChannelLayout channel);

		/// <summary>
		/// Return a channel layout id that matches name, or 0 if no match is found.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static ulong av_get_channel_layout([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Get the index of a channel in channel_layout.
		/// </summary>
		/// <param name="channel">a channel layout describing exactly one channel which must be present in channel_layout.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_channel_layout_channel_index(AVChannelLayout channel_layout, AVChannelLayout channel);

		/// <summary>
		/// Return the number of channels in the channel layout.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_channel_layout_nb_channels(AVChannelLayout channel_layout);

		/// <summary>
		/// Return a description of a channel layout. If nb_channels is &lt;= 0, it is guessed from the channel_layout.
		/// </summary>
		/// <param name="buf">put here the string containing the channel layout</param>
		/// <param name="buf_size">size in bytes of the buffer</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_get_channel_layout_string(byte* buf, int buf_size, int nb_channels, AVChannelLayout channel_layout);

		/// <summary>
		/// Get the name of a given channel.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_channel_name(AVChannelLayout channel);

		/// <summary>
		/// Get the name of a colorspace.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_colorspace_name(AVColorSpace val);

		/// <summary>
		/// Return the flags which specify extensions supported by the CPU. The returned value is affected by av_force_cpu_flags() if that was used before. So av_get_cpu_flags() can easily be used in an application to detect the enabled cpu flags.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_cpu_flags();

		/// <summary>
		/// Return default channel layout for a given number of channels.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVChannelLayout av_get_default_channel_layout(int nb_channels);

		/// <summary>
		/// Return a channel layout and the number of channels based on the specified name.
		/// </summary>
		/// <param name="name">channel layout specification string</param>
		/// <param name="channel_layout">parsed channel layout (0 if unknown)</param>
		/// <param name="nb_channels">number of channels</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_extended_channel_layout([MarshalAs(UnmanagedType.LPStr)] string name, AVChannelLayout* channel_layout, int* nb_channels);

		/// <summary>
		/// Return a string describing the media_type enum, NULL if media_type is unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_media_type_string(AVMediaType media_type);

		/// <summary>
		/// Get the packed alternative form of the given sample format.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVSampleFormat av_get_packed_sample_fmt(AVSampleFormat sample_fmt);

		/// <summary>
		/// Return the number of bits per pixel for the pixel format described by pixdesc, including any padding or unused bits.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_padded_bits_per_pixel(AVPixFmtDescriptor* pixdesc);

		/// <summary>
		/// Return a single letter to describe the given picture type pict_type.
		/// </summary>
		/// <param name="pict_type">the picture type</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte av_get_picture_type_char(AVPictureType pict_type);

		/// <summary>
		/// Return the pixel format corresponding to name.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixelFormat av_get_pix_fmt([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Compute what kind of losses will occur when converting from one specific pixel format to another. When converting from one pixel format to another, information loss may occur. For example, when converting from RGB24 to GRAY, the color information will be lost. Similarly, other losses occur when converting from some formats to other formats. These losses can involve loss of chroma, but also loss of resolution, loss of color depth, loss due to the color space conversion, loss of the alpha bits or loss due to color quantization. av_get_fix_fmt_loss() informs you about the various types of losses which will occur when converting from one pixel format to another.
		/// </summary>
		/// <param name="dst_pix_fmt">destination pixel format</param>
		/// <param name="src_pix_fmt">source pixel format</param>
		/// <param name="has_alpha">Whether the source pixel format alpha channel is used.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_pix_fmt_loss(AVPixelFormat dst_pix_fmt, AVPixelFormat src_pix_fmt, bool has_alpha);

		/// <summary>
		/// Return the short name for a pixel format, NULL in case pix_fmt is unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_pix_fmt_name(AVPixelFormat pix_fmt);

		/// <summary>
		/// Print in buf the string corresponding to the pixel format with number pix_fmt, or a header if pix_fmt is negative.
		/// </summary>
		/// <param name="buf">the buffer where to write the string</param>
		/// <param name="buf_size">the size of buf</param>
		/// <param name="pix_fmt">the number of the pixel format to print the corresponding info string, or a negative value to print the corresponding header.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_get_pix_fmt_string(byte* buf, int buf_size, AVPixelFormat pix_fmt);

		/// <summary>
		/// Get the planar alternative form of the given sample format.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVSampleFormat av_get_planar_sample_fmt(AVSampleFormat sample_fmt);

		/// <summary>
		/// Return a sample format corresponding to name, or AV_SAMPLE_FMT_NONE on error.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVSampleFormat av_get_sample_fmt([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Return the name of sample_fmt, or NULL if sample_fmt is not recognized.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_get_sample_fmt_name(AVSampleFormat sample_fmt);

		/// <summary>
		/// Generate a string corresponding to the sample format with sample_fmt, or a header if sample_fmt is negative.
		/// </summary>
		/// <param name="buf">the buffer where to write the string</param>
		/// <param name="buf_size">the size of buf</param>
		/// <param name="sample_fmt">the number of the sample format to print the corresponding info string, or a negative value to print the corresponding header.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_get_sample_fmt_string(byte* buf, int buf_size, AVSampleFormat sample_fmt);

		/// <summary>
		/// Get the value and name of a standard channel layout.
		/// </summary>
		/// <param name="index">index in an internal list, starting at 0</param>
		/// <param name="layout">channel layout mask</param>
		/// <param name="name">name of the layout</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_get_standard_channel_layout(uint index, AVChannelLayout* layout, byte** name);

		/// <summary>
		/// Return the fractional representation of the internal time base.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_get_time_base_q();

		/// <summary>
		/// Allocate an AVHWDeviceContext for a given hardware type.
		/// </summary>
		/// <param name="type">the type of the hardware device to allocate.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_hwdevice_ctx_alloc(AVHWDeviceType type);

		/// <summary>
		/// Open a device of the specified type and create an AVHWDeviceContext for it.
		/// </summary>
		/// <param name="device_ctx">On success, a reference to the newly-created device context will be written here. The reference is owned by the caller and must be released with av_buffer_unref() when no longer needed. On failure, NULL will be written to this pointer.</param>
		/// <param name="type">The type of the device to create.</param>
		/// <param name="device">A type-specific string identifying the device to open.</param>
		/// <param name="opts">A dictionary of additional (type-specific) options to use in opening the device. The dictionary remains owned by the caller.</param>
		/// <param name="flags">currently unused</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwdevice_ctx_create(AVBufferRef** device_ctx, AVHWDeviceType type, [MarshalAs(UnmanagedType.LPStr)] string device, AVDictionary* opts, int flags);

		/// <summary>
		/// Create a new device of the specified type from an existing device.
		/// </summary>
		/// <param name="dst_ctx">On success, a reference to the newly-created AVHWDeviceContext.</param>
		/// <param name="type">The type of the new device to create.</param>
		/// <param name="src_ctx">A reference to an existing AVHWDeviceContext which will be used to create the new device.</param>
		/// <param name="flags">Currently unused; should be set to zero.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwdevice_ctx_create_derived(AVBufferRef** dst_ctx, AVHWDeviceType type, AVBufferRef* src_ctx, int flags);

		/// <summary>
		/// Finalize the device context before use. This function must be called after the context is filled with all the required information and before it is used in any way.
		/// </summary>
		/// <param name="ref">a reference to the AVHWDeviceContext</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwdevice_ctx_init(AVBufferRef* @ref);

		/// <summary>
		/// Look up an AVHWDeviceType by name.
		/// </summary>
		/// <param name="name">String name of the device type (case-insensitive).</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVHWDeviceType av_hwdevice_find_type_by_name([MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Get the constraints on HW frames given a device and the HW-specific configuration to be used with that device. If no HW-specific configuration is provided, returns the maximum possible capabilities of the device.
		/// </summary>
		/// <param name="ref">a reference to the associated AVHWDeviceContext.</param>
		/// <param name="hwconfig">a filled HW-specific configuration structure, or NULL to return the maximum possible capabilities of the device.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVHWFramesConstraints* av_hwdevice_get_hwframe_constraints(AVBufferRef* @ref, void* hwconfig);

		/// <summary>
		/// Get the string name of an AVHWDeviceType.
		/// </summary>
		/// <param name="type">Type from enum AVHWDeviceType.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string av_hwdevice_get_type_name(AVHWDeviceType type);

		/// <summary>
		/// Allocate a HW-specific configuration structure for a given HW device. After use, the user must free all members as required by the specific hardware structure being used, then free the structure itself with av_free().
		/// </summary>
		/// <param name="device_ctx">a reference to the associated AVHWDeviceContext.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_hwdevice_hwconfig_alloc(AVBufferRef* device_ctx);

		/// <summary>
		/// Iterate over supported device types.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVHWDeviceType av_hwdevice_iterate_types(AVHWDeviceType prev);

		/// <summary>
		/// Free an AVHWFrameConstraints structure.
		/// </summary>
		/// <param name="constraints">The (filled or unfilled) AVHWFrameConstraints structure.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_hwframe_constraints_free(AVHWFramesConstraints** constraints);

		/// <summary>
		/// Allocate an AVHWFramesContext tied to a given device context.
		/// </summary>
		/// <param name="device_ctx">a reference to a AVHWDeviceContext. This function will make a new reference for internal use, the one passed to the function remains owned by the caller.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVBufferRef* av_hwframe_ctx_alloc(AVBufferRef* device_ctx);

		/// <summary>
		/// Create and initialise an AVHWFramesContext as a mapping of another existing AVHWFramesContext on a different device.
		/// </summary>
		/// <param name="derived_frame_ctx">On success, a reference to the newly created AVHWFramesContext.</param>
		/// <param name="derived_device_ctx">A reference to the device to create the new AVHWFramesContext on.</param>
		/// <param name="source_frame_ctx">A reference to an existing AVHWFramesContext which will be mapped to the derived context.</param>
		/// <param name="flags">Some combination of AV_HWFRAME_MAP_* flags, defining the mapping parameters to apply to frames which are allocated in the derived device.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_ctx_create_derived(AVBufferRef** derived_frame_ctx, AVPixelFormat format, AVBufferRef* derived_device_ctx, AVBufferRef* source_frame_ctx, int flags);

		/// <summary>
		/// Finalize the context before use. This function must be called after the context is filled with all the required information and before it is attached to any frames.
		/// </summary>
		/// <param name="ref">a reference to the AVHWFramesContext</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_ctx_init(AVBufferRef* @ref);

		/// <summary>
		/// Allocate a new frame attached to the given AVHWFramesContext.
		/// </summary>
		/// <param name="hwframe_ctx">a reference to an AVHWFramesContext</param>
		/// <param name="frame">an empty (freshly allocated or unreffed) frame to be filled with newly allocated buffers.</param>
		/// <param name="flags">currently unused, should be set to zero</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_get_buffer(AVBufferRef* hwframe_ctx, AVFrame* frame, int flags);

		/// <summary>
		/// Map a hardware frame.
		/// </summary>
		/// <param name="dst">Destination frame, to contain the mapping.</param>
		/// <param name="src">Source frame, to be mapped.</param>
		/// <param name="flags">Some combination of AV_HWFRAME_MAP_* flags.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_map(AVFrame* dst, AVFrame* src, int flags);

		/// <summary>
		/// Copy data to or from a hw surface. At least one of dst/src must have an AVHWFramesContext attached.
		/// </summary>
		/// <param name="dst">the destination frame. dst is not touched on failure.</param>
		/// <param name="src">the source frame.</param>
		/// <param name="flags">currently unused, should be set to zero</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_transfer_data(AVFrame* dst, AVFrame* src, int flags);

		/// <summary>
		/// Get a list of possible source or target formats usable in av_hwframe_transfer_data().
		/// </summary>
		/// <param name="hwframe_ctx">the frame context to obtain the information for</param>
		/// <param name="dir">the direction of the transfer</param>
		/// <param name="formats">the pointer to the output format list will be written here. The list is terminated with AV_PIX_FMT_NONE and must be freed by the caller when no longer needed using av_free(). If this function returns successfully, the format list will have at least one item (not counting the terminator). On failure, the contents of this pointer are unspecified.</param>
		/// <param name="flags">currently unused, should be set to zero</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_hwframe_transfer_get_formats(AVBufferRef* hwframe_ctx, AVHWFrameTransferDirection dir, AVPixelFormat** formats, int flags);

		/// <summary>
		/// Allocate an image with size w and h and pixel format pix_fmt, and fill pointers and linesizes accordingly. The allocated image buffer has to be freed by using av_freep(&amp;pointers[0]).
		/// </summary>
		/// <param name="align">the value to use for buffer size alignment</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_alloc(ref byte_ptrArray4 pointers, ref int_array4 linesizes, int w, int h, AVPixelFormat pix_fmt, int align);

		/// <summary>
		/// Check if the given sample aspect ratio of an image is valid.
		/// </summary>
		/// <param name="w">width of the image</param>
		/// <param name="h">height of the image</param>
		/// <param name="sar">sample aspect ratio of the image</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_check_sar(uint w, uint h, AVRational sar);

		/// <summary>
		/// Check if the given dimension of an image is valid, meaning that all bytes of the image can be addressed with a signed int.
		/// </summary>
		/// <param name="w">the width of the picture</param>
		/// <param name="h">the height of the picture</param>
		/// <param name="log_offset">the offset to sum to the log level for logging with log_ctx</param>
		/// <param name="log_ctx">the parent logging context, it may be NULL</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_check_size(uint w, uint h, int log_offset, void* log_ctx);

		/// <summary>
		/// Check if the given dimension of an image is valid, meaning that all bytes of a plane of an image with the specified pix_fmt can be addressed with a signed int.
		/// </summary>
		/// <param name="w">the width of the picture</param>
		/// <param name="h">the height of the picture</param>
		/// <param name="max_pixels">the maximum number of pixels the user wants to accept</param>
		/// <param name="pix_fmt">the pixel format, can be AV_PIX_FMT_NONE if unknown.</param>
		/// <param name="log_offset">the offset to sum to the log level for logging with log_ctx</param>
		/// <param name="log_ctx">the parent logging context, it may be NULL</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_check_size2(uint w, uint h, long max_pixels, AVPixelFormat pix_fmt, int log_offset, void* log_ctx);

		/// <summary>
		/// Copy image in src_data to dst_data.
		/// </summary>
		/// <param name="dst_linesizes">linesizes for the image in dst_data</param>
		/// <param name="src_linesizes">linesizes for the image in src_data</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_image_copy(ref byte_ptrArray4 dst_data, ref int_array4 dst_linesizes, ref byte_ptrArray4 src_data, int_array4 src_linesizes, AVPixelFormat pix_fmt, int width, int height);

		/// <summary>
		/// Copy image in src_data to dst_data.
		/// </summary>
		/// <param name="dst_linesizes">linesizes for the image in dst_data</param>
		/// <param name="src_linesizes">linesizes for the image in src_data</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_image_copy(byte** dst_data, int* dst_linesizes, byte** src_data, int* src_linesizes, AVPixelFormat pix_fmt, int width, int height);

		/// <summary>
		/// Copy image plane from src to dst. That is, copy &quot;height&quot; number of lines of &quot;bytewidth&quot; bytes each. The first byte of each successive line is separated by *_linesize bytes.
		/// </summary>
		/// <param name="dst_linesize">linesize for the image plane in dst</param>
		/// <param name="src_linesize">linesize for the image plane in src</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_image_copy_plane(byte* dst, int dst_linesize, byte* src, int src_linesize, int bytewidth, int height);

		/// <summary>
		/// Copy image data from an image into a buffer.
		/// </summary>
		/// <param name="dst">a buffer into which picture data will be copied</param>
		/// <param name="dst_size">the size in bytes of dst</param>
		/// <param name="src_data">pointers containing the source image data</param>
		/// <param name="src_linesize">linesizes for the image in src_data</param>
		/// <param name="pix_fmt">the pixel format of the source image</param>
		/// <param name="width">the width of the source image in pixels</param>
		/// <param name="height">the height of the source image in pixels</param>
		/// <param name="align">the assumed linesize alignment for dst</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_copy_to_buffer(byte* dst, int dst_size, byte_ptrArray4 src_data, int_array4 src_linesize, AVPixelFormat pix_fmt, int width, int height, int align);

		/// <summary>
		/// Copy image data located in uncacheable (e.g. GPU mapped) memory. Where available, this function will use special functionality for reading from such memory, which may result in greatly improved performance compared to plain av_image_copy().
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_image_copy_uc_from(ref byte_ptrArray4 dst_data, long_array4 dst_linesizes, ref byte_ptrArray4 src_data, long_array4 src_linesizes, AVPixelFormat pix_fmt, int width, int height);

		/// <summary>
		/// Setup the data pointers and linesizes based on the specified image parameters and the provided array.
		/// </summary>
		/// <param name="dst_data">data pointers to be filled in</param>
		/// <param name="dst_linesize">linesizes for the image in dst_data to be filled in</param>
		/// <param name="src">buffer which will contain or contains the actual image data, can be NULL</param>
		/// <param name="pix_fmt">the pixel format of the image</param>
		/// <param name="width">the width of the image in pixels</param>
		/// <param name="height">the height of the image in pixels</param>
		/// <param name="align">the value used in src for linesize alignment</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_arrays(ref byte_ptrArray4 dst_data, ref int_array4 dst_linesize, byte* src, AVPixelFormat pix_fmt, int width, int height, int align);

		/// <summary>
		/// Setup the data pointers and linesizes based on the specified image parameters and the provided array.
		/// </summary>
		/// <param name="dst_data">data pointers to be filled in</param>
		/// <param name="dst_linesize">linesizes for the image in dst_data to be filled in</param>
		/// <param name="src">buffer which will contain or contains the actual image data, can be NULL</param>
		/// <param name="pix_fmt">the pixel format of the image</param>
		/// <param name="width">the width of the image in pixels</param>
		/// <param name="height">the height of the image in pixels</param>
		/// <param name="align">the value used in src for linesize alignment</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_arrays(byte** dst_data, int* dst_linesize, byte* src, AVPixelFormat pix_fmt, int width, int height, int align);

		/// <summary>
		/// Overwrite the image data with black. This is suitable for filling a sub-rectangle of an image, meaning the padding between the right most pixel and the left most pixel on the next line will not be overwritten. For some formats, the image size might be rounded up due to inherent alignment.
		/// </summary>
		/// <param name="dst_data">data pointers to destination image</param>
		/// <param name="dst_linesize">linesizes for the destination image</param>
		/// <param name="pix_fmt">the pixel format of the image</param>
		/// <param name="range">the color range of the image (important for colorspaces such as YUV)</param>
		/// <param name="width">the width of the image in pixels</param>
		/// <param name="height">the height of the image in pixels</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_black(ref byte_ptrArray4 dst_data, long_array4 dst_linesize, AVPixelFormat pix_fmt, AVColorRange range, int width, int height);

		/// <summary>
		/// Fill plane linesizes for an image with pixel format pix_fmt and width width.
		/// </summary>
		/// <param name="linesizes">array to be filled with the linesize for each plane</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_linesizes(ref int_array4 linesizes, AVPixelFormat pix_fmt, int width);

		/// <summary>
		/// Fill plane linesizes for an image with pixel format pix_fmt and width width.
		/// </summary>
		/// <param name="linesizes">array to be filled with the linesize for each plane</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_linesizes(int* linesizes, AVPixelFormat pix_fmt, int width);

		/// <summary>
		/// Compute the max pixel step for each plane of an image with a format described by pixdesc.
		/// </summary>
		/// <param name="max_pixsteps">an array which is filled with the max pixel step for each plane. Since a plane may contain different pixel components, the computed max_pixsteps[plane] is relative to the component in the plane with the max pixel step.</param>
		/// <param name="max_pixstep_comps">an array which is filled with the component for each plane which has the max pixel step. May be NULL.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_image_fill_max_pixsteps(ref int_array4 max_pixsteps, ref int_array4 max_pixstep_comps, AVPixFmtDescriptor* pixdesc);

		/// <summary>
		/// Fill plane data pointers for an image with pixel format pix_fmt and height height.
		/// </summary>
		/// <param name="data">pointers array to be filled with the pointer for each image plane</param>
		/// <param name="ptr">the pointer to a buffer which will contain the image</param>
		/// <param name="linesizes">the array containing the linesize for each plane, should be filled by av_image_fill_linesizes()</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_pointers(ref byte_ptrArray4 data, AVPixelFormat pix_fmt, int height, byte* ptr, int_array4 linesizes);

		/// <summary>
		/// Fill plane data pointers for an image with pixel format pix_fmt and height height.
		/// </summary>
		/// <param name="data">pointers array to be filled with the pointer for each image plane</param>
		/// <param name="ptr">the pointer to a buffer which will contain the image</param>
		/// <param name="linesizes">the array containing the linesize for each plane, should be filled by av_image_fill_linesizes()</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_fill_pointers(byte** data, AVPixelFormat pix_fmt, int height, byte* ptr, int* linesizes);

		/// <summary>
		/// Return the size in bytes of the amount of data required to store an image with the given parameters.
		/// </summary>
		/// <param name="pix_fmt">the pixel format of the image</param>
		/// <param name="width">the width of the image in pixels</param>
		/// <param name="height">the height of the image in pixels</param>
		/// <param name="align">the assumed linesize alignment</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_get_buffer_size(AVPixelFormat pix_fmt, int width, int height, int align);

		/// <summary>
		/// Compute the size of an image line with format pix_fmt and width width for the plane plane.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_image_get_linesize(AVPixelFormat pix_fmt, int width, int plane);

		/// <summary>
		/// Compute the length of an integer list.
		/// </summary>
		/// <param name="elsize">size in bytes of each list element (only 1, 2, 4 or 8)</param>
		/// <param name="list">pointer to the list</param>
		/// <param name="term">list terminator (usually 0 or -1)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static uint av_int_list_length_for_size(uint elsize, void* list, ulong term);

		/// <summary>
		/// Send the specified message to the log if the level is less than or equal to the current av_log_level. By default, all logging messages are sent to stderr. This behavior can be altered by setting a different logging callback function.
		/// </summary>
		/// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct or NULL if general log.</param>
		/// <param name="level">The importance level of the message expressed using a</param>
		/// <param name="fmt">The format string (printf-compatible) that specifies how subsequent arguments are converted to output.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log(void* avcl, int level, [MarshalAs(UnmanagedType.LPStr)] string fmt);

		/// <summary>
		/// Default logging callback
		/// </summary>
		/// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
		/// <param name="level">The importance level of the message expressed using a</param>
		/// <param name="fmt">The format string (printf-compatible) that specifies how subsequent arguments are converted to output.</param>
		/// <param name="vl">The arguments referenced by the format string.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log_default_callback(void* avcl, int level, [MarshalAs(UnmanagedType.LPStr)] string fmt, byte* vl);

		/// <summary>
		/// Format a line of log the same way as the default callback.
		/// </summary>
		/// <param name="line">buffer to receive the formatted line</param>
		/// <param name="line_size">size of the buffer</param>
		/// <param name="print_prefix">used to store whether the prefix must be printed; must point to a persistent integer initially set to 1</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log_format_line(void* ptr, int level, [MarshalAs(UnmanagedType.LPStr)] string fmt, byte* vl, byte* line, int line_size, int* print_prefix);

		/// <summary>
		/// Format a line of log the same way as the default callback.
		/// </summary>
		/// <param name="line">buffer to receive the formatted line; may be NULL if line_size is 0</param>
		/// <param name="line_size">size of the buffer; at most line_size-1 characters will be written to the buffer, plus one null terminator</param>
		/// <param name="print_prefix">used to store whether the prefix must be printed; must point to a persistent integer initially set to 1</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_log_format_line2(void* ptr, int level, [MarshalAs(UnmanagedType.LPStr)] string fmt, byte* vl, byte* line, int line_size, int* print_prefix);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_log_get_flags();

		/// <summary>
		/// Get the current log level
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_log_get_level();

		/// <summary>
		/// Set the logging callback
		/// </summary>
		/// <param name="callback">A logging function with a compatible signature.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log_set_callback(av_log_set_callback_callback callback);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log_set_flags(int arg);

		/// <summary>
		/// Set the log level
		/// </summary>
		/// <param name="level">Logging level</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_log_set_level(int level);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_log2(uint v);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_log2_16bit(uint v);

		/// <summary>
		/// Allocate a memory block with alignment suitable for all memory accesses (including vectors if available on the CPU).
		/// </summary>
		/// <param name="size">Size in bytes for the memory block to be allocated</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_malloc(IntPtr size);

		/// <summary>
		/// Allocate a memory block for an array with av_malloc().
		/// </summary>
		/// <param name="nmemb">Number of element</param>
		/// <param name="size">Size of a single element</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_malloc_array(IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Allocate a memory block with alignment suitable for all memory accesses (including vectors if available on the CPU) and zero all the bytes of the block.
		/// </summary>
		/// <param name="size">Size in bytes for the memory block to be allocated</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_mallocz(IntPtr size);

		/// <summary>
		/// Allocate a memory block for an array with av_mallocz().
		/// </summary>
		/// <param name="nmemb">Number of elements</param>
		/// <param name="size">Size of the single element</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_mallocz_array(IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Set the maximum size that may be allocated in one block.
		/// </summary>
		/// <param name="max">Value to be set as the new maximum size</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_max_alloc(IntPtr max);

		/// <summary>
		/// Overlapping memcpy() implementation.
		/// </summary>
		/// <param name="dst">Destination buffer</param>
		/// <param name="back">Number of bytes back to start copying (i.e. the initial size of the overlapping window); must be &gt; 0</param>
		/// <param name="cnt">Number of bytes to copy; must be &gt;= 0</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_memcpy_backptr(byte* dst, int back, int cnt);

		/// <summary>
		/// Duplicate a buffer with av_malloc().
		/// </summary>
		/// <param name="p">Buffer to be duplicated</param>
		/// <param name="size">Size in bytes of the buffer copied</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_memdup(void* p, IntPtr size);

		/// <summary>
		/// Multiply two rationals.
		/// </summary>
		/// <param name="b">First rational</param>
		/// <param name="c">Second rational</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_mul_q(AVRational b, AVRational c);

		/// <summary>
		/// Find which of the two rationals is closer to another rational.
		/// </summary>
		/// <param name="q">Rational to be compared against</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_nearer_q(AVRational q, AVRational q1, AVRational q2);

		/// <summary>
		/// Iterate over potential AVOptions-enabled children of parent.
		/// </summary>
		/// <param name="prev">result of a previous call to this function or NULL</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVClass* av_opt_child_class_next(AVClass* parent, AVClass* prev);

		/// <summary>
		/// Iterate over AVOptions-enabled children of obj.
		/// </summary>
		/// <param name="prev">result of a previous call to this function or NULL</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_opt_child_next(void* obj, void* prev);

		/// <summary>
		/// Copy options from src object into dest object.
		/// </summary>
		/// <param name="dest">Object to copy from</param>
		/// <param name="src">Object to copy into</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_copy(void* dest, void* src);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_double(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, double* double_out);

		/// <summary>
		/// @{ This group of functions can be used to evaluate option strings and get numbers out of them. They do the same thing as av_opt_set(), except the result is written into the caller-supplied pointer.
		/// </summary>
		/// <param name="obj">a struct whose first element is a pointer to AVClass.</param>
		/// <param name="o">an option for which the string is to be evaluated.</param>
		/// <param name="val">string to be evaluated.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_flags(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, int* flags_out);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_float(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, float* float_out);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_int(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, int* int_out);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_int64(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, long* int64_out);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_eval_q(void* obj, AVOption* o, [MarshalAs(UnmanagedType.LPStr)] string val, AVRational* q_out);

		/// <summary>
		/// Look for an option in an object. Consider only options which have all the specified flags set.
		/// </summary>
		/// <param name="obj">A pointer to a struct whose first element is a pointer to an AVClass. Alternatively a double pointer to an AVClass, if AV_OPT_SEARCH_FAKE_OBJ search flag is set.</param>
		/// <param name="name">The name of the option to look for.</param>
		/// <param name="unit">When searching for named constants, name of the unit it belongs to.</param>
		/// <param name="opt_flags">Find only options with all the specified flags set (AV_OPT_FLAG).</param>
		/// <param name="search_flags">A combination of AV_OPT_SEARCH_*.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVOption* av_opt_find(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string unit, int opt_flags, int search_flags);

		/// <summary>
		/// Look for an option in an object. Consider only options which have all the specified flags set.
		/// </summary>
		/// <param name="obj">A pointer to a struct whose first element is a pointer to an AVClass. Alternatively a double pointer to an AVClass, if AV_OPT_SEARCH_FAKE_OBJ search flag is set.</param>
		/// <param name="name">The name of the option to look for.</param>
		/// <param name="unit">When searching for named constants, name of the unit it belongs to.</param>
		/// <param name="opt_flags">Find only options with all the specified flags set (AV_OPT_FLAG).</param>
		/// <param name="search_flags">A combination of AV_OPT_SEARCH_*.</param>
		/// <param name="target_obj">if non-NULL, an object to which the option belongs will be written here. It may be different from obj if AV_OPT_SEARCH_CHILDREN is present in search_flags. This parameter is ignored if search_flags contain AV_OPT_SEARCH_FAKE_OBJ.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVOption* av_opt_find2(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string unit, int opt_flags, int search_flags, void** target_obj);

		/// <summary>
		/// Check whether a particular flag is set in a flags field.
		/// </summary>
		/// <param name="field_name">the name of the flag field option</param>
		/// <param name="flag_name">the name of the flag to check</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_flag_is_set(void* obj, [MarshalAs(UnmanagedType.LPStr)] string field_name, [MarshalAs(UnmanagedType.LPStr)] string flag_name);

		/// <summary>
		/// Free all allocated objects in obj.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_opt_free(void* obj);

		/// <summary>
		/// Free an AVOptionRanges struct and set it to NULL.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_opt_freep_ranges(AVOptionRanges** ranges);

		/// <summary>
		/// @{ Those functions get a value of the option with the given name from an object.
		/// </summary>
		/// <param name="obj">a struct whose first element is a pointer to an AVClass.</param>
		/// <param name="name">name of the option to get.</param>
		/// <param name="search_flags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN is passed here, then the option may be found in a child of obj.</param>
		/// <param name="out_val">value of the option will be written here</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, byte** out_val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_channel_layout(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVChannelLayout* ch_layout);

		/// <param name="out_val">The returned dictionary is a copy of the actual value and must be freed with av_dict_free() by the caller</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_dict_val(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVDictionary** out_val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_double(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, double* out_val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_image_size(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, int* w_out, int* h_out);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_int(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, long* out_val);

		/// <summary>
		/// Extract a key-value pair from the beginning of a string.
		/// </summary>
		/// <param name="ropts">pointer to the options string, will be updated to point to the rest of the string (one of the pairs_sep or the final NUL)</param>
		/// <param name="key_val_sep">a 0-terminated list of characters used to separate key from value, for example &apos;=&apos;</param>
		/// <param name="pairs_sep">a 0-terminated list of characters used to separate two pairs from each other, for example &apos;:&apos; or &apos;,&apos;</param>
		/// <param name="flags">flags; see the AV_OPT_FLAG_* values below</param>
		/// <param name="rkey">parsed key; must be freed using av_free()</param>
		/// <param name="rval">parsed value; must be freed using av_free()</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_key_value(byte** ropts, [MarshalAs(UnmanagedType.LPStr)] string key_val_sep, [MarshalAs(UnmanagedType.LPStr)] string pairs_sep, uint flags, byte** rkey, byte** rval);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_pixel_fmt(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVPixelFormat* out_fmt);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_q(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVRational* out_val);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_sample_fmt(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVSampleFormat* out_fmt);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_get_video_rate(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags, AVRational* out_val);

		/// <summary>
		/// Check if given option is set to its default value.
		/// </summary>
		/// <param name="obj">AVClass object to check option on</param>
		/// <param name="o">option to be checked</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_is_set_to_default(void* obj, AVOption* o);

		/// <summary>
		/// Check if given option is set to its default value.
		/// </summary>
		/// <param name="obj">AVClass object to check option on</param>
		/// <param name="name">option name</param>
		/// <param name="search_flags">combination of AV_OPT_SEARCH_*</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_is_set_to_default_by_name(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int search_flags);

		/// <summary>
		/// Iterate over all AVOptions belonging to obj.
		/// </summary>
		/// <param name="obj">an AVOptions-enabled struct or a double pointer to an AVClass describing it.</param>
		/// <param name="prev">result of the previous call to av_opt_next() on this object or NULL</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVOption* av_opt_next(void* obj, AVOption* prev);

		/// <summary>
		/// @}
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_opt_ptr(AVClass* avclass, void* obj, [MarshalAs(UnmanagedType.LPStr)] string name);

		/// <summary>
		/// Get a list of allowed ranges for the given option.
		/// </summary>
		/// <param name="flags">is a bitmask of flags, undefined flags should not be set and should be ignored AV_OPT_SEARCH_FAKE_OBJ indicates that the obj is a double pointer to a AVClass instead of a full instance AV_OPT_MULTI_COMPONENT_RANGE indicates that function may return more than one component,</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_query_ranges(AVOptionRanges** p0, void* obj, [MarshalAs(UnmanagedType.LPStr)] string key, int flags);

		/// <summary>
		/// Get a default list of allowed ranges for the given option.
		/// </summary>
		/// <param name="flags">is a bitmask of flags, undefined flags should not be set and should be ignored AV_OPT_SEARCH_FAKE_OBJ indicates that the obj is a double pointer to a AVClass instead of a full instance AV_OPT_MULTI_COMPONENT_RANGE indicates that function may return more than one component,</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_query_ranges_default(AVOptionRanges** p0, void* obj, [MarshalAs(UnmanagedType.LPStr)] string key, int flags);

		/// <summary>
		/// Serialize object&apos;s options.
		/// </summary>
		/// <param name="obj">AVClass object to serialize</param>
		/// <param name="opt_flags">serialize options with all the specified flags set (AV_OPT_FLAG)</param>
		/// <param name="flags">combination of AV_OPT_SERIALIZE_* flags</param>
		/// <param name="buffer">Pointer to buffer that will be allocated with string containg serialized options. Buffer must be freed by the caller when is no longer needed.</param>
		/// <param name="key_val_sep">character used to separate key from value</param>
		/// <param name="pairs_sep">character used to separate two pairs from each other</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_serialize(void* obj, int opt_flags, int flags, byte** buffer, byte key_val_sep, byte pairs_sep);

		/// <summary>
		/// @{ Those functions set the field of obj with the given name to value.
		/// </summary>
		/// <param name="obj">A struct whose first element is a pointer to an AVClass.</param>
		/// <param name="name">the name of the field to set</param>
		/// <param name="val">The value to set. In case of av_opt_set() if the field is not of a string type, then the given string is parsed. SI postfixes and some named scalars are supported. If the field is of a numeric type, it has to be a numeric or named scalar. Behavior with more than one scalar and +- infix operators is undefined. If the field is of a flags type, it has to be a sequence of numeric scalars or named flags separated by &apos;+&apos; or &apos;-&apos;. Prefixing a flag with &apos;+&apos; causes it to be set without affecting the other flags; similarly, &apos;-&apos; unsets a flag.</param>
		/// <param name="search_flags">flags passed to av_opt_find2. I.e. if AV_OPT_SEARCH_CHILDREN is passed here, then the option may be set on a child of obj.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string val, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_bin(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, byte* val, int size, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_channel_layout(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVChannelLayout ch_layout, int search_flags);

		/// <summary>
		/// Set the values of all AVOption fields to their default values.
		/// </summary>
		/// <param name="s">an AVOption-enabled struct (its first member must be a pointer to AVClass)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_opt_set_defaults(void* s);

		/// <summary>
		/// Set the values of all AVOption fields to their default values. Only these AVOption fields for which (opt-&gt;flags &amp; mask) == flags will have their default applied to s.
		/// </summary>
		/// <param name="s">an AVOption-enabled struct (its first member must be a pointer to AVClass)</param>
		/// <param name="mask">combination of AV_OPT_FLAG_*</param>
		/// <param name="flags">combination of AV_OPT_FLAG_*</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_opt_set_defaults2(void* s, int mask, int flags);

		/// <summary>
		/// Set all the options from a given dictionary on an object.
		/// </summary>
		/// <param name="obj">a struct whose first element is a pointer to AVClass</param>
		/// <param name="options">options to process. This dictionary will be freed and replaced by a new one containing all options not found in obj. Of course this new dictionary needs to be freed by caller with av_dict_free().</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_dict(void* obj, AVDictionary** options);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_dict_val(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVDictionary* val, int search_flags);

		/// <summary>
		/// Set all the options from a given dictionary on an object.
		/// </summary>
		/// <param name="obj">a struct whose first element is a pointer to AVClass</param>
		/// <param name="options">options to process. This dictionary will be freed and replaced by a new one containing all options not found in obj. Of course this new dictionary needs to be freed by caller with av_dict_free().</param>
		/// <param name="search_flags">A combination of AV_OPT_SEARCH_*.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_dict2(void* obj, AVDictionary** options, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_double(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, double val, int search_flags);

		/// <summary>
		/// Parse the key-value pairs list in opts. For each key=value pair found, set the value of the corresponding option in ctx.
		/// </summary>
		/// <param name="ctx">the AVClass object to set options on</param>
		/// <param name="opts">the options string, key-value pairs separated by a delimiter</param>
		/// <param name="shorthand">a NULL-terminated array of options names for shorthand notation: if the first field in opts has no key part, the key is taken from the first element of shorthand; then again for the second, etc., until either opts is finished, shorthand is finished or a named option is found; after that, all options must be named</param>
		/// <param name="key_val_sep">a 0-terminated list of characters used to separate key from value, for example &apos;=&apos;</param>
		/// <param name="pairs_sep">a 0-terminated list of characters used to separate two pairs from each other, for example &apos;:&apos; or &apos;,&apos;</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_from_string(void* ctx, [MarshalAs(UnmanagedType.LPStr)] string opts, byte** shorthand, [MarshalAs(UnmanagedType.LPStr)] string key_val_sep, [MarshalAs(UnmanagedType.LPStr)] string pairs_sep);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_image_size(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, int w, int h, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_int(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, long val, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_pixel_fmt(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVPixelFormat fmt, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_q(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVRational val, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_sample_fmt(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVSampleFormat fmt, int search_flags);

		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_set_video_rate(void* obj, [MarshalAs(UnmanagedType.LPStr)] string name, AVRational val, int search_flags);

		/// <summary>
		/// Show the obj options.
		/// </summary>
		/// <param name="av_log_obj">log context to use for showing the options</param>
		/// <param name="req_flags">requested flags for the options to show. Show only the options for which it is opt-&gt;flags &amp; req_flags.</param>
		/// <param name="rej_flags">rejected flags for the options to show. Show only the options for which it is !(opt-&gt;flags &amp; req_flags).</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_opt_show2(void* obj, void* av_log_obj, int req_flags, int rej_flags);

		/// <summary>
		/// Parse CPU caps from a string and update the given AV_CPU_* flags based on that.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_parse_cpu_caps(uint* flags, [MarshalAs(UnmanagedType.LPStr)] string s);

		/// <summary>
		/// Parse CPU flags from a string.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_parse_cpu_flags([MarshalAs(UnmanagedType.LPStr)] string s);

		/// <summary>
		/// Returns number of planes in pix_fmt, a negative AVERROR if pix_fmt is not a valid pixel format.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_pix_fmt_count_planes(AVPixelFormat pix_fmt);

		/// <summary>
		/// Returns a pixel format descriptor for provided pixel format or NULL if this pixel format is unknown.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixFmtDescriptor* av_pix_fmt_desc_get(AVPixelFormat pix_fmt);

		/// <summary>
		/// Returns an AVPixelFormat id described by desc, or AV_PIX_FMT_NONE if desc is not a valid pointer to a pixel format descriptor.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixelFormat av_pix_fmt_desc_get_id(AVPixFmtDescriptor* desc);

		/// <summary>
		/// Iterate over all pixel format descriptors known to libavutil.
		/// </summary>
		/// <param name="prev">previous descriptor. NULL to get the first descriptor.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixFmtDescriptor* av_pix_fmt_desc_next(AVPixFmtDescriptor* prev);

		/// <summary>
		/// Utility function to access log2_chroma_w log2_chroma_h from the pixel format AVPixFmtDescriptor.
		/// </summary>
		/// <param name="pix_fmt">the pixel format</param>
		/// <param name="h_shift">store log2_chroma_w (horizontal/width shift)</param>
		/// <param name="v_shift">store log2_chroma_h (vertical/height shift)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_pix_fmt_get_chroma_sub_sample(AVPixelFormat pix_fmt, int* h_shift, int* v_shift);

		/// <summary>
		/// Utility function to swap the endianness of a pixel format.
		/// </summary>
		/// <param name="pix_fmt">the pixel format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVPixelFormat av_pix_fmt_swap_endianness(AVPixelFormat pix_fmt);

		/// <summary>
		/// Convert an AVRational to a IEEE 32-bit `float` expressed in fixed-point format.
		/// </summary>
		/// <param name="q">Rational to be converted</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static uint av_q2intfloat(AVRational q);

		/// <summary>
		/// Read a line from an image, and write the values of the pixel format component c to dst.
		/// </summary>
		/// <param name="data">the array containing the pointers to the planes of the image</param>
		/// <param name="linesize">the array containing the linesizes of the image</param>
		/// <param name="desc">the pixel format descriptor for the image</param>
		/// <param name="x">the horizontal coordinate of the first pixel to read</param>
		/// <param name="y">the vertical coordinate of the first pixel to read</param>
		/// <param name="w">the width of the line to read, that is the number of values to write to dst</param>
		/// <param name="read_pal_component">if not zero and the format is a paletted format writes the values corresponding to the palette component c in data[1] to dst, rather than the palette indexes in data[0]. The behavior is undefined if the format is not paletted.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_read_image_line(ushort* dst, ref byte_ptrArray4 data, int_array4 linesize, AVPixFmtDescriptor* desc, int x, int y, int c, int w, int read_pal_component);

		/// <summary>
		/// Allocate, reallocate, or free a block of memory.
		/// </summary>
		/// <param name="ptr">Pointer to a memory block already allocated with av_realloc() or `NULL`</param>
		/// <param name="size">Size in bytes of the memory block to be allocated or reallocated</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_realloc(void* ptr, IntPtr size);

		/// <summary>
		/// Allocate, reallocate, or free an array.
		/// </summary>
		/// <param name="ptr">Pointer to a memory block already allocated with av_realloc() or `NULL`</param>
		/// <param name="nmemb">Number of elements in the array</param>
		/// <param name="size">Size of the single element of the array</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_realloc_array(void* ptr, IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Allocate, reallocate, or free a block of memory.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void* av_realloc_f(void* ptr, IntPtr nelem, IntPtr elsize);

		/// <summary>
		/// Allocate, reallocate, or free a block of memory through a pointer to a pointer.
		/// </summary>
		/// <param name="ptr">Pointer to a pointer to a memory block already allocated with av_realloc(), or a pointer to `NULL`. The pointer is updated on success, or freed on failure.</param>
		/// <param name="size">Size in bytes for the memory block to be allocated or reallocated</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_reallocp(void* ptr, IntPtr size);

		/// <summary>
		/// Allocate, reallocate, or free an array through a pointer to a pointer.
		/// </summary>
		/// <param name="ptr">Pointer to a pointer to a memory block already allocated with av_realloc(), or a pointer to `NULL`. The pointer is updated on success, or freed on failure.</param>
		/// <param name="nmemb">Number of elements</param>
		/// <param name="size">Size of the single element</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_reallocp_array(void* ptr, IntPtr nmemb, IntPtr size);

		/// <summary>
		/// Reduce a fraction.
		/// </summary>
		/// <param name="dst_num">Destination numerator</param>
		/// <param name="dst_den">Destination denominator</param>
		/// <param name="num">Source numerator</param>
		/// <param name="den">Source denominator</param>
		/// <param name="max">Maximum allowed values for `dst_num` &amp; `dst_den`</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_reduce(int* dst_num, int* dst_den, long num, long den, long max);

		/// <summary>
		/// Rescale a 64-bit integer with rounding to nearest.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_rescale(long a, long b, long c);

		/// <summary>
		/// Rescale a timestamp while preserving known durations.
		/// </summary>
		/// <param name="in_tb">Input time base</param>
		/// <param name="in_ts">Input timestamp</param>
		/// <param name="fs_tb">Duration time base; typically this is finer-grained (greater) than `in_tb` and `out_tb`</param>
		/// <param name="duration">Duration till the next call to this function (i.e. duration of the current packet/frame)</param>
		/// <param name="last">Pointer to a timestamp expressed in terms of `fs_tb`, acting as a state variable</param>
		/// <param name="out_tb">Output timebase</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_rescale_delta(AVRational in_tb, long in_ts, AVRational fs_tb, int duration, long* last, AVRational out_tb);

		/// <summary>
		/// Rescale a 64-bit integer by 2 rational numbers.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_rescale_q(long a, AVRational bq, AVRational cq);

		/// <summary>
		/// Rescale a 64-bit integer by 2 rational numbers with specified rounding.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_rescale_q_rnd(long a, AVRational bq, AVRational cq, AVRounding rnd);

		/// <summary>
		/// Rescale a 64-bit integer with specified rounding.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static long av_rescale_rnd(long a, long b, long c, AVRounding rnd);

		/// <summary>
		/// Check if the sample format is planar.
		/// </summary>
		/// <param name="sample_fmt">the sample format to inspect</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_sample_fmt_is_planar(AVSampleFormat sample_fmt);

		/// <summary>
		/// Allocate a samples buffer for nb_samples samples, and fill data pointers and linesize accordingly. The allocated samples buffer can be freed by using av_freep(&amp;audio_data[0]) Allocated data will be initialized to silence.
		/// </summary>
		/// <param name="audio_data">array to be filled with the pointer for each channel</param>
		/// <param name="linesize">aligned size for audio buffer(s), may be NULL</param>
		/// <param name="nb_channels">number of audio channels</param>
		/// <param name="nb_samples">number of samples per channel</param>
		/// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_alloc(byte** audio_data, int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

		/// <summary>
		/// Allocate a data pointers array, samples buffer for nb_samples samples, and fill data pointers and linesize accordingly.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_alloc_array_and_samples(byte*** audio_data, int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

		/// <summary>
		/// Copy samples from src to dst.
		/// </summary>
		/// <param name="dst">destination array of pointers to data planes</param>
		/// <param name="src">source array of pointers to data planes</param>
		/// <param name="dst_offset">offset in samples at which the data will be written to dst</param>
		/// <param name="src_offset">offset in samples at which the data will be read from src</param>
		/// <param name="nb_samples">number of samples to be copied</param>
		/// <param name="nb_channels">number of audio channels</param>
		/// <param name="sample_fmt">audio sample format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_copy(byte** dst, byte** src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

		/// <summary>
		/// Copy samples from src to dst.
		/// </summary>
		/// <param name="dst">destination array of pointers to data planes</param>
		/// <param name="src">source array of pointers to data planes</param>
		/// <param name="dst_offset">offset in samples at which the data will be written to dst</param>
		/// <param name="src_offset">offset in samples at which the data will be read from src</param>
		/// <param name="nb_samples">number of samples to be copied</param>
		/// <param name="nb_channels">number of audio channels</param>
		/// <param name="sample_fmt">audio sample format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_copy(IntPtr[] dst, IntPtr* src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

		/// <summary>
		/// Copy samples from src to dst.
		/// </summary>
		/// <param name="dst">destination array of pointers to data planes</param>
		/// <param name="src">source array of pointers to data planes</param>
		/// <param name="dst_offset">offset in samples at which the data will be written to dst</param>
		/// <param name="src_offset">offset in samples at which the data will be read from src</param>
		/// <param name="nb_samples">number of samples to be copied</param>
		/// <param name="nb_channels">number of audio channels</param>
		/// <param name="sample_fmt">audio sample format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_copy(IntPtr[] dst, IntPtr[] src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

		/// <summary>
		/// Fill plane data pointers and linesize for samples with sample format sample_fmt.
		/// </summary>
		/// <param name="audio_data">array to be filled with the pointer for each channel</param>
		/// <param name="linesize">calculated linesize, may be NULL</param>
		/// <param name="buf">the pointer to a buffer containing the samples</param>
		/// <param name="nb_channels">the number of channels</param>
		/// <param name="nb_samples">the number of samples in a single channel</param>
		/// <param name="sample_fmt">the sample format</param>
		/// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_fill_arrays(byte** audio_data, int* linesize, byte* buf, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

		/// <summary>
		/// Fill plane data pointers and linesize for samples with sample format sample_fmt.
		/// </summary>
		/// <param name="audio_data">array to be filled with the pointer for each channel</param>
		/// <param name="linesize">calculated linesize, may be NULL</param>
		/// <param name="buf">the pointer to a buffer containing the samples</param>
		/// <param name="nb_channels">the number of channels</param>
		/// <param name="nb_samples">the number of samples in a single channel</param>
		/// <param name="sample_fmt">the sample format</param>
		/// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_fill_arrays(IntPtr[] audio_data, int* linesize, IntPtr buf, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

		/// <summary>
		/// Get the required buffer size for the given audio parameters.
		/// </summary>
		/// <param name="linesize">calculated linesize, may be NULL</param>
		/// <param name="nb_channels">the number of channels</param>
		/// <param name="nb_samples">the number of samples in a single channel</param>
		/// <param name="sample_fmt">the sample format</param>
		/// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_get_buffer_size(int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);

		/// <summary>
		/// Fill an audio buffer with silence.
		/// </summary>
		/// <param name="audio_data">array of pointers to data planes</param>
		/// <param name="offset">offset in samples at which to start filling</param>
		/// <param name="nb_samples">number of samples to fill</param>
		/// <param name="nb_channels">number of audio channels</param>
		/// <param name="sample_fmt">audio sample format</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_samples_set_silence(byte** audio_data, int offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);

		/// <summary>
		/// Set a mask on flags returned by av_get_cpu_flags(). This function is mainly useful for testing. Please use av_force_cpu_flags() and av_get_cpu_flags() instead which are more flexible
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_set_cpu_flags_mask(int mask);

		/// <summary>
		/// Parse the key/value pairs list in opts. For each key/value pair found, stores the value in the field in ctx that is named like the key. ctx must be an AVClass context, storing is done using AVOptions.
		/// </summary>
		/// <param name="opts">options string to parse, may be NULL</param>
		/// <param name="key_val_sep">a 0-terminated list of characters used to separate key from value</param>
		/// <param name="pairs_sep">a 0-terminated list of characters used to separate two pairs from each other</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_set_options_string(void* ctx, [MarshalAs(UnmanagedType.LPStr)] string opts, [MarshalAs(UnmanagedType.LPStr)] string key_val_sep, [MarshalAs(UnmanagedType.LPStr)] string pairs_sep);

		/// <summary>
		/// Duplicate a string.
		/// </summary>
		/// <param name="s">String to be duplicated</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_strdup([MarshalAs(UnmanagedType.LPStr)] string s);

		/// <summary>
		/// Put a description of the AVERROR code errnum in errbuf. In case of failure the global variable errno is set to indicate the error. Even in case of failure av_strerror() will print a generic error message indicating the errnum provided to errbuf.
		/// </summary>
		/// <param name="errnum">error code to describe</param>
		/// <param name="errbuf">buffer to which description is written</param>
		/// <param name="errbuf_size">the size in bytes of errbuf</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_strerror(int errnum, byte* errbuf, IntPtr errbuf_size);

		/// <summary>
		/// Duplicate a substring of a string.
		/// </summary>
		/// <param name="s">String to be duplicated</param>
		/// <param name="len">Maximum length of the resulting string (not counting the terminating byte)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_strndup([MarshalAs(UnmanagedType.LPStr)] string s, IntPtr len);

		/// <summary>
		/// Subtract one rational from another.
		/// </summary>
		/// <param name="b">First rational</param>
		/// <param name="c">Second rational</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static AVRational av_sub_q(AVRational b, AVRational c);

		/// <summary>
		/// Adjust frame number for NTSC drop frame time code.
		/// </summary>
		/// <param name="framenum">frame number to adjust</param>
		/// <param name="fps">frame per second, 30 or 60</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_timecode_adjust_ntsc_framenum2(int framenum, int fps);

		/// <summary>
		/// Check if the timecode feature is available for the given frame rate
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_timecode_check_frame_rate(AVRational rate);

		/// <summary>
		/// Convert frame number to SMPTE 12M binary representation.
		/// </summary>
		/// <param name="tc">timecode data correctly initialized</param>
		/// <param name="framenum">frame number</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static uint av_timecode_get_smpte_from_framenum(AVTimecode* tc, int framenum);

		/// <summary>
		/// Init a timecode struct with the passed parameters.
		/// </summary>
		/// <param name="tc">pointer to an allocated AVTimecode</param>
		/// <param name="rate">frame rate in rational form</param>
		/// <param name="flags">miscellaneous flags such as drop frame, +24 hours, ... (see AVTimecodeFlag)</param>
		/// <param name="frame_start">the first frame number</param>
		/// <param name="log_ctx">a pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct (used for av_log)</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_timecode_init(AVTimecode* tc, AVRational rate, int flags, int frame_start, void* log_ctx);

		/// <summary>
		/// Parse timecode representation (hh:mm:ss[:;.]ff).
		/// </summary>
		/// <param name="tc">pointer to an allocated AVTimecode</param>
		/// <param name="rate">frame rate in rational form</param>
		/// <param name="str">timecode string which will determine the frame start</param>
		/// <param name="log_ctx">a pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct (used for av_log).</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static int av_timecode_init_from_string(AVTimecode* tc, AVRational rate, [MarshalAs(UnmanagedType.LPStr)] string str, void* log_ctx);

		/// <summary>
		/// Get the timecode string from the 25-bit timecode format (MPEG GOP format).
		/// </summary>
		/// <param name="buf">destination buffer, must be at least AV_TIMECODE_STR_SIZE long</param>
		/// <param name="tc25bit">the 25-bits timecode</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_timecode_make_mpeg_tc_string(byte* buf, uint tc25bit);

		/// <summary>
		/// Get the timecode string from the SMPTE timecode format.
		/// </summary>
		/// <param name="buf">destination buffer, must be at least AV_TIMECODE_STR_SIZE long</param>
		/// <param name="tcsmpte">the 32-bit SMPTE timecode</param>
		/// <param name="prevent_df">prevent the use of a drop flag when it is known the DF bit is arbitrary</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_timecode_make_smpte_tc_string(byte* buf, uint tcsmpte, int prevent_df);

		/// <summary>
		/// Load timecode string in buf.
		/// </summary>
		/// <param name="tc">timecode data correctly initialized</param>
		/// <param name="buf">destination buffer, must be at least AV_TIMECODE_STR_SIZE long</param>
		/// <param name="framenum">frame number</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static byte* av_timecode_make_string(AVTimecode* tc, byte* buf, int framenum);

		/// <summary>
		/// Return an informative version string. This usually is the actual release version number or a git commit description. This string has no fixed format and can change any time. It should never be parsed by code.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public extern static string av_version_info();

		/// <summary>
		/// Send the specified message to the log if the level is less than or equal to the current av_log_level. By default, all logging messages are sent to stderr. This behavior can be altered by setting a different logging callback function.
		/// </summary>
		/// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
		/// <param name="level">The importance level of the message expressed using a</param>
		/// <param name="fmt">The format string (printf-compatible) that specifies how subsequent arguments are converted to output.</param>
		/// <param name="vl">The arguments referenced by the format string.</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_vlog(void* avcl, int level, [MarshalAs(UnmanagedType.LPStr)] string fmt, byte* vl);

		/// <summary>
		/// Write the values from src to the pixel format component c of an image line.
		/// </summary>
		/// <param name="src">array containing the values to write</param>
		/// <param name="data">the array containing the pointers to the planes of the image to write into. It is supposed to be zeroed.</param>
		/// <param name="linesize">the array containing the linesizes of the image</param>
		/// <param name="desc">the pixel format descriptor for the image</param>
		/// <param name="x">the horizontal coordinate of the first pixel to write</param>
		/// <param name="y">the vertical coordinate of the first pixel to write</param>
		/// <param name="w">the width of the line to write, that is the number of values to write to the image line</param>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static void av_write_image_line(ushort* src, ref byte_ptrArray4 data, int_array4 linesize, AVPixFmtDescriptor* desc, int x, int y, int c, int w);

		/// <summary>
		/// Return the libavutil build-time configuration.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string avutil_configuration();

		/// <summary>
		/// Return the libavutil license.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static string avutil_license();

		/// <summary>
		/// Return the LIBAVUTIL_VERSION_INT constant.
		/// </summary>
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		public extern static uint avutil_version();

	}
#pragma warning restore IDE1006 // 命名样式
}
