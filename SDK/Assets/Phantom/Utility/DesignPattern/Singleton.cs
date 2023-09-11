using UnityEngine;

namespace Phantom
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool enable;
        private static readonly object safe = new();
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (enable) return null;

                lock (safe)
                {
                    if (instance == null)
                    {
                        instance = (T)FindObjectOfType(typeof(T));

                        if (instance == null)
                        {
                            var obj = new GameObject();
                            instance = obj.AddComponent<T>();
                            obj.name = typeof(T).ToString();

                            DontDestroyOnLoad(obj);
                        }
                    }

                    return instance;
                }
            }
        }


        private void OnDestroy()
        {
            instance = null;
            enable = false;
        }


        private void OnApplicationQuit()
        {
            enable = true;
        }
    }
}