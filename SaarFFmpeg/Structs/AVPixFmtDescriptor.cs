using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Saar.FFmpeg.CSharp;

namespace Saar.FFmpeg.Structs {
	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVPixFmtDescriptor {
		public byte* Name;
		public byte NbComponents;
		public byte Log2ChromeW;
		public byte Log2ChromeH;
		public AVPixelFormatFlag Flags;
		public AVComponentDescriptor Component0;
		public AVComponentDescriptor Component1;
		public AVComponentDescriptor Component2;
		public AVComponentDescriptor Component3;
		public byte* Alias;
	}
}
