using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkZero.Core.Extensions
{
	public static class ListExtensions
	{
		public static string GetCommaSeperatedString(this List<String> list, bool allowEmptyString)
		{
			if (list == null)
			{
				return String.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			string delimiter = String.Empty;
			foreach (string item in list)
			{
				if (allowEmptyString || !String.IsNullOrEmpty(item))
				{
					stringBuilder.Append(delimiter);
					stringBuilder.Append("'");
					stringBuilder.Append(item);
					stringBuilder.Append("'");
					delimiter = ",";
				}
			}

			return stringBuilder.ToString();
		}
	}
}