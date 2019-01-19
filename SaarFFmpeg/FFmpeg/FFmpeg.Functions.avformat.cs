using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Delegates;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.Internal {
#pragma warning disable IDE1006 // 命名样式
	public unsafe static partial class FFmpeg {
		/// <summary>
		/// Add an index entry into a sorted list. Update the entry if the list already contains it.
		/// </summary>
		/// <param name="timestamp">timestamp in the time base of the given stream</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_add_index_entry(AVStream* st, long pos, long timestamp, int size, int distance, int flags);

		/// <summary>
		/// Read data and append it to the current content of the AVPacket. If pkt-&gt;size is 0 this is identical to av_get_packet. Note that this uses av_grow_packet and thus involves a realloc which is inefficient. Thus this function should only be used when there is no reasonable way to know (an upper bound of) the final size.
		/// </summary>
		/// <param name="s">associated IO context</param>
		/// <param name="pkt">packet</param>
		/// <param name="size">amount of data to read</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_append_packet(AVIOContext* s, AVPacket* pkt, int size);

		/// <summary>
		/// Apply a list of bitstream filters to a packet.
		/// </summary>
		/// <param name="codec">AVCodecContext, usually from an AVStream</param>
		/// <param name="pkt">the packet to apply filters to. If, on success, the returned packet has size == 0 and side_data_elems == 0, it indicates that the packet should be dropped</param>
		/// <param name="bsfc">a NULL-terminated list of filters to apply</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_apply_bitstream_filters(AVCodecContext* codec, AVPacket* pkt, AVBitStreamFilterContext* bsfc);

		/// <summary>
		/// Get the AVCodecID for the given codec tag tag. If no codec id is found returns AV_CODEC_ID_NONE.
		/// </summary>
		/// <param name="tags">list of supported codec_id-codec_tag pairs, as stored in AVInputFormat.codec_tag and AVOutputFormat.codec_tag</param>
		/// <param name="tag">codec tag to match to a codec ID</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecID av_codec_get_id(AVCodecTag** tags, uint tag);

		/// <summary>
		/// Get the codec tag for the given codec id id. If no codec tag is found returns 0.
		/// </summary>
		/// <param name="tags">list of supported codec_id-codec_tag pairs, as stored in AVInputFormat.codec_tag and AVOutputFormat.codec_tag</param>
		/// <param name="id">codec ID to match to a codec tag</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint av_codec_get_tag(AVCodecTag** tags, AVCodecID id);

		/// <summary>
		/// Get the codec tag for the given codec id.
		/// </summary>
		/// <param name="tags">list of supported codec_id - codec_tag pairs, as stored in AVInputFormat.codec_tag and AVOutputFormat.codec_tag</param>
		/// <param name="id">codec id that should be searched for in the list</param>
		/// <param name="tag">A pointer to the found tag</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_codec_get_tag2(AVCodecTag** tags, AVCodecID id, uint* tag);

		/// <summary>
		/// Iterate over all registered demuxers.
		/// </summary>
		/// <param name="opaque">a pointer where libavformat will store the iteration state. Must point to NULL to start the iteration.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_demuxer_iterate(void** opaque);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_demuxer_open(AVFormatContext* ic);

		/// <summary>
		/// Print detailed information about the input or output format, such as duration, bitrate, streams, container, programs, metadata, side data, codec and time base.
		/// </summary>
		/// <param name="ic">the context to analyze</param>
		/// <param name="index">index of the stream to dump information about</param>
		/// <param name="url">the URL to print, such as source or destination file</param>
		/// <param name="is_output">Select whether the specified context is an input(0) or output(1)</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_dump_format(AVFormatContext* ic, int index, [MarshalAs(UnmanagedType.LPStr)] string url, bool is_output);

		/// <summary>
		/// Check whether filename actually is a numbered sequence generator.
		/// </summary>
		/// <param name="filename">possible numbered sequence string</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_filename_number_test([MarshalAs(UnmanagedType.LPStr)] string filename);

		/// <summary>
		/// Find the &quot;best&quot; stream in the file. The best stream is determined according to various heuristics as the most likely to be what the user expects. If the decoder parameter is non-NULL, av_find_best_stream will find the default decoder for the stream&apos;s codec; streams for which no decoder can be found are ignored.
		/// </summary>
		/// <param name="ic">media file handle</param>
		/// <param name="type">stream type: video, audio, subtitles, etc.</param>
		/// <param name="wanted_stream_nb">user-requested stream number, or -1 for automatic selection</param>
		/// <param name="related_stream">try to find a stream related (eg. in the same program) to this one, or -1 if none</param>
		/// <param name="decoder_ret">if non-NULL, returns the decoder for the selected stream</param>
		/// <param name="flags">flags; none are currently defined</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_find_best_stream(AVFormatContext* ic, AVMediaType type, int wanted_stream_nb, int related_stream, AVCodec** decoder_ret, int flags);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_find_default_stream_index(AVFormatContext* s);

		/// <summary>
		/// Find AVInputFormat based on the short name of the input format.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_find_input_format([MarshalAs(UnmanagedType.LPStr)] string short_name);

		/// <summary>
		/// Find the programs which belong to a given stream.
		/// </summary>
		/// <param name="ic">media file handle</param>
		/// <param name="last">the last found program, the search will start after this program, or from the beginning if it is NULL</param>
		/// <param name="s">stream index</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVProgram* av_find_program_from_stream(AVFormatContext* ic, AVProgram* last, int s);

		/// <summary>
		/// Returns the method used to set ctx-&gt;duration.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVDurationEstimationMethod av_fmt_ctx_get_duration_estimation_method(AVFormatContext* ctx);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodec* av_format_get_audio_codec(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static av_format_control_message av_format_get_control_message_cb(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodec* av_format_get_data_codec(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_format_get_metadata_header_padding(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void* av_format_get_opaque(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVOpenCallback av_format_get_open_cb(AVFormatContext* s);

		/// <summary>
		/// Accessors for some AVFormatContext fields. These used to be provided for ABI compatibility, and do not need to be used anymore.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_format_get_probe_score(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodec* av_format_get_subtitle_codec(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodec* av_format_get_video_codec(AVFormatContext* s);

		/// <summary>
		/// This function will cause global side data to be injected in the next packet of each stream as well as after any subsequent seek.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_inject_global_side_data(AVFormatContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_audio_codec(AVFormatContext* s, AVCodec* c);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_control_message_cb(AVFormatContext* s, av_format_set_control_message_cb_callback callback);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_data_codec(AVFormatContext* s, AVCodec* c);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_metadata_header_padding(AVFormatContext* s, int c);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_opaque(AVFormatContext* s, void* opaque);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_open_cb(AVFormatContext* s, av_format_set_open_cb_callback callback);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_subtitle_codec(AVFormatContext* s, AVCodec* c);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_format_set_video_codec(AVFormatContext* s, AVCodec* c);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_get_frame_filename(byte* buf, int buf_size, [MarshalAs(UnmanagedType.LPStr)] string path, int number);

		/// <summary>
		/// Return in &apos;buf&apos; the path with &apos;%d&apos; replaced by a number.
		/// </summary>
		/// <param name="buf">destination buffer</param>
		/// <param name="buf_size">destination buffer size</param>
		/// <param name="path">numbered sequence string</param>
		/// <param name="number">frame number</param>
		/// <param name="flags">AV_FRAME_FILENAME_FLAGS_*</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_get_frame_filename2(byte* buf, int buf_size, [MarshalAs(UnmanagedType.LPStr)] string path, int number, int flags);

		/// <summary>
		/// Get timing information for the data currently output. The exact meaning of &quot;currently output&quot; depends on the format. It is mostly relevant for devices that have an internal buffer and/or work in real time.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="stream">stream in the media file</param>
		/// <param name="dts">DTS of the last packet output for the stream, in stream time_base units</param>
		/// <param name="wall">absolute time when that packet whas output, in microsecond</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_get_output_timestamp(AVFormatContext* s, int stream, long* dts, long* wall);

		/// <summary>
		/// Allocate and read the payload of a packet and initialize its fields with default values.
		/// </summary>
		/// <param name="s">associated IO context</param>
		/// <param name="pkt">packet</param>
		/// <param name="size">desired payload size</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_get_packet(AVIOContext* s, AVPacket* pkt, int size);

		/// <summary>
		/// Guess the codec ID based upon muxer and filename.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecID av_guess_codec(AVOutputFormat* fmt, [MarshalAs(UnmanagedType.LPStr)] string short_name, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string mime_type, AVMediaType type);

		/// <summary>
		/// Return the output format in the list of registered output formats which best matches the provided parameters, or return NULL if there is no match.
		/// </summary>
		/// <param name="short_name">if non-NULL checks if short_name matches with the names of the registered formats</param>
		/// <param name="filename">if non-NULL checks if filename terminates with the extensions of the registered formats</param>
		/// <param name="mime_type">if non-NULL checks if mime_type matches with the MIME type of the registered formats</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVOutputFormat* av_guess_format([MarshalAs(UnmanagedType.LPStr)] string short_name, [MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string mime_type);

		/// <summary>
		/// Return the output format in the list of registered output formats which best matches the provided parameters, or return NULL if there is no match.
		/// </summary>
		/// <param name="short_name">if non-NULL checks if short_name matches with the names of the registered formats</param>
		/// <param name="filename">if non-NULL checks if filename terminates with the extensions of the registered formats</param>
		/// <param name="mime_type">if non-NULL checks if mime_type matches with the MIME type of the registered formats</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVOutputFormat* av_guess_format(byte* short_name, byte* filename, byte* mime_type);


		/// <summary>
		/// Guess the frame rate, based on both the container and codec information.
		/// </summary>
		/// <param name="ctx">the format context which the stream is part of</param>
		/// <param name="stream">the stream which the frame is part of</param>
		/// <param name="frame">the frame for which the frame rate should be determined, may be NULL</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVRational av_guess_frame_rate(AVFormatContext* ctx, AVStream* stream, AVFrame* frame);

		/// <summary>
		/// Guess the sample aspect ratio of a frame, based on both the stream and the frame aspect ratio.
		/// </summary>
		/// <param name="format">the format context which the stream is part of</param>
		/// <param name="stream">the stream which the frame is part of</param>
		/// <param name="frame">the frame with the aspect ratio to be determined</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVRational av_guess_sample_aspect_ratio(AVFormatContext* format, AVStream* stream, AVFrame* frame);

		/// <summary>
		/// Send a nice hexadecimal dump of a buffer to the specified file stream.
		/// </summary>
		/// <param name="f">The file stream pointer where the dump should be sent to.</param>
		/// <param name="buf">buffer</param>
		/// <param name="size">buffer size</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_hex_dump(_iobuf* f, byte* buf, int size);

		/// <summary>
		/// Send a nice hexadecimal dump of a buffer to the log.
		/// </summary>
		/// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
		/// <param name="level">The importance level of the message, lower values signifying higher importance.</param>
		/// <param name="buf">buffer</param>
		/// <param name="size">buffer size</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_hex_dump_log(void* avcl, int level, byte* buf, int size);

		/// <summary>
		/// If f is NULL, returns the first registered input format, if f is non-NULL, returns the next registered input format after f or NULL if f is the last one.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_iformat_next(AVInputFormat* f);

		/// <summary>
		/// Get the index for a specific timestamp.
		/// </summary>
		/// <param name="st">stream that the timestamp belongs to</param>
		/// <param name="timestamp">timestamp to retrieve the index for</param>
		/// <param name="flags">if AVSEEK_FLAG_BACKWARD then the returned index will correspond to the timestamp which is &lt; = the requested one, if backward is 0, then it will be &gt;= if AVSEEK_FLAG_ANY seek to any frame, only keyframes otherwise</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_index_search_timestamp(AVStream* st, long timestamp, int flags);

		/// <summary>
		/// Write a packet to an output media file ensuring correct interleaving.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="pkt">The packet containing the data to be written.  If the packet is reference-counted, this function will take ownership of this reference and unreference it later when it sees fit. The caller must not access the data through this reference after this function returns. If the packet is not reference-counted, libavformat will make a copy.  This parameter can be NULL (at any time, not just at the end), to flush the interleaving queues.  Packet&apos;s</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_interleaved_write_frame(AVFormatContext* s, AVPacket* pkt);

		/// <summary>
		/// Write an uncoded frame to an output media file.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_interleaved_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);

		/// <summary>
		/// Return a positive value if the given filename has one of the given extensions, 0 otherwise.
		/// </summary>
		/// <param name="filename">file name to check against the given extensions</param>
		/// <param name="extensions">a comma-separated list of filename extensions</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_match_ext([MarshalAs(UnmanagedType.LPStr)] string filename, [MarshalAs(UnmanagedType.LPStr)] string extensions);

		/// <summary>
		/// Iterate over all registered muxers.
		/// </summary>
		/// <param name="opaque">a pointer where libavformat will store the iteration state. Must point to NULL to start the iteration.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVOutputFormat* av_muxer_iterate(void** opaque);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVProgram* av_new_program(AVFormatContext* s, int id);

		/// <summary>
		/// If f is NULL, returns the first registered output format, if f is non-NULL, returns the next registered output format after f or NULL if f is the last one.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVOutputFormat* av_oformat_next(AVOutputFormat* f);

		/// <summary>
		/// Send a nice dump of a packet to the log.
		/// </summary>
		/// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
		/// <param name="level">The importance level of the message, lower values signifying higher importance.</param>
		/// <param name="pkt">packet to dump</param>
		/// <param name="dump_payload">True if the payload must be displayed, too.</param>
		/// <param name="st">AVStream that the packet belongs to</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_pkt_dump_log2(void* avcl, int level, AVPacket* pkt, int dump_payload, AVStream* st);

		/// <summary>
		/// Send a nice dump of a packet to the specified file stream.
		/// </summary>
		/// <param name="f">The file stream pointer where the dump should be sent to.</param>
		/// <param name="pkt">packet to dump</param>
		/// <param name="dump_payload">True if the payload must be displayed, too.</param>
		/// <param name="st">AVStream that the packet belongs to</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_pkt_dump2(_iobuf* f, AVPacket* pkt, int dump_payload, AVStream* st);

		/// <summary>
		/// Like av_probe_input_buffer2() but returns 0 on success
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_probe_input_buffer(AVIOContext* pb, AVInputFormat** fmt, [MarshalAs(UnmanagedType.LPStr)] string url, void* logctx, uint offset, uint max_probe_size);

		/// <summary>
		/// Probe a bytestream to determine the input format. Each time a probe returns with a score that is too low, the probe buffer size is increased and another attempt is made. When the maximum probe size is reached, the input format with the highest score is returned.
		/// </summary>
		/// <param name="pb">the bytestream to probe</param>
		/// <param name="fmt">the input format is put here</param>
		/// <param name="url">the url of the stream</param>
		/// <param name="logctx">the log context</param>
		/// <param name="offset">the offset within the bytestream to probe from</param>
		/// <param name="max_probe_size">the maximum probe buffer size (zero for default)</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_probe_input_buffer2(AVIOContext* pb, AVInputFormat** fmt, [MarshalAs(UnmanagedType.LPStr)] string url, void* logctx, uint offset, uint max_probe_size);

		/// <summary>
		/// Guess the file format.
		/// </summary>
		/// <param name="pd">data to be probed</param>
		/// <param name="is_opened">Whether the file is already opened; determines whether demuxers with or without AVFMT_NOFILE are probed.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_probe_input_format(AVProbeData* pd, bool is_opened);

		/// <summary>
		/// Guess the file format.
		/// </summary>
		/// <param name="pd">data to be probed</param>
		/// <param name="is_opened">Whether the file is already opened; determines whether demuxers with or without AVFMT_NOFILE are probed.</param>
		/// <param name="score_max">A probe score larger that this is required to accept a detection, the variable is set to the actual detection score afterwards. If the score is &lt; = AVPROBE_SCORE_MAX / 4 it is recommended to retry with a larger probe buffer.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_probe_input_format2(AVProbeData* pd, bool is_opened, int* score_max);

		/// <summary>
		/// Guess the file format.
		/// </summary>
		/// <param name="is_opened">Whether the file is already opened; determines whether demuxers with or without AVFMT_NOFILE are probed.</param>
		/// <param name="score_ret">The score of the best detection.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVInputFormat* av_probe_input_format3(AVProbeData* pd, bool is_opened, int* score_ret);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_program_add_stream_index(AVFormatContext* ac, int progid, uint idx);

		/// <summary>
		/// Return the next frame of a stream. This function returns what is stored in the file, and does not validate that what is there are valid frames for the decoder. It will split what is stored in the file into frames and return one for each call. It will not omit invalid data between valid frames so as to give the decoder the maximum information possible for decoding.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_read_frame(AVFormatContext* s, AVPacket* pkt);

		/// <summary>
		/// Pause a network-based stream (e.g. RTSP stream).
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_read_pause(AVFormatContext* s);

		/// <summary>
		/// Start playing a network-based stream (e.g. RTSP stream) at the current position.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_read_play(AVFormatContext* s);

		/// <summary>
		/// Initialize libavformat and register all the muxers, demuxers and protocols. If you do not call this function, then you can select exactly which formats you want to support.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_register_all();

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_register_input_format(AVInputFormat* format);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_register_output_format(AVOutputFormat* format);

		/// <summary>
		/// Generate an SDP for an RTP session.
		/// </summary>
		/// <param name="ac">array of AVFormatContexts describing the RTP streams. If the array is composed by only one context, such context can contain multiple AVStreams (one AVStream per RTP stream). Otherwise, all the contexts in the array (an AVCodecContext per RTP stream) must contain only one AVStream.</param>
		/// <param name="n_files">number of AVCodecContexts contained in ac</param>
		/// <param name="buf">buffer where the SDP will be stored (must be allocated by the caller)</param>
		/// <param name="size">the size of the buffer</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_sdp_create(AVFormatContext** ac, int n_files, byte* buf, int size);

		/// <summary>
		/// Seek to the keyframe at timestamp. &apos;timestamp&apos; in &apos;stream_index&apos;.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="stream_index">If stream_index is (-1), a default stream is selected, and timestamp is automatically converted from AV_TIME_BASE units to the stream specific time_base.</param>
		/// <param name="timestamp">Timestamp in AVStream.time_base units or, if no stream is specified, in AV_TIME_BASE units.</param>
		/// <param name="flags">flags which select direction and seeking mode</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_seek_frame(AVFormatContext* s, int stream_index, long timestamp, AVSeekFlag flags);

		/// <summary>
		/// Wrap an existing array as stream side data.
		/// </summary>
		/// <param name="st">stream</param>
		/// <param name="type">side information type</param>
		/// <param name="data">the side data array. It must be allocated with the av_malloc() family of functions. The ownership of the data is transferred to st.</param>
		/// <param name="size">side information size</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_stream_add_side_data(AVStream* st, AVPacketSideDataType type, byte* data, IntPtr size);

		/// <summary>
		/// Get the internal codec timebase from a stream.
		/// </summary>
		/// <param name="st">input stream to extract the timebase from</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVRational av_stream_get_codec_timebase(AVStream* st);

		/// <summary>
		/// Returns the pts of the last muxed packet + its duration
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static long av_stream_get_end_pts(AVStream* st);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecParserContext* av_stream_get_parser(AVStream* s);

		/// <summary>
		/// Accessors for some AVStream fields. These used to be provided for ABI compatibility, and do not need to be used anymore.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVRational av_stream_get_r_frame_rate(AVStream* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static byte* av_stream_get_recommended_encoder_configuration(AVStream* s);

		/// <summary>
		/// Get side information from stream.
		/// </summary>
		/// <param name="stream">stream</param>
		/// <param name="type">desired side information type</param>
		/// <param name="size">pointer for side information size to store (optional)</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static byte* av_stream_get_side_data(AVStream* stream, AVPacketSideDataType type, int* size);

		/// <summary>
		/// Allocate new information from stream.
		/// </summary>
		/// <param name="stream">stream</param>
		/// <param name="type">desired side information type</param>
		/// <param name="size">side information size</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static byte* av_stream_new_side_data(AVStream* stream, AVPacketSideDataType type, int size);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_stream_set_r_frame_rate(AVStream* s, AVRational r);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_stream_set_recommended_encoder_configuration(AVStream* s, byte* configuration);

		/// <summary>
		/// Split a URL string into components.
		/// </summary>
		/// <param name="proto">the buffer for the protocol</param>
		/// <param name="proto_size">the size of the proto buffer</param>
		/// <param name="authorization">the buffer for the authorization</param>
		/// <param name="authorization_size">the size of the authorization buffer</param>
		/// <param name="hostname">the buffer for the host name</param>
		/// <param name="hostname_size">the size of the hostname buffer</param>
		/// <param name="port_ptr">a pointer to store the port number in</param>
		/// <param name="path">the buffer for the path</param>
		/// <param name="path_size">the size of the path buffer</param>
		/// <param name="url">the URL to split</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void av_url_split(byte* proto, int proto_size, byte* authorization, int authorization_size, byte* hostname, int hostname_size, int* port_ptr, byte* path, int path_size, [MarshalAs(UnmanagedType.LPStr)] string url);

		/// <summary>
		/// Write a packet to an output media file.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="pkt">The packet containing the data to be written. Note that unlike av_interleaved_write_frame(), this function does not take ownership of the packet passed to it (though some muxers may make an internal reference to the input packet).  This parameter can be NULL (at any time, not just at the end), in order to immediately flush data buffered within the muxer, for muxers that buffer up data internally before writing it to the output.  Packet&apos;s</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_write_frame(AVFormatContext* s, AVPacket* pkt);

		/// <summary>
		/// Write the stream trailer to an output media file and free the file private data.
		/// </summary>
		/// <param name="s">media file handle</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_write_trailer(AVFormatContext* s);

		/// <summary>
		/// Write an uncoded frame to an output media file.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);

		/// <summary>
		/// Test whether a muxer supports uncoded frame.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int av_write_uncoded_frame_query(AVFormatContext* s, int stream_index);

		/// <summary>
		/// Allocate an AVFormatContext. avformat_free_context() can be used to free the context and everything allocated by the framework within it.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVFormatContext* avformat_alloc_context();

		/// <summary>
		/// Allocate an AVFormatContext for an output format. avformat_free_context() can be used to free the context and everything allocated by the framework within it.
		/// </summary>
		/// <param name="oformat">format to use for allocating the context, if NULL format_name and filename are used instead</param>
		/// <param name="format_name">the name of output format to use for allocating the context, if NULL filename is used instead</param>
		/// <param name="filename">the name of the filename to use for allocating the context, may be NULL</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_alloc_output_context2(AVFormatContext** ctx, AVOutputFormat* oformat, [MarshalAs(UnmanagedType.LPStr)] string format_name, [MarshalAs(UnmanagedType.LPStr)] string filename);

		/// <summary>
		/// Close an opened input AVFormatContext. Free it and all its contents and set *s to NULL.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avformat_close_input(ref AVFormatContext* s);

		/// <summary>
		/// Return the libavformat build-time configuration.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static string avformat_configuration();

		/// <summary>
		/// Read packets of a media file to get stream information. This is useful for file formats with no headers such as MPEG. This function also computes the real framerate in case of MPEG-2 repeat frame mode. The logical file position is not changed by this function; examined packets may be buffered for later processing.
		/// </summary>
		/// <param name="ic">media file handle</param>
		/// <param name="options">If non-NULL, an ic.nb_streams long array of pointers to dictionaries, where i-th member contains options for codec corresponding to i-th stream. On return each dictionary will be filled with options that were not found.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_find_stream_info(AVFormatContext* ic, AVDictionary** options);

		/// <summary>
		/// Discard all internally buffered data. This can be useful when dealing with discontinuities in the byte stream. Generally works only with formats that can resync. This includes headerless formats like MPEG-TS/TS but should also work with NUT, Ogg and in a limited way AVI for example.
		/// </summary>
		/// <param name="s">media file handle</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_flush(AVFormatContext* s);

		/// <summary>
		/// Free an AVFormatContext and all its streams.
		/// </summary>
		/// <param name="s">context to free</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avformat_free_context(AVFormatContext* s);

		/// <summary>
		/// Get the AVClass for AVFormatContext. It can be used in combination with AV_OPT_SEARCH_FAKE_OBJ for examining options.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVClass* avformat_get_class();

		/// <summary>
		/// Returns the table mapping MOV FourCCs for audio to AVCodecID.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecTag* avformat_get_mov_audio_tags();

		/// <summary>
		/// Returns the table mapping MOV FourCCs for video to libavcodec AVCodecID.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecTag* avformat_get_mov_video_tags();

		/// <summary>
		/// Returns the table mapping RIFF FourCCs for audio to AVCodecID.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecTag* avformat_get_riff_audio_tags();

		/// <summary>
		/// @{ Get the tables mapping RIFF FourCCs to libavcodec AVCodecIDs. The tables are meant to be passed to av_codec_get_id()/av_codec_get_tag() as in the following code:
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVCodecTag* avformat_get_riff_video_tags();

		/// <summary>
		/// Allocate the stream private data and initialize the codec, but do not write the header. May optionally be used before avformat_write_header to initialize stream parameters before actually writing the header. If using this function, do not pass the same options to avformat_write_header.
		/// </summary>
		/// <param name="s">Media file handle, must be allocated with avformat_alloc_context(). Its oformat field must be set to the desired output format; Its pb field must be set to an already opened AVIOContext.</param>
		/// <param name="options">An AVDictionary filled with AVFormatContext and muxer-private options. On return this parameter will be destroyed and replaced with a dict containing options that were not found. May be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_init_output(AVFormatContext* s, AVDictionary** options);

		/// <summary>
		/// Return the libavformat license.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static string avformat_license();

		/// <summary>
		/// Check if the stream st contained in s is matched by the stream specifier spec.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_match_stream_specifier(AVFormatContext* s, AVStream* st, [MarshalAs(UnmanagedType.LPStr)] string spec);

		/// <summary>
		/// Undo the initialization done by avformat_network_init. Call it only once for each time you called avformat_network_init.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_network_deinit();

		/// <summary>
		/// Do global initialization of network libraries. This is optional, and not recommended anymore.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_network_init();

		/// <summary>
		/// Add a new stream to a media file.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="c">If non-NULL, the AVCodecContext corresponding to the new stream will be initialized to use this codec. This is needed for e.g. codec-specific defaults to be set, so codec should be provided if it is known.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVStream* avformat_new_stream(AVFormatContext* s, AVCodec* c);

		/// <summary>
		/// Open an input stream and read the header. The codecs are not opened. The stream must be closed with avformat_close_input().
		/// </summary>
		/// <param name="ps">Pointer to user-supplied AVFormatContext (allocated by avformat_alloc_context). May be a pointer to NULL, in which case an AVFormatContext is allocated by this function and written into ps. Note that a user-supplied AVFormatContext will be freed on failure.</param>
		/// <param name="url">URL of the stream to open.</param>
		/// <param name="fmt">If non-NULL, this parameter forces a specific input format. Otherwise the format is autodetected.</param>
		/// <param name="options">A dictionary filled with AVFormatContext and demuxer-private options. On return this parameter will be destroyed and replaced with a dict containing options that were not found. May be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_open_input(AVFormatContext** ps, [MarshalAs(UnmanagedType.LPStr)] string url, AVInputFormat* fmt, AVDictionary** options);

		/// <summary>
		/// Test if the given container can store a codec.
		/// </summary>
		/// <param name="ofmt">container to check for compatibility</param>
		/// <param name="codec_id">codec to potentially store in container</param>
		/// <param name="std_compliance">standards compliance level, one of FF_COMPLIANCE_*</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_query_codec(AVOutputFormat* ofmt, AVCodecID codec_id, int std_compliance);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_queue_attached_pictures(AVFormatContext* s);

		/// <summary>
		/// Seek to timestamp ts. Seeking will be done so that the point from which all active streams can be presented successfully will be closest to ts and within min/max_ts. Active streams are all streams that have AVStream.discard &lt; AVDISCARD_ALL.
		/// </summary>
		/// <param name="s">media file handle</param>
		/// <param name="stream_index">index of the stream which is used as time base reference</param>
		/// <param name="min_ts">smallest acceptable timestamp</param>
		/// <param name="ts">target timestamp</param>
		/// <param name="max_ts">largest acceptable timestamp</param>
		/// <param name="flags">flags</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_seek_file(AVFormatContext* s, int stream_index, long min_ts, long ts, long max_ts, int flags);

		/// <summary>
		/// Transfer internal timing information from one stream to another.
		/// </summary>
		/// <param name="ofmt">target output format for ost</param>
		/// <param name="ost">output stream which needs timings copy and adjustments</param>
		/// <param name="ist">reference input stream to copy timings from</param>
		/// <param name="copy_tb">define from where the stream codec timebase needs to be imported</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_transfer_internal_stream_timing_info(AVOutputFormat* ofmt, AVStream* ost, AVStream* ist, AVTimebaseSource copy_tb);

		/// <summary>
		/// Return the LIBAVFORMAT_VERSION_INT constant.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avformat_version();

		/// <summary>
		/// Allocate the stream private data and write the stream header to an output media file.
		/// </summary>
		/// <param name="s">Media file handle, must be allocated with avformat_alloc_context(). Its oformat field must be set to the desired output format; Its pb field must be set to an already opened AVIOContext.</param>
		/// <param name="options">An AVDictionary filled with AVFormatContext and muxer-private options. On return this parameter will be destroyed and replaced with a dict containing options that were not found. May be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avformat_write_header(AVFormatContext* s, AVDictionary** options);

		/// <summary>
		/// Accept and allocate a client context on a server context.
		/// </summary>
		/// <param name="s">the server context</param>
		/// <param name="c">the client context, must be unallocated</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_accept(AVIOContext* s, AVIOContext** c);

		/// <summary>
		/// Allocate and initialize an AVIOContext for buffered I/O. It must be later freed with avio_context_free().
		/// </summary>
		/// <param name="buffer">Memory block for input/output operations via AVIOContext. The buffer must be allocated with av_malloc() and friends. It may be freed and replaced with a new buffer by libavformat. AVIOContext.buffer holds the buffer currently in use, which must be later freed with av_free().</param>
		/// <param name="buffer_size">The buffer size is very important for performance. For protocols with fixed blocksize it should be set to this blocksize. For others a typical size is a cache page, e.g. 4kb.</param>
		/// <param name="write_flag">Set to 1 if the buffer should be writable, 0 otherwise.</param>
		/// <param name="opaque">An opaque pointer to user-specific data.</param>
		/// <param name="read_packet">A function for refilling the buffer, may be NULL. For stream protocols, must never return 0 but rather a proper AVERROR code.</param>
		/// <param name="write_packet">A function for writing the buffer contents, may be NULL. The function may not change the input buffers content.</param>
		/// <param name="seek">A function for seeking to specified byte position, may be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static AVIOContext* avio_alloc_context(byte* buffer, int buffer_size, bool write_flag, void* opaque, avio_alloc_context_read_packet read_packet, avio_alloc_context_write_packet write_packet, avio_alloc_context_seek seek);

		/// <summary>
		/// Return AVIO_FLAG_* access flags corresponding to the access permissions of the resource in url, or a negative value corresponding to an AVERROR code in case of failure. The returned access flags are masked by the value in flags.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_check([MarshalAs(UnmanagedType.LPStr)] string url, int flags);

		/// <summary>
		/// Close the resource accessed by the AVIOContext s and free it. This function can only be used if s was opened by avio_open().
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_close(AVIOContext* s);

		/// <summary>
		/// Close directory.
		/// </summary>
		/// <param name="s">directory read context.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_close_dir(AVIODirContext** s);

		/// <summary>
		/// Return the written size and a pointer to the buffer. The buffer must be freed with av_free(). Padding of AV_INPUT_BUFFER_PADDING_SIZE is added to the buffer.
		/// </summary>
		/// <param name="s">IO context</param>
		/// <param name="pbuffer">pointer to a byte buffer</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_close_dyn_buf(AVIOContext* s, byte** pbuffer);

		/// <summary>
		/// Close the resource accessed by the AVIOContext *s, free it and set the pointer pointing to it to NULL. This function can only be used if s was opened by avio_open().
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_closep(AVIOContext** s);

		/// <summary>
		/// Free the supplied IO context and everything associated with it.
		/// </summary>
		/// <param name="s">Double pointer to the IO context. This function will write NULL into s.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_context_free(AVIOContext** s);

		/// <summary>
		/// Iterate through names of available protocols.
		/// </summary>
		/// <param name="opaque">A private pointer representing current protocol. It must be a pointer to NULL on first iteration and will be updated by successive calls to avio_enum_protocols.</param>
		/// <param name="output">If set to 1, iterate over output protocols, otherwise over input protocols.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static string avio_enum_protocols(void** opaque, int output);

		/// <summary>
		/// feof() equivalent for AVIOContext.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_feof(AVIOContext* s);

		/// <summary>
		/// Return the name of the protocol that will handle the passed URL.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static string avio_find_protocol_name([MarshalAs(UnmanagedType.LPStr)] string url);

		/// <summary>
		/// Force flushing of buffered data.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_flush(AVIOContext* s);

		/// <summary>
		/// Free entry allocated by avio_read_dir().
		/// </summary>
		/// <param name="entry">entry to be freed.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_free_directory_entry(AVIODirEntry** entry);

		/// <summary>
		/// Return the written size and a pointer to the buffer. The AVIOContext stream is left intact. The buffer must NOT be freed. No padding is added to the buffer.
		/// </summary>
		/// <param name="s">IO context</param>
		/// <param name="pbuffer">pointer to a byte buffer</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_get_dyn_buf(AVIOContext* s, byte** pbuffer);

		/// <summary>
		/// Read a string from pb into buf. The reading will terminate when either a NULL character was encountered, maxlen bytes have been read, or nothing more can be read from pb. The result is guaranteed to be NULL-terminated, it will be truncated if buf is too small. Note that the string is not interpreted or validated in any way, it might get truncated in the middle of a sequence for multi-byte encodings.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_get_str(AVIOContext* pb, int maxlen, byte* buf, int buflen);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_get_str16be(AVIOContext* pb, int maxlen, byte* buf, int buflen);

		/// <summary>
		/// Read a UTF-16 string from pb and convert it to UTF-8. The reading will terminate when either a null or invalid character was encountered or maxlen bytes have been read.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_get_str16le(AVIOContext* pb, int maxlen, byte* buf, int buflen);

		/// <summary>
		/// Perform one step of the protocol handshake to accept a new client. This function must be called on a client returned by avio_accept() before using it as a read/write context. It is separate from avio_accept() because it may block. A step of the handshake is defined by places where the application may decide to change the proceedings. For example, on a protocol with a request header and a reply header, each one can constitute a step because the application may use the parameters from the request to change parameters in the reply; or each individual chunk of the request can constitute a step. If the handshake is already finished, avio_handshake() does nothing and returns 0 immediately.
		/// </summary>
		/// <param name="c">the client context to perform the handshake on</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_handshake(AVIOContext* c);

		/// <summary>
		/// Create and initialize a AVIOContext for accessing the resource indicated by url.
		/// </summary>
		/// <param name="s">Used to return the pointer to the created AVIOContext. In case of failure the pointed to value is set to NULL.</param>
		/// <param name="url">resource to access</param>
		/// <param name="flags">flags which control how the resource indicated by url is to be opened</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_open(AVIOContext** s, [MarshalAs(UnmanagedType.LPStr)] string url, int flags);

		/// <summary>
		/// Open directory for reading.
		/// </summary>
		/// <param name="s">directory read context. Pointer to a NULL pointer must be passed.</param>
		/// <param name="url">directory to be listed.</param>
		/// <param name="options">A dictionary filled with protocol-private options. On return this parameter will be destroyed and replaced with a dictionary containing options that were not found. May be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_open_dir(AVIODirContext** s, [MarshalAs(UnmanagedType.LPStr)] string url, AVDictionary** options);

		/// <summary>
		/// Open a write only memory stream.
		/// </summary>
		/// <param name="s">new IO context</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_open_dyn_buf(AVIOContext** s);

		/// <summary>
		/// Create and initialize a AVIOContext for accessing the resource indicated by url.
		/// </summary>
		/// <param name="s">Used to return the pointer to the created AVIOContext. In case of failure the pointed to value is set to NULL.</param>
		/// <param name="url">resource to access</param>
		/// <param name="flags">flags which control how the resource indicated by url is to be opened</param>
		/// <param name="int_cb">an interrupt callback to be used at the protocols level</param>
		/// <param name="options">A dictionary filled with protocol-private options. On return this parameter will be destroyed and replaced with a dict containing options that were not found. May be NULL.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_open2(AVIOContext** s, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options);

		/// <summary>
		/// Pause and resume playing - only meaningful if using a network streaming protocol (e.g. MMS).
		/// </summary>
		/// <param name="h">IO context from which to call the read_pause function pointer</param>
		/// <param name="pause">1 for pause, 0 for resume</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_pause(AVIOContext* h, int pause);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_printf(AVIOContext* s, [MarshalAs(UnmanagedType.LPStr)] string fmt);

		/// <summary>
		/// Write a NULL-terminated string.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_put_str(AVIOContext* s, [MarshalAs(UnmanagedType.LPStr)] string str);

		/// <summary>
		/// Convert an UTF-8 string to UTF-16BE and write it.
		/// </summary>
		/// <param name="s">the AVIOContext</param>
		/// <param name="str">NULL-terminated UTF-8 string</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_put_str16be(AVIOContext* s, [MarshalAs(UnmanagedType.LPStr)] string str);

		/// <summary>
		/// Convert an UTF-8 string to UTF-16LE and write it.
		/// </summary>
		/// <param name="s">the AVIOContext</param>
		/// <param name="str">NULL-terminated UTF-8 string</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_put_str16le(AVIOContext* s, [MarshalAs(UnmanagedType.LPStr)] string str);

		/// <summary>
		/// @{
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_r8(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rb16(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rb24(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rb32(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static ulong avio_rb64(AVIOContext* s);

		/// <summary>
		/// Read size bytes from AVIOContext into buf.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_read(AVIOContext* s, byte* buf, int size);

		/// <summary>
		/// Get next directory entry.
		/// </summary>
		/// <param name="s">directory read context.</param>
		/// <param name="next">next entry or NULL when no more entries.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_read_dir(AVIODirContext* s, AVIODirEntry** next);

		/// <summary>
		/// Read size bytes from AVIOContext into buf. Unlike avio_read(), this is allowed to read fewer bytes than requested. The missing bytes can be read in the next call. This always tries to read at least 1 byte. Useful to reduce latency in certain cases.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_read_partial(AVIOContext* s, byte* buf, int size);

		/// <summary>
		/// Read contents of h into print buffer, up to max_size bytes, or up to EOF.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avio_read_to_bprint(AVIOContext* h, AVBPrint* pb, IntPtr max_size);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rl16(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rl24(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static uint avio_rl32(AVIOContext* s);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static ulong avio_rl64(AVIOContext* s);

		/// <summary>
		/// fseek() equivalent for AVIOContext.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static long avio_seek(AVIOContext* s, long offset, int whence);

		/// <summary>
		/// Seek to a given timestamp relative to some component stream. Only meaningful if using a network streaming protocol (e.g. MMS.).
		/// </summary>
		/// <param name="h">IO context from which to call the seek function pointers</param>
		/// <param name="stream_index">The stream index that the timestamp is relative to. If stream_index is (-1) the timestamp should be in AV_TIME_BASE units from the beginning of the presentation. If a stream_index &gt;= 0 is used and the protocol does not support seeking based on component streams, the call will fail.</param>
		/// <param name="timestamp">timestamp in AVStream.time_base units or if there is no stream specified then in AV_TIME_BASE units.</param>
		/// <param name="flags">Optional combination of AVSEEK_FLAG_BACKWARD, AVSEEK_FLAG_BYTE and AVSEEK_FLAG_ANY. The protocol may silently ignore AVSEEK_FLAG_BACKWARD and AVSEEK_FLAG_ANY, but AVSEEK_FLAG_BYTE will fail if used and not supported.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static long avio_seek_time(AVIOContext* h, int stream_index, long timestamp, int flags);

		/// <summary>
		/// Get the filesize.
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static long avio_size(AVIOContext* s);

		/// <summary>
		/// Skip given number of bytes forward
		/// </summary>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static long avio_skip(AVIOContext* s, long offset);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_w8(AVIOContext* s, int b);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wb16(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wb24(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wb32(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wb64(AVIOContext* s, ulong val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wl16(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wl24(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wl32(AVIOContext* s, uint val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_wl64(AVIOContext* s, ulong val);

		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_write(AVIOContext* s, byte* buf, int size);

		/// <summary>
		/// Mark the written bytestream as a specific type.
		/// </summary>
		/// <param name="time">the stream time the current bytestream pos corresponds to (in AV_TIME_BASE units), or AV_NOPTS_VALUE if unknown or not applicable</param>
		/// <param name="type">the kind of data written starting at the current pos</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static void avio_write_marker(AVIOContext* s, long time, AVIODataMarkerType type);

		/// <summary>
		/// Delete a resource.
		/// </summary>
		/// <param name="url">resource to be deleted.</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avpriv_io_delete([MarshalAs(UnmanagedType.LPStr)] string url);

		/// <summary>
		/// Move or rename a resource.
		/// </summary>
		/// <param name="url_src">url to resource to be moved</param>
		/// <param name="url_dst">new url to resource if the operation succeeded</param>
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		public extern static int avpriv_io_move([MarshalAs(UnmanagedType.LPStr)] string url_src, [MarshalAs(UnmanagedType.LPStr)] string url_dst);

	}
#pragma warning restore IDE1006 // 命名样式
}
