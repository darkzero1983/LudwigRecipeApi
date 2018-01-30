using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkZero.Core.Extensions
{
	public static class DictionaryExtensions
	{
		#region Generic Dictionary Get Methods

		/// =========================================================================================================================================================
		/// <summary>
		/// Gets a value from the given dictionary. If the value for the key is not found, a defaultValue is returned
		/// </summary>
		/// <typeparam name="K">The type parameter for the keys of the dictionary</typeparam>
		/// <typeparam name="V">The type parameter for the values of the dictionary</typeparam>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the value that should be returned from the dictionary</param>
		/// <param name="defaultValue">The default Value that is returned, if the key could not be found</param>
		/// <returns>The value of the given key or the default value</returns>
		/// =========================================================================================================================================================
		public static V Get<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue)
		{
			V result;
			bool valueFound = dictionary.TryGetValue(key, out result);
			if (valueFound)
			{
				return result;
			}

			return defaultValue;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Gets a value from the given dictionary
		/// </summary>
		/// <typeparam name="K">The type parameter for the keys of the dictionary</typeparam>
		/// <typeparam name="V">The type parameter for the values of the dictionary</typeparam>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the value that should be returned from the dictionary</param>
		/// <returns>The value of the given key or the default value of the type parameter for the values</returns>
		/// =========================================================================================================================================================
		public static V Get<K, V>(this IDictionary<K, V> dictionary, K key)
		{
			return dictionary.Get(key, default(V));
		}

		#endregion

		#region Generic dictionary set methods

		/// =========================================================================================================================================================
		/// <summary>
		/// Sets a value in the dictionary. If the key does not yet exist, the value is added to the dictionary. If it exists, the value is replaced.
		/// </summary>
		/// <typeparam name="K">The type parameter for the keys of the dictionary</typeparam>
		/// <typeparam name="V">The type parameter for the values of the dictionary</typeparam>
		/// <param name="dictionary">The dictionary to insert the value into</param>
		/// <param name="key">The key of the value that should be inserted or replaced</param>
		/// <param name="value">The value that should be inserted or replaced</param>
		/// =========================================================================================================================================================
		public static void Set<K, V>(this IDictionary<K, V> dictionary, K key, V value)
		{
			if (key == null)
			{
				return;
			}
			if (dictionary.ContainsKey(key))
			{
				dictionary[key] = value;
			}
			else
			{
				dictionary.Add(key, value);
			}
		}

		#endregion

		#region IDictionary get methods

		/// =========================================================================================================================================================
		/// <summary>
		/// Gets a value from the given dictionary. If the value for the key is not found, a defaultValue is returned
		/// </summary>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the value that should be returned from the dictionary</param>
		/// <param name="defaultValue">The default Value that is returned, if the key could not be found</param>
		/// <returns>The value of the given key or the default value</returns>
		/// =========================================================================================================================================================
		public static object Get(this System.Collections.IDictionary dictionary, object key, object defaultValue)
		{
			bool isKeyAvailable = dictionary.Contains(key);
			return isKeyAvailable ? dictionary[key] : defaultValue;
		}

		/// =========================================================================================================================================================
		/// <summary>
		/// Gets a value from the given dictionary. If the value for the key is not found, null is returned
		/// </summary>
		/// <param name="dictionary">The dictionary to get the value from</param>
		/// <param name="key">The key of the value that should be returned from the dictionary</param>
		/// <returns>The value of the given key or null</returns>
		/// =========================================================================================================================================================
		public static object Get(this System.Collections.IDictionary dictionary, object key)
		{
			return dictionary.Get(key, null);
		}

		#endregion

		#region IDictionary set methods

		/// =========================================================================================================================================================
		/// <summary>
		/// Sets a value in the dictionary. If the key does not yet exist, the value is added to the dictionary. If it exists, the value is replaced.
		/// </summary>
		/// <param name="dictionary">The dictionary to insert the value into</param>
		/// <param name="key">The key of the value that should be inserted or replaced</param>
		/// <param name="value">The value that should be inserted or replaced</param>
		/// =========================================================================================================================================================
		public static void Set(this System.Collections.IDictionary dictionary, object key, object value)
		{
			if (key == null)
			{
				return;
			}
			bool isKeyAvailable = dictionary.Contains(key);
			if (isKeyAvailable)
			{
				dictionary[key] = value;
			}
			else
			{
				dictionary.Add(key, value);
			}
		}

		#endregion

	}
}
