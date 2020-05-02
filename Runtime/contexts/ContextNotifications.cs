using BeatThat.Notifications;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeatThat.Contexts
{
	/// <summary>
	/// Isolates notifications into a context by prefixing all 'type's with 'aotc_', 'rots_', etc.
	/// </summary>
	public class ContextNotifications 
	{		
		public static NotificationBinding Add<T>(string type, System.Action<T> handler, GameObject handlerGO = null) 
		{
			return NotificationBus.Add<T>(ContextTypeFor(type), handler, handlerGO);
		}

		public static NotificationBinding Add(string type, System.Action handler, GameObject handlerGO = null) 
		{
			return NotificationBus.Add(ContextTypeFor(type), handler, handlerGO);
		}

		public static bool Remove(string type, System.Action handler)
		{
			return NotificationBus.Remove(ContextTypeFor(type), handler);
		}
		
		public static bool Remove<T>(string type, System.Action<T> handler)
		{
			return NotificationBus.Remove<T>(ContextTypeFor(type), handler);
		}

		public static void Send(string type) 
		{
			NotificationBus.Send(ContextTypeFor(type));
		}

		public static void Send<T>(string type, T body) 
		{
			NotificationBus.SendWBody(ContextTypeFor(type), body);
		}

		private static string ContextTypeFor(string type)
		{
			return Context.activeContext + "_" + type;
		}

	}
}



