namespace Saar.FFmpeg.Enumerates {
	public enum AVOptionType : int {
		Flags,
		Int,
		Int64,
		Double,
		Float,
		String,
		Rational,
		Binary,
		Dict,
		Const = 128,
		ImageSize = (('E') | (('Z') << 8) | (('I') << 16) | (('S') << 24)),
		PixelFmt = (('T') | (('M') << 8) | (('F') << 16) | (('P') << 24)),
		SampleFmt = (('T') | (('M') << 8) | (('F') << 16) | (('S') << 24)),
		VideoRate = (('T') | (('A') << 8) | (('R') << 16) | (('V') << 24)),
		Duration = ((' ') | (('R') << 8) | (('U') << 16) | (('D') << 24)),
		Color = (('R') | (('L') << 8) | (('O') << 16) | (('C') << 24)),
		ChannelLayout = (('A') | (('L') << 8) | (('H') << 16) | (('C') << 24)),
		Bool = (('L') | (('O') << 8) | (('O') << 16) | (('B') << 24)),
	}
}
