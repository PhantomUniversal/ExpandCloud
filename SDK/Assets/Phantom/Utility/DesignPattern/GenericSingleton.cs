using UnityEngine;

namespace Phantom
{
    public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _enable;
        private static readonly object _lock = new();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_enable) return null;

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));
                        if (_instance == null)
                        {
                            var obj = new GameObject();
                            _instance = obj.AddComponent<T>();
                            obj.name = typeof(T).Name;
                        }
                    }

                    return _instance;
                }
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            _instance = null;
            _enable = false;
        }
        
        private void OnApplicationQuit()
        {
            _enable = true;
        }
    }
}