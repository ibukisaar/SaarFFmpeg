using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.CSharp {
	public class VideoEncoderParameters {
		public BitRate BitRate { get; set; }
		public Fraction FrameRate { get; set; }
		public int GopSize { get; set; }
		public int MaxBFrames { get; set; }
		public int MbDecision { get; set; }
		public int Qmin { get; set; }
		public int Qmax { get; set; }
		public SwsFlags ResampleFlags { get; set; }

		public static VideoEncoderParameters Default { get; }
			= new VideoEncoderParameters {
				BitRate = BitRate.FromMBitPerSecond(1.28),
				FrameRate = new Fraction(25, 1),
				ResampleFlags = SwsFlags.FastBilinear,
			};
	}
}
