using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Enumerates;
using System.Security;

namespace Saar.FFmpeg.Internal {
	unsafe public static partial class FFmpeg {
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* av_codec_next(AVCodec* c);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avcodec_version();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avcodec_configuration();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avcodec_license();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_register(AVCodec* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_register_all();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecContext* avcodec_alloc_context3(AVCodec* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_free_context(AVCodecContext** avctx);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_get_context_defaults3(AVCodecContext* s, AVCodec* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* avcodec_get_class();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* avcodec_get_frame_class();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* avcodec_get_subtitle_rect_class();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_copy_context(AVCodecContext* dest, AVCodecContext* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecParameters* avcodec_parameters_alloc();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_parameters_free(AVCodecParameters** par);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_parameters_copy(AVCodecParameters* dst, AVCodecParameters* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_parameters_from_context(AVCodecParameters* par, AVCodecContext* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_parameters_to_context(AVCodecContext* codec, AVCodecParameters* par);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_open2(AVCodecContext* avctx, AVCodec* codec, AVDictionary** options);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_close(AVCodecContext* avctx);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avsubtitle_free(AVSubtitle* sub);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPacket* av_packet_alloc();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPacket* av_packet_clone(AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_packet_free(ref AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_init_packet(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_new_packet(AVPacket* pkt, int size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_shrink_packet(AVPacket* pkt, int size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_grow_packet(AVPacket* pkt, int grow_by);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_from_data(AVPacket* pkt, byte* data, int size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_dup_packet(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_copy_packet(AVPacket* dst, AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_copy_packet_side_data(AVPacket* dst, AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_free_packet(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_packet_new_side_data(AVPacket* pkt, AVPacketSideDataType type, int size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_add_side_data(AVPacket* pkt, AVPacketSideDataType type, byte* data, IntPtr size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_shrink_side_data(AVPacket* pkt, AVPacketSideDataType type, int size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_packet_get_side_data(AVPacket* pkt, AVPacketSideDataType type, int* size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_merge_side_data(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_split_side_data(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_packet_side_data_name(AVPacketSideDataType type);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_packet_pack_dictionary(AVDictionary* dict, int* size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_unpack_dictionary(byte* data, int size, AVDictionary** dict);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_packet_free_side_data(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_ref(AVPacket* dst, AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_packet_unref(AVPacket* pkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_packet_move_ref(AVPacket* dst, AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_packet_copy_props(AVPacket* dst, AVPacket* src);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_packet_rescale_ts(AVPacket* pkt, AVRational tb_src, AVRational tb_dst);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* avcodec_find_decoder(AVCodecID id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* avcodec_find_decoder_by_name(byte* name);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_default_get_buffer2(AVCodecContext* s, AVFrame* frame, int flags);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avcodec_get_edge_width();
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_align_dimensions(AVCodecContext* s, int* width, int* height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_align_dimensions2(AVCodecContext* s, int* width, int* height, int linesize_align);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec__to_chroma_pos(int* xpos, int* ypos, AVChromaLocation pos);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVChromaLocation avcodec_chroma_pos_to_(int xpos, int ypos);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_audio4(AVCodecContext* avctx, AVFrame* frame, int* got_frame_ptr, AVPacket* avpkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_video2(AVCodecContext* avctx, AVFrame* picture, int* got_picture_ptr, AVPacket* avpkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_subtitle2(AVCodecContext* avctx, AVSubtitle* sub, int* got_sub_ptr, AVPacket* avpkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_send_packet(AVCodecContext* avctx, AVPacket* avpkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_receive_frame(AVCodecContext* avctx, AVFrame* frame);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_send_frame(AVCodecContext* avctx, AVFrame* frame);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_receive_packet(AVCodecContext* avctx, AVPacket* avpkt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecParser* av_parser_next(AVCodecParser* c);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_register_codec_parser(AVCodecParser* parser);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecParserContext* av_parser_init(int codec_id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_parser_parse2(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size, long pts, long dts, long pos);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_parser_change(AVCodecParserContext* s, AVCodecContext* avctx, byte** poutbuf, int* poutbuf_size, byte* buf, int buf_size, int keyframe);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_parser_close(AVCodecParserContext* s);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* avcodec_find_encoder(AVCodecID id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodec* avcodec_find_encoder_by_name(byte* name);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_audio2(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_video2(AVCodecContext* avctx, AVPacket* avpkt, AVFrame* frame, int* got_packet_ptr);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_subtitle(AVCodecContext* avctx, byte* buf, int buf_size, AVSubtitle* sub);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern ReSampleContext* av_audio_resample_init(int output_channels, int input_channels, int output_rate, int input_rate, AVSampleFormat sample_fmt_out, AVSampleFormat sample_fmt_in, int filter_length, int log2_phase_count, int linear, double cutoff);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int audio_resample(ReSampleContext* s, short* output, short* input, int nb_samples);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void audio_resample_close(ReSampleContext* s);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVResampleContext* av_resample_init(int out_rate, int in_rate, int filter_length, int log2_phase_count, int linear, double cutoff);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_resample(AVResampleContext* c, short* dst, short* src, int* consumed, int src_size, int dst_size, int update_ctx);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_resample_compensate(AVResampleContext* c, int sample_delta, int compensation_distance);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_resample_close(AVResampleContext* c);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_alloc(AVPicture* picture, AVPixelFormat pix_fmt, int width, int height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avpicture_free(AVPicture* picture);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_fill(AVPicture* picture, byte* ptr, AVPixelFormat pix_fmt, int width, int height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_layout(AVPicture* src, AVPixelFormat pix_fmt, int width, int height, byte* dest, int dest_size);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_get_size(AVPixelFormat pix_fmt, int width, int height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_picture_copy(AVPicture* dst, AVPicture* src, AVPixelFormat pix_fmt, int width, int height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_picture_crop(AVPicture* dst, AVPicture* src, AVPixelFormat pix_fmt, int top_band, int left_band);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_picture_pad(AVPicture* dst, AVPicture* src, int height, int width, AVPixelFormat pix_fmt, int padtop, int padbottom, int padleft, int padright, int* color);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_get_chroma_sub_sample(AVPixelFormat pix_fmt, int* h_shift, int* v_shift);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avcodec_pix_fmt_to_codec_tag(AVPixelFormat pix_fmt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_get_pix_fmt_loss(AVPixelFormat dst_pix_fmt, AVPixelFormat src_pix_fmt, int has_alpha);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat avcodec_find_best_pix_fmt_of_list(AVPixelFormat* pix_fmt_list, AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat avcodec_find_best_pix_fmt_of_2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat avcodec_find_best_pix_fmt2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat avcodec_default_get_format(AVCodecContext* s, AVPixelFormat* fmt);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_set_dimensions(AVCodecContext* s, int width, int height);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_get_codec_tag_string(byte* buf, IntPtr buf_size, uint codec_tag);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_string(byte* buf, int buf_size, AVCodecContext* enc, int encode);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_profile_name(AVCodec* codec, int profile);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avcodec_profile_name(AVCodecID codec_id, int profile);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_default_execute(AVCodecContext* c);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_default_execute2(AVCodecContext* c);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_fill_audio_frame(AVFrame* frame, int nb_channels, AVSampleFormat sample_fmt, byte* buf, int buf_size, int align);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_flush_buffers(AVCodecContext* avctx);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_bits_per_sample(AVCodecID codec_id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecID av_get_pcm_codec(AVSampleFormat fmt, int be);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_exact_bits_per_sample(AVCodecID codec_id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_audio_frame_duration(AVCodecContext* avctx, int frame_bytes);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_audio_frame_duration2(AVCodecParameters* par, int frame_bytes);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVMediaType avcodec_get_type(AVCodecID codec_id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avcodec_get_name(AVCodecID id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_is_open(AVCodecContext* s);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_codec_is_encoder(AVCodec* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_codec_is_decoder(AVCodec* codec);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecDescriptor* avcodec_descriptor_get(AVCodecID id);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecDescriptor* avcodec_descriptor_next(AVCodecDescriptor* prev);
		[DllImport(Dll_AVCodec, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVCodecDescriptor* avcodec_descriptor_get_by_name(byte* name);
	}
}
