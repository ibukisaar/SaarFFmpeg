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
        /// Audio input devices iterator.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static AVInputFormat* av_input_audio_device_next(AVInputFormat* d);
        
        /// <summary>
        /// Video input devices iterator.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static AVInputFormat* av_input_video_device_next(AVInputFormat* d);
        
        /// <summary>
        /// Audio output devices iterator.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static AVOutputFormat* av_output_audio_device_next(AVOutputFormat* d);
        
        /// <summary>
        /// Video output devices iterator.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static AVOutputFormat* av_output_video_device_next(AVOutputFormat* d);
        
        /// <summary>
        /// Send control message from application to device.
        /// </summary>
        /// <param name="s">device context.</param>
        /// <param name="type">message type.</param>
        /// <param name="data">message data. Exact type depends on message type.</param>
        /// <param name="data_size">size of message data.</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_app_to_dev_control_message(AVFormatContext* s, AVAppToDevMessageType type, void* data, IntPtr data_size);
        
        /// <summary>
        /// Initialize capabilities probing API based on AVOption API.
        /// </summary>
        /// <param name="caps">Device capabilities data. Pointer to a NULL pointer must be passed.</param>
        /// <param name="s">Context of the device.</param>
        /// <param name="device_options">An AVDictionary filled with device-private options. On return this parameter will be destroyed and replaced with a dict containing options that were not found. May be NULL. The same options must be passed later to avformat_write_header() for output devices or avformat_open_input() for input devices, or at any other place that affects device-private options.</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_capabilities_create(AVDeviceCapabilitiesQuery** caps, AVFormatContext* s, AVDictionary** device_options);
        
        /// <summary>
        /// Free resources created by avdevice_capabilities_create()
        /// </summary>
        /// <param name="caps">Device capabilities data to be freed.</param>
        /// <param name="s">Context of the device.</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static void avdevice_capabilities_free(AVDeviceCapabilitiesQuery** caps, AVFormatContext* s);
        
        /// <summary>
        /// Return the libavdevice build-time configuration.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static string avdevice_configuration();
        
        /// <summary>
        /// Send control message from device to application.
        /// </summary>
        /// <param name="s">device context.</param>
        /// <param name="type">message type.</param>
        /// <param name="data">message data. Can be NULL.</param>
        /// <param name="data_size">size of message data.</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_dev_to_app_control_message(AVFormatContext* s, AVDevToAppMessageType type, void* data, IntPtr data_size);
        
        /// <summary>
        /// Convenient function to free result of avdevice_list_devices().
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static void avdevice_free_list_devices(AVDeviceInfoList** device_list);
        
        /// <summary>
        /// Return the libavdevice license.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static string avdevice_license();
        
        /// <summary>
        /// List devices.
        /// </summary>
        /// <param name="s">device context.</param>
        /// <param name="device_list">list of autodetected devices.</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_list_devices(AVFormatContext* s, AVDeviceInfoList** device_list);
        
        /// <summary>
        /// List devices.
        /// </summary>
        /// <param name="device">device format. May be NULL if device name is set.</param>
        /// <param name="device_name">device name. May be NULL if device format is set.</param>
        /// <param name="device_options">An AVDictionary filled with device-private options. May be NULL. The same options must be passed later to avformat_write_header() for output devices or avformat_open_input() for input devices, or at any other place that affects device-private options.</param>
        /// <param name="device_list">list of autodetected devices</param>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_list_input_sources(AVInputFormat* device, [MarshalAs(UnmanagedType.LPStr)] string device_name, AVDictionary* device_options, AVDeviceInfoList** device_list);
        
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static int avdevice_list_output_sinks(AVOutputFormat* device, [MarshalAs(UnmanagedType.LPStr)] string device_name, AVDictionary* device_options, AVDeviceInfoList** device_list);
        
        /// <summary>
        /// Initialize libavdevice and register all the input and output devices.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static void avdevice_register_all();
        
        /// <summary>
        /// Return the LIBAVDEVICE_VERSION_INT constant.
        /// </summary>
        [DllImport(Dll_AVDevice, CallingConvention = Convention)]
        public extern static uint avdevice_version();
        
    }
    #pragma warning restore IDE1006 // 命名样式
}
