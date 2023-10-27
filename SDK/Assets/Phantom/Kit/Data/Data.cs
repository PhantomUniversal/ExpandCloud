using UnityEngine;

namespace Phantom
{
    public static class Data
    {
        public static DataManager Manager => DataManager.Instance;

        public static bool Add(string soKey, ScriptableObject soValue) => DataManager.Instance.Add(soKey, soValue);

        public static bool Remove(string soKey) => DataManager.Instance.Remove(soKey);

        public static bool Remove(ScriptableObject soValue) => DataManager.Instance.Remove(soValue);
    
        public static ScriptableObject Find(string soKey) => DataManager.Instance.Find(soKey);
    }
}