namespace Saar.FFmpeg.Enumerates {
	public enum AVClassCategory : int {
		Na = 0,
		Input,
		Output,
		Muxer,
		Demuxer,
		Encoder,
		Decoder,
		Filter,
		BitstreamFilter,
		Swscaler,
		Swresampler,
		DeviceVideoOutput = 40,
		DeviceVideoInput,
		DeviceAudioOutput,
		DeviceAudioInput,
		DeviceOutput,
		DeviceInput,
		Nb,
	}
}