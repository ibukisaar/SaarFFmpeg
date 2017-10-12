using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SaarFFmpeg.FFTVisual {
	public class StreamObserver<T> where T : struct {
		public readonly static int TSize = Marshal.SizeOf<T>();

		private T[] data;
		private int fixedCount;
		private int moveCount;
		private int count;
		private int alignCount;

		public int FixedCount {
			get { return fixedCount; }
			set {
				if (value % alignCount != 0) {
					fixedCount = value + alignCount - value % alignCount;
				} else {
					fixedCount = value;
				}
			}
		}

		public int MoveCount {
			get { return moveCount; }
			set {
				if (value % alignCount != 0) {
					moveCount = value + alignCount - value % alignCount;
				} else {
					moveCount = value;
				}
			}
		}

		public int AlignCount {
			get { return alignCount; }
			set {
				if (value <= 0) value = 1;
				alignCount = value;
			}
		}

		public int Count { get { return count; } }

		public event Action<IntPtr> Completed;

		public StreamObserver(int fixedCount)
			: this(fixedCount, fixedCount) {
		}

		public StreamObserver(int fixedCount, int moveCount) : this(fixedCount, moveCount, 1) {
		}

		public StreamObserver(int fixedCount, int moveCount, int alignCount) {
			if (moveCount <= 0) throw new ArgumentException("moveCount 不能小于等于0");
			if (fixedCount < moveCount) throw new ArgumentException("fixedCount 不能小于 moveCount");

			this.AlignCount = alignCount;
			this.FixedCount = fixedCount;
			this.MoveCount = moveCount;
			this.data = new T[this.FixedCount];
			this.count = this.FixedCount - this.MoveCount;
		}

		unsafe public void Write(IntPtr data, int length) {
			if (this.data.Length < count + length) {
				Array.Resize(ref this.data, count + length);
			}
			var handle = GCHandle.Alloc(this.data, GCHandleType.Pinned);
			try {
				var dst = handle.AddrOfPinnedObject();
				Buffer.MemoryCopy((void*) data, (void*) (dst + count * TSize), TSize * length, TSize * length);
				count += length;
				if (count >= fixedCount) {
					int i;
					for (i = 0; i + fixedCount <= count; i += moveCount) {
						Completed?.Invoke(dst + i * TSize);
					}

					count -= i;
					Buffer.MemoryCopy((void*) (dst + i * TSize), (void*) dst, TSize * count, TSize * count);
				}
			} finally {
				handle.Free();
			}
		}
	}
}
