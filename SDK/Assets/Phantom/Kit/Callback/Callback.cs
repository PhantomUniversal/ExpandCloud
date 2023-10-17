using System;
using System.Collections.Generic;
using System.Linq;

namespace Phantom.Callback
{
    public static class Callback
    {

        #region VARIABLE

        private static Dictionary<CallbackOption, ICallback> _containers;

        #endregion



        #region RETURN

        public static bool Use => _containers != null && _containers.Count != 0;

        public static int Count => _containers.Count;

        #endregion



        #region UTILITY

        public static bool Add(object callback) => Add( callback, null );
        
        public static bool Add(object callback, CallbackOption callbackOption)
        {
            if (callback is not ICallback target)
                return false;

            // callbacks null is → new callback system
            _containers ??= new Dictionary<CallbackOption, ICallback>();

#if UNITY_EDITOR
            if (CallbackManager.Instance == null)
            {
                CallbackManager.Instance.Init();
            }            
#endif
            
            // callback option null is → new callback data
            callbackOption ??= new CallbackOption();
            callbackOption.Uid = string.IsNullOrEmpty(callbackOption.Uid) ? Guid.NewGuid().ToString() : callbackOption.Uid;

            return _containers.TryAdd(callbackOption, target);
        }

        public static bool Remove(string callbackUid)
        {
            if (_containers is null || _containers.Count == 0)
                return false;

            var callbackOption = _containers.FirstOrDefault(x => x.Key.Uid == callbackUid).Key;
            if (callbackOption is null)
            {
                return false;
            }
            
            return Remove(callbackOption);
        }

        public static bool Remove(object callback)
        {
            if (callback is not ICallback target)
                return false;
            
            if (_containers is null || _containers.Count == 0 || !_containers.ContainsValue(target))
                return false;
            
            var callbackOption = _containers.FirstOrDefault(x => x.Value == target).Key;
            return Remove(callbackOption);
        }

        private static bool Remove(CallbackOption callbackOption)
        { 
            return _containers.Remove(callbackOption);
        }

        // public static void CategoryRemove()
        // {
        //     
        // }
        
        public static bool Clear(bool enable = false)
        {
            if (_containers is null || _containers.Count == 0)
                return false;
            
            _containers.Clear();
            if (enable)
            {
                _containers = null;
            }

            return true;
        }

        public static ICallback Find(string callbackUid)
        {
            if (_containers is null || _containers.Count == 0)
                return null;
            
            foreach (var callbackOption in _containers.Keys)
            {
                if (callbackOption.Uid == callbackUid)
                {
                    return _containers[callbackOption];
                }
            }

            return null;
        }

        public static bool Exist(object callback)
        {
            if (callback is not ICallback target)
                return false;

            if (_containers is null || _containers.Count == 0 || !_containers.ContainsValue(target))
                return false;

            return true;
        }

        public static string FindUid(object callback)
        {
            if (callback is not ICallback target)
                return "";
            
            if (_containers is null || _containers.Count == 0 || !_containers.ContainsValue(target))
                return "";

            return _containers.FirstOrDefault(x => x.Value == target).Key.Uid;
        }

        public static bool ExistUid(string callbackUid)
        {
            if (_containers is null || _containers.Count == 0)
                return false;

            foreach (var callbackOption in _containers.Keys)
            {
                if (callbackOption.Uid == callbackUid)
                {
                    return true;
                }
            }

            return false;
        }
        
        #endregion



        #region METHOD

        public static void UpdateCallback(string callbackUid)
        {
            if (_containers is null || _containers.Count == 0)
                return;
            
            (_containers.FirstOrDefault(x => x.Key.Uid == callbackUid).Value)?.OnUpdateCallback();
        }

        public static void UpdateCallback(object callback)
        {
            if (callback is not ICallback target)
                return;
            
            target.OnUpdateCallback();
        }

        public static void AllUpdateCallback()
        {
            if (_containers is null || _containers.Count == 0)
                return;
            
            foreach (var callback in _containers.Values)
            {
                callback.OnUpdateCallback();
            }
        }
        
        #endregion

    }
}