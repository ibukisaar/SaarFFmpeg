namespace Saar.FFmpeg.Enumerates {
	public enum AVStreamParseType : int {
		None,
		Full,
		Headers,
		Timestamps,
		FullOnce,
		FullRaw = ((0) | (('R') << 8) | (('A') << 16) | (('W') << 24)),
	}
}