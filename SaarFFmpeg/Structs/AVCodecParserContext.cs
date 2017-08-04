using System;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVCodecParserContext {
		public void* PrivData;
		public AVCodecParser* Parser;
		public long FrameOffset;
		public long CurOffset;
		public long NextFrameOffset;
		public int PictType;
		public int RepeatPict;
		public long Pts;
		public long Dts;
		public long LastPts;
		public long LastDts;
		public int FetchTimestamp;
		public int CurFrameStartIndex;
		public fixed long CurFrameOffset[4];
		public fixed long CurFramePts[4];
		public fixed long CurFrameDts[4];
		public int Flags;
		public long Offset;
		public fixed long CurFrameEnd[4];
		public int KeyFrame;
		public long ConvergenceDuration;
		public int DtsSyncPoint;
		public int DtsRefDtsDelta;
		public int PtsDtsDelta;
		public fixed long CurFramePos[4];
		public long Pos;
		public long LastPos;
		public int Duration;
		public AVFieldOrder FieldOrder;
		public AVPictureStructure PictureUre;
		public int OutputPictureNumber;
		public int Width;
		public int Height;
		public int CodedWidth;
		public int CodedHeight;
		public int Format;
	}
}