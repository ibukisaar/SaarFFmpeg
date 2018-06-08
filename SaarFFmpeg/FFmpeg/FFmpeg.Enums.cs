using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.Support;
using Saar.FFmpeg.Internal;
using Saar.FFmpeg.Delegates;

namespace Saar.FFmpeg.CSharp {
	public enum AVActiveFormatDescription : int {
		Same = 8,
		_4_3 = 9,
		_16_9 = 10,
		_14_9 = 11,
		_4_3Sp_14_9 = 13,
		_16_9Sp_14_9 = 14,
		Sp_4_3 = 15,
	}

	/// <summary>
	/// Message types used by avdevice_app_to_dev_control_message().
	/// </summary>
	public enum AVAppToDevMessageType : int {
		/// <summary>
		/// Dummy message.
		/// </summary>
		None = 1313820229,
		/// <summary>
		/// Window size change message.
		/// </summary>
		WindowSize = 1195724621,
		/// <summary>
		/// Repaint request message.
		/// </summary>
		WindowRepaint = 1380274241,
		/// <summary>
		/// Request pause/play.
		/// </summary>
		Pause = 1346458912,
		/// <summary>
		/// Request pause/play.
		/// </summary>
		Play = 1347174745,
		/// <summary>
		/// Request pause/play.
		/// </summary>
		TogglePause = 1346458964,
		/// <summary>
		/// Volume control message.
		/// </summary>
		SetVolume = 1398165324,
		/// <summary>
		/// Mute control messages.
		/// </summary>
		Mute = 541939028,
		/// <summary>
		/// Mute control messages.
		/// </summary>
		Unmute = 1431131476,
		/// <summary>
		/// Mute control messages.
		/// </summary>
		ToggleMute = 1414354260,
		/// <summary>
		/// Get volume/mute messages.
		/// </summary>
		GetVolume = 1196838732,
		/// <summary>
		/// Get volume/mute messages.
		/// </summary>
		GetMute = 1196250452,
	}

	public enum AVAudioServiceType : int {
		Main = 0,
		Effects = 1,
		VisuallyImpaired = 2,
		HearingImpaired = 3,
		Dialogue = 4,
		Commentary = 5,
		Emergency = 6,
		VoiceOver = 7,
		Karaoke = 8,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 9,
	}

	[Flags]
	public enum AVBuffersinkFlag : int {
		NoRequest = 0x2,
		Peek = 0x1,
	}

	[Flags]
	public enum AVChannelLayout : ulong {
		FrontLeft = 0x00000001,
		FrontRight = 0x00000002,
		FrontCenter = 0x00000004,
		LowFrequency = 0x00000008,
		BackLeft = 0x00000010,
		BackRight = 0x00000020,
		FrontLeftOfCenter = 0x00000040,
		FrontRightOfCenter = 0x00000080,
		BackCenter = 0x00000100,
		SideLeft = 0x00000200,
		SideRight = 0x00000400,
		TopCenter = 0x00000800,
		TopFrontLeft = 0x00001000,
		TopFrontCenter = 0x00002000,
		TopFrontRight = 0x00004000,
		TopBackLeft = 0x00008000,
		TopBackCenter = 0x00010000,
		TopBackRight = 0x00020000,
		StereoLeft = 0x20000000,
		StereoRight = 0x40000000,
		WideLeft = 0x0000000080000000UL,
		WideRight = 0x0000000100000000UL,
		SurroundDirectLeft = 0x0000000200000000UL,
		SurroundDirectRight = 0x0000000400000000UL,
		LowFrequency2 = 0x0000000800000000UL,
		LayoutNative = 0x8000000000000000UL,

		LayoutMono = (FrontCenter),
		LayoutStereo = (FrontLeft | FrontRight),
		Layout2point1 = (LayoutStereo | LowFrequency),
		Layout2_1 = (LayoutStereo | BackCenter),
		LayoutSurround = (LayoutStereo | FrontCenter),
		Layout3point1 = (LayoutSurround | LowFrequency),
		Layout4point0 = (LayoutSurround | BackCenter),
		Layout4point1 = (Layout4point0 | LowFrequency),
		Layout2_2 = (LayoutStereo | SideLeft | SideRight),
		LayoutQuad = (LayoutStereo | BackLeft | BackRight),
		Layout5point0 = (LayoutSurround | SideLeft | SideRight),
		Layout5point1 = (Layout5point0 | LowFrequency),
		Layout5point0Back = (LayoutSurround | BackLeft | BackRight),
		Layout5point1Back = (Layout5point0Back | LowFrequency),
		Layout6point0 = (Layout5point0 | BackCenter),
		Layout6point0Front = (Layout2_2 | FrontLeftOfCenter | FrontRightOfCenter),
		LayoutHexagonal = (Layout5point0Back | BackCenter),
		Layout6point1 = (Layout5point1 | BackCenter),
		Layout6point1Back = (Layout5point1Back | BackCenter),
		Layout6point1Front = (Layout6point0Front | LowFrequency),
		Layout7point0 = (Layout5point0 | BackLeft | BackRight),
		Layout7point0Front = (Layout5point0 | FrontLeftOfCenter | FrontRightOfCenter),
		Layout7point1 = (Layout5point1 | BackLeft | BackRight),
		Layout7point1Wide = (Layout5point1 | FrontLeftOfCenter | FrontRightOfCenter),
		Layout7point1WideBack = (Layout5point1Back | FrontLeftOfCenter | FrontRightOfCenter),
		LayoutOctagonal = (Layout5point0 | BackLeft | BackCenter | BackRight),
		LayoutHexadecagonal = (LayoutOctagonal | WideLeft | WideRight | TopBackLeft | TopBackRight | TopBackCenter | TopFrontCenter | TopFrontLeft | TopFrontRight),
		LayoutStereoDownmix = (StereoLeft | StereoRight),
	}

	/// <summary>
	/// Location of chroma samples.
	/// </summary>
	public enum AVChromaLocation : int {
		Unspecified = 0,
		/// <summary>
		/// MPEG-2/4 4:2:0, H.264 default for 4:2:0
		/// </summary>
		Left = 1,
		/// <summary>
		/// MPEG-1 4:2:0, JPEG 4:2:0, H.263 4:2:0
		/// </summary>
		Center = 2,
		/// <summary>
		/// ITU-R 601, SMPTE 274M 296M S314M(DV 4:1:1), mpeg2 4:2:2
		/// </summary>
		Topleft = 3,
		Top = 4,
		Bottomleft = 5,
		Bottom = 6,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 7,
	}

	public enum AVClassCategory : int {
		Na = 0,
		Input = 1,
		Output = 2,
		Muxer = 3,
		Demuxer = 4,
		Encoder = 5,
		Decoder = 6,
		Filter = 7,
		BitstreamFilter = 8,
		Swscaler = 9,
		Swresampler = 10,
		DeviceVideoOutput = 40,
		DeviceVideoInput = 41,
		DeviceAudioOutput = 42,
		DeviceAudioInput = 43,
		DeviceOutput = 44,
		DeviceInput = 45,
		/// <summary>
		/// not part of ABI/API
		/// </summary>
		Nb = 46,
	}

	public enum AVCodecCap : uint {
		VariableFrameSize = 0x1 << 0x10,
		Truncated = 0x1 << 0x3,
		Subframes = 0x1 << 0x8,
		SmallLastFrame = 0x1 << 0x6,
		SliceThreads = 0x1 << 0xd,
		ParamChange = 0x1 << 0xe,
		Lossless = 0x80000000U,
		IntraOnly = 0x40000000,
		Hybrid = 0x1 << 0x13,
		Hardware = 0x1 << 0x12,
		FrameThreads = 0x1 << 0xc,
		Experimental = 0x1 << 0x9,
		DrawHorizBand = 0x1 << 0x0,
		Dr1 = 0x1 << 0x1,
		Delay = 0x1 << 0x5,
		ChannelConf = 0x1 << 0xa,
		AVOidProbing = 0x1 << 0x11,
		AutoThreads = 0x1 << 0xf,
	}

	public enum AVCodecFlag : uint {
		Pass1 = 0x1 << 0x9,
		OutputCorrupt = 0x1 << 0x3,
		LowDelay = 0x1 << 0x13,
		LoopFilter = 0x1 << 0xb,
		InterlacedMe = 0x1 << 0x1d,
		InterlacedDct = 0x1 << 0x12,
		Gray = 0x1 << 0xd,
		GlobalHeader = 0x1 << 0x16,
		ClosedGop = 0x1U << 0x1f,
		Bitexact = 0x1 << 0x17,
		AcPred = 0x1 << 0x18,
		_4mv = 0x1 << 0x2,
	}

	public enum AVCodecFlag2 : uint {
		Chunks = 0x1 << 0xf,
		DropFrameTimecode = 0x1 << 0xd,
		ExportMvs = 0x1 << 0x1c,
		Fast = 0x1 << 0x0,
		IgnoreCrop = 0x1 << 0x10,
		LocalHeader = 0x1 << 0x3,
		NoOutput = 0x1 << 0x2,
		RoFlushNoop = 0x1 << 0x1e,
		ShowAll = 0x1 << 0x16,
		SkipManual = 0x1 << 0x1d,
	}

