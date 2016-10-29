using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;
using Saar.FFmpeg.Support;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVFrame {
		public BytePtrArray8 Data;
		public fixed int Linesize[8];
		public byte** ExtendedData;
		public int Width;
		public int Height;
		public int NbSamples;
		public int Format;
		public int KeyFrame;
		public AVPictureType PictType;
		public AVRational SampleAspectRatio;
		public long Pts;
		public long PktPts;
		public long PktDts;
		public int CodedPictureNumber;
		public int DisplayPictureNumber;
		public int Quality;
		public void* Opaque;
		public fixed ulong Error[8];
		public int RepeatPict;
		public int InterlacedFrame;
		public int TopFieldFirst;
		public int PaletteHasChanged;
		public long ReorderedOpaque;
		public int SampleRate;
		public AVChannelLayout ChannelLayout;
		public AVBufferRefArray8 Buf;
		public AVBufferRef** ExtendedBuf;
		public int NbExtendedBuf;
		public AVFrameSideData** SideData;
		public int NbSideData;
		public int Flags;
		public AVColorRange ColorRange;
		public AVColorPrimaries ColorPrimaries;
		public AVColorTransferCharacteristic ColorTrc;
		public AVColorSpace Colorspace;
		public AVChromaLocation ChromaLocation;
		public long BestEffortTimestamp;
		public long PktPos;
		public long PktDuration;
		public AVDictionary* Metadatar;
		public int DecodeErrorFlags;
		public int Channels;
		public int PktSize;
		public sbyte* QscaleTable;
		public int Qstride;
		public int QscaleType;
		public AVBufferRef* QpTableBuf;
		public AVBufferRef* HwFramesCtx;
	}
}