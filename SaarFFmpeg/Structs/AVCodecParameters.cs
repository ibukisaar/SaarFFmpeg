using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.Enumerates;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodecParameters {
		public AVMediaType CodecType;
		public AVCodecID CodecId;
		public uint CodecTag;
		public byte* Extradata;
		public int ExtradataSize;
		public int Format;
		public long BitRate;
		public int BitsPerCodedSample;
		public int BitsPerRawSample;
		public int Profile;
		public int Level;
		public int Width;
		public int Height;
		public AVRational SampleAspectRatio;
		public AVFieldOrder FieldOrder;
		public AVColorRange ColorRange;
		public AVColorPrimaries ColorPrimaries;
		public AVColorTransferCharacteristic ColorTrc;
		public AVColorSpace ColorSpace;
		public AVChromaLocation ChromaLocation;
		public int VideoDelay;
		public AVChannelLayout ChannelLayout;
		public int Channels;
		public int SampleRate;
		public int BlockAlign;
		public int FrameSize;
		public int InitialPadding;
		public int TrailingPadding;
		public int SeekPreroll;
	}
}