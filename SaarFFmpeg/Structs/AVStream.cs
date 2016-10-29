using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVStream {
		/// <summary>
		/// 表示流的编号。
		/// </summary>
		public int Index;
		public int Id;
		/// <summary>
		/// 对应的编解码器上下文。
		/// </summary>
		public AVCodecContext* Codec;
		public void* PrivData;
		public AVFrac Pts;
		/// <summary>
		/// 时间基，表示两帧之间的时间间隔。
		/// 一般情况，视频是“1/帧率(FrameRate)”，音频是“1/采样率(SampleRate)”。
		/// </summary>
		public AVRational TimeBase;
		public long StartTime;
		/// <summary>
		/// 该流的时间长度。
		/// </summary>
		public long Duration;
		/// <summary>
		/// 该流的总帧数。
		/// <para>不要设置这个字段，FFmpeg会自动计算。</para>
		/// </summary>
		public long NbFrames;
		public int Disposition;
		public AVDiscard Discard;
		public AVRational SampleAspectRatio;
		public AVDictionary* Metadata;
		/// <summary>
		/// 该流的平均帧率/采样率。
		/// <para>对于视频应当设置这个值。</para>
		/// </summary>
		public AVRational AvgFrameRate;
		/// <summary>
		/// 附带的图片。比如音乐专辑封面。
		/// </summary>
		public AVPacket AttachedPic;
		public AVPacketSideData* SideData;
		public int NbSideData;
		public int EventFlags;
		public AVStreamInfo* Info;
		public int PtsWrapBits;
		public long FirstDts;
		public long CurDts;
		public long LastIpPts;
		public int LastIpDuration;
		public int ProbePackets;
		public int CodecInfoNbFrames;
		public AVStreamParseType NeedParsing;
		public AVCodecParserContext* Parser;
		public AVPacketList* LastInPacketBuffer;
		public AVProbeData ProbeData;
		public fixed long PtsBuffer[17];
		public AVIndexEntry* IndexEntries;
		public int NbIndexEntries;
		public uint IndexEntriesAllocatedSize;
		public AVRational RFrameRate;
		public int StreamIdentifier;
		public long InterleaverChunkSize;
		public long InterleaverChunkDuration;
		public int RequestProbe;
		public int SkipToKeyframe;
		public int SkipSamples;
		public long StartSkipSamples;
		public long FirstDiscardSample;
		public long LastDiscardSample;
		public int NbDecodedFrames;
		public long MuxTsOffset;
		public long PtsWrapReference;
		public int PtsWrapBehavior;
		public int UpdateInitialDurationsDone;
		public fixed long PtsReorderError[17];
		public fixed byte PtsReorderErrorCount[17];
		public long LastDtsForOrderCheck;
		public byte DtsOrdered;
		public byte DtsMisordered;
		public int InjectGlobalSideData;
		public byte* RecommendedEncoderConfiguration;
		public AVRational DisplayAspectRatio;
		public IntPtr PrivPts_FFFracPtr;
		public IntPtr Internal_AVStreamInternalPtr;
		public AVCodecParameters* Codecpar;
	}
}