using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Saar.FFmpeg.CSharp {
	public sealed class Timer : IDisposable {
		private Timer() { }

		private static string message;
		private static readonly Timer @default = new Timer();
		private static readonly Stopwatch timer = new Stopwatch();

		public static IDisposable Run(string message = null) {
			Timer.message = message;
			timer.Restart();
			return @default;
		}

		void IDisposable.Dispose() {
			timer.Stop();
			Console.WriteLine($"{message ?? "Time"}: {timer.Elapsed}");
		}
	}
}
