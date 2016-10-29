using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVFormatContext {
		public AVClass* AvClass;
		public AVInputFormat* Iformat;
		public AVOutputFormat* Oformat;
		public void* PrivData;
		/// <summary>
		/// Input/Output上下文。
		/// </summary>
		public AVIOContext* Pb;
		public int CtxFlags;
		/// <summary>
		/// 媒体中流的个数。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public uint NbStreams;
		/// <summary>
		/// 一个指向流数组的指针。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public AVStream** Streams;
		/// <summary>
		/// 表示媒体的文件名。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public fixed byte Filename[1024];
		/// <summary>
		/// 分离专用(Demuxing only)。媒体开始时间。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public long StartTime;
		/// <summary>
		/// 分离专用(Demuxing only)。媒体总时间长度。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public long Duration;
		/// <summary>
		/// 所有流的比特率之和，如果为0表示不可用。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public long BitRate;
		public uint PacketSize;
		public int MaxDelay;
		public AVFmtFlag Flags;
		public long Probesize;
		public long MaxAnalyzeDuration;
		public byte* Key;
		public int Keylen;
		public uint NbPrograms;
		public AVProgram** Programs;
		public AVCodecID VideoCodecId;
		public AVCodecID AudioCodecId;
		public AVCodecID SubtitleCodecId;
		public uint MaxIndexSize;
		public uint MaxPictureBuffer;
		public uint NbChapters;
		public AVChapter** Chapters;
		public AVDictionary** Metadata;
		public long StartTimeRealtime;
		public int FpsProbeSize;
		public int ErrorRecognition;
		public AVIOInterruptCB InterruptCallback;
		public int Debug;
		public long MaxInterleaveDelta;
		public int StrictStdCompliance;
		public int EventFlags;
		public int MaxTsProbe;
		public int AvoidNegativeTs;
		public int TsId;
		public int AudioPreload;
		public int MaxChunkDuration;
		public int MaxChunkSize;
		public int UseWallclockAsTimestamps;
		public int AvioFlags;
		public AVDurationEstimationMethod DurationEstimationMethod;
		public long SkipInitialBytes;
		public uint CorrectTsOverflow;
		public int Seek2any;
		public int FlushPackets;
		public int ProbeScore;
		public int FormatProbesize;
		public byte* CodecWhitelist;
		public byte* FormatWhitelist;
		public IntPtr Internal_AVFormatInternalPtr;
		public int IoRepositioned;
		public AVCodec* VideoCodec;
		public AVCodec* AudioCodec;
		public AVCodec* SubtitleCodec;
		public AVCodec* DataCodec;
		public int MetadataHeaderPadding;
		public void* Opaque;
		public IntPtr ControlMessageCb; // 待处理方法
		public long OutputTsOffset;
		public byte* DumpSeparator;
		public AVCodecID DataCodecId;
		public IntPtr OpenCb; // 待处理方法
		public byte* ProtocolWhitelist;
		public IntPtr IoOpen; // 待处理方法
		public IntPtr IoClose; // 待处理方法
		public byte* ProtocolBlacklist;
	}
}