	/// <summary>
	/// Identify the syntax and semantics of the bitstream. The principle is roughly: Two decoders with the same ID can decode the same streams. Two encoders with the same ID can encode compatible streams. There may be slight deviations from the principle due to implementation details.
	/// </summary>
	public enum AVCodecID : int {
		None = 0,
		Mpeg1video = 1,
		/// <summary>
		/// preferred ID for MPEG-1/2 video decoding
		/// </summary>
		Mpeg2video = 2,
		H261 = 3,
		H263 = 4,
		Rv10 = 5,
		Rv20 = 6,
		Mjpeg = 7,
		Mjpegb = 8,
		Ljpeg = 9,
		Sp5x = 10,
		Jpegls = 11,
		Mpeg4 = 12,
		Rawvideo = 13,
		Msmpeg4v1 = 14,
		Msmpeg4v2 = 15,
		Msmpeg4v3 = 16,
		Wmv1 = 17,
		Wmv2 = 18,
		H263p = 19,
		H263i = 20,
		Flv1 = 21,
		Svq1 = 22,
		Svq3 = 23,
		Dvvideo = 24,
		Huffyuv = 25,
		Cyuv = 26,
		H264 = 27,
		Indeo3 = 28,
		Vp3 = 29,
		Theora = 30,
		Asv1 = 31,
		Asv2 = 32,
		Ffv1 = 33,
		_4XM = 34,
		Vcr1 = 35,
		Cljr = 36,
		Mdec = 37,
		Roq = 38,
		InterplayVideo = 39,
		XanWc3 = 40,
		XanWc4 = 41,
		Rpza = 42,
		Cinepak = 43,
		WsVqa = 44,
		Msrle = 45,
		Msvideo1 = 46,
		Idcin = 47,
		_8BPS = 48,
		Smc = 49,
		Flic = 50,
		Truemotion1 = 51,
		Vmdvideo = 52,
		Mszh = 53,
		Zlib = 54,
		Qtrle = 55,
		Tscc = 56,
		Ulti = 57,
		Qdraw = 58,
		Vixl = 59,
		Qpeg = 60,
		Png = 61,
		Ppm = 62,
		Pbm = 63,
		Pgm = 64,
		Pgmyuv = 65,
		Pam = 66,
		Ffvhuff = 67,
		Rv30 = 68,
		Rv40 = 69,
		Vc1 = 70,
		Wmv3 = 71,
		Loco = 72,
		Wnv1 = 73,
		Aasc = 74,
		Indeo2 = 75,
		Fraps = 76,
		Truemotion2 = 77,
		Bmp = 78,
		Cscd = 79,
		Mmvideo = 80,
		Zmbv = 81,
		Avs = 82,
		Smackvideo = 83,
		Nuv = 84,
		Kmvc = 85,
		Flashsv = 86,
		Cavs = 87,
		Jpeg2000 = 88,
		Vmnc = 89,
		Vp5 = 90,
		Vp6 = 91,
		Vp6f = 92,
		Targa = 93,
		Dsicinvideo = 94,
		Tiertexseqvideo = 95,
		Tiff = 96,
		Gif = 97,
		Dxa = 98,
		Dnxhd = 99,
		Thp = 100,
		Sgi = 101,
		C93 = 102,
		Bethsoftvid = 103,
		Ptx = 104,
		Txd = 105,
		Vp6a = 106,
		Amv = 107,
		Vb = 108,
		Pcx = 109,
		Sunrast = 110,
		Indeo4 = 111,
		Indeo5 = 112,
		Mimic = 113,
		Rl2 = 114,
		Escape124 = 115,
		Dirac = 116,
		Bfi = 117,
		Cmv = 118,
		Motionpixels = 119,
		Tgv = 120,
		Tgq = 121,
		Tqi = 122,
		Aura = 123,
		Aura2 = 124,
		V210x = 125,
		Tmv = 126,
		V210 = 127,
		Dpx = 128,
		Mad = 129,
		Frwu = 130,
		Flashsv2 = 131,
		Cdgraphics = 132,
		R210 = 133,
		Anm = 134,
		Binkvideo = 135,
		IffIlbm = 136,
		Kgv1 = 137,
		Yop = 138,
		Vp8 = 139,
		Pictor = 140,
		Ansi = 141,
		A64Multi = 142,
		A64Multi5 = 143,
		R10k = 144,
		Mxpeg = 145,
		Lagarith = 146,
		Prores = 147,
		Jv = 148,
		Dfa = 149,
		Wmv3image = 150,
		Vc1image = 151,
		Utvideo = 152,
		BmvVideo = 153,
		Vble = 154,
		Dxtory = 155,
		V410 = 156,
		Xwd = 157,
		Cdxl = 158,
		Xbm = 159,
		Zerocodec = 160,
		Mss1 = 161,
		Msa1 = 162,
		Tscc2 = 163,
		Mts2 = 164,
		Cllc = 165,
		Mss2 = 166,
		Vp9 = 167,
		Aic = 168,
		Escape130 = 169,
		G2m = 170,
		Webp = 171,
		Hnm4Video = 172,
		Hevc = 173,
		Fic = 174,
		AliasPix = 175,
		BrenderPix = 176,
		PafVideo = 177,
		Exr = 178,
		Vp7 = 179,
		Sanm = 180,
		Sgirle = 181,
		Mvc1 = 182,
		Mvc2 = 183,
		Hqx = 184,
		Tdsc = 185,
		HqHqa = 186,
		Hap = 187,
		Dds = 188,
		Dxv = 189,
		Screenpresso = 190,
		Rscc = 191,
		Y41p = 32768,
		Avrp = 32769,
		_012V = 32770,
		Avui = 32771,
		Ayuv = 32772,
		TargaY216 = 32773,
		V308 = 32774,
		V408 = 32775,
		Yuv4 = 32776,
		Avrn = 32777,
		Cpia = 32778,
		Xface = 32779,
		Snow = 32780,
		Smvjpeg = 32781,
		Apng = 32782,
		Daala = 32783,
		Cfhd = 32784,
		Truemotion2rt = 32785,
		M101 = 32786,
		Magicyuv = 32787,
		Sheervideo = 32788,
		Ylc = 32789,
		Psd = 32790,
		Pixlet = 32791,
		Speedhq = 32792,
		Fmvc = 32793,
		Scpr = 32794,
		Clearvideo = 32795,
		Xpm = 32796,
		Av1 = 32797,
		Bitpacked = 32798,
		Mscc = 32799,
		Srgc = 32800,
		Svg = 32801,
		Gdv = 32802,
		Fits = 32803,
		/// <summary>
		/// A dummy id pointing at the start of audio codecs
		/// </summary>
		FirstAudio = 65536,
		PcmS16le = 65536,
		PcmS16be = 65537,
		PcmU16le = 65538,
		PcmU16be = 65539,
		PcmS8 = 65540,
		PcmU8 = 65541,
		PcmMulaw = 65542,
		PcmAlaw = 65543,
		PcmS32le = 65544,
		PcmS32be = 65545,
		PcmU32le = 65546,
		PcmU32be = 65547,
		PcmS24le = 65548,
		PcmS24be = 65549,
		PcmU24le = 65550,
		PcmU24be = 65551,
		PcmS24daud = 65552,
		PcmZork = 65553,
		PcmS16lePlanar = 65554,
		PcmDvd = 65555,
		PcmF32be = 65556,
		PcmF32le = 65557,
		PcmF64be = 65558,
		PcmF64le = 65559,
		PcmBluray = 65560,
		PcmLxf = 65561,
		S302m = 65562,
		PcmS8Planar = 65563,
		PcmS24lePlanar = 65564,
		PcmS32lePlanar = 65565,
		PcmS16bePlanar = 65566,
		PcmS64le = 67584,
		PcmS64be = 67585,
		PcmF16le = 67586,
		PcmF24le = 67587,
		AdpcmImaQt = 69632,
		AdpcmImaWav = 69633,
		AdpcmImaDk3 = 69634,
		AdpcmImaDk4 = 69635,
		AdpcmImaWs = 69636,
		AdpcmImaSmjpeg = 69637,
		AdpcmMs = 69638,
		Adpcm_4XM = 69639,
		AdpcmXa = 69640,
		AdpcmAdx = 69641,
		AdpcmEa = 69642,
		AdpcmG726 = 69643,
		AdpcmCt = 69644,
		AdpcmSwf = 69645,
		AdpcmYamaha = 69646,
		AdpcmSbpro_4 = 69647,
		AdpcmSbpro_3 = 69648,
		AdpcmSbpro_2 = 69649,
		AdpcmThp = 69650,
		AdpcmImaAmv = 69651,
		AdpcmEaR1 = 69652,
		AdpcmEaR3 = 69653,
		AdpcmEaR2 = 69654,
		AdpcmImaEaSead = 69655,
		AdpcmImaEaEacs = 69656,
		AdpcmEaXas = 69657,
		AdpcmEaMaxisXa = 69658,
		AdpcmImaIss = 69659,
		AdpcmG722 = 69660,
		AdpcmImaApc = 69661,
		AdpcmVima = 69662,
		AdpcmAfc = 71680,
		AdpcmImaOki = 71681,
		AdpcmDtk = 71682,
		AdpcmImaRad = 71683,
		AdpcmG726le = 71684,
		AdpcmThpLe = 71685,
		AdpcmPsx = 71686,
		AdpcmAica = 71687,
		AdpcmImaDat4 = 71688,
		AdpcmMtaf = 71689,
		AmrNb = 73728,
		AmrWb = 73729,
		Ra_144 = 77824,
		Ra_288 = 77825,
		RoqDpcm = 81920,
		InterplayDpcm = 81921,
		XanDpcm = 81922,
		SolDpcm = 81923,
		Sdx2Dpcm = 83968,
		GremlinDpcm = 83969,
		Mp2 = 86016,
		/// <summary>
		/// preferred ID for decoding MPEG audio layer 1, 2 or 3
		/// </summary>
		Mp3 = 86017,
		Aac = 86018,
		Ac3 = 86019,
		Dts = 86020,
		Vorbis = 86021,
		Dvaudio = 86022,
		Wmav1 = 86023,
		Wmav2 = 86024,
		Mace3 = 86025,
		Mace6 = 86026,
		Vmdaudio = 86027,
		Flac = 86028,
		Mp3adu = 86029,
		Mp3on4 = 86030,
		Shorten = 86031,
		Alac = 86032,
		WestwoodSnd1 = 86033,
		/// <summary>
		/// as in Berlin toast format
		/// </summary>
		Gsm = 86034,
		Qdm2 = 86035,
		Cook = 86036,
		Truespeech = 86037,
		Tta = 86038,
		Smackaudio = 86039,
		Qcelp = 86040,
		Wavpack = 86041,
		Dsicinaudio = 86042,
		Imc = 86043,
		Musepack7 = 86044,
		Mlp = 86045,
		GsmMs = 86046,
		Atrac3 = 86047,
		Ape = 86048,
		Nellymoser = 86049,
		Musepack8 = 86050,
		Speex = 86051,
		Wmavoice = 86052,
		Wmapro = 86053,
		Wmalossless = 86054,
		Atrac3p = 86055,
		Eac3 = 86056,
		Sipr = 86057,
		Mp1 = 86058,
		Twinvq = 86059,
		Truehd = 86060,
		Mp4als = 86061,
		Atrac1 = 86062,
		BinkaudioRdft = 86063,
		BinkaudioDct = 86064,
		AacLatm = 86065,
		Qdmc = 86066,
		Celt = 86067,
		G723_1 = 86068,
		G729 = 86069,
		_8SVXExp = 86070,
		_8SVXFib = 86071,
		BmvAudio = 86072,
		Ralf = 86073,
		Iac = 86074,
		Ilbc = 86075,
		Opus = 86076,
		ComfortNoise = 86077,
		Tak = 86078,
		Metasound = 86079,
		PafAudio = 86080,
		On2avc = 86081,
		DssSp = 86082,
		Codec2 = 86083,
		Ffwavesynth = 88064,
		Sonic = 88065,
		SonicLs = 88066,
		Evrc = 88067,
		Smv = 88068,
		DsdLsbf = 88069,
		DsdMsbf = 88070,
		DsdLsbfPlanar = 88071,
		DsdMsbfPlanar = 88072,
		_4GV = 88073,
		InterplayAcm = 88074,
		Xma1 = 88075,
		Xma2 = 88076,
		Dst = 88077,
		Atrac3al = 88078,
		Atrac3pal = 88079,
		DolbyE = 88080,
		Aptx = 88081,
		AptxHd = 88082,
		Sbc = 88083,
		/// <summary>
		/// A dummy ID pointing at the start of subtitle codecs.
		/// </summary>
		FirstSubtitle = 94208,
		DvdSubtitle = 94208,
		DvbSubtitle = 94209,
		/// <summary>
		/// raw UTF-8 text
		/// </summary>
		Text = 94210,
		Xsub = 94211,
		Ssa = 94212,
		MovText = 94213,
		HdmvPgsSubtitle = 94214,
		DvbTeletext = 94215,
		Srt = 94216,
		Microdvd = 96256,
		Eia_608 = 96257,
		Jacosub = 96258,
		Sami = 96259,
		Realtext = 96260,
		Stl = 96261,
		Subviewer1 = 96262,
		Subviewer = 96263,
		Subrip = 96264,
		Webvtt = 96265,
		Mpl2 = 96266,
		Vplayer = 96267,
		Pjs = 96268,
		Ass = 96269,
		HdmvTextSubtitle = 96270,
		/// <summary>
		/// A dummy ID pointing at the start of various fake codecs.
		/// </summary>
		FirstUnknown = 98304,
		Ttf = 98304,
		/// <summary>
		/// Contain timestamp estimated through PCR of program stream.
		/// </summary>
		Scte_35 = 98305,
		Bintext = 100352,
		Xbin = 100353,
		Idf = 100354,
		Otf = 100355,
		SmpteKlv = 100356,
		DvdNav = 100357,
		TimedId3 = 100358,
		BinData = 100359,
		/// <summary>
		/// codec_id is not known (like AV_CODEC_ID_NONE) but lavf should attempt to identify it
		/// </summary>
		Probe = 102400,
		/// <summary>
		/// _FAKE_ codec to indicate a raw MPEG-2 TS stream (only used by libavformat)
		/// </summary>
		Mpeg2ts = 131072,
		/// <summary>
		/// _FAKE_ codec to indicate a MPEG-4 Systems stream (only used by libavformat)
		/// </summary>
		Mpeg4systems = 131073,
		/// <summary>
		/// Dummy codec for streams containing only metadata information.
		/// </summary>
		Ffmetadata = 135168,
		/// <summary>
		/// Passthrough codec, AVFrames wrapped in AVPacket
		/// </summary>
		WrappedAvframe = 135169,

