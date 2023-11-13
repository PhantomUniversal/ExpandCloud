/*
 * day : 2023-09-13
 * write : phantom
 * email : chho1365@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Phantom
{
    public class UI
    {

        #region CALLBACK

        // ==================================================
        // [ Variable ]
        // ==================================================
        private static Dictionary<string, IUICallback> _container;
        
        
        // ==================================================
        // [ Return ]
        // ==================================================
        public static bool IsContainer => _container != null && _container.Count != 0;

        public static int ContainerCount => _container.Count;
        
        
        // ==================================================
        // [ Utility ]
        // ==================================================
        public static bool AddCallback(object callback) => AddCallback(callback, null); 
        public static bool AddCallback(object callback, string uniqueCode)
        {
            if (callback is not IUICallback target) 
                return false;

            _container ??= new Dictionary<string, IUICallback>();

            uniqueCode = string.IsNullOrEmpty(uniqueCode) ? Guid.NewGuid().ToString() : uniqueCode;
            return _container.TryAdd(uniqueCode, target);
        }

        public static bool RemoveCallback(string uniqueCode)
        {
            if (_container == null || _container.Count == 0)
                return false;

            var callback = _container[uniqueCode];
            if (callback == null)
                return false;
                
            return RemoveCallback(callback, uniqueCode);
        }
        
        public static bool RemoveCallback(object callback, string uniqueCode)
        {
            if (callback is not IUICallback target) 
                return false;

            if (_container == null || _container.Count == 0)
                return false;

            uniqueCode = string.IsNullOrEmpty(uniqueCode)
                ? _container.FirstOrDefault(x => x.Value == target).Key : uniqueCode;
            return _container.Remove(uniqueCode);
        }

        public static bool ClearCallback()
        {
            if (_container == null || _container.Count == 0)
                return false;
            
            _container.Clear();
            return true;
        }

        public static IUICallback FindCallback(string uniqueCode) => _container[uniqueCode];

        public static string FindCode(object callback)
        {
            var target = callback as IUICallback;
            if (target is null)
                return "";

            if (!_container.ContainsValue(target))
                return "";

            return _container.FirstOrDefault(x => x.Value == target).Key;
        }
        
        public static bool EventCallback(UICallbackType type, string uniqueCode)
        {
            if (!_container.ContainsKey(uniqueCode))
                return false;
            
            var callback = _container[uniqueCode];
            switch (type)
            {
                case UICallbackType.Init:
                    callback.OnInitCallback();
                    break;
                case UICallbackType.Update:
                    callback.OnUpdateCallback();
                    break;
            }

            return true;
        }
            
        
        public static bool InitCallback()
        {
            if (!IsContainer)
                return false;
            
            foreach (var callback in _container.Values)
            {
                callback.OnInitCallback();
            }

            return true;
        }
        
        public static bool UpdateCallback()
        {
            if (IsContainer)
                return false;
            
            foreach (var callback in _container.Values)
            {
                callback.OnUpdateCallback();
            }

            return true;
        }
        
        #endregion
        
    }   
}