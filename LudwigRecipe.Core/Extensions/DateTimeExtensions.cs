using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkZero.Core.Extensions
{
	public static class DateTimeExtensions
	{
		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a nullable DateTime to a DateTime-value that can be used with the SQL Server. This conversion is only needed if 
		/// the SQL Server does not use the datetime2 - datatype. If the date that should be converted is before 1.1.1753 (which is
		/// the minimum date for the datetime-datatype in SQL Server), the 1.1.1753 is returned.
		/// </summary>
		/// <param name="item">The nullable DateTime to convert</param>
		/// <returns>The converted value or the 1.1.1753 if the value is null or lies before 1.1.1753</returns>
		/// =========================================================================================================================================================
		public static DateTime ToSqlServerDateTime(this DateTime? item)
		{
			DateTime sqlServerMinDateTime = new DateTime(1753, 1, 1);
			DateTime dateToSave = item.HasValue ? item.Value : sqlServerMinDateTime;

			if (dateToSave < sqlServerMinDateTime)
			{
				dateToSave = sqlServerMinDateTime;
			}

			return dateToSave;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a nullable DateTime to a normal DateTime with a default Value. If the nullable DateTime is null, the defaultValue is returned. 
		/// </summary>
		/// <param name="item">The nullable DateTime to convert</param>
		/// <param name="defaultValue">The defaultValue that is returned if the item is null</param>
		/// <returns>The DateTime if the conversion succeeds or the defaultValue</returns>
		/// =========================================================================================================================================================
		public static DateTime ToDateTimeWithDefault(this DateTime? item, DateTime defaultValue)
		{
			DateTime result = item.HasValue ? item.Value : defaultValue;
			return result;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a nullable DateTime to a normal DateTime. If the nullable DateTime is null, DateTime.MinValue is returned. 
		/// </summary>
		/// <param name="item">The nullable DateTime to convert</param>
		/// <returns>The DateTime if the conversion succeeds or DateTime.MinValue</returns>
		/// =========================================================================================================================================================
		public static DateTime ToDateTimeWithDefault(this DateTime? item)
		{
			return item.ToDateTimeWithDefault(DateTime.MinValue);
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Converts a DateTime to UTC if it is not already UTC.
		/// </summary>
		/// <param name="dateTime">The DateTime to convert</param>
		/// <returns>The datetime as UTC</returns>
		/// =========================================================================================================================================================
		public static DateTime ToUtcDateTimeWithCheck(this DateTime dateTime)
		{
			DateTime result = (dateTime.Kind == DateTimeKind.Local) ? dateTime.ToUniversalTime() : dateTime;
			return result;
		}

	}
}