		H265 = Hevc,
		IffByterun1 = IffIlbm,
	}

	public enum AVCodecProp : int {
		BitmapSub = 0x1 << 0x10,
		IntraOnly = 0x1 << 0x0,
		Lossless = 0x1 << 0x2,
		Lossy = 0x1 << 0x1,
		Reorder = 0x1 << 0x3,
		TextSub = 0x1 << 0x11,
	}

	/// <summary>
	/// Chromaticity coordinates of the source primaries. These values match the ones defined by ISO/IEC 23001-8_2013 § 7.1.
	/// </summary>
	public enum AVColorPrimaries : int {
		Reserved0 = 0,
		/// <summary>
		/// also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP177 Annex B
		/// </summary>
		Bt709 = 1,
		Unspecified = 2,
		Reserved = 3,
		/// <summary>
		/// also FCC Title 47 Code of Federal Regulations 73.682 (a)(20)
		/// </summary>
		Bt470m = 4,
		/// <summary>
		/// also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL &amp; SECAM
		/// </summary>
		Bt470bg = 5,
		/// <summary>
		/// also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC
		/// </summary>
		Smpte170m = 6,
		/// <summary>
		/// functionally identical to above
		/// </summary>
		Smpte240m = 7,
		/// <summary>
		/// colour filters using Illuminant C
		/// </summary>
		Film = 8,
		/// <summary>
		/// ITU-R BT2020
		/// </summary>
		Bt2020 = 9,
		/// <summary>
		/// SMPTE ST 428-1 (CIE 1931 XYZ)
		/// </summary>
		Smpte428 = 10,
		Smptest428_1 = 10,
		/// <summary>
		/// SMPTE ST 431-2 (2011) / DCI P3
		/// </summary>
		Smpte431 = 11,
		/// <summary>
		/// SMPTE ST 432-1 (2010) / P3 D65 / Display P3
		/// </summary>
		Smpte432 = 12,
		/// <summary>
		/// JEDEC P22 phosphors
		/// </summary>
		JedecP22 = 22,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 23,
	}

	/// <summary>
	/// MPEG vs JPEG YUV range.
	/// </summary>
	public enum AVColorRange : int {
		Unspecified = 0,
		/// <summary>
		/// the normal 219*2^(n-8) &quot;MPEG&quot; YUV ranges
		/// </summary>
		Mpeg = 1,
		/// <summary>
		/// the normal 2^n-1 &quot;JPEG&quot; YUV ranges
		/// </summary>
		Jpeg = 2,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 3,
	}

	/// <summary>
	/// YUV colorspace type. These values match the ones defined by ISO/IEC 23001-8_2013 § 7.3.
	/// </summary>
	public enum AVColorSpace : int {
		/// <summary>
		/// order of coefficients is actually GBR, also IEC 61966-2-1 (sRGB)
		/// </summary>
		Rgb = 0,
		/// <summary>
		/// also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / SMPTE RP177 Annex B
		/// </summary>
		Bt709 = 1,
		Unspecified = 2,
		Reserved = 3,
		/// <summary>
		/// FCC Title 47 Code of Federal Regulations 73.682 (a)(20)
		/// </summary>
		Fcc = 4,
		/// <summary>
		/// also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL &amp; SECAM / IEC 61966-2-4 xvYCC601
		/// </summary>
		Bt470bg = 5,
		/// <summary>
		/// also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC
		/// </summary>
		Smpte170m = 6,
		/// <summary>
		/// functionally identical to above
		/// </summary>
		Smpte240m = 7,
		/// <summary>
		/// Used by Dirac / VC-2 and H.264 FRext, see ITU-T SG16
		/// </summary>
		Ycgco = 8,
		Ycocg = 8,
		/// <summary>
		/// ITU-R BT2020 non-constant luminance system
		/// </summary>
		Bt2020Ncl = 9,
		/// <summary>
		/// ITU-R BT2020 constant luminance system
		/// </summary>
		Bt2020Cl = 10,
		/// <summary>
		/// SMPTE 2085, Y&apos;D&apos;zD&apos;x
		/// </summary>
		Smpte2085 = 11,
		/// <summary>
		/// Chromaticity-derived non-constant luminance system
		/// </summary>
		ChromaDerivedNcl = 12,
		/// <summary>
		/// Chromaticity-derived constant luminance system
		/// </summary>
		ChromaDerivedCl = 13,
		/// <summary>
		/// ITU-R BT.2100-0, ICtCp
		/// </summary>
		Ictcp = 14,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 15,
	}

	/// <summary>
	/// Color Transfer Characteristic. These values match the ones defined by ISO/IEC 23001-8_2013 § 7.2.
	/// </summary>
	public enum AVColorTransferCharacteristic : int {
		Reserved0 = 0,
		/// <summary>
		/// also ITU-R BT1361
		/// </summary>
		Bt709 = 1,
		Unspecified = 2,
		Reserved = 3,
		/// <summary>
		/// also ITU-R BT470M / ITU-R BT1700 625 PAL &amp; SECAM
		/// </summary>
		Gamma22 = 4,
		/// <summary>
		/// also ITU-R BT470BG
		/// </summary>
		Gamma28 = 5,
		/// <summary>
		/// also ITU-R BT601-6 525 or 625 / ITU-R BT1358 525 or 625 / ITU-R BT1700 NTSC
		/// </summary>
		Smpte170m = 6,
		Smpte240m = 7,
		/// <summary>
		/// &quot;Linear transfer characteristics&quot;
		/// </summary>
		Linear = 8,
		/// <summary>
		/// &quot;Logarithmic transfer characteristic (100:1 range)&quot;
		/// </summary>
		Log = 9,
		/// <summary>
		/// &quot;Logarithmic transfer characteristic (100 * Sqrt(10) : 1 range)&quot;
		/// </summary>
		LogSqrt = 10,
		/// <summary>
		/// IEC 61966-2-4
		/// </summary>
		Iec61966_2_4 = 11,
		/// <summary>
		/// ITU-R BT1361 Extended Colour Gamut
		/// </summary>
		Bt1361Ecg = 12,
		/// <summary>
		/// IEC 61966-2-1 (sRGB or sYCC)
		/// </summary>
		Iec61966_2_1 = 13,
		/// <summary>
		/// ITU-R BT2020 for 10-bit system
		/// </summary>
		Bt2020_10 = 14,
		/// <summary>
		/// ITU-R BT2020 for 12-bit system
		/// </summary>
		Bt2020_12 = 15,
		/// <summary>
		/// SMPTE ST 2084 for 10-, 12-, 14- and 16-bit systems
		/// </summary>
		Smpte2084 = 16,
		Smptest2084 = 16,
		/// <summary>
		/// SMPTE ST 428-1
		/// </summary>
		Smpte428 = 17,
		Smptest428_1 = 17,
		/// <summary>
		/// ARIB STD-B67, known as &quot;Hybrid log-gamma&quot;
		/// </summary>
		AribStdB67 = 18,
		/// <summary>
		/// Not part of ABI
		/// </summary>
		Nb = 19,
	}

	public enum AVCpuFlag : uint {
		Xop = 0x400,
		Vsx = 0x2,
		Vfpv3 = 0x1 << 0x4,
		VfpVm = 0x1 << 0x7,
		Vfp = 0x1 << 0x3,
		Ssse3slow = 0x4000000,
		Ssse3 = 0x80,
		Sse42 = 0x200,
		Sse4 = 0x100,
		Sse3slow = 0x20000000,
		Sse3 = 0x40,
		Sse2slow = 0x40000000,
		Sse2 = 0x10,
		Sse = 0x8,
		Setend = 0x1 << 0x10,
		Power8 = 0x4,
		Neon = 0x1 << 0x5,
		Mmxext = 0x2,
		Mmx2 = 0x2,
		Mmx = 0x1,
		Force = 0x80000000U,
		Fma4 = 0x800,
		Fma3 = 0x10000,
		Cmov = 0x1000,
		Bmi2 = 0x40000,
		Bmi1 = 0x20000,
		AVXslow = 0x8000000,
		Avx512 = 0x100000,
		Avx2 = 0x8000,
		Avx = 0x4000,
		Atom = 0x10000000,
		Armv8 = 0x1 << 0x6,
		Armv6t2 = 0x1 << 0x2,
		Armv6 = 0x1 << 0x1,
		Armv5te = 0x1 << 0x0,
		Altivec = 0x1,
		Aesni = 0x80000,
		_3dnowext = 0x20,
		_3dnow = 0x4,
	}

	/// <summary>
	/// Message types used by avdevice_dev_to_app_control_message().
	/// </summary>
	public enum AVDevToAppMessageType : int {
		/// <summary>
		/// Dummy message.
		/// </summary>
		None = 1313820229,
		/// <summary>
		/// Create window buffer message.
		/// </summary>
		CreateWindowBuffer = 1111708229,
		/// <summary>
		/// Prepare window buffer message.
		/// </summary>
		PrepareWindowBuffer = 1112560197,
		/// <summary>
		/// Display window buffer message.
		/// </summary>
		DisplayWindowBuffer = 1111771475,
		/// <summary>
		/// Destroy window buffer message.
		/// </summary>
		DestroyWindowBuffer = 1111770451,
		/// <summary>
		/// Buffer fullness status messages.
		/// </summary>
		BufferOverflow = 1112491596,
		/// <summary>
		/// Buffer fullness status messages.
		/// </summary>
		BufferUnderflow = 1112884812,
		/// <summary>
		/// Buffer readable/writable.
		/// </summary>
		BufferReadable = 1112687648,
		/// <summary>
		/// Buffer readable/writable.
		/// </summary>
		BufferWritable = 1113018912,
		/// <summary>
		/// Mute state change message.
		/// </summary>
		MuteStateChanged = 1129141588,
		/// <summary>
		/// Volume level change message.
		/// </summary>
		VolumeLevelChanged = 1129729868,
	}

	public enum AVDict : int {
		Append = 0x20,
		DontOverwrite = 0x10,
		DontStrdupKey = 0x4,
		DontStrdupVal = 0x8,
		IgnoreSuffix = 0x2,
		MatchCase = 0x1,
		Multikey = 0x40,
	}

	public enum AVDiscard : int {
		/// <summary>
		/// discard nothing
		/// </summary>
		None = -16,
		/// <summary>
		/// discard useless packets like 0 size packets in avi
		/// </summary>
		Default = 0,
		/// <summary>
		/// discard all non reference
		/// </summary>
		Nonref = 8,
		/// <summary>
		/// discard all bidirectional frames
		/// </summary>
		Bidir = 16,
		/// <summary>
		/// discard all non intra frames
		/// </summary>
		Nonintra = 24,
		/// <summary>
		/// discard all frames except keyframes
		/// </summary>
		Nonkey = 32,
		/// <summary>
		/// discard all
		/// </summary>
		All = 48,
	}

	public enum AVDisposition : int {
		VisualImpaired = 0x100,
		TimedThumbnails = 0x800,
		Original = 0x4,
		Metadata = 0x40000,
		Lyrics = 0x10,
		Karaoke = 0x20,
		HearingImpaired = 0x80,
		Forced = 0x40,
		Dub = 0x2,
		Descriptions = 0x20000,
		Dependent = 0x80000,
		Default = 0x1,
		Comment = 0x8,
		CleanEffects = 0x200,
		Captions = 0x10000,
		AttachedPic = 0x400,
	}

