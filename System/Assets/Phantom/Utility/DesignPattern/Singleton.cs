using UnityEngine;

namespace Phantom
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool enable = false;
        private static object safe = new object();
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (enable)
                {
                    return null;
                }

                lock (safe)
                {
                    if (instance == null)
                    {
                        instance = (T)FindObjectOfType(typeof(T));

                        if (instance == null)
                        {
                            GameObject obj = new GameObject();
                            instance = obj.AddComponent<T>();
                            obj.name = typeof(T).ToString();

                            DontDestroyOnLoad(obj);
                        }
                    }

                    return instance;
                }
            }
        }


        private void OnApplicationQuit()
        {
            enable = true;
        }


        private void OnDestroy()
        {
            instance = null;
            enable = false;
        }
    }

}