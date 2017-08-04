using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Saar.FFmpeg.CSharp {
	public static class Debug {
		unsafe public static void Print(object ffStruct) {
			ConsoleColor oldColor = Console.ForegroundColor;
			var fields = ffStruct.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
			foreach (var field in fields) {
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write(field.FieldType.Name + " ");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write(field.Name + " = ");
				Console.ForegroundColor = ConsoleColor.Magenta;
				var obj = field.GetValue(ffStruct);

				if (field.FieldType.IsPointer) {
					IntPtr pointer = (IntPtr) Pointer.Unbox(obj);
					if (pointer == IntPtr.Zero) {
						Console.WriteLine("null");
					} else {
						Console.WriteLine(IntPtr.Size == 8 ? $"0x{(long) pointer:x16}" : $"0x{(int) pointer:x8}");
					}
				} else {
					Console.WriteLine(obj);
				}
			}
			Console.ForegroundColor = oldColor;
		}

		public static void Warning(string message) {
			var old = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"[WARNING] {message}");
			Console.ForegroundColor = old;
		}
	}
}
