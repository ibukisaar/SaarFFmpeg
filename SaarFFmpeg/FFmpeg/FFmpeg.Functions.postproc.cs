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
        /// Return the libpostproc build-time configuration.
        /// </summary>
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static string postproc_configuration();
        
        /// <summary>
        /// Return the libpostproc license.
        /// </summary>
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static string postproc_license();
        
        /// <summary>
        /// Return the LIBPOSTPROC_VERSION_INT constant.
        /// </summary>
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static uint postproc_version();
        
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static void pp_free_context(void* ppContext);
        
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static void pp_free_mode(void* mode);
        
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static void* pp_get_context(int width, int height, int flags);
        
        /// <summary>
        /// Return a pp_mode or NULL if an error occurred.
        /// </summary>
        /// <param name="name">the string after &quot;-pp&quot; on the command line</param>
        /// <param name="quality">a number from 0 to PP_QUALITY_MAX</param>
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static void* pp_get_mode_by_name_and_quality([MarshalAs(UnmanagedType.LPStr)] string name, int quality);
        
        [DllImport(Dll_PostProc, CallingConvention = Convention)]
        public extern static void pp_postprocess(ref byte_ptrArray3 src, int_array3 srcStride, ref byte_ptrArray3 dst, int_array3 dstStride, int horizontalSize, int verticalSize, sbyte* QP_store, int QP_stride, void* mode, void* ppContext, int pict_type);
        
    }
    #pragma warning restore IDE1006 // 命名样式
}
