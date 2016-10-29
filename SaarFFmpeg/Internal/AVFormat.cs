using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Structs;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Saar.FFmpeg.Internal {
	unsafe public static partial class FFmpeg {
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_register_all();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVStream* avformat_new_stream(AVFormatContext* s, AVCodec* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_register_input_format(AVInputFormat* format);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_register_output_format(AVOutputFormat* format);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_stream_new_side_data(AVStream* stream, AVPacketSideDataType type, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_stream_get_side_data(AVStream* stream, AVPacketSideDataType type, int* size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avformat_version();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avformat_configuration();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avformat_license();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_network_init();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_network_deinit();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVInputFormat* av_iformat_next(AVInputFormat* f);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOutputFormat* av_oformat_next(AVOutputFormat* f);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVFormatContext* avformat_alloc_context();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avformat_free_context(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* avformat_get_class();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVProgram* av_new_program(AVFormatContext* s, int id);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_alloc_output_context2(ref AVFormatContext* ctx, AVOutputFormat* oformat, string format_name, string filename);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVInputFormat* av_find_input_format(byte* short_name);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVInputFormat* av_probe_input_format(AVProbeData* pd, int is_opened);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVInputFormat* av_probe_input_format2(AVProbeData* pd, int is_opened, int* score_max);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVInputFormat* av_probe_input_format3(AVProbeData* pd, int is_opened, int* score_ret);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_probe_input_buffer2(AVIOContext* pb, AVInputFormat** fmt, byte* url, void* logctx, uint offset, uint max_probe_size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_probe_input_buffer(AVIOContext* pb, AVInputFormat** fmt, byte* url, void* logctx, uint offset, uint max_probe_size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_open_input(AVFormatContext** ps, string url, AVInputFormat* fmt, AVDictionary** options);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_demuxer_open(AVFormatContext* ic);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_find_stream_info(AVFormatContext* ic, AVDictionary** options);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVProgram* av_find_program_from_stream(AVFormatContext* ic, AVProgram* last, int s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_program_add_stream_index(AVFormatContext* ac, int progid, uint idx);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_find_best_stream(AVFormatContext* ic, AVMediaType type, int wanted_stream_nb, int related_stream, AVCodec** decoder_ret, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_read_frame(AVFormatContext* s, AVPacket* pkt);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_seek_frame(AVFormatContext* s, int stream_index, long timestamp, AVSeekFlag flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_seek_file(AVFormatContext* s, int stream_index, long min_ts, long ts, long max_ts, AVSeekFlag flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_flush(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_read_play(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_read_pause(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avformat_close_input(ref AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_write_header(AVFormatContext* s, AVDictionary** options);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_write_frame(AVFormatContext* s, AVPacket* pkt);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_interleaved_write_frame(AVFormatContext* s, AVPacket* pkt);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_interleaved_write_uncoded_frame(AVFormatContext* s, int stream_index, AVFrame* frame);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_write_uncoded_frame_query(AVFormatContext* s, int stream_index);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_write_trailer(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOutputFormat* av_guess_format(byte* short_name, byte* filename, byte* mime_type);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOutputFormat* av_guess_format(string short_name, string filename, string mime_type);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecID av_guess_codec(AVOutputFormat* fmt, string short_name, string filename, string mime_type, AVMediaType type);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_output_timestamp(AVFormatContext* s, int stream, long* dts, long* wall);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_hex_dump(IntPtr fileHandle, byte* buf, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_hex_dump_log(void* avcl, int level, byte* buf, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_pkt_dump2(IntPtr fileHandle, AVPacket* pkt, int dump_payload, AVStream* st);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_pkt_dump_log2(void* avcl, int level, AVPacket* pkt, int dump_payload, AVStream* st);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecID av_codec_get_id(AVCodecTag** tags, uint tag);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint av_codec_get_tag(AVCodecTag** tags, AVCodecID id);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_codec_get_tag2(AVCodecTag** tags, AVCodecID id, uint* tag);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_find_default_stream_index(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_index_search_timestamp(AVStream* st, long timestamp, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_add_index_entry(AVStream* st, long pos, long timestamp, int size, int distance, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_url_split(byte* proto, int proto_size, byte* authorization, int authorization_size, byte* hostname, int hostname_size, int* port_ptr, byte* path, int path_size, byte* url);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_dump_format(AVFormatContext* ic, int index, string url, bool is_output);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_frame_filename2(byte* buf, int buf_size, byte* path, int number, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_frame_filename(byte* buf, int buf_size, byte* path, int number);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_filename_number_test(byte* filename);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_sdp_create(AVFormatContext* ac, int n_files, byte* buf, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_match_ext(byte* filename, byte* extensions);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_query_codec(AVOutputFormat* ofmt, AVCodecID codec_id, int std_compliance);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avformat_get_riff_video_tags();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avformat_get_riff_audio_tags();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avformat_get_mov_video_tags();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avformat_get_mov_audio_tags();
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVRational av_guess_sample_aspect_ratio(AVFormatContext* format, AVStream* stream, AVFrame* frame);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVRational av_guess_frame_rate(AVFormatContext* ctx, AVStream* stream, AVFrame* frame);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_match_stream_specifier(AVFormatContext* s, AVStream* st, byte* spec);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avformat_queue_attached_pictures(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_apply_bitstream_filters(AVCodecContext* codec, AVPacket* pkt, AVBitStreamFilterContext* bsfc);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_format_get_probe_score(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* av_format_get_video_codec(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_video_codec(AVFormatContext* s, AVCodec* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* av_format_get_audio_codec(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_audio_codec(AVFormatContext* s, AVCodec* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* av_format_get_subtitle_codec(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_subtitle_codec(AVFormatContext* s, AVCodec* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* av_format_get_data_codec(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_data_codec(AVFormatContext* s, AVCodec* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_format_get_metadata_header_padding(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_metadata_header_padding(AVFormatContext* s, int c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_format_get_opaque(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_opaque(AVFormatContext* s, void* opaque);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_format_get_control_message_cb(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_control_message_cb(AVFormatContext* s, IntPtr callback);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_format_get_open_cb(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_set_open_cb(AVFormatContext* s, IntPtr callback);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_format_inject_global_side_data(AVFormatContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVDurationEstimationMethod av_fmt_ctx_get_duration_estimation_method(AVFormatContext* ctx);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avio_find_protocol_name(byte* url);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_check(byte* url, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpriv_io_move(byte* url_src, byte* url_dst);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpriv_io_delete(byte* url);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_open_dir(AVIODirContext** s, byte* url, AVDictionary** options);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_read_dir(AVIODirContext* s, AVIODirEntry** next);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_close_dir(AVIODirContext** s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_free_directory_entry(AVIODirEntry** entry);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVIOContext* avio_alloc_context(byte* buffer, int buffer_size, bool write_flag, void* opaque, Delegates.IOBufferDelegate readCallback, Delegates.IOBufferDelegate writeCallback, Delegates.SeekBufferDelegate seekCallback);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_w8(AVIOContext* s, int b);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_write(AVIOContext* s, byte* buf, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wl64(AVIOContext* s, ulong val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wb64(AVIOContext* s, ulong val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wl32(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wb32(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wl24(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wb24(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wl16(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_wb16(AVIOContext* s, uint val);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_put_str(AVIOContext* s, byte* str);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_put_str16le(AVIOContext* s, byte* str);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_put_str16be(AVIOContext* s, byte* str);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_write_marker(AVIOContext* s, long time, AVIODataMarkerType type);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long avio_seek(AVIOContext* s, long offset, int whence);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long avio_skip(AVIOContext* s, long offset);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long avio_size(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_feof(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int url_feof(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avio_flush(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_read(AVIOContext* s, byte* buf, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_r8(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rl16(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rl24(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rl32(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern ulong avio_rl64(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rb16(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rb24(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avio_rb32(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern ulong avio_rb64(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_get_str(AVIOContext* pb, int maxlen, byte* buf, int buflen);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_get_str16le(AVIOContext* pb, int maxlen, byte* buf, int buflen);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_get_str16be(AVIOContext* pb, int maxlen, byte* buf, int buflen);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_open(AVIOContext** s, byte* url, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_open2(AVIOContext** s, byte* url, int flags, AVIOInterruptCB* int_cb, AVDictionary** options);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_close(AVIOContext* s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_closep(AVIOContext** s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_open_dyn_buf(AVIOContext** s);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_close_dyn_buf(AVIOContext* s, byte** pbuffer);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avio__protocols(void** opaque, int output);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_pause(AVIOContext* h, int pause);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long avio_seek_time(AVIOContext* h, int stream_index, long timestamp, int flags);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_read_to_bprint(AVIOContext* h, IntPtr pb, IntPtr max_size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_accept(AVIOContext* s, AVIOContext** c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avio_handshake(AVIOContext* c);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_packet(AVIOContext* s, AVPacket* pkt, int size);
		[DllImport(Dll_AVFormat, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_append_packet(AVIOContext* s, AVPacket* pkt, int size);
	}
}