	/// <summary>
	/// The duration of a video can be estimated through various ways, and this enum can be used to know how the duration was estimated.
	/// </summary>
	public enum AVDurationEstimationMethod : int {
		/// <summary>
		/// Duration accurately estimated from PTSes
		/// </summary>
		Pts = 0,
		/// <summary>
		/// Duration estimated from a stream with a known duration
		/// </summary>
		Stream = 1,
		/// <summary>
		/// Duration estimated from bitrate (less accurate)
		/// </summary>
		Bitrate = 2,
	}

	public enum AVEf : int {
		Aggressive = 0x1 << 0x12,
		Bitstream = 0x1 << 0x1,
		Buffer = 0x1 << 0x2,
		Careful = 0x1 << 0x10,
		Compliant = 0x1 << 0x11,
		Crccheck = 0x1 << 0x0,
		Explode = 0x1 << 0x3,
		IgnoreErr = 0x1 << 0xf,
	}

	public enum AVError : int {
		BsfNotFound = -(0xf8 | ('B' << 8) | ('S' << 16) | ('F' << 24)),
		BufferTooSmall = -('B' | ('U' << 8) | ('F' << 16) | ('S' << 24)),
		Bug = -('B' | ('U' << 8) | ('G' << 16) | ('!' << 24)),
		Bug2 = -('B' | ('U' << 8) | ('G' << 16) | (' ' << 24)),
		DecoderNotFound = -(0xf8 | ('D' << 8) | ('E' << 16) | ('C' << 24)),
		DemuxerNotFound = -(0xf8 | ('D' << 8) | ('E' << 16) | ('M' << 24)),
		EncoderNotFound = -(0xf8 | ('E' << 8) | ('N' << 16) | ('C' << 24)),
		Eof = -('E' | ('O' << 8) | ('F' << 16) | (' ' << 24)),
		Exit = -('E' | ('X' << 8) | ('I' << 16) | ('T' << 24)),
		Experimental = -0x2bb2afa8,
		External = -('E' | ('X' << 8) | ('T' << 16) | (' ' << 24)),
		FilterNotFound = -(0xf8 | ('F' << 8) | ('I' << 16) | ('L' << 24)),
		HttpBadRequest = -(0xf8 | ('4' << 8) | ('0' << 16) | ('0' << 24)),
		HttpForbidden = -(0xf8 | ('4' << 8) | ('0' << 16) | ('3' << 24)),
		HttpNotFound = -(0xf8 | ('4' << 8) | ('0' << 16) | ('4' << 24)),
		HttpOther_4xx = -(0xf8 | ('4' << 8) | ('X' << 16) | ('X' << 24)),
		HttpServerError = -(0xf8 | ('5' << 8) | ('X' << 16) | ('X' << 24)),
		HttpUnauthorized = -(0xf8 | ('4' << 8) | ('0' << 16) | ('1' << 24)),
		InputChanged = -0x636e6701,
		Invaliddata = -('I' | ('N' << 8) | ('D' << 16) | ('A' << 24)),
		MuxerNotFound = -(0xf8 | ('M' << 8) | ('U' << 16) | ('X' << 24)),
		OptionNotFound = -(0xf8 | ('O' << 8) | ('P' << 16) | ('T' << 24)),
		OutputChanged = -0x636e6702,
		Patchwelcome = -('P' | ('A' << 8) | ('W' << 16) | ('E' << 24)),
		ProtocolNotFound = -(0xf8 | ('P' << 8) | ('R' << 16) | ('O' << 24)),
		StreamNotFound = -(0xf8 | ('S' << 8) | ('T' << 16) | ('R' << 24)),
		Unknown = -('U' | ('N' << 8) | ('K' << 16) | ('N' << 24)),
	}

	public enum AVFieldOrder : int {
		Unknown = 0,
		Progressive = 1,
		Tt = 2,
		Bb = 3,
		Tb = 4,
		Bt = 5,
	}

	/// <summary>
	/// stage of the initialization of the link properties (dimensions, etc)
	/// </summary>
	public enum AVFilterLink_InitState : int {
		/// <summary>
		/// not started
		/// </summary>
		Uninit = 0,
		/// <summary>
		/// started, but incomplete
		/// </summary>
		Startinit = 1,
		/// <summary>
		/// complete
		/// </summary>
		Init = 2,
	}

	public enum AVFmt : int {
		VariableFps = 0x400,
		TsNonstrict = 0x20000,
		TsNegative = 0x40000,
		TsDiscont = 0x200,
		ShowIds = 0x8,
		SeekToPts = 0x4000000,
		Notimestamps = 0x80,
		Nostreams = 0x1000,
		Nogensearch = 0x4000,
		Nofile = 0x1,
		Nodimensions = 0x800,
		Nobinsearch = 0x2000,
		NoByteSeek = 0x8000,
		Neednumber = 0x2,
		Globalheader = 0x40,
		GenericIndex = 0x100,
		EventFlagMetadataUpdated = 0x1,
		AVOidNegTsMakeZero = 0x2,
		AVOidNegTsMakeNonNegative = 0x1,
		AVOidNegTsAuto = -0x1,
		AllowFlush = 0x10000,
	}

	[Flags]
	public enum AVFmtFlag : int {
		SortDts = 0x10000,
		Shortest = 0x100000,
		PrivOpt = 0x20000,
		Noparse = 0x20,
		Nonblock = 0x4,
		Nofillin = 0x10,
		Nobuffer = 0x40,
		Mp4aLatm = 0x8000,
		KeepSideData = 0x40000,
		Ignidx = 0x2,
		Igndts = 0x8,
		Genpts = 0x1,
		FlushPackets = 0x200,
		FastSeek = 0x80000,
		DiscardCorrupt = 0x100,
		CustomIO = 0x80,
		Bitexact = 0x400,
		AutoBsf = 0x200000,
	}

	public enum AVFmtctx : int {
		Unseekable = 0x2,
		Noheader = 0x1,
	}

	public enum AVFrameFlag : int {
		Discard = 0x1 << 0x2,
		Corrupt = 0x1 << 0x0,
	}

	/// <summary>
	/// @{ AVFrame is an abstraction for reference-counted raw multimedia data.
	/// </summary>
	public enum AVFrameSideDataType : int {
		/// <summary>
		/// The data is the AVPanScan struct defined in libavcodec.
		/// </summary>
		Panscan = 0,
		/// <summary>
		/// ATSC A53 Part 4 Closed Captions. A53 CC bitstream is stored as uint8_t in AVFrameSideData.data. The number of bytes of CC data is AVFrameSideData.size.
		/// </summary>
		A53Cc = 1,
		/// <summary>
		/// Stereoscopic 3d metadata. The data is the AVStereo3D struct defined in libavutil/stereo3d.h.
		/// </summary>
		Stereo3d = 2,
		/// <summary>
		/// The data is the AVMatrixEncoding enum defined in libavutil/channel_layout.h.
		/// </summary>
		Matrixencoding = 3,
		/// <summary>
		/// Metadata relevant to a downmix procedure. The data is the AVDownmixInfo struct defined in libavutil/downmix_info.h.
		/// </summary>
		DownmixInfo = 4,
		/// <summary>
		/// ReplayGain information in the form of the AVReplayGain struct.
		/// </summary>
		Replaygain = 5,
		/// <summary>
		/// This side data contains a 3x3 transformation matrix describing an affine transformation that needs to be applied to the frame for correct presentation.
		/// </summary>
		Displaymatrix = 6,
		/// <summary>
		/// Active Format Description data consisting of a single byte as specified in ETSI TS 101 154 using AVActiveFormatDescription enum.
		/// </summary>
		Afd = 7,
		/// <summary>
		/// Motion vectors exported by some codecs (on demand through the export_mvs flag set in the libavcodec AVCodecContext flags2 option). The data is the AVMotionVector struct defined in libavutil/motion_vector.h.
		/// </summary>
		MotionVectors = 8,
		/// <summary>
		/// Recommmends skipping the specified number of samples. This is exported only if the &quot;skip_manual&quot; AVOption is set in libavcodec. This has the same format as AV_PKT_DATA_SKIP_SAMPLES.
		/// </summary>
		SkipSamples = 9,
		/// <summary>
		/// This side data must be associated with an audio frame and corresponds to enum AVAudioServiceType defined in avcodec.h.
		/// </summary>
		AudioServiceType = 10,
		/// <summary>
		/// Mastering display metadata associated with a video frame. The payload is an AVMasteringDisplayMetadata type and contains information about the mastering display color volume.
		/// </summary>
		MasteringDisplayMetadata = 11,
		/// <summary>
		/// The GOP timecode in 25 bit timecode format. Data format is 64-bit integer. This is set on the first frame of a GOP that has a temporal reference of 0.
		/// </summary>
		GopTimecode = 12,
		/// <summary>
		/// The data represents the AVSphericalMapping structure defined in libavutil/spherical.h.
		/// </summary>
		Spherical = 13,
		/// <summary>
		/// Content light level (based on CTA-861.3). This payload contains data in the form of the AVContentLightMetadata struct.
		/// </summary>
		ContentLightLevel = 14,
		/// <summary>
		/// The data contains an ICC profile as an opaque octet buffer following the format described by ISO 15076-1 with an optional name defined in the metadata key entry &quot;name&quot;.
		/// </summary>
		IccProfile = 15,
		/// <summary>
		/// Implementation-specific description of the format of AV_FRAME_QP_TABLE_DATA. The contents of this side data are undocumented and internal; use av_frame_set_qp_table() and av_frame_get_qp_table() to access this in a meaningful way instead.
		/// </summary>
		QpTableProperties = 16,
		/// <summary>
		/// Raw QP table data. Its format is described by AV_FRAME_DATA_QP_TABLE_PROPERTIES. Use av_frame_set_qp_table() and av_frame_get_qp_table() to access this instead.
		/// </summary>
		QpTableData = 17,
	}

	public enum AVHave : long {
		Bigendian = 0x0,
		FastUnaligned = 0x1,
	}

	public enum AVHwaccel : int {
		CodecCapExperimental = 0x200,
		FlagAllowHighDepth = 0x1 << 0x1,
		FlagAllowProfileMismatch = 0x1 << 0x2,
		FlagIgnoreLevel = 0x1 << 0x0,
	}

	public enum AVHWDeviceType : int {
		None = 0,
		Vdpau = 1,
		Cuda = 2,
		Vaapi = 3,
		Dxva2 = 4,
		Qsv = 5,
		Videotoolbox = 6,
		D3d11va = 7,
		Drm = 8,
		Opencl = 9,
		Mediacodec = 10,
	}

	public enum AVHWFrameTransferDirection : int {
		/// <summary>
		/// Transfer the data from the queried hw frame.
		/// </summary>
		From = 0,
		/// <summary>
		/// Transfer the data to the queried hw frame.
		/// </summary>
		To = 1,
	}

	public enum AVIndex : int {
		Keyframe = 0x1,
		DiscardFrame = 0x2,
	}

	public enum AVInputBuffer : int {
		MinSize = 0x4000,
		PaddingSize = 0x40,
	}

	public enum AVIo : int {
		FlagDirect = 0x8000,
		FlagNonblock = 0x8,
		FlagRead = 0x1,
		FlagReadWrite = FlagRead | FlagWrite,
		FlagWrite = 0x2,
		SeekableNormal = 0x1 << 0x0,
		SeekableTime = 0x1 << 0x1,
	}

