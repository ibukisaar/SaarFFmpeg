using Saar.FFmpeg.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saar.FFmpeg.CSharp {
	public sealed class AudioFormat {
		private static readonly Type[] SampleTypeMap = {
			typeof(byte),
			typeof(short),
			typeof(int),
			typeof(float),
			typeof(double),
			typeof(byte),
			typeof(short),
			typeof(int),
			typeof(float),
			typeof(double),
			typeof(long),
			typeof(long),
		};

		public int SampleRate { get; }
		public AVChannelLayout ChannelLayout { get; }
		public AVSampleFormat SampleFormat { get; }
		public int Channels => GetChannels(ChannelLayout);
		public int BitsPerSample { get; }
		public Type SampleType => GetSampleType(SampleFormat);
		public bool IsPlanarFormat => SampleFormat.IsPlanar();
		public int LineCount => IsPlanarFormat ? Channels : 1;
		public int LineBlock => IsPlanarFormat ? (BitsPerSample >> 3) : (BitsPerSample >> 3) * Channels;
		public int ValidBitsPerSample { get; }

		public AudioFormat(int sampleRate, AVChannelLayout channelLayout, AVSampleFormat sampleFormat) {
			SampleRate = sampleRate;
			ChannelLayout = channelLayout;
			SampleFormat = sampleFormat;
			BitsPerSample = GetBytePerSample(sampleFormat) * 8;
			ValidBitsPerSample = SampleFormat.EqualsType(AVSampleFormat.Int32) ? 24 : BitsPerSample;
		}

		public AudioFormat(int sampleRate, int channels, int sampleBits, bool planar = false) {
			SampleRate = sampleRate;
			BitsPerSample = sampleBits == 24 ? 32 : sampleBits;
			ChannelLayout = GetDefaultChannelLayout(channels);
			switch (sampleBits) {
				case 8: SampleFormat = AVSampleFormat.UInt8; break;
				case 16: SampleFormat = AVSampleFormat.Int16; break;
				case 24: SampleFormat = AVSampleFormat.Int32; break;
				case 32: SampleFormat = AVSampleFormat.Float; break;
				case 64: SampleFormat = AVSampleFormat.Double; break;
				default: throw new ArgumentException($"不支持的采样位数:{sampleBits}");
			}
			if (planar) SampleFormat = SampleFormat.ToPlanar();
			ValidBitsPerSample = SampleFormat.EqualsType(AVSampleFormat.Int32) ? 24 : BitsPerSample;
		}

		public override bool Equals(object obj) {
			return obj is AudioFormat other
				&& SampleRate == other.SampleRate
				&& ChannelLayout == other.ChannelLayout
				&& SampleFormat == other.SampleFormat;
		}

		public override int GetHashCode() {
			return SampleRate + (int)ChannelLayout + (int)SampleFormat;
		}

		public string String => $"{SampleRate} Hz, {Channels} channels, {ValidBitsPerSample} bits";

		public override string ToString()
			=> IsPlanarFormat ? String + ", planar" : String;

		public AudioFormat ToPacked() {
			return new AudioFormat(SampleRate, ChannelLayout, SampleFormat.ToPacked());
		}

		public AudioFormat ToPlanar() {
			return new AudioFormat(SampleRate, ChannelLayout, SampleFormat.ToPlanar());
		}

		public int GetLineBytes(int sampleCount) {
			return sampleCount * LineBlock;
		}

		public int GetBytes(int sampleCount) {
			return sampleCount * LineBlock * LineCount;
		}

		public static AVChannelLayout GetDefaultChannelLayout(int channels) {
			return Internal.FFmpeg.av_get_default_channel_layout(channels);
		}

		public static int GetChannels(AVChannelLayout channelLayout) {
			return Internal.FFmpeg.av_get_channel_layout_nb_channels(channelLayout);
		}

		public static bool operator ==(AudioFormat left, AudioFormat right) {
			if (ReferenceEquals(left, right)) return true;
			if (left is null) return false;
			return left.Equals(right);
		}

		public static bool operator !=(AudioFormat left, AudioFormat right) {
			if (ReferenceEquals(left, right)) return false;
			if (left is null) return true;
			return !left.Equals(right);
		}

		public static Type GetSampleType(AVSampleFormat sampleFormat) {
			return SampleTypeMap[(int)sampleFormat];
		}

		public static int GetBytePerSample(AVSampleFormat sampleFormat) {
			return Internal.FFmpeg.av_get_bytes_per_sample(sampleFormat);
		}

		public AudioFormat Match(IEnumerable<int> sampleRates, IEnumerable<AVSampleFormat> sampleFormats, IEnumerable<AVChannelLayout> channelLayouts) {
			int sampleRate = SampleRate;
			if (sampleRates != null) {
				foreach (var sr in sampleRates.OrderBy(sr => sr)) {
					sampleRate = sr;
					if (sr >= SampleRate) break;
				}
			}

			AVSampleFormat sampleFormat = SampleFormat;
			if (sampleFormats != null) {
				foreach (var sf in sampleFormats.OrderBy(sf => GetBytePerSample(sf))) {
					sampleFormat = sf;
					if (GetBytePerSample(sf) >= BitsPerSample >> 3) break;
				}
			}

			AVChannelLayout channelLayout = ChannelLayout;
			if (channelLayouts != null) {
				foreach (var cl in channelLayouts.OrderBy(cl => GetChannels(cl))) {
					channelLayout = cl;
					if (GetChannels(cl) >= Channels) break;
				}
			}

			return new AudioFormat(sampleRate, channelLayout, sampleFormat);
		}
	}
}
