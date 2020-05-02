using BeatThat.Notifications;

namespace BeatThat.Contexts
{
	/// <summary>
	/// Global singleton that controls whether resource, playerprefs, services, etc.
	/// are from the AOTC activity or ROTS
	/// </summary>
	public static class Context 
	{
		public static string activeContext { get; private set; }

		// TODO: probably better if contexts were push/popped on a stack
		public static void SetActiveContext(string ctx)
		{
			Context.activeContext = ctx;
		}

		class NotificationCtx : NotificationContext
		{
			public NotificationCtx(string ctx)
			{
				this.ctx = ctx;
			}

			private string ctx
			{
				get; set;
			}

			public string TranslateNotificationType (string notificationType)
			{
				return this.ctx + "-" + notificationType;
			}
		}

	}
}

