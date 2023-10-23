using System;
using System.Collections.Generic;
using System.Linq;

namespace Phantom.Callback
{
    public static class Callback
    {

        #region VARIABLE
        
        public static Dictionary<CallbackOption, ICallback> Containers { get; private set; }
        
        public static bool Use => Containers != null && Containers.Count != 0;

        public static int Count => Containers.Count;

        #endregion



        #region UTILITY

        public static bool Add(object callback) => Add( callback, null );
        
        public static bool Add(object callback, CallbackOption callbackOption)
        {
            if (callback is not ICallback target)
                return false;

            // callbacks null is → new callback system
            Containers ??= new Dictionary<CallbackOption, ICallback>();

#if UNITY_EDITOR
            if (CallbackManager.Instance == null)
            {
                CallbackManager.Instance.Init();
            }            
#endif
            
            // callback option null is → new callback data
            callbackOption ??= new CallbackOption();
            callbackOption.Uid = string.IsNullOrEmpty(callbackOption.Uid) ? Guid.NewGuid().ToString() : callbackOption.Uid;

            var result = Containers.TryAdd(callbackOption, target);
            if (!result) 
                return false;
            
            target.OnOpenCallback();
            return true;
        }

        public static bool Remove(string callbackUid)
        {
            if (Containers is null || Containers.Count == 0)
                return false;

            var callbackOption = Containers.FirstOrDefault(x => x.Key.Uid == callbackUid).Key;
            if (callbackOption is null)
            {
                return false;
            }
            var callback = Containers[callbackOption];
            
            return Remove(callbackOption, callback);
        }

        public static bool Remove(object callback)
        {
            if (callback is not ICallback target)
                return false;
            
            if (Containers is null || Containers.Count == 0 || !Containers.ContainsValue(target))
                return false;
            
            var callbackOption = Containers.FirstOrDefault(x => x.Value == target).Key;
            return Remove(callbackOption, target);
        }

        private static bool Remove(CallbackOption callbackOption, ICallback callback)
        { 
            var result = Containers.Remove(callbackOption);
            if (!result)
                return false;
            
            callback.OnCloseCallback();
            return true;
        }

        public static bool CategoryRemove(string category)
        {
            if (Containers is null || Containers.Count == 0)
                return false;

            foreach (var option in Containers.Keys)
            {
                if (option.Category.Equals(category))
                    Containers.Remove(option);
            }

            return true;
        }
        
        public static bool Clear(bool enable = false)
        {
            if (Containers is null || Containers.Count == 0)
                return false;

            foreach (var callback in Containers.Values)
            {
                callback.OnCloseCallback();
            }
            Containers.Clear();
            
            if (enable)
                Containers = null;

            return true;
        }

        public static ICallback Find(string callbackUid)
        {
            if (Containers is null || Containers.Count == 0)
                return null;
            
            foreach (var callbackOption in Containers.Keys)
            {
                if (callbackOption.Uid == callbackUid)
                    return Containers[callbackOption];
            }

            return null;
        }

        public static bool Exist(object callback)
        {
            if (callback is not ICallback target)
                return false;

            if (Containers is null || Containers.Count == 0 || !Containers.ContainsValue(target))
                return false;

            return true;
        }

        public static string FindUid(object callback)
        {
            if (callback is not ICallback target)
                return "";
            
            if (Containers is null || Containers.Count == 0 || !Containers.ContainsValue(target))
                return "";

            return Containers.FirstOrDefault(x => x.Value == target).Key.Uid;
        }

        public static bool ExistUid(string callbackUid)
        {
            if (Containers is null || Containers.Count == 0)
                return false;

            foreach (var callbackOption in Containers.Keys)
            {
                if (callbackOption.Uid == callbackUid)
                    return true;
            }

            return false;
        }
        
        #endregion



        #region METHOD

        public static void EventCallback(string callbackUid)
        {
            if (Containers is null || Containers.Count == 0)
                return;
            
            (Containers.FirstOrDefault(x => x.Key.Uid == callbackUid).Value)?.OnEventCallback();
        }

        public static void EventCallback(object callback)
        {
            if (callback is not ICallback target)
                return;
            
            target.OnEventCallback();
        }

        public static void CategoryEventCallback(string category)
        {
            if (Containers is null || Containers.Count == 0)
                return;
            
            foreach (var option in Containers.Keys)
            {
                if (option.Category == category)
                    Containers[option].OnEventCallback();
            }
        }
        
        public static void AllEventCallback()
        {
            if (Containers is null || Containers.Count == 0)
                return;
            
            foreach (var callback in Containers.Values)
            {
                callback.OnEventCallback();
            }
        }
        
        #endregion

    }
}