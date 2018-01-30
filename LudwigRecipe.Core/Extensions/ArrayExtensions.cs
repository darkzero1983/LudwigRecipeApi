using System;
using System.Collections.Generic;

namespace DarkZero.Core.Extensions
{
	public static class ArrayExtensions
	{
		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if an array is empty (has a length of 0, but is not null)
		/// </summary>
		/// <param name="array">The array to check</param>
		/// <returns>true if the array is empty, false if it has items</returns>
		/// =========================================================================================================================================================
		public static bool IsEmpty(this Array array)
		{
			if (array == null)
			{
				return true;
			}
			return (array.Length == 0);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given array has items
		/// </summary>
		/// <param name="array">the array to check if it has items</param>
		/// <returns>true if the array has items, false if not</returns>
		/// =========================================================================================================================================================
		public static bool HasItems(this Array array)
		{
			return !array.IsEmpty();
		}
	}
}
