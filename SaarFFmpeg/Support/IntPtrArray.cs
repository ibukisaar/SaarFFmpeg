using Saar.FFmpeg.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Saar.FFmpeg.CSharp {
	public interface IPtrArray {
		int FixedCount { get; }
		int PtrCount { get; }
		IntPtr[] ToArray();
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct BytePtrArray8 : IPtrArray {
		public byte* _0;
		public byte* _1;
		public byte* _2;
		public byte* _3;
		public byte* _4;
		public byte* _5;
		public byte* _6;
		public byte* _7;

		public int FixedCount => 8;

		public byte* this[int index] {
			get {
				switch (index) {
					case 0: return _0;
					case 1: return _1;
					case 2: return _2;
					case 3: return _3;
					case 4: return _4;
					case 5: return _5;
					case 6: return _6;
					case 7: return _7;
					default: return null;
				}
			}
			set {
				switch (index) {
					case 0: _0 = value; break;
					case 1: _1 = value; break;
					case 2: _2 = value; break;
					case 3: _3 = value; break;
					case 4: _4 = value; break;
					case 5: _5 = value; break;
					case 6: _6 = value; break;
					case 7: _7 = value; break;
				}
			}
		}

		public int PtrCount {
			get {
				return
					_0 == null ? 0 :
					_1 == null ? 1 :
					_2 == null ? 2 :
					_3 == null ? 3 :
					_4 == null ? 4 :
					_5 == null ? 5 :
					_6 == null ? 6 :
					_7 == null ? 7 :
					8;
			}
		}

		public IntPtr[] ToArray() {
			List<IntPtr> result = new List<IntPtr>(FixedCount);
			if (_0 == null) return result.ToArray(); result.Add((IntPtr) _0);
			if (_1 == null) return result.ToArray(); result.Add((IntPtr) _1);
			if (_2 == null) return result.ToArray(); result.Add((IntPtr) _2);
			if (_3 == null) return result.ToArray(); result.Add((IntPtr) _3);
			if (_4 == null) return result.ToArray(); result.Add((IntPtr) _4);
			if (_5 == null) return result.ToArray(); result.Add((IntPtr) _5);
			if (_6 == null) return result.ToArray(); result.Add((IntPtr) _6);
			if (_7 == null) return result.ToArray(); result.Add((IntPtr) _7);
			return result.ToArray();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct BytePtrArray4 : IPtrArray {
		public byte* _0;
		public byte* _1;
		public byte* _2;
		public byte* _3;

		public int FixedCount => 4;

		public byte* this[int index] {
			get {
				switch (index) {
					case 0: return _0;
					case 1: return _1;
					case 2: return _2;
					case 3: return _3;
					default: return null;
				}
			}
			set {
				switch (index) {
					case 0: _0 = value; break;
					case 1: _1 = value; break;
					case 2: _2 = value; break;
					case 3: _3 = value; break;
				}
			}
		}

		public int PtrCount {
			get {
				return
					_0 == null ? 0 :
					_1 == null ? 1 :
					_2 == null ? 2 :
					_3 == null ? 3 :
					4;
			}
		}

		public IntPtr[] ToArray() {
			List<IntPtr> result = new List<IntPtr>(FixedCount);
			if (_0 == null) return result.ToArray(); result.Add((IntPtr) _0);
			if (_1 == null) return result.ToArray(); result.Add((IntPtr) _1);
			if (_2 == null) return result.ToArray(); result.Add((IntPtr) _2);
			if (_3 == null) return result.ToArray(); result.Add((IntPtr) _3);
			return result.ToArray();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	unsafe public struct AVBufferRefArray8 : IPtrArray {
		public AVBufferRef* _0;
		public AVBufferRef* _1;
		public AVBufferRef* _2;
		public AVBufferRef* _3;
		public AVBufferRef* _4;
		public AVBufferRef* _5;
		public AVBufferRef* _6;
		public AVBufferRef* _7;

		public int FixedCount => 8;

		public AVBufferRef* this[int index] {
			get {
				switch (index) {
					case 0: return _0;
					case 1: return _1;
					case 2: return _2;
					case 3: return _3;
					case 4: return _4;
					case 5: return _5;
					case 6: return _6;
					case 7: return _7;
					default: return null;
				}
			}
			set {
				switch (index) {
					case 0: _0 = value; break;
					case 1: _1 = value; break;
					case 2: _2 = value; break;
					case 3: _3 = value; break;
					case 4: _4 = value; break;
					case 5: _5 = value; break;
					case 6: _6 = value; break;
					case 7: _7 = value; break;
				}
			}
		}

		public int PtrCount {
			get {
				return
					_0 == null ? 0 :
					_1 == null ? 1 :
					_2 == null ? 2 :
					_3 == null ? 3 :
					_4 == null ? 4 :
					_5 == null ? 5 :
					_6 == null ? 6 :
					_7 == null ? 7 :
					8;
			}
		}

		public IntPtr[] ToArray() {
			List<IntPtr> result = new List<IntPtr>(FixedCount);
			if (_0 == null) return result.ToArray(); result.Add((IntPtr) _0);
			if (_1 == null) return result.ToArray(); result.Add((IntPtr) _1);
			if (_2 == null) return result.ToArray(); result.Add((IntPtr) _2);
			if (_3 == null) return result.ToArray(); result.Add((IntPtr) _3);
			if (_4 == null) return result.ToArray(); result.Add((IntPtr) _4);
			if (_5 == null) return result.ToArray(); result.Add((IntPtr) _5);
			if (_6 == null) return result.ToArray(); result.Add((IntPtr) _6);
			if (_7 == null) return result.ToArray(); result.Add((IntPtr) _7);
			return result.ToArray();
		}
	}
}