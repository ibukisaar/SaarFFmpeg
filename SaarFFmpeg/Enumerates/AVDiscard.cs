namespace Saar.FFmpeg.CSharp {
	public enum AVDiscard : int {
		None = -16,
		Default = 0,
		Nonref = 8,
		Bidir = 16,
		Nonintra = 24,
		Nonkey = 32,
		All = 48,
	}
}