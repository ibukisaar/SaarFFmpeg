using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Saar.FFmpeg.Internal {
	unsafe public static partial class FFmpeg {
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern uint avutil_version();
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_version_info();
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avutil_configuration();
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* avutil_license();
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_show2(void* obj, void* av_log_obj, int req_flags, int rej_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_opt_set_defaults(void* s);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_opt_set_defaults2(void* s, int mask, int flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_set_options_string(void* ctx, byte* opts, byte* key_val_sep, byte* pairs_sep);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_from_string(void* ctx, byte* opts, byte** shorthand, byte* key_val_sep, byte* pairs_sep);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_opt_free(void* obj);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_flag_is_set(void* obj, byte* field_name, byte* flag_name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_dict(void* obj, AVDictionary** options);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_dict2(void* obj, AVDictionary** options, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_key_value(byte** ropts, byte* key_val_sep, byte* pairs_sep, uint flags, byte** rkey, byte** rval);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_flags(void* obj, AVOption* o, byte* val, int* flags_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_int(void* obj, AVOption* o, byte* val, int* int_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_int64(void* obj, AVOption* o, byte* val, long* int64_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_float(void* obj, AVOption* o, byte* val, float* float_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_double(void* obj, AVOption* o, byte* val, double* double_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_eval_q(void* obj, AVOption* o, byte* val, AVRational* q_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOption* av_opt_find(void* obj, byte* name, byte* unit, int opt_flags, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOption* av_opt_find2(void* obj, byte* name, byte* unit, int opt_flags, int search_flags, void** target_obj);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVOption* av_opt_next(void* obj, AVOption* prev);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_opt_child_next(void* obj, void* prev);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVClass* av_opt_child_class_next(AVClass* parent, AVClass* prev);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set(void* obj, byte* name, byte* val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_int(void* obj, byte* name, long val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_double(void* obj, byte* name, double val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_q(void* obj, byte* name, AVRational val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_bin(void* obj, byte* name, byte* val, int size, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_image_size(void* obj, byte* name, int w, int h, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_pixel_fmt(void* obj, byte* name, AVPixelFormat fmt, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_sample_fmt(void* obj, byte* name, AVSampleFormat fmt, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_video_rate(void* obj, byte* name, AVRational val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_channel_layout(void* obj, byte* name, long ch_layout, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_set_dict_val(void* obj, byte* name, AVDictionary* val, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get(void* obj, byte* name, int search_flags, byte** out_val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_int(void* obj, byte* name, int search_flags, long* out_val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_double(void* obj, byte* name, int search_flags, double* out_val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_q(void* obj, byte* name, int search_flags, AVRational* out_val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_image_size(void* obj, byte* name, int search_flags, int* w_out, int* h_out);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_pixel_fmt(void* obj, byte* name, int search_flags, AVPixelFormat* out_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_sample_fmt(void* obj, byte* name, int search_flags, AVSampleFormat* out_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_video_rate(void* obj, byte* name, int search_flags, AVRational* out_val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_channel_layout(void* obj, byte* name, int search_flags, long* ch_layout);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_get_dict_val(void* obj, byte* name, int search_flags, AVDictionary** outVal);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_opt_ptr(AVClass* avclass, void* obj, byte* name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_opt_freep_ranges(AVOptionRanges** ranges);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_query_ranges(void* obj, byte* key, int flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_copy(void* dest, void* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_query_ranges_default(void* obj, byte* key, int flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_is_set_to_default(void* obj, AVOption* o);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_is_set_to_default_by_name(void* obj, byte* name, int search_flags);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_opt_serialize(void* obj, int opt_flags, int flags, byte** buffer, byte key_val_sep, byte pairs_sep);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_malloc(IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_mallocz(IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_calloc(IntPtr nmemb, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_realloc(void* ptr, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_reallocp(void* ptr, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_realloc_f(void* ptr, IntPtr nelem, IntPtr elsize);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_realloc_array(void* ptr, IntPtr nmemb, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_reallocp_array(void* ptr, IntPtr nmemb, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_fast_realloc(void* ptr, uint* size, IntPtr min_size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_fast_realloc(IntPtr ptr, ref int size, IntPtr min_size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_fast_malloc(void* ptr, uint* size, IntPtr min_size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_fast_mallocz(void* ptr, uint* size, IntPtr min_size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_free(void* ptr);
		public static void av_freep(void* ptr) {
			av_free(*(void**) ptr);
			*(void**) ptr = null;
		}
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_strdup(byte* s);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_strndup(byte* s, IntPtr len);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_memdup(void* p, IntPtr size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_memcpy_backptr(byte* dst, int back, int cnt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_dynarray_add(void* tab_ptr, int* nb_ptr, void* elem);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_dynarray_add_nofree(void* tab_ptr, int* nb_ptr, void* elem);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void* av_dynarray2_add(void** tab_ptr, int* nb_ptr, IntPtr elem_size, byte* elem_data);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_max_alloc(IntPtr max);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVChannelLayout av_get_channel_layout(byte* name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_get_channel_layout_string(byte* buf, int buf_size, int nb_channels, AVChannelLayout channel_layout);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_channel_layout_nb_channels(AVChannelLayout channel_layout);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVChannelLayout av_get_default_channel_layout(int nb_channels);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_channel_layout_channel_index(AVChannelLayout channel_layout, AVChannelLayout channel);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVChannelLayout av_channel_layout_extract_channel(AVChannelLayout channel_layout, int index);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_channel_name(AVChannelLayout channel);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_channel_description(AVChannelLayout channel);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_standard_channel_layout(uint index, AVChannelLayout* layout, byte** name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_sample_fmt_name(AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVSampleFormat av_get_sample_fmt(byte* name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVSampleFormat av_get_alt_sample_fmt(AVSampleFormat sample_fmt, int planar);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVSampleFormat av_get_packed_sample_fmt(AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVSampleFormat av_get_planar_sample_fmt(AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_sample_fmt_string(byte* buf, int buf_size, AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_bytes_per_sample(AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_sample_fmt_is_planar(AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_get_buffer_size(int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_get_buffer_size(ref int linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_fill_arrays(byte** audio_data, int* linesize, byte* buf, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_fill_arrays(IntPtr[] audio_data, ref int linesize, IntPtr buf, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_fill_arrays(IntPtr[] audio_data, int* linesize, IntPtr buf, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_alloc(byte** audio_data, int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_alloc_array_and_samples(byte*** audio_data, int* linesize, int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_copy(byte** dst, byte** src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_copy(IntPtr[] dst, IntPtr* src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_copy(IntPtr[] dst, IntPtr[] src, int dst_offset, int src_offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_samples_set_silence(byte** audio_data, int offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_strerror(int error_num, StringBuilder buffer, IntPtr buffer_size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_gcd(long a, long b);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_rescale(long a, long b, long c);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_rescale_rnd(long a, long b, long c, AVRounding rnd);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_rescale_q(long a, AVRational bq, AVRational cq);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_rescale_q_rnd(long a, AVRational bq, AVRational cq, AVRounding rnd);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_compare_ts(long ts_a, AVRational tb_a, long ts_b, AVRational tb_b);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_compare_mod(ulong a, ulong b, ulong mod);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_rescale_delta(AVRational in_tb, long in_ts, AVRational fs_tb, int duration, long* last, AVRational out_tb);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_add_stable(AVRational ts_tb, long ts, AVRational inc_tb, long inc);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_frame_get_best_effort_timestamp(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_best_effort_timestamp(AVFrame* frame, long val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_frame_get_pkt_duration(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_pkt_duration(AVFrame* frame, long val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_frame_get_pkt_pos(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_pkt_pos(AVFrame* frame, long val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern long av_frame_get_channel_layout(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_channel_layout(AVFrame* frame, long val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_get_channels(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_channels(AVFrame* frame, int val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_get_sample_rate(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_sample_rate(AVFrame* frame, int val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVDictionary* av_frame_get_metadata(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_metadata(AVFrame* frame, AVDictionary* val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_get_decode_error_flags(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_decode_error_flags(AVFrame* frame, int val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_get_pkt_size(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_pkt_size(AVFrame* frame, int val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVDictionary** avpriv_frame_get_metadatap(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern sbyte* av_frame_get_qp_table(AVFrame* f, int* stride, int* type);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_set_qp_table(AVFrame* f, AVBufferRef* buf, int stride, int type);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVColorSpace av_frame_get_colorspace(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_colorspace(AVFrame* frame, AVColorSpace val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVColorRange av_frame_get_color_range(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_set_color_range(AVFrame* frame, AVColorRange val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_colorspace_name(AVColorSpace val);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVFrame* av_frame_alloc();
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_free(ref AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_ref(AVFrame* dst, AVFrame* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVFrame* av_frame_clone(AVFrame* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_unref(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_move_ref(AVFrame* dst, AVFrame* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_get_buffer(AVFrame* frame, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_is_writable(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_make_writable(AVFrame* frame);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_copy(AVFrame* dst, AVFrame* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_frame_copy_props(AVFrame* dst, AVFrame* src);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVBufferRef* av_frame_get_plane_buffer(AVFrame* frame, int plane);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVFrameSideData* av_frame_new_side_data(AVFrame* frame, AVFrameSideDataType type, int size);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVFrameSideData* av_frame_get_side_data(AVFrame* frame, AVFrameSideDataType type);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_frame_remove_side_data(AVFrame* frame, AVFrameSideDataType type);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_frame_side_data_name(AVFrameSideDataType type);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_read_image_line(ushort* dst, byte** data_Array4, int* linesize_Array4, AVPixFmtDescriptor* desc, int x, int y, int c, int w, int read_pal_component);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_write_image_line(ushort* src, byte** data_Array4, int* linesize_Array4, AVPixFmtDescriptor* desc, int x, int y, int c, int w);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat av_get_pix_fmt(byte* name);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_pix_fmt_name(AVPixelFormat pix_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_get_pix_fmt_string(byte* buf, int buf_size, AVPixelFormat pix_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_bits_per_pixel(AVPixFmtDescriptor* pixdesc);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_padded_bits_per_pixel(AVPixFmtDescriptor* pixdesc);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixFmtDescriptor* av_pix_fmt_desc_get(AVPixelFormat pix_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixFmtDescriptor* av_pix_fmt_desc_next(AVPixFmtDescriptor* prev);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat av_pix_fmt_desc_get_id(AVPixFmtDescriptor* desc);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_pix_fmt_get_chroma_sub_sample(AVPixelFormat pix_fmt, int* h_shift, int* v_shift);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_pix_fmt_count_planes(AVPixelFormat pix_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat av_pix_fmt_swap_endianness(AVPixelFormat pix_fmt);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_get_pix_fmt_loss(AVPixelFormat dst_pix_fmt, AVPixelFormat src_pix_fmt, int has_alpha);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern AVPixelFormat av_find_best_pix_fmt_of_2(AVPixelFormat dst_pix_fmt1, AVPixelFormat dst_pix_fmt2, AVPixelFormat src_pix_fmt, int has_alpha, int* loss_ptr);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_color_range_name(AVColorRange range);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_color_primaries_name(AVColorPrimaries primaries);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_color_transfer_name(AVColorTransferCharacteristic transfer);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_color_space_name(AVColorSpace space);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern byte* av_chroma_location_name(AVChromaLocation location);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_image_fill_max_pixsteps(int* max_pixsteps_Array4, int* max_pixstep_comps_Array4, AVPixFmtDescriptor* pixdesc);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_get_linesize(AVPixelFormat pix_fmt, int width, int plane);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_fill_linesizes(int* linesizes_Array4, AVPixelFormat pix_fmt, int width);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_fill_pointers(byte** data_Array4, AVPixelFormat pix_fmt, int height, byte* ptr, int* linesizes_Array4);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_alloc(byte** pointers_Array4, int* linesizes_Array4, int w, int h, AVPixelFormat pix_fmt, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_image_copy_plane(byte* dst, int dst_linesize, byte* src, int src_linesize, int bytewidth, int height);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern void av_image_copy(byte** dst_data_Array4, int* dst_linesizes_Array4, byte** src_data_Array4, int* src_linesizes_Array4, AVPixelFormat pix_fmt, int width, int height);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_fill_arrays(byte** dst_data_Array4, int* dst_linesize_Array4, byte* src, AVPixelFormat pix_fmt, int width, int height, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_get_buffer_size(AVPixelFormat pix_fmt, int width, int height, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_copy_to_buffer(byte* dst, int dst_size, byte** src_data_Array4, int* src_linesize_Array4, AVPixelFormat pix_fmt, int width, int height, int align);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_check_size(uint w, uint h, int log_offset, void* log_ctx);
		[DllImport(Dll_AVUtil, CallingConvention = Convention)]
		[SuppressUnmanagedCodeSecurity]
		public static extern int av_image_check_sar(uint w, uint h, AVRational sar);
	}
}
