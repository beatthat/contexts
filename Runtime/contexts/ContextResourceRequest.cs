using BeatThat.Requests;
using System;
using UnityEngine;

namespace BeatThat.Contexts
{
	public class ContextResourceRequest<T> : RequestBase, Request<T> where T : class
	{
		public ContextResourceRequest(string path) 
		{
			this.path = path;
		}

		public object GetItem() { return this.item; } 

		public T item { get; private set; }
		public string path { get; private set; }

        public override string loggingName => this.path;
		
		private ResourceRequest req { get; set; }
		private GameObject runner { get; set; }

		override public float progress 
		{
			get {
				switch(this.status) {
				case RequestStatus.IN_PROGRESS:
					return 0f;
				case RequestStatus.DONE:
					return 1f;
				default:
					return 0f;
				}
			}
		}

		override protected void DisposeRequest()
		{
			var obj = this.item as UnityEngine.Object;
			this.item = null;
			// only unload if the object type is a file asset, e.g. a texure or audio file
			if(obj != null && !(obj is GameObject) && !(obj is Component)) {
				Resources.UnloadAsset(obj);
			}
		}

		override protected void ExecuteRequest()
		{
			this.item = ContextResources.Load<T>(this.path);
			if(this.item == null) {
				this.error = "not found at path '" + this.path + "'";
			}
			CompleteRequest();
		}

		virtual public void Execute(Action<Request<T>> callback)
		{
			if(callback == null)  {
				Execute();
			}
			RequestExecutionPool<T, Request<T>>.Get().Execute(this, callback);
		}
	}
}



