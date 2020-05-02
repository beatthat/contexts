using System.Collections;
using UnityEngine;

namespace BeatThat.Contexts
{
	/// <summary>
	/// isolates player prefs by preprended a context prefix to all keys
	/// </summary>
	public static class ContextPlayerPrefs 
	{
		public static int GetInt(string key)
		{
			return PlayerPrefs.GetInt(ContextKeyFor(key));
		}

		public static int GetInt(string key, int defaultVal)
		{
			return PlayerPrefs.GetInt(ContextKeyFor(key), defaultVal);
		}

		public static void SetInt(string key, int val)
		{
			PlayerPrefs.SetInt(ContextKeyFor(key), val);
		}

		public static float GetFloat(string key)
		{
			return PlayerPrefs.GetFloat(ContextKeyFor(key));
		}

		public static float GetFloat(string key, float defaultVal)
		{
			return PlayerPrefs.GetFloat(ContextKeyFor(key), defaultVal);
		}

		public static void SetFloat(string key, float v)
		{
			PlayerPrefs.SetFloat(ContextKeyFor(key), v);
		}

		public static string GetString(string key)
		{
			return PlayerPrefs.GetString(ContextKeyFor(key));
		}

		public static string GetString(string key, string defaultVal)
		{
			return PlayerPrefs.GetString(ContextKeyFor(key), defaultVal);
		}

		public static void SetString(string key, string v)
		{
			PlayerPrefs.SetString(ContextKeyFor(key), v);
		}

		public static void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(ContextKeyFor(key));
		}

		public static bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(ContextKeyFor(key));
		}
	
		private static string ContextKeyFor(string key)
		{
			return Context.activeContext + "_" + key;
		}
	}
}
