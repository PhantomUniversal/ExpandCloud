using UnityEngine;

namespace Phantom
{
    public static class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public static DataManager Manager => DataManager.Instance;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Init() => DataManager.Instance.Init();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Destroy() => DataManager.Instance.Fina();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSetting Setting() => DataManager.Instance.Setting();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soKey"></param>
        /// <param name="soValue"></param>
        /// <returns></returns>
        public static bool Add(string soKey, object soValue) => DataManager.Instance.Add(soKey, soValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soKey"></param>
        /// <returns></returns>
        public static bool Remove(string soKey) => DataManager.Instance.Remove(soKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soValue"></param>
        /// <returns></returns>
        public static bool Remove(object soValue) => DataManager.Instance.Remove(soValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soKey"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Find<T>(string soKey) where T : Object => DataManager.Instance.Find<T>(soKey);
    }
}