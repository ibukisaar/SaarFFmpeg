using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp {
	/// <summary>
	/// 提供把不连续内存当连续内存处理的能力
	/// </summary>
	unsafe public struct UnionBuffer {
		public IntPtr SrcData1;
		public int SrcLength1;
		public IntPtr SrcData2;
		public int SrcLength2;

		public UnionBuffer(IntPtr src1, int srcLen1, IntPtr src2, int srcLen2) {
			SrcData1 = src1;
			SrcLength1 = srcLen1;
			SrcData2 = src2;
			SrcLength2 = srcLen2;
		}

		public int Length => SrcLength1 + SrcLength2;

		/// <summary>
		/// 拷贝<seealso cref="UnionBuffer"/>对象中的不连续缓冲区到连续缓冲区
		/// </summary>
		/// <param name="srcOffset">源字节偏移</param>
		/// <param name="dst">目标缓冲区</param>
		/// <param name="copyBytes">拷贝的字节数，可以大于源缓冲区长度，但会被截断</param>
		/// <returns>实际拷贝的字节数</returns>
		public int CopyTo(int srcOffset, IntPtr dst, int copyBytes) {
			copyBytes = Math.Min(Length - srcOffset, copyBytes);

			if (srcOffset >= SrcLength1) {
				srcOffset -= SrcLength1;
				Buffer.MemoryCopy((void*) (SrcData2 + srcOffset), (void*) dst, copyBytes, copyBytes);
			} else {
				int srcLen1 = SrcLength1 - srcOffset;
				if (srcLen1 >= copyBytes) {
					Buffer.MemoryCopy((void*) (SrcData1 + srcOffset), (void*) dst, copyBytes, copyBytes);
				} else {
					Buffer.MemoryCopy((void*) (SrcData1 + srcOffset), (void*) dst, srcLen1, srcLen1);
					Buffer.MemoryCopy((void*) SrcData2, (void*) (dst + srcLen1), copyBytes - srcLen1, copyBytes - srcLen1);
				}
			}
			return copyBytes;
		}

		public int CopyTo(int srcOffset, Array dst, int dstOffset, int copyBytes) {
			if (dstOffset + copyBytes > Buffer.ByteLength(dst)) throw new ArgumentOutOfRangeException();

			var handle = GCHandle.Alloc(dst, GCHandleType.Pinned);
			try {
				return CopyTo(srcOffset, handle.AddrOfPinnedObject() + dstOffset, copyBytes);
			} finally {
				handle.Free();
			}
		}
	}
}
