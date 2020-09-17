using UnityEngine;

namespace BeatThat.Contexts
{
    /// <summary>
    /// isolates resources by preprended a context node all all resource paths
    /// </summary>
    public static class ContextResources
    {
        private static string ContextPathFor(string path)
        {
            return string.IsNullOrEmpty(Context.activeContext)
                ? path
                : Context.activeContext + "/" + path;
        }

        public static T Load<T>(string path) where T : class
        {
            T obj = default(T);
            if (typeof(UnityEngine.Object).IsAssignableFrom(typeof(T)))
            {
                obj = (Resources.Load(ContextPathFor(path), typeof(T)) ?? Resources.Load(path, typeof(T))) as T;
            }
            else
            {
                var asset = Load(path);

                if (asset != null)
                {
                    var go = asset as GameObject;
                    obj = go != null ? go.GetComponent<T>() : asset as T;
                }
            }
#if UNITY_EDITOR
            if (obj == default(T))
            {
                Debug.Log("Unable to find ITheater Resource at path: " + path);
            }
#endif
            return obj;
        }

        public static Object Load(string path)
        {
            Object obj = Resources.Load(ContextPathFor(path)) ?? Resources.Load(path);
#if UNITY_EDITOR
            if (obj == null)
            {
                Debug.Log("Unable to find Resource at path: " + path);
            }
#endif
            return obj;
        }
    }
}
