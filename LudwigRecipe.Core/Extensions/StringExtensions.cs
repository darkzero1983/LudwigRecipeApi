using System;
using System.Linq;

namespace DarkZero.Core.Extensions
{
	public static class StringExtensions
	{
		#region static properties

		private static string[] AllowedTags { get; set; }

		#endregion

		#region Difference checks

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if two strings are different
		/// </summary>
		/// <param name="first">The first string</param>
		/// <param name="other">The string to check against</param>
		/// <param name="ignoreCase">true to ignore casing, false to respect casing</param>
		/// <returns>true if the strings match, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsDifferent(this string first, string other, bool ignoreCase)
		{
			if (first == null || other == null)
			{
				return false;
			}
			return String.Compare(first, other, ignoreCase) != 0;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if two string are different, ignoring the case
		/// </summary>
		/// <param name="first">The first string</param>
		/// <param name="other">The string to check against</param>
		/// <returns>true if the strings match, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsDifferentIgnoringCase(this string first, string other)
		{
			return first.IsDifferent(other, true);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if two string are different, respecting the case
		/// </summary>
		/// <param name="first">The first string</param>
		/// <param name="other">The string to check against</param>
		/// <returns>true if the strings match, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsDifferentRespectingCase(this string first, string other)
		{
			return first.IsDifferent(other, false);
		}

		#endregion

		#region Equality Checks

		/// =========================================================================================================================================================
		/// <summary>
		/// Compares two strings for equality 
		/// </summary>
		/// <param name="item">the first string to compare</param>
		/// <param name="value">the second string to compare</param>
		/// <param name="ignoreCase">
		/// <c>true</c> if the comparison should ignore case, <c>false</c> if case is respected
		/// </param>
		/// <returns>true if both strings have the same content, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsEqual(this string item, string value, bool ignoreCase)
		{
			if (item == null || value == null)
			{
				return false;
			}
			return String.Compare(item, value, ignoreCase) == 0;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Compares two strings for equality, ignoring case-sensitivity 
		/// </summary>
		/// <param name="item">the first string to compare</param>
		/// <param name="value">the second string to compare</param>
		/// <returns>true if both strings have the same content, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsEqualIgnoringCase(this string item, string value)
		{
			return item.IsEqual(value, true);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Compares two strings for equality, resopecting case-sensitivity 
		/// </summary>
		/// <param name="item">the first string to compare</param>
		/// <param name="value">the second string to compare</param>
		/// <returns>true if both strings have the same content, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsEqualRespectingCase(this string item, string value)
		{
			return item.IsEqual(value, false);
		}

		#endregion

		#region Type checks

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string contains the string-representation of a guid
		/// </summary>
		/// <param name="item">The string to compare</param>
		/// <returns>true if the string contains a Guid, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsGuid(this string item)
		{
			bool result = false;
			try
			{
				Guid g = new Guid(item);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string contains the string-representation of an int
		/// </summary>
		/// <param name="item">The string to compare</param>
		/// <returns>true if the string contains an int, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsInt32(this string item)
		{
			int numericValue;
			bool result = Int32.TryParse(item, out numericValue);
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string contains the string-representation of a double
		/// </summary>
		/// <param name="item">The string to compare</param>
		/// <returns>true if the string contains a double, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsDouble(this string item)
		{
			double numericValue;
			bool result = Double.TryParse(item, out numericValue);
			return result;
		}

		public static bool IsDateTime(this string item)
		{
			DateTime dateTime;
			return DateTime.TryParse(item, out dateTime);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// returns true if the string contains a boolean value, false if not.
		/// Only true and false are considered boolean values, 0 and 1 are considered int.
		/// </summary>
		/// <param name="item">the string to check for a boolean value</param>
		/// <returns>true if the string contains a boolean value, false if not.</returns>
		/// =========================================================================================================================================================
		public static bool IsBoolean(this string item)
		{
			if (item == null)
			{
				return false;
			}
			item = item.ToLower();
			bool booleanValue;
			bool result = Boolean.TryParse(item, out booleanValue);
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string is null (not null or empty, but explicitely null)
		/// </summary>
		/// <param name="item">then string to check</param>
		/// <returns>true if the string is null, false if not</returns>
		/// =========================================================================================================================================================
		public static bool IsNull(this string item)
		{
			return item == null;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string contains a value (is not null, not empty and not only filled with whitespaces))
		/// </summary>
		/// <param name="item">The string to check</param>
		/// <returns>true if the given string contains a value, false if not</returns>
		/// =========================================================================================================================================================
		public static bool HasValue(this string item)
		{
			return !String.IsNullOrWhiteSpace(item);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Checks if the given string is null, empty or contains only whitespaces.
		/// </summary>
		/// <param name="item">The string to check</param>
		/// <returns>true if the given string contains no value or is null, false otherwise</returns>
		/// =========================================================================================================================================================
		public static bool IsEmpty(this string item)
		{
			return !item.HasValue();
		}

		#endregion
		
		#region Conversions

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to an int with a defaultValue. If the conversion fails,
		/// the default value is returned
		/// </summary>
		/// <param name="item">The string to convert</param>
		/// <param name="defaultValue">the default value to return if the conversion fails</param>
		/// <returns>the converted value or defaultValue if the conversion fails</returns>
		/// =========================================================================================================================================================
		public static int ToInt32WithDefault(this string item, int defaultValue)
		{
			int result;
			bool convertOk = Int32.TryParse(item, out result);
			if (!convertOk)
			{
				result = defaultValue;
			}
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to an int with a defaultValue. If the conversion fails,
		/// a default value of -1 is returned
		/// </summary>
		/// <param name="item">The string to convert</param>
		/// <returns>the converted value or -1 if the conversion fails</returns>
		/// =========================================================================================================================================================
		public static int ToInt32WithDefault(this string item)
		{
			return item.ToInt32WithDefault(-1);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to a boolean value with a given default value if the conversion fails.
		/// </summary>
		/// <param name="item">The string to convert to a boolean</param>
		/// <param name="defaultValue">The default value for the conversion</param>
		/// <returns>The converted value or the default value if the conversion fails</returns>
		/// =========================================================================================================================================================
		public static bool ToBooleanWithDefault(this string item, bool defaultValue)
		{
			bool result = defaultValue;
			if (item != null)
			{
				item = item.ToLower();
				if (item.Equals("true"))
				{
					result = true;
				}
				if (item.Equals("false"))
				{
					result = false;
				}
			}
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to a boolean value, returning false if the conversion fails.
		/// </summary>
		/// <param name="item">The string to convert to a boolean</param>
		/// <returns>The converted value or false if the conversion fails</returns>
		/// =========================================================================================================================================================
		public static bool ToBooleanWithDefault(this string item)
		{
			return item.ToBooleanWithDefault(false);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to a Guid, returning Guid.Empty if the conversion fails.
		/// </summary>
		/// <param name="item">The string to convert to a Guid</param>
		/// <param name="defaultValue">The default value to return when the string is not a Guid</param>
		/// <returns>The converted value or the default value if the string does not contain a Guid</returns>
		/// =========================================================================================================================================================
		public static Guid ToGuidWithDefault(this string item, Guid defaultValue)
		{
			Guid result;
			try
			{
				result = new Guid(item);
			}
			catch
			{
				result = defaultValue;
			}
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a string to a Guid, returning Guid.Empty if the conversion fails.
		/// </summary>
		/// <param name="item">The string to convert to a Guid</param>
		/// <returns>The converted value or Guid.Empty if the conversion fails</returns>
		/// =========================================================================================================================================================
		public static Guid ToGuidWithDefault(this string item)
		{
			return item.ToGuidWithDefault(Guid.Empty);
		}


		public static DateTime ToDateTime(this string item, DateTime defaultValue)
		{
			DateTime result;
			if (!DateTime.TryParse(item, out result))
			{
				result = defaultValue;
			}
			return result;
		}

		public static DateTime ToDateTime(this string item)
		{
			return item.ToDateTime(DateTime.Now);
		}

		public static DateTime? ToNullableDateTime(this string item, DateTime? defaultValue)
		{
			if (item.IsDateTime())
			{
				return (DateTime?)item.ToDateTime();
			}
			return defaultValue;
		}

		public static DateTime? ToNullableDateTime(this string item)
		{
			return item.ToNullableDateTime(null);
		}

		#endregion

		#region Ensure string ends or starts with a specific string

		/// =========================================================================================================================================================
		/// <summary>
		/// Makes sure the string starts with the specified sequence.
		/// If the string does not start with the specified sequence, it is added
		/// </summary>
		/// <param name="item">The string to check</param>
		/// <param name="prefix">The sequence the string must start with</param>
		/// <param name="ignoreCase">if true, the case of the letters in the value is ignored. The default is false.</param>
		/// <returns>the string starting with the given sequence</returns>
		/// =========================================================================================================================================================
		public static string EnsureStartsWith(this string item, string prefix, bool ignoreCase = false)
		{
			if (item == null && prefix != null)
			{
				return prefix;
			}
			if (prefix == null)
			{
				return item;
			}
			StringComparison comparison = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
			if (!item.StartsWith(prefix, comparison))
			{
				return prefix + item;
			}
			return item;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Makes sure the string ends with the specified sequence.
		/// If the string does not end with the specified sequence, it is added
		/// </summary>
		/// <param name="item">The string to check</param>
		/// <param name="suffix">The sequence the string must end with</param>
		/// <param name="ignoreCase">if true, the case of the letters in the value is ignored. The default is false.</param>
		/// <returns>the string ending with the given sequence</returns>
		/// =========================================================================================================================================================
		public static string EnsureEndsWith(this string item, string suffix, bool ignoreCase = false)
		{
			if (item == null && suffix != null)
			{
				return suffix;
			}
			if (suffix == null)
			{
				return item;
			}
			StringComparison comparison = ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
			if (!item.EndsWith(suffix, comparison))
			{
				return item + suffix;
			}
			return item;
		}

		#endregion

		#region Strip Tags
		
		public static string BuildUrl(this string item)
		{
			item = item.ReplaceUmlauts();
			item = item.Replace(" ", "-");
			item = item.Replace("/", "-");
			item = item.Replace("_", "-");
			while(item.IndexOf("--") > 0)
			{
				item = item.Replace("--", "-");
			}
			return item;
		}
		public static string ReplaceUmlauts(this string item)
		{
			item = item.Replace("Ä", "Ae");
			item = item.Replace("ä", "ae");
			item = item.Replace("Ö", "Oe");
			item = item.Replace("ö", "oe");
			item = item.Replace("Ü", "Ue");
			item = item.Replace("ü", "ue");
			item = item.Replace("ß", "ss");
			return item;
		}

		#endregion
	}
}
