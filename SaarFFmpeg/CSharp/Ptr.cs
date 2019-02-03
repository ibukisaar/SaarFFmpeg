using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Saar.FFmpeg.CSharp {
	unsafe public readonly struct Ptr<T> where T : unmanaged {
		public readonly T* Value;

		public Ptr(T* value) {
			Value = value;
		}
		
		public static implicit operator T* (Ptr<T> @this) => @this.Value;
		public static implicit operator Ptr<T>(T* value) => new Ptr<T>(value);
	}

	unsafe public static class Ptr {
		/// <summary>
		/// 当 <paramref name="in"/> 不为 null 时，函数返回 true，并设置 <paramref name="out"/>；否则返回 false
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="in"></param>
		/// <param name="out"></param>
		/// <returns></returns>
		public static bool Get<T>(T* @in, out T* @out) where T : unmanaged {
			@out = @in;
			return @in != null;
		}
	}
}
