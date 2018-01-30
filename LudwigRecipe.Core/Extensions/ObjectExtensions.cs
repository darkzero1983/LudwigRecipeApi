using System;

namespace DarkZero.Core.Extensions
{
	public static class ObjectExtensions
	{
		/// =========================================================================================================================================================  
		/// <summary>
		/// Checks if an object is not null or throws ArgumentNullException otherwise. Is used in methods for parameters that must not be null.
		/// </summary>
		/// <param name="item">The object to check</param>
		/// <param name="parameterName">The name of the parameter for the exception. If the name is null, "unknown" is used.</param>
		/// =========================================================================================================================================================  
		public static void CheckIfNotNull(this object item, string parameterName)
		{
			if (String.IsNullOrWhiteSpace(parameterName))
			{
				parameterName = "unknown";
			}
			if (item == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		/// =========================================================================================================================================================  
		/// <summary>
		/// Whether an object is not null. Is used in methods for parameters that must not be null
		/// </summary>
		/// <param name="item">The object to check</param>
		/// =========================================================================================================================================================  
		public static bool IsNotNull(this object item)
		{
			return (item != null);
		}
	}
}
