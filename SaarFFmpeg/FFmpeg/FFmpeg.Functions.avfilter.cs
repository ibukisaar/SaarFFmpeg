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
        /// <summary>
        /// Create an AVABufferSinkParams structure.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVABufferSinkParams* av_abuffersink_params_alloc();
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static ulong av_buffersink_get_channel_layout(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_channels(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_format(AVFilterContext* ctx);
        
        /// <summary>
        /// Get a frame with filtered data from sink and put it in frame.
        /// </summary>
        /// <param name="ctx">pointer to a context of a buffersink or abuffersink AVFilter.</param>
        /// <param name="frame">pointer to an allocated frame that will be filled with data. The data must be freed using av_frame_unref() / av_frame_free()</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_frame(AVFilterContext* ctx, AVFrame* frame);
        
        /// <summary>
        /// Get a frame with filtered data from sink and put it in frame.
        /// </summary>
        /// <param name="ctx">pointer to a buffersink or abuffersink filter context.</param>
        /// <param name="frame">pointer to an allocated frame that will be filled with data. The data must be freed using av_frame_unref() / av_frame_free()</param>
        /// <param name="flags">a combination of AV_BUFFERSINK_FLAG_* flags</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_frame_flags(AVFilterContext* ctx, AVFrame* frame, int flags);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVRational av_buffersink_get_frame_rate(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_h(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVBufferRef* av_buffersink_get_hw_frames_ctx(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVRational av_buffersink_get_sample_aspect_ratio(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_sample_rate(AVFilterContext* ctx);
        
        /// <summary>
        /// Same as av_buffersink_get_frame(), but with the ability to specify the number of samples read. This function is less efficient than av_buffersink_get_frame(), because it copies the data around.
        /// </summary>
        /// <param name="ctx">pointer to a context of the abuffersink AVFilter.</param>
        /// <param name="frame">pointer to an allocated frame that will be filled with data. The data must be freed using av_frame_unref() / av_frame_free() frame will contain exactly nb_samples audio samples, except at the end of stream, when it can contain less than nb_samples.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_samples(AVFilterContext* ctx, AVFrame* frame, int nb_samples);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVRational av_buffersink_get_time_base(AVFilterContext* ctx);
        
        /// <summary>
        /// Get the properties of the stream @{
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVMediaType av_buffersink_get_type(AVFilterContext* ctx);
        
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersink_get_w(AVFilterContext* ctx);
        
        /// <summary>
        /// Create an AVBufferSinkParams structure.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVBufferSinkParams* av_buffersink_params_alloc();
        
        /// <summary>
        /// Set the frame size for an audio buffer sink.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void av_buffersink_set_frame_size(AVFilterContext* ctx, uint frame_size);
        
        /// <summary>
        /// Add a frame to the buffer source.
        /// </summary>
        /// <param name="ctx">an instance of the buffersrc filter</param>
        /// <param name="frame">frame to be added. If the frame is reference counted, this function will take ownership of the reference(s) and reset the frame. Otherwise the frame data will be copied. If this function returns an error, the input frame is not touched.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersrc_add_frame(AVFilterContext* ctx, AVFrame* frame);
        
        /// <summary>
        /// Add a frame to the buffer source.
        /// </summary>
        /// <param name="buffer_src">pointer to a buffer source context</param>
        /// <param name="frame">a frame, or NULL to mark EOF</param>
        /// <param name="flags">a combination of AV_BUFFERSRC_FLAG_*</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersrc_add_frame_flags(AVFilterContext* buffer_src, AVFrame* frame, int flags);
        
        /// <summary>
        /// Close the buffer source after EOF.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersrc_close(AVFilterContext* ctx, long pts, uint flags);
        
        /// <summary>
        /// Get the number of failed requests.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static uint av_buffersrc_get_nb_failed_requests(AVFilterContext* buffer_src);
        
        /// <summary>
        /// Allocate a new AVBufferSrcParameters instance. It should be freed by the caller with av_free().
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVBufferSrcParameters* av_buffersrc_parameters_alloc();
        
        /// <summary>
        /// Initialize the buffersrc or abuffersrc filter with the provided parameters. This function may be called multiple times, the later calls override the previous ones. Some of the parameters may also be set through AVOptions, then whatever method is used last takes precedence.
        /// </summary>
        /// <param name="ctx">an instance of the buffersrc or abuffersrc filter</param>
        /// <param name="param">the stream parameters. The frames later passed to this filter must conform to those parameters. All the allocated fields in param remain owned by the caller, libavfilter will make internal copies or references when necessary.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersrc_parameters_set(AVFilterContext* ctx, AVBufferSrcParameters* param);
        
        /// <summary>
        /// Add a frame to the buffer source.
        /// </summary>
        /// <param name="ctx">an instance of the buffersrc filter</param>
        /// <param name="frame">frame to be added. If the frame is reference counted, this function will make a new reference to it. Otherwise the frame data will be copied.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int av_buffersrc_write_frame(AVFilterContext* ctx, AVFrame* frame);
        
        /// <summary>
        /// Iterate over all registered filters.
        /// </summary>
        /// <param name="opaque">a pointer where libavfilter will store the iteration state. Must point to NULL to start the iteration.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilter* av_filter_iterate(void** opaque);
        
        /// <summary>
        /// Negotiate the media format, dimensions, etc of all inputs to a filter.
        /// </summary>
        /// <param name="filter">the filter to negotiate the properties for its inputs</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_config_links(AVFilterContext* filter);
        
        /// <summary>
        /// Return the libavfilter build-time configuration.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static string avfilter_configuration();
        
        /// <summary>
        /// Free a filter context. This will also remove the filter from its filtergraph&apos;s list of filters.
        /// </summary>
        /// <param name="filter">the filter to free</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_free(AVFilterContext* filter);
        
        /// <summary>
        /// Get a filter definition matching the given name.
        /// </summary>
        /// <param name="name">the filter name to find</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilter* avfilter_get_by_name([MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Returns AVClass for AVFilterContext.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVClass* avfilter_get_class();
        
        /// <summary>
        /// Allocate a filter graph.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilterGraph* avfilter_graph_alloc();
        
        /// <summary>
        /// Create a new filter instance in a filter graph.
        /// </summary>
        /// <param name="graph">graph in which the new filter will be used</param>
        /// <param name="filter">the filter to create an instance of</param>
        /// <param name="name">Name to give to the new instance (will be copied to AVFilterContext.name). This may be used by the caller to identify different filters, libavfilter itself assigns no semantics to this parameter. May be NULL.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilterContext* avfilter_graph_alloc_filter(AVFilterGraph* graph, AVFilter* filter, [MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Check validity and configure all the links and formats in the graph.
        /// </summary>
        /// <param name="graphctx">the filter graph</param>
        /// <param name="log_ctx">context used for logging</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_config(AVFilterGraph* graphctx, void* log_ctx);
        
        /// <summary>
        /// Create and add a filter instance into an existing graph. The filter instance is created from the filter filt and inited with the parameters args and opaque.
        /// </summary>
        /// <param name="name">the instance name to give to the created filter instance</param>
        /// <param name="graph_ctx">the filter graph</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_create_filter(AVFilterContext** filt_ctx, AVFilter* filt, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string args, void* opaque, AVFilterGraph* graph_ctx);
        
        /// <summary>
        /// Dump a graph into a human-readable string representation.
        /// </summary>
        /// <param name="graph">the graph to dump</param>
        /// <param name="options">formatting options; currently ignored</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static byte* avfilter_graph_dump(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string options);
        
        /// <summary>
        /// Free a graph, destroy its links, and set *graph to NULL. If *graph is NULL, do nothing.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_graph_free(AVFilterGraph** graph);
        
        /// <summary>
        /// Get a filter instance identified by instance name from graph.
        /// </summary>
        /// <param name="graph">filter graph to search through.</param>
        /// <param name="name">filter instance name (should be unique in the graph).</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilterContext* avfilter_graph_get_filter(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        /// Add a graph described by a string to a graph.
        /// </summary>
        /// <param name="graph">the filter graph where to link the parsed graph context</param>
        /// <param name="filters">string to be parsed</param>
        /// <param name="inputs">linked list to the inputs of the graph</param>
        /// <param name="outputs">linked list to the outputs of the graph</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_parse(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string filters, AVFilterInOut* inputs, AVFilterInOut* outputs, void* log_ctx);
        
        /// <summary>
        /// Add a graph described by a string to a graph.
        /// </summary>
        /// <param name="graph">the filter graph where to link the parsed graph context</param>
        /// <param name="filters">string to be parsed</param>
        /// <param name="inputs">pointer to a linked list to the inputs of the graph, may be NULL. If non-NULL, *inputs is updated to contain the list of open inputs after the parsing, should be freed with avfilter_inout_free().</param>
        /// <param name="outputs">pointer to a linked list to the outputs of the graph, may be NULL. If non-NULL, *outputs is updated to contain the list of open outputs after the parsing, should be freed with avfilter_inout_free().</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_parse_ptr(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string filters, AVFilterInOut** inputs, AVFilterInOut** outputs, void* log_ctx);
        
        /// <summary>
        /// Add a graph described by a string to a graph.
        /// </summary>
        /// <param name="graph">the filter graph where to link the parsed graph context</param>
        /// <param name="filters">string to be parsed</param>
        /// <param name="inputs">a linked list of all free (unlinked) inputs of the parsed graph will be returned here. It is to be freed by the caller using avfilter_inout_free().</param>
        /// <param name="outputs">a linked list of all free (unlinked) outputs of the parsed graph will be returned here. It is to be freed by the caller using avfilter_inout_free().</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_parse2(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string filters, AVFilterInOut** inputs, AVFilterInOut** outputs);
        
        /// <summary>
        /// Queue a command for one or more filter instances.
        /// </summary>
        /// <param name="graph">the filter graph</param>
        /// <param name="target">the filter(s) to which the command should be sent &quot;all&quot; sends to all filters otherwise it can be a filter or filter instance name which will send the command to all matching filters.</param>
        /// <param name="cmd">the command to sent, for handling simplicity all commands must be alphanumeric only</param>
        /// <param name="arg">the argument for the command</param>
        /// <param name="ts">time at which the command should be sent to the filter</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_queue_command(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string target, [MarshalAs(UnmanagedType.LPStr)] string cmd, [MarshalAs(UnmanagedType.LPStr)] string arg, int flags, double ts);
        
        /// <summary>
        /// Request a frame on the oldest sink link.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_request_oldest(AVFilterGraph* graph);
        
        /// <summary>
        /// Send a command to one or more filter instances.
        /// </summary>
        /// <param name="graph">the filter graph</param>
        /// <param name="target">the filter(s) to which the command should be sent &quot;all&quot; sends to all filters otherwise it can be a filter or filter instance name which will send the command to all matching filters.</param>
        /// <param name="cmd">the command to send, for handling simplicity all commands must be alphanumeric only</param>
        /// <param name="arg">the argument for the command</param>
        /// <param name="res">a buffer with size res_size where the filter(s) can return a response.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_graph_send_command(AVFilterGraph* graph, [MarshalAs(UnmanagedType.LPStr)] string target, [MarshalAs(UnmanagedType.LPStr)] string cmd, [MarshalAs(UnmanagedType.LPStr)] string arg, byte* res, int res_len, int flags);
        
        /// <summary>
        /// Enable or disable automatic format conversion inside the graph.
        /// </summary>
        /// <param name="flags">any of the AVFILTER_AUTO_CONVERT_* constants</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_graph_set_auto_convert(AVFilterGraph* graph, uint flags);
        
        /// <summary>
        /// Initialize a filter with the supplied dictionary of options.
        /// </summary>
        /// <param name="ctx">uninitialized filter context to initialize</param>
        /// <param name="options">An AVDictionary filled with options for this filter. On return this parameter will be destroyed and replaced with a dict containing options that were not found. This dictionary must be freed by the caller. May be NULL, then this function is equivalent to avfilter_init_str() with the second parameter set to NULL.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_init_dict(AVFilterContext* ctx, AVDictionary** options);
        
        /// <summary>
        /// Initialize a filter with the supplied parameters.
        /// </summary>
        /// <param name="ctx">uninitialized filter context to initialize</param>
        /// <param name="args">Options to initialize the filter with. This must be a &apos;:&apos;-separated list of options in the &apos;key=value&apos; form. May be NULL if the options have been set directly using the AVOptions API or there are no options that need to be set.</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_init_str(AVFilterContext* ctx, [MarshalAs(UnmanagedType.LPStr)] string args);
        
        /// <summary>
        /// Allocate a single AVFilterInOut entry. Must be freed with avfilter_inout_free().
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilterInOut* avfilter_inout_alloc();
        
        /// <summary>
        /// Free the supplied list of AVFilterInOut and set *inout to NULL. If *inout is NULL, do nothing.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_inout_free(AVFilterInOut** inout);
        
        /// <summary>
        /// Insert a filter in the middle of an existing link.
        /// </summary>
        /// <param name="link">the link into which the filter should be inserted</param>
        /// <param name="filt">the filter to be inserted</param>
        /// <param name="filt_srcpad_idx">the input pad on the filter to connect</param>
        /// <param name="filt_dstpad_idx">the output pad on the filter to connect</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_insert_filter(AVFilterLink* link, AVFilterContext* filt, uint filt_srcpad_idx, uint filt_dstpad_idx);
        
        /// <summary>
        /// Return the libavfilter license.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static string avfilter_license();
        
        /// <summary>
        /// Link two filters together.
        /// </summary>
        /// <param name="src">the source filter</param>
        /// <param name="srcpad">index of the output pad on the source filter</param>
        /// <param name="dst">the destination filter</param>
        /// <param name="dstpad">index of the input pad on the destination filter</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_link(AVFilterContext* src, uint srcpad, AVFilterContext* dst, uint dstpad);
        
        /// <summary>
        /// Free the link in *link, and set its pointer to NULL.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_link_free(AVFilterLink** link);
        
        /// <summary>
        /// Get the number of channels of a link.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_link_get_channels(AVFilterLink* link);
        
        /// <summary>
        /// Set the closed field of a link.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_link_set_closed(AVFilterLink* link, int closed);
        
        /// <summary>
        /// Iterate over all registered filters.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVFilter* avfilter_next(AVFilter* prev);
        
        /// <summary>
        /// Get the number of elements in a NULL-terminated array of AVFilterPads (e.g. AVFilter.inputs/outputs).
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_pad_count(AVFilterPad* pads);
        
        /// <summary>
        /// Get the name of an AVFilterPad.
        /// </summary>
        /// <param name="pads">an array of AVFilterPads</param>
        /// <param name="pad_idx">index of the pad in the array it; is the caller&apos;s responsibility to ensure the index is valid</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static string avfilter_pad_get_name(AVFilterPad* pads, int pad_idx);
        
        /// <summary>
        /// Get the type of an AVFilterPad.
        /// </summary>
        /// <param name="pads">an array of AVFilterPads</param>
        /// <param name="pad_idx">index of the pad in the array; it is the caller&apos;s responsibility to ensure the index is valid</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static AVMediaType avfilter_pad_get_type(AVFilterPad* pads, int pad_idx);
        
        /// <summary>
        /// Make the filter instance process a command. It is recommended to use avfilter_graph_send_command().
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_process_command(AVFilterContext* filter, [MarshalAs(UnmanagedType.LPStr)] string cmd, [MarshalAs(UnmanagedType.LPStr)] string arg, byte* res, int res_len, int flags);
        
        /// <summary>
        /// Register a filter. This is only needed if you plan to use avfilter_get_by_name later to lookup the AVFilter structure by name. A filter can still by instantiated with avfilter_graph_alloc_filter even if it is not registered.
        /// </summary>
        /// <param name="filter">the filter to register</param>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static int avfilter_register(AVFilter* filter);
        
        /// <summary>
        /// Initialize the filter system. Register all builtin filters.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static void avfilter_register_all();
        
        /// <summary>
        /// Return the LIBAVFILTER_VERSION_INT constant.
        /// </summary>
        [DllImport(Dll_AVFilter, CallingConvention = Convention)]
        public extern static uint avfilter_version();
        
    }
    #pragma warning restore IDE1006 // 命名样式
}