	/// <summary>
	/// Different data types that can be returned via the AVIO write_data_type callback.
	/// </summary>
	public enum AVIODataMarkerType : int {
		/// <summary>
		/// Header data; this needs to be present for the stream to be decodeable.
		/// </summary>
		Header = 0,
		/// <summary>
		/// A point in the output bytestream where a decoder can start decoding (i.e. a keyframe). A demuxer/decoder given the data flagged with AVIO_DATA_MARKER_HEADER, followed by any AVIO_DATA_MARKER_SYNC_POINT, should give decodeable results.
		/// </summary>
		SyncPoint = 1,
		/// <summary>
		/// A point in the output bytestream where a demuxer can start parsing (for non self synchronizing bytestream formats). That is, any non-keyframe packet start point.
		/// </summary>
		BoundaryPoint = 2,
		/// <summary>
		/// This is any, unlabelled data. It can either be a muxer not marking any positions at all, it can be an actual boundary/sync point that the muxer chooses not to mark, or a later part of a packet/fragment that is cut into multiple write callbacks due to limited IO buffer size.
		/// </summary>
		Unknown = 3,
		/// <summary>
		/// Trailer data, which doesn&apos;t contain actual content, but only for finalizing the output file.
		/// </summary>
		Trailer = 4,
		/// <summary>
		/// A point in the output bytestream where the underlying AVIOContext might flush the buffer depending on latency or buffering requirements. Typically means the end of a packet.
		/// </summary>
		FlushPoint = 5,
	}

	/// <summary>
	/// Directory entry types.
	/// </summary>
	public enum AVIODirEntryType : int {
		Unknown = 0,
		BlockDevice = 1,
		CharacterDevice = 2,
		Directory = 3,
		NamedPipe = 4,
		SymbolicLink = 5,
		Socket = 6,
		File = 7,
		Server = 8,
		Share = 9,
		Workgroup = 10,
	}

	/// <summary>
	/// Lock operation used by lockmgr
	/// </summary>
	public enum AVLockOp : int {
		/// <summary>
		/// Create a mutex
		/// </summary>
		Create = 0,
		/// <summary>
		/// Lock the mutex
		/// </summary>
		Obtain = 1,
		/// <summary>
		/// Unlock the mutex
		/// </summary>
		Release = 2,
		/// <summary>
		/// Free mutex resources
		/// </summary>
		Destroy = 3,
	}

	public enum AVLog : long {
		Debug = 0x30,
		Error = 0x10,
		Fatal = 0x8,
		Info = 0x20,
		MaxOffset = Trace - Quiet,
		Panic = 0x0,
		PrintLevel = 0x2,
		Quiet = -0x8,
		SkipRepeated = 0x1,
		Trace = 0x38,
		Verbose = 0x28,
		Warning = 0x18,
	}

	public enum AVMatrixEncoding : int {
		None = 0,
		Dolby = 1,
		Dplii = 2,
		Dpliix = 3,
		Dpliiz = 4,
		Dolbyex = 5,
		Dolbyheadphone = 6,
		Nb = 7,
	}

	/// <summary>
	/// Media Type
	/// </summary>
	public enum AVMediaType : int {
		/// <summary>
		/// Usually treated as AVMEDIA_TYPE_DATA
		/// </summary>
		Unknown = -1,
		Video = 0,
		Audio = 1,
		/// <summary>
		/// Opaque data information usually continuous
		/// </summary>
		Data = 2,
		Subtitle = 3,
		/// <summary>
		/// Opaque data information usually sparse
		/// </summary>
		Attachment = 4,
		Nb = 5,
	}

	public enum AVOpt : int {
		FlagSubtitleParam = 0x20,
		FlagReadonly = 0x80,
		FlagFilteringParam = 0x1 << 0x10,
		FlagExport = 0x40,
		FlagEncodingParam = 0x1,
		FlagDecodingParam = 0x2,
		FlagBsfParam = 0x1 << 0x8,
		FlagAudioParam = 0x8,
		AllowNull = 0x1 << 0x2,
		FlagVideoParam = 0x10,
		MultiComponentRange = 0x1 << 0xc,
		SearchChildren = 0x1 << 0x0,
		SearchFakeObj = 0x1 << 0x1,
		SerializeOptFlagsExact = 0x2,
		SerializeSkipDefaults = 0x1,
	}

	/// <summary>
	/// @{ AVOptions provide a generic system to declare options on arbitrary structs (&quot;objects&quot;). An option can have a help text, a type and a range of possible values. Options may then be enumerated, read and written to.
	/// </summary>
	public enum AVOptionType : int {
		Flags = 0,
		Int = 1,
		Int64 = 2,
		Double = 3,
		Float = 4,
		String = 5,
		Rational = 6,
		/// <summary>
		/// offset must point to a pointer immediately followed by an int for the length
		/// </summary>
		Binary = 7,
		Dict = 8,
		Uint64 = 9,
		Const = 10,
		/// <summary>
		/// offset must point to two consecutive integers
		/// </summary>
		ImageSize = 11,
		PixelFmt = 12,
		SampleFmt = 13,
		/// <summary>
		/// offset must point to AVRational
		/// </summary>
		VideoRate = 14,
		Duration = 15,
		Color = 16,
		ChannelLayout = 17,
		Bool = 18,
	}

	/// <summary>
	/// Types and functions for working with AVPacket. @{
	/// </summary>
	public enum AVPacketSideDataType : int {
		/// <summary>
		/// An AV_PKT_DATA_PALETTE side data packet contains exactly AVPALETTE_SIZE bytes worth of palette. This side data signals that a new palette is present.
		/// </summary>
		Palette = 0,
		/// <summary>
		/// The AV_PKT_DATA_NEW_EXTRADATA is used to notify the codec or the format that the extradata buffer was changed and the receiving side should act upon it appropriately. The new extradata is embedded in the side data buffer and should be immediately used for processing the current frame or packet.
		/// </summary>
		NewExtradata = 1,
		/// <summary>
		/// An AV_PKT_DATA_PARAM_CHANGE side data packet is laid out as follows:
		/// </summary>
		ParamChange = 2,
		/// <summary>
		/// An AV_PKT_DATA_H263_MB_INFO side data packet contains a number of structures with info about macroblocks relevant to splitting the packet into smaller packets on macroblock edges (e.g. as for RFC 2190). That is, it does not necessarily contain info about all macroblocks, as long as the distance between macroblocks in the info is smaller than the target payload size. Each MB info structure is 12 bytes, and is laid out as follows:
		/// </summary>
		H263MbInfo = 3,
		/// <summary>
		/// This side data should be associated with an audio stream and contains ReplayGain information in form of the AVReplayGain struct.
		/// </summary>
		Replaygain = 4,
		/// <summary>
		/// This side data contains a 3x3 transformation matrix describing an affine transformation that needs to be applied to the decoded video frames for correct presentation.
		/// </summary>
		Displaymatrix = 5,
		/// <summary>
		/// This side data should be associated with a video stream and contains Stereoscopic 3D information in form of the AVStereo3D struct.
		/// </summary>
		Stereo3d = 6,
		/// <summary>
		/// This side data should be associated with an audio stream and corresponds to enum AVAudioServiceType.
		/// </summary>
		AudioServiceType = 7,
		/// <summary>
		/// This side data contains quality related information from the encoder.
		/// </summary>
		QualityStats = 8,
		/// <summary>
		/// This side data contains an integer value representing the stream index of a &quot;fallback&quot; track. A fallback track indicates an alternate track to use when the current track can not be decoded for some reason. e.g. no decoder available for codec.
		/// </summary>
		FallbackTrack = 9,
		/// <summary>
		/// This side data corresponds to the AVCPBProperties struct.
		/// </summary>
		CpbProperties = 10,
		/// <summary>
		/// Recommmends skipping the specified number of samples
		/// </summary>
		SkipSamples = 11,
		/// <summary>
		/// An AV_PKT_DATA_JP_DUALMONO side data packet indicates that the packet may contain &quot;dual mono&quot; audio specific to Japanese DTV and if it is true, recommends only the selected channel to be used.
		/// </summary>
		JpDualmono = 12,
		/// <summary>
		/// A list of zero terminated key/value strings. There is no end marker for the list, so it is required to rely on the side data size to stop.
		/// </summary>
		StringsMetadata = 13,
		/// <summary>
		/// Subtitle event position
		/// </summary>
		SubtitlePosition = 14,
		/// <summary>
		/// Data found in BlockAdditional element of matroska container. There is no end marker for the data, so it is required to rely on the side data size to recognize the end. 8 byte id (as found in BlockAddId) followed by data.
		/// </summary>
		MatroskaBlockadditional = 15,
		/// <summary>
		/// The optional first identifier line of a WebVTT cue.
		/// </summary>
		WebvttIdentifier = 16,
		/// <summary>
		/// The optional settings (rendering instructions) that immediately follow the timestamp specifier of a WebVTT cue.
		/// </summary>
		WebvttSettings = 17,
		/// <summary>
		/// A list of zero terminated key/value strings. There is no end marker for the list, so it is required to rely on the side data size to stop. This side data includes updated metadata which appeared in the stream.
		/// </summary>
		MetadataUpdate = 18,
		/// <summary>
		/// MPEGTS stream ID, this is required to pass the stream ID information from the demuxer to the corresponding muxer.
		/// </summary>
		MpegtsStreamId = 19,
		/// <summary>
		/// Mastering display metadata (based on SMPTE-2086:2014). This metadata should be associated with a video stream and contains data in the form of the AVMasteringDisplayMetadata struct.
		/// </summary>
		MasteringDisplayMetadata = 20,
		/// <summary>
		/// This side data should be associated with a video stream and corresponds to the AVSphericalMapping structure.
		/// </summary>
		Spherical = 21,
		/// <summary>
		/// Content light level (based on CTA-861.3). This metadata should be associated with a video stream and contains data in the form of the AVContentLightMetadata struct.
		/// </summary>
		ContentLightLevel = 22,
		/// <summary>
		/// ATSC A53 Part 4 Closed Captions. This metadata should be associated with a video stream. A53 CC bitstream is stored as uint8_t in AVPacketSideData.data. The number of bytes of CC data is AVPacketSideData.size.
		/// </summary>
		A53Cc = 23,
		/// <summary>
		/// This side data is encryption initialization data. The format is not part of ABI, use av_encryption_init_info_* methods to access.
		/// </summary>
		EncryptionInitInfo = 24,
		/// <summary>
		/// This side data contains encryption info for how to decrypt the packet. The format is not part of ABI, use av_encryption_info_* methods to access.
		/// </summary>
		EncryptionInfo = 25,
		/// <summary>
		/// The number of side data types. This is not part of the public API/ABI in the sense that it may change when new side data types are added. This must stay the last enum value. If its value becomes huge, some code using it needs to be updated as it assumes it to be smaller than other limits.
		/// </summary>
		Nb = 26,
	}

	public enum AVPalette : long {
		Count = 0x100,
		Size = 0x400,
	}

	/// <summary>
	/// @{
	/// </summary>
	public enum AVPictureStructure : int {
		Unknown = 0,
		TopField = 1,
		BottomField = 2,
		Frame = 3,
	}

	/// <summary>
	/// @} @}
	/// </summary>
	public enum AVPictureType : int {
		/// <summary>
		/// Undefined
		/// </summary>
		None = 0,
		/// <summary>
		/// Intra
		/// </summary>
		I = 1,
		/// <summary>
		/// Predicted
		/// </summary>
		P = 2,
		/// <summary>
		/// Bi-dir predicted
		/// </summary>
		B = 3,
		/// <summary>
		/// S(GMC)-VOP MPEG-4
		/// </summary>
		S = 4,
		/// <summary>
		/// Switching Intra
		/// </summary>
		Si = 5,
		/// <summary>
		/// Switching Predicted
		/// </summary>
		Sp = 6,
		/// <summary>
		/// BI type
		/// </summary>
		Bi = 7,
	}

