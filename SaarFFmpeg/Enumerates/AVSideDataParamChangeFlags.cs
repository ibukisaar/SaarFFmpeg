using System;
namespace Saar.FFmpeg.Enumerates {
	[Flags]
	public enum AVSideDataParamChangeFlags : int {
		ChannelCount = 1,
		ChannelLayout = 2,
		SampleRate = 4,
		Dimensions = 8,
	}
}