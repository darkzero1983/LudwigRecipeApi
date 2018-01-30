using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkZero.Core.Extensions
{
	public static class DiagnosticsExtensions
	{
		/// <summary>
		/// Stops the running clock and returns the elapsed time in the format [00:00:00]. Adds also the hours if > 1.
		/// </summary>
		/// <param name="clock">The current clock</param>
		/// <returns>A string with the elapsed time in the format [00:00:00].</returns>
		public static string StopAndGetFormattedTime(this Stopwatch clock)
		{
			if (clock == null)
			{
				return String.Empty;
			}
			clock.Stop();
			if (clock.Elapsed.Hours > 0)
			{
				return string.Format("[{0:00}:{1:00}:{2:00}:{3:000}]", clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds, clock.Elapsed.Milliseconds);
			}
			else
			{
				return string.Format("[{0:00}:{1:00}:{2:000}]", clock.Elapsed.Minutes, clock.Elapsed.Seconds, clock.Elapsed.Milliseconds);
			}
		}

	}
}