	/// <summary>
	/// Pixel format.
	/// </summary>
	public enum AVPixelFormat : int {
		None = -1,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, (1 Cr &amp; Cb sample per 2x2 Y samples)
		/// </summary>
		Yuv420p = 0,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr
		/// </summary>
		Yuyv422 = 1,
		/// <summary>
		/// packed RGB 8:8:8, 24bpp, RGBRGB...
		/// </summary>
		Rgb24 = 2,
		/// <summary>
		/// packed RGB 8:8:8, 24bpp, BGRBGR...
		/// </summary>
		Bgr24 = 3,
		/// <summary>
		/// planar YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)
		/// </summary>
		Yuv422p = 4,
		/// <summary>
		/// planar YUV 4:4:4, 24bpp, (1 Cr &amp; Cb sample per 1x1 Y samples)
		/// </summary>
		Yuv444p = 5,
		/// <summary>
		/// planar YUV 4:1:0, 9bpp, (1 Cr &amp; Cb sample per 4x4 Y samples)
		/// </summary>
		Yuv410p = 6,
		/// <summary>
		/// planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples)
		/// </summary>
		Yuv411p = 7,
		/// <summary>
		/// Y , 8bpp
		/// </summary>
		Gray8 = 8,
		/// <summary>
		/// Y , 1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb
		/// </summary>
		Monowhite = 9,
		/// <summary>
		/// Y , 1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb
		/// </summary>
		Monoblack = 10,
		/// <summary>
		/// 8 bits with AV_PIX_FMT_RGB32 palette
		/// </summary>
		Pal8 = 11,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV420P and setting color_range
		/// </summary>
		Yuvj420p = 12,
		/// <summary>
		/// planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV422P and setting color_range
		/// </summary>
		Yuvj422p = 13,
		/// <summary>
		/// planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV444P and setting color_range
		/// </summary>
		Yuvj444p = 14,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1
		/// </summary>
		Uyvy422 = 15,
		/// <summary>
		/// packed YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3
		/// </summary>
		Uyyvyy411 = 16,
		/// <summary>
		/// packed RGB 3:3:2, 8bpp, (msb)2B 3G 3R(lsb)
		/// </summary>
		Bgr8 = 17,
		/// <summary>
		/// packed RGB 1:2:1 bitstream, 4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
		/// </summary>
		Bgr4 = 18,
		/// <summary>
		/// packed RGB 1:2:1, 8bpp, (msb)1B 2G 1R(lsb)
		/// </summary>
		Bgr4Byte = 19,
		/// <summary>
		/// packed RGB 3:3:2, 8bpp, (msb)2R 3G 3B(lsb)
		/// </summary>
		Rgb8 = 20,
		/// <summary>
		/// packed RGB 1:2:1 bitstream, 4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits
		/// </summary>
		Rgb4 = 21,
		/// <summary>
		/// packed RGB 1:2:1, 8bpp, (msb)1R 2G 1B(lsb)
		/// </summary>
		Rgb4Byte = 22,
		/// <summary>
		/// planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)
		/// </summary>
		Nv12 = 23,
		/// <summary>
		/// as above, but U and V bytes are swapped
		/// </summary>
		Nv21 = 24,
		/// <summary>
		/// packed ARGB 8:8:8:8, 32bpp, ARGBARGB...
		/// </summary>
		Argb = 25,
		/// <summary>
		/// packed RGBA 8:8:8:8, 32bpp, RGBARGBA...
		/// </summary>
		Rgba = 26,
		/// <summary>
		/// packed ABGR 8:8:8:8, 32bpp, ABGRABGR...
		/// </summary>
		Abgr = 27,
		/// <summary>
		/// packed BGRA 8:8:8:8, 32bpp, BGRABGRA...
		/// </summary>
		Bgra = 28,
		/// <summary>
		/// Y , 16bpp, big-endian
		/// </summary>
		Gray16be = 29,
		/// <summary>
		/// Y , 16bpp, little-endian
		/// </summary>
		Gray16le = 30,
		/// <summary>
		/// planar YUV 4:4:0 (1 Cr &amp; Cb sample per 1x2 Y samples)
		/// </summary>
		Yuv440p = 31,
		/// <summary>
		/// planar YUV 4:4:0 full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV440P and setting color_range
		/// </summary>
		Yuvj440p = 32,
		/// <summary>
		/// planar YUV 4:2:0, 20bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples)
		/// </summary>
		Yuva420p = 33,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian
		/// </summary>
		Rgb48be = 34,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian
		/// </summary>
		Rgb48le = 35,
		/// <summary>
		/// packed RGB 5:6:5, 16bpp, (msb) 5R 6G 5B(lsb), big-endian
		/// </summary>
		Rgb565be = 36,
		/// <summary>
		/// packed RGB 5:6:5, 16bpp, (msb) 5R 6G 5B(lsb), little-endian
		/// </summary>
		Rgb565le = 37,
		/// <summary>
		/// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), big-endian , X=unused/undefined
		/// </summary>
		Rgb555be = 38,
		/// <summary>
		/// packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), little-endian, X=unused/undefined
		/// </summary>
		Rgb555le = 39,
		/// <summary>
		/// packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), big-endian
		/// </summary>
		Bgr565be = 40,
		/// <summary>
		/// packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), little-endian
		/// </summary>
		Bgr565le = 41,
		/// <summary>
		/// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), big-endian , X=unused/undefined
		/// </summary>
		Bgr555be = 42,
		/// <summary>
		/// packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), little-endian, X=unused/undefined
		/// </summary>
		Bgr555le = 43,
		/// <summary>
		/// HW acceleration through VA API at motion compensation entry-point, Picture.data[3] contains a vaapi_render_state struct which contains macroblocks as well as various fields extracted from headers
		/// </summary>
		VaapiMoco = 44,
		/// <summary>
		/// HW acceleration through VA API at IDCT entry-point, Picture.data[3] contains a vaapi_render_state struct which contains fields extracted from headers
		/// </summary>
		VaapiIdct = 45,
		/// <summary>
		/// HW decoding through VA API, Picture.data[3] contains a VASurfaceID
		/// </summary>
		VaapiVld = 46,
		/// <summary>
		/// @}
		/// </summary>
		Vaapi = 46,
		/// <summary>
		/// planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p16le = 47,
		/// <summary>
		/// planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p16be = 48,
		/// <summary>
		/// planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p16le = 49,
		/// <summary>
		/// planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p16be = 50,
		/// <summary>
		/// planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p16le = 51,
		/// <summary>
		/// planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p16be = 52,
		/// <summary>
		/// HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer
		/// </summary>
		Dxva2Vld = 53,
		/// <summary>
		/// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), little-endian, X=unused/undefined
		/// </summary>
		Rgb444le = 54,
		/// <summary>
		/// packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), big-endian, X=unused/undefined
		/// </summary>
		Rgb444be = 55,
		/// <summary>
		/// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), little-endian, X=unused/undefined
		/// </summary>
		Bgr444le = 56,
		/// <summary>
		/// packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), big-endian, X=unused/undefined
		/// </summary>
		Bgr444be = 57,
		/// <summary>
		/// 8 bits gray, 8 bits alpha
		/// </summary>
		Ya8 = 58,
		/// <summary>
		/// alias for AV_PIX_FMT_YA8
		/// </summary>
		Y400a = 58,
		/// <summary>
		/// alias for AV_PIX_FMT_YA8
		/// </summary>
		Gray8a = 58,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian
		/// </summary>
		Bgr48be = 59,
		/// <summary>
		/// packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian
		/// </summary>
		Bgr48le = 60,
		/// <summary>
		/// planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p9be = 61,
		/// <summary>
		/// planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p9le = 62,
		/// <summary>
		/// planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p10be = 63,
		/// <summary>
		/// planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p10le = 64,
		/// <summary>
		/// planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p10be = 65,
		/// <summary>
		/// planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p10le = 66,
		/// <summary>
		/// planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p9be = 67,
		/// <summary>
		/// planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p9le = 68,
		/// <summary>
		/// planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p10be = 69,
		/// <summary>
		/// planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p10le = 70,
		/// <summary>
		/// planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p9be = 71,
		/// <summary>
		/// planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p9le = 72,
		/// <summary>
		/// planar GBR 4:4:4 24bpp
		/// </summary>
		Gbrp = 73,
		Gbr24p = 73,
		/// <summary>
		/// planar GBR 4:4:4 27bpp, big-endian
		/// </summary>
		Gbrp9be = 74,
		/// <summary>
		/// planar GBR 4:4:4 27bpp, little-endian
		/// </summary>
		Gbrp9le = 75,
		/// <summary>
		/// planar GBR 4:4:4 30bpp, big-endian
		/// </summary>
		Gbrp10be = 76,
		/// <summary>
		/// planar GBR 4:4:4 30bpp, little-endian
		/// </summary>
		Gbrp10le = 77,
		/// <summary>
		/// planar GBR 4:4:4 48bpp, big-endian
		/// </summary>
		Gbrp16be = 78,
		/// <summary>
		/// planar GBR 4:4:4 48bpp, little-endian
		/// </summary>
		Gbrp16le = 79,
		/// <summary>
		/// planar YUV 4:2:2 24bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples)
		/// </summary>
		Yuva422p = 80,
		/// <summary>
		/// planar YUV 4:4:4 32bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples)
		/// </summary>
		Yuva444p = 81,
		/// <summary>
		/// planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), big-endian
		/// </summary>
		Yuva420p9be = 82,
		/// <summary>
		/// planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), little-endian
		/// </summary>
		Yuva420p9le = 83,
		/// <summary>
		/// planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), big-endian
		/// </summary>
		Yuva422p9be = 84,
		/// <summary>
		/// planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), little-endian
		/// </summary>
		Yuva422p9le = 85,
		/// <summary>
		/// planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian
		/// </summary>
		Yuva444p9be = 86,
		/// <summary>
		/// planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian
		/// </summary>
		Yuva444p9le = 87,
		/// <summary>
		/// planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva420p10be = 88,
		/// <summary>
		/// planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva420p10le = 89,
		/// <summary>
		/// planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva422p10be = 90,
		/// <summary>
		/// planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva422p10le = 91,
		/// <summary>
		/// planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva444p10be = 92,
		/// <summary>
		/// planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva444p10le = 93,
		/// <summary>
		/// planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva420p16be = 94,
		/// <summary>
		/// planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva420p16le = 95,
		/// <summary>
		/// planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva422p16be = 96,
		/// <summary>
		/// planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva422p16le = 97,
		/// <summary>
		/// planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)
		/// </summary>
		Yuva444p16be = 98,
		/// <summary>
		/// planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)
		/// </summary>
		Yuva444p16le = 99,
		/// <summary>
		/// HW acceleration through VDPAU, Picture.data[3] contains a VdpVideoSurface
		/// </summary>
		Vdpau = 100,
		/// <summary>
		/// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as little-endian, the 4 lower bits are set to 0
		/// </summary>
		Xyz12le = 101,
		/// <summary>
		/// packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as big-endian, the 4 lower bits are set to 0
		/// </summary>
		Xyz12be = 102,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)
		/// </summary>
		Nv16 = 103,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Nv20le = 104,
		/// <summary>
		/// interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Nv20be = 105,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
		/// </summary>
		Rgba64be = 106,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
		/// </summary>
		Rgba64le = 107,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian
		/// </summary>
		Bgra64be = 108,
		/// <summary>
		/// packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian
		/// </summary>
		Bgra64le = 109,
		/// <summary>
		/// packed YUV 4:2:2, 16bpp, Y0 Cr Y1 Cb
		/// </summary>
		Yvyu422 = 110,
		/// <summary>
		/// 16 bits gray, 16 bits alpha (big-endian)
		/// </summary>
		Ya16be = 111,
		/// <summary>
		/// 16 bits gray, 16 bits alpha (little-endian)
		/// </summary>
		Ya16le = 112,
		/// <summary>
		/// planar GBRA 4:4:4:4 32bpp
		/// </summary>
		Gbrap = 113,
		/// <summary>
		/// planar GBRA 4:4:4:4 64bpp, big-endian
		/// </summary>
		Gbrap16be = 114,
		/// <summary>
		/// planar GBRA 4:4:4:4 64bpp, little-endian
		/// </summary>
		Gbrap16le = 115,
		/// <summary>
		/// HW acceleration through QSV, data[3] contains a pointer to the mfxFrameSurface1 structure.
		/// </summary>
		Qsv = 116,
		/// <summary>
		/// HW acceleration though MMAL, data[3] contains a pointer to the MMAL_BUFFER_HEADER_T structure.
		/// </summary>
		Mmal = 117,
		/// <summary>
		/// HW decoding through Direct3D11 via old API, Picture.data[3] contains a ID3D11VideoDecoderOutputView pointer
		/// </summary>
		D3d11vaVld = 118,
		/// <summary>
		/// HW acceleration through CUDA. data[i] contain CUdeviceptr pointers exactly as for system memory frames.
		/// </summary>
		Cuda = 119,
		/// <summary>
		/// packed RGB 8:8:8, 32bpp, XRGBXRGB... X=unused/undefined
		/// </summary>
		_0RGB = 120,
		/// <summary>
		/// packed RGB 8:8:8, 32bpp, RGBXRGBX... X=unused/undefined
		/// </summary>
		Rgb0 = 121,
		/// <summary>
		/// packed BGR 8:8:8, 32bpp, XBGRXBGR... X=unused/undefined
		/// </summary>
		_0BGR = 122,
		/// <summary>
		/// packed BGR 8:8:8, 32bpp, BGRXBGRX... X=unused/undefined
		/// </summary>
		Bgr0 = 123,
		/// <summary>
		/// planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p12be = 124,
		/// <summary>
		/// planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p12le = 125,
		/// <summary>
		/// planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian
		/// </summary>
		Yuv420p14be = 126,
		/// <summary>
		/// planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian
		/// </summary>
		Yuv420p14le = 127,
		/// <summary>
		/// planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p12be = 128,
		/// <summary>
		/// planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p12le = 129,
		/// <summary>
		/// planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian
		/// </summary>
		Yuv422p14be = 130,
		/// <summary>
		/// planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian
		/// </summary>
		Yuv422p14le = 131,
		/// <summary>
		/// planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p12be = 132,
		/// <summary>
		/// planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p12le = 133,
		/// <summary>
		/// planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian
		/// </summary>
		Yuv444p14be = 134,
		/// <summary>
		/// planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian
		/// </summary>
		Yuv444p14le = 135,
		/// <summary>
		/// planar GBR 4:4:4 36bpp, big-endian
		/// </summary>
		Gbrp12be = 136,
		/// <summary>
		/// planar GBR 4:4:4 36bpp, little-endian
		/// </summary>
		Gbrp12le = 137,
		/// <summary>
		/// planar GBR 4:4:4 42bpp, big-endian
		/// </summary>
		Gbrp14be = 138,
		/// <summary>
		/// planar GBR 4:4:4 42bpp, little-endian
		/// </summary>
		Gbrp14le = 139,
		/// <summary>
		/// planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples) full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV411P and setting color_range
		/// </summary>
		Yuvj411p = 140,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 8-bit samples */
		/// </summary>
		BayerBggr8 = 141,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 8-bit samples */
		/// </summary>
		BayerRggb8 = 142,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 8-bit samples */
		/// </summary>
		BayerGbrg8 = 143,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 8-bit samples */
		/// </summary>
		BayerGrbg8 = 144,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerBggr16le = 145,
		/// <summary>
		/// bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerBggr16be = 146,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerRggb16le = 147,
		/// <summary>
		/// bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerRggb16be = 148,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerGbrg16le = 149,
		/// <summary>
		/// bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerGbrg16be = 150,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, little-endian */
		/// </summary>
		BayerGrbg16le = 151,
		/// <summary>
		/// bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, big-endian */
		/// </summary>
		BayerGrbg16be = 152,
		/// <summary>
		/// XVideo Motion Acceleration via common packet passing
		/// </summary>
		Xvmc = 153,
		/// <summary>
		/// planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian
		/// </summary>
		Yuv440p10le = 154,
		/// <summary>
		/// planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian
		/// </summary>
		Yuv440p10be = 155,
		/// <summary>
		/// planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian
		/// </summary>
		Yuv440p12le = 156,
		/// <summary>
		/// planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian
		/// </summary>
		Yuv440p12be = 157,
		/// <summary>
		/// packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian
		/// </summary>
		Ayuv64le = 158,
		/// <summary>
		/// packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian
		/// </summary>
		Ayuv64be = 159,
		/// <summary>
		/// hardware decoding through Videotoolbox
		/// </summary>
		Videotoolbox = 160,
		/// <summary>
		/// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, little-endian
		/// </summary>
		P010le = 161,
		/// <summary>
		/// like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, big-endian
		/// </summary>
		P010be = 162,
		/// <summary>
		/// planar GBR 4:4:4:4 48bpp, big-endian
		/// </summary>
		Gbrap12be = 163,
		/// <summary>
		/// planar GBR 4:4:4:4 48bpp, little-endian
		/// </summary>
		Gbrap12le = 164,
		/// <summary>
		/// planar GBR 4:4:4:4 40bpp, big-endian
		/// </summary>
		Gbrap10be = 165,
		/// <summary>
		/// planar GBR 4:4:4:4 40bpp, little-endian
		/// </summary>
		Gbrap10le = 166,
		/// <summary>
		/// hardware decoding through MediaCodec
		/// </summary>
		Mediacodec = 167,
		/// <summary>
		/// Y , 12bpp, big-endian
		/// </summary>
		Gray12be = 168,
		/// <summary>
		/// Y , 12bpp, little-endian
		/// </summary>
		Gray12le = 169,
		/// <summary>
		/// Y , 10bpp, big-endian
		/// </summary>
		Gray10be = 170,
		/// <summary>
		/// Y , 10bpp, little-endian
		/// </summary>
		Gray10le = 171,
		/// <summary>
		/// like NV12, with 16bpp per component, little-endian
		/// </summary>
		P016le = 172,
		/// <summary>
		/// like NV12, with 16bpp per component, big-endian
		/// </summary>
		P016be = 173,
		/// <summary>
		/// Hardware surfaces for Direct3D11.
		/// </summary>
		D3d11 = 174,
		/// <summary>
		/// Y , 9bpp, big-endian
		/// </summary>
		Gray9be = 175,
		/// <summary>
		/// Y , 9bpp, little-endian
		/// </summary>
		Gray9le = 176,
		/// <summary>
		/// IEEE-754 single precision planar GBR 4:4:4, 96bpp, big-endian
		/// </summary>
		Gbrpf32be = 177,
		/// <summary>
		/// IEEE-754 single precision planar GBR 4:4:4, 96bpp, little-endian
		/// </summary>
		Gbrpf32le = 178,
		/// <summary>
		/// IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, big-endian
		/// </summary>
		Gbrapf32be = 179,
		/// <summary>
		/// IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, little-endian
		/// </summary>
		Gbrapf32le = 180,
		/// <summary>
		/// DRM-managed buffers exposed through PRIME buffer sharing.
		/// </summary>
		DrmPrime = 181,
		/// <summary>
		/// Hardware surfaces for OpenCL.
		/// </summary>
		Opencl = 182,
		/// <summary>
		/// number of pixel formats, DO NOT USE THIS if you want to link with shared libav* because the number of formats might differ between versions
		/// </summary>
		Nb = 183,
	}

	[Flags]
	public enum AVPixFmtFlag : int {
		Alpha = 0x1 << 0x7,
		Bayer = 0x1 << 0x8,
		Be = 0x1 << 0x0,
		Bitstream = 0x1 << 0x2,
		Float = 0x1 << 0x9,
		Hwaccel = 0x1 << 0x3,
		Pal = 0x1 << 0x1,
		Planar = 0x1 << 0x4,
		Pseudopal = 0x1 << 0x6,
		Rgb = 0x1 << 0x5,
	}

	[Flags]
	public enum AVPktFlag : int {
		Corrupt = 0x2,
		Discard = 0x4,
		Disposable = 0x10,
		Key = 0x1,
		Trusted = 0x8,
	}

	public enum AVProbe : int {
		ScoreStreamRetry = ScoreMax / 0x4 - 0x1,
		ScoreRetry = ScoreMax / 0x4,
		ScoreMime = 0x4b,
		ScoreMax = 0x64,
		ScoreExtension = 0x32,
		PaddingSize = 0x20,
	}

	public enum AVPtsWrap : int {
		SubOffset = -0x1,
		Ignore = 0x0,
		AddOffset = 0x1,
	}

	/// <summary>
	/// Rounding methods.
	/// </summary>
	public enum AVRounding : int {
		/// <summary>
		/// Round toward zero.
		/// </summary>
		Zero = 0,
		/// <summary>
		/// Round away from zero.
		/// </summary>
		Inf = 1,
		/// <summary>
		/// Round toward -infinity.
		/// </summary>
		Down = 2,
		/// <summary>
		/// Round toward +infinity.
		/// </summary>
		Up = 3,
		/// <summary>
		/// Round to nearest and halfway cases away from zero.
		/// </summary>
		NearInf = 5,
		/// <summary>
		/// Flag telling rescaling functions to pass `INT64_MIN`/`MAX` through unchanged, avoiding special cases for #AV_NOPTS_VALUE.
		/// </summary>
		PassMinmax = 8192,
	}

	/// <summary>
	/// Audio sample formats
	/// </summary>
	public enum AVSampleFormat : int {
		None = -1,
		UInt8,
		Int16,
		Int32,
		Float,
		Double,
		UInt8Planar,
		Int16Planar,
		Int32Planar,
		FloatPlanar,
		DoublePlanar,
		Int64,
		Int64Planar,
		Count,
	}

	public enum AVSeek : int {
		Force = 0x20000,
		Size = 0x10000,
	}

	[Flags]
	public enum AVSeekFlag : int {
		Frame = 0x8,
		Byte = 0x2,
		Backward = 0x1,
		Any = 0x4,
	}

	public enum AVSideDataParamChangeFlags : int {
		ChannelCount = 1,
		ChannelLayout = 2,
		SampleRate = 4,
		Dimensions = 8,
	}

	/// <summary>
	/// @}
	/// </summary>
	public enum AVStreamParseType : int {
		None = 0,
		/// <summary>
		/// full parsing and repack
		/// </summary>
		Full = 1,
		/// <summary>
		/// Only parse headers, do not repack.
		/// </summary>
		Headers = 2,
		/// <summary>
		/// full parsing and interpolation of timestamps for frames not starting on a packet boundary
		/// </summary>
		Timestamps = 3,
		/// <summary>
		/// full parsing and repack of the first frame only, only implemented for H.264 currently
		/// </summary>
		FullOnce = 4,
		/// <summary>
		/// full parsing and repack with timestamp and position generation by parser for raw this assumes that each packet in the file contains no demuxer level headers and just codec level data, otherwise position generation would fail
		/// </summary>
		FullRaw = 5,
	}

	public enum AVSubtitleType : int {
		None = 0,
		/// <summary>
		/// A bitmap, pict will be set
		/// </summary>
		Bitmap = 1,
		/// <summary>
		/// Plain text, the text field must be set by the decoder and is authoritative. ass and pict fields may contain approximations.
		/// </summary>
		Text = 2,
		/// <summary>
		/// Formatted text, the ass field must be set by the decoder and is authoritative. pict and text fields may contain approximations.
		/// </summary>
		Ass = 3,
	}

	public enum AVTimebaseSource : int {
		Auto = -1,
		Decoder = 0,
		Demuxer = 1,
		RFramerate = 2,
	}

	public enum AVTimecodeFlag : int {
		/// <summary>
		/// timecode is drop frame
		/// </summary>
		Dropframe = 1,
		/// <summary>
		/// timecode wraps after 24 hours
		/// </summary>
		_24HOURSMAX = 2,
		/// <summary>
		/// negative time values are allowed
		/// </summary>
		Allownegative = 4,
	}

	public enum FFBug : uint {
		Amv = 0x20,
		Autodetect = 0x1,
		DcClip = 0x1000,
		DirectBlocksize = 0x200,
		Edge = 0x400,
		HpelChroma = 0x800,
		Iedge = 0x8000,
		Ms = 0x2000,
		NoPadding = 0x10,
		QpelChroma = 0x40,
		QpelChroma2 = 0x100,
		StdQpel = 0x80,
		Truncated = 0x4000,
		Ump4 = 0x8,
		XvidIlace = 0x4,
	}

	public enum FFCmp : uint {
		Bit = 0x5,
		Chroma = 0x100,
		Dct = 0x3,
		Dct264 = 0xe,
		Dctmax = 0xd,
		MedianSad = 0xf,
		Nsse = 0xa,
		Psnr = 0x4,
		Rd = 0x6,
		Sad = 0x0,
		Satd = 0x2,
		Sse = 0x1,
		Vsad = 0x8,
		Vsse = 0x9,
		W53 = 0xb,
		W97 = 0xc,
		Zero = 0x7,
	}

	public enum FFCodecProperty : int {
		ClosedCaptions = 0x2,
		Lossless = 0x1,
	}

	public enum FFCoderType : int {
		Ac = 0x1,
		Raw = 0x2,
		Rle = 0x3,
		Vlc = 0x0,
	}

	public enum FFCompliance : int {
		Experimental = -0x2,
		Normal = 0x0,
		Strict = 0x1,
		Unofficial = -0x1,
		VeryStrict = 0x2,
	}

	public enum FFDct : int {
		Altivec = 0x5,
		Auto = 0x0,
		Faan = 0x6,
		Fastint = 0x1,
		Int = 0x2,
		Mmx = 0x3,
	}

	public enum FFDebug : uint {
		Bitstream = 0x4,
		Buffers = 0x8000,
		Bugs = 0x1000,
		DctCoeff = 0x40,
		Er = 0x400,
		GreenMd = 0x800000,
		MbType = 0x8,
		Mmco = 0x800,
		Nomc = 0x1000000,
		PictInfo = 0x1,
		Qp = 0x10,
		Rc = 0x2,
		Skip = 0x80,
		Startcode = 0x100,
		Threads = 0x10000,
		VisMvBBack = 0x4,
		VisMvBFor = 0x2,
		VisMvPFor = 0x1,
	}

	public enum FFDecodeError : int {
		MissingReference = 0x2,
		InvalidBitstream = 0x1,
	}

	public enum FFDxva2Workaround : int {
		ScalingListZigzag = 0x1,
		IntelClearvideo = 0x2,
	}

	public enum FFEc : int {
		Deblock = 0x2,
		FavorInter = 0x100,
		GuessMvs = 0x1,
	}

	public enum FFIdct : uint {
		Altivec = 0x8,
		Arm = 0x7,
		Auto = 0x0,
		Faan = 0x14,
		Int = 0x1,
		None = 0x18,
		Simple = 0x2,
		Simplearm = 0xa,
		Simplearmv5te = 0x10,
		Simplearmv6 = 0x11,
		Simpleauto = 0x80,
		Simplemmx = 0x3,
		Simpleneon = 0x16,
		Xvid = 0xe,
	}

	[Flags]
	public enum FFLoss : int {
		Alpha = 0x8,
		Chroma = 0x20,
		Colorquant = 0x10,
		Colorspace = 0x4,
		Depth = 0x2,
		Resolution = 0x1,
	}

	public enum FFMbDecision : int {
		Bits = 0x1,
		Rd = 0x2,
		Simple = 0x0,
	}

	public enum FFPred : int {
		Left = 0x0,
		Median = 0x2,
		Plane = 0x1,
	}

	public enum FFProfile : int {
		AacEld = 0x26,
		AacHe = 0x4,
		AacHeV2 = 0x1c,
		AacLd = 0x16,
		AacLow = 0x1,
		AacLtp = 0x3,
		AacMain = 0x0,
		AacSsr = 0x2,
		Av_1High = 0x1,
		Av_1Main = 0x0,
		Av_1Professional = 0x2,
		Dnxhd = 0x0,
		Dnxhr_444 = 0x5,
		DnxhrHq = 0x3,
		DnxhrHqx = 0x4,
		DnxhrLb = 0x1,
		DnxhrSq = 0x2,
		Dts = 0x14,
		Dts_96_24 = 0x28,
		DtsEs = 0x1e,
		DtsExpress = 0x46,
		DtsHdHra = 0x32,
		DtsHdMa = 0x3c,
		H264Baseline = 0x42,
		H264Cavlc_444 = 0x2c,
		H264Constrained = 0x1 << 0x9,
		H264ConstrainedBaseline = 0x42 | H264Constrained,
		H264Extended = 0x58,
		H264High = 0x64,
		H264High_10 = 0x6e,
		H264High_10Intra = 0x6e | H264Intra,
		H264High_422 = 0x7a,
		H264High_422Intra = 0x7a | H264Intra,
		H264High_444 = 0x90,
		H264High_444Intra = 0xf4 | H264Intra,
		H264High_444Predictive = 0xf4,
		H264Intra = 0x1 << 0xb,
		H264Main = 0x4d,
		H264MultiviewHigh = 0x76,
		H264StereoHigh = 0x80,
		HevcMain = 0x1,
		HevcMain_10 = 0x2,
		HevcMainStillPicture = 0x3,
		HevcRext = 0x4,
		Jpeg2000CstreamNoRestriction = 0x8000,
		Jpeg2000CstreamRestriction_0 = 0x1,
		Jpeg2000CstreamRestriction_1 = 0x2,
		Jpeg2000Dcinema_2k = 0x3,
		Jpeg2000Dcinema_4k = 0x4,
		MjpegHuffmanBaselineDct = 0xc0,
		MjpegHuffmanExtendedSequentialDct = 0xc1,
		MjpegHuffmanLossless = 0xc3,
		MjpegHuffmanProgressiveDct = 0xc2,
		MjpegJpegLs = 0xf7,
		Mpeg2_422 = 0x0,
		Mpeg2AacHe = 0x83,
		Mpeg2AacLow = 0x80,
		Mpeg2High = 0x1,
		Mpeg2Main = 0x4,
		Mpeg2Simple = 0x5,
		Mpeg2SnrScalable = 0x3,
		Mpeg2Ss = 0x2,
		Mpeg4AdvancedCoding = 0xb,
		Mpeg4AdvancedCore = 0xc,
		Mpeg4AdvancedRealTime = 0x9,
		Mpeg4AdvancedScalableTexture = 0xd,
		Mpeg4AdvancedSimple = 0xf,
		Mpeg4BasicAnimatedTexture = 0x7,
		Mpeg4Core = 0x2,
		Mpeg4CoreScalable = 0xa,
		Mpeg4Hybrid = 0x8,
		Mpeg4Main = 0x3,
		Mpeg4NBit = 0x4,
		Mpeg4ScalableTexture = 0x5,
		Mpeg4Simple = 0x0,
		Mpeg4SimpleFaceAnimation = 0x6,
		Mpeg4SimpleScalable = 0x1,
		Mpeg4SimpleStudio = 0xe,
		Reserved = -0x64,
		SbcMsbc = 0x1,
		Unknown = -0x63,
		Vc1Advanced = 0x3,
		Vc1Complex = 0x2,
		Vc1Main = 0x1,
		Vc1Simple = 0x0,
		Vp9_0 = 0x0,
		Vp9_1 = 0x1,
		Vp9_2 = 0x2,
		Vp9_3 = 0x3,
	}

	public enum FFSub : int {
		CharencModeAutomatic = 0x0,
		CharencModeDoNothing = -0x1,
		CharencModeIgnore = 0x2,
		CharencModePreDecoder = 0x1,
		TextFmtAss = 0x0,
		TextFmtAssWithTimings = 0x1,
	}

	public enum FFThread : int {
		Frame = 0x1,
		Slice = 0x2,
	}

	public enum Max : int {
		StdTimebases = 0x1e * 0xc + 0x1e + 0x3 + 0x6,
		ReorderDelay = 0x10,
	}

	[Flags]
	public enum ParserFlag : int {
		CompleteFrames = 0x1,
		FetchedOffset = 0x4,
		Once = 0x2,
		UseCodecTs = 0x1000,
	}

	[Flags]
	public enum SliceFlag : int {
		AllowField = 0x2,
		AllowPlane = 0x4,
		CodedOrder = 0x1,
	}

	/// <summary>
	/// Dithering algorithms
	/// </summary>
	public enum SwrDitherType : int {
		None = 0,
		Rectangular = 1,
		Triangular = 2,
		TriangularHighpass = 3,
		/// <summary>
		/// not part of API/ABI
		/// </summary>
		Ns = 64,
		NsLipshitz = 65,
		NsFWeighted = 66,
		NsModifiedEWeighted = 67,
		NsImprovedEWeighted = 68,
		NsShibata = 69,
		NsLowShibata = 70,
		NsHighShibata = 71,
		/// <summary>
		/// not part of API/ABI
		/// </summary>
		Nb = 72,
	}

	/// <summary>
	/// Resampling Engines
	/// </summary>
	public enum SwrEngine : int {
		/// <summary>
		/// SW Resampler
		/// </summary>
		Swr = 0,
		/// <summary>
		/// SoX Resampler
		/// </summary>
		Soxr = 1,
		/// <summary>
		/// not part of API/ABI
		/// </summary>
		Nb = 2,
	}

	/// <summary>
	/// Resampling Filter Types
	/// </summary>
	public enum SwrFilterType : int {
		/// <summary>
		/// Cubic
		/// </summary>
		Cubic = 0,
		/// <summary>
		/// Blackman Nuttall windowed sinc
		/// </summary>
		BlackmanNuttall = 1,
		/// <summary>
		/// Kaiser windowed sinc
		/// </summary>
		Kaiser = 2,
	}

	[Flags]
	public enum SwsFlags : int {
		AccurateRnd = 0x40000,
		Area = 0x20,
		Bicubic = 0x4,
		Bicublin = 0x40,
		Bilinear = 0x2,
		Bitexact = 0x80000,
		DirectBgr = 0x8000,
		ErrorDiffusion = 0x800000,
		FastBilinear = 0x1,
		FullChrHInp = 0x4000,
		FullChrHInt = 0x2000,
		Gauss = 0x80,
		Lanczos = 0x200,
		//MaxReduceCutoff = 0.002D,
		ParamDefault = 0x1e240,
		Point = 0x10,
		PrintInfo = 0x1000,
		Sinc = 0x100,
		Spline = 0x400,
		SrcVChrDropMask = 0x30000,
		SrcVChrDropShift = 0x10,
		X = 0x8,
	}

	public enum SwsCs : int {
		Bt2020 = 0x9,
		Default = 0x5,
		Fcc = 0x4,
		Itu601 = 0x5,
		Itu624 = 0x5,
		Itu709 = 0x1,
		Smpte170m = 0x5,
		Smpte240m = 0x7,
	}
}
