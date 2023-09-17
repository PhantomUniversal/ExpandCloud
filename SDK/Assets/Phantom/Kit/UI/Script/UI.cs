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

        #region Variable

        internal static bool containerUse;

        internal static Dictionary<string, IUICallback> container;        

        #endregion



        #region Return

        public static bool Use => containerUse;

        public static int Count => container.Count;
        
        #endregion


        
        #region Method

        public static bool AddCallback(object callback) => AddCallback(callback, "");
        public static bool AddCallback(object callback, string uniqueCode)
        {
            var target = callback as IUICallback;
            if (target is null)
                return false;

            container ??= new Dictionary<string, IUICallback>();
            uniqueCode = string.IsNullOrEmpty(uniqueCode) ? Guid.NewGuid().ToString() : uniqueCode;
            container.Add(uniqueCode, target);
            
            if (container is not null && container.Count > 0)
                containerUse = true;

            return true;
        }

        public static bool RemoveCallback(string uniqueCode)
        {
            if (container is null || container.Count == 0)
            {
                containerUse = false;
                return false;
            }

            if (!container.ContainsKey(uniqueCode))
                return false;
            
            var result = container.Remove(uniqueCode);
            if (result)
            {
                if (container.Count == 0)
                    containerUse = false;
            }

            return true;
        }
        
        public static bool RemoveCallback(object callback)
        {
            var target = callback as IUICallback;
            if (target is null)
                return false;

            if (container is null || container.Count == 0)
            {
                containerUse = false;
                return false;
            }

            if (!container.ContainsValue(target))
                return false;

            var key = container.FirstOrDefault(x => x.Value == target).Key;
            var result = container.Remove(key);
            if (result)
            {
                if (container.Count == 0)
                    containerUse = false;
            }

            return true;
        }
        
        public static bool ClearCallback()
        {
            if (!containerUse)
            {
                return false;
            }
            
            container.Clear();
            containerUse = false;

            return true;
        }

        public static string FindCode(object callback)
        {
            var target = callback as IUICallback;
            if (target is null)
                return "";

            if (!container.ContainsValue(target))
                return "";

            return container.FirstOrDefault(x => x.Value == target).Key;
        }
        
        public static IUICallback FindCallback(string uniqueCode)
        {
            return container[uniqueCode];
        }
        
        public static bool EventCallback(UICallbackType type, string uniqueCode)
        {
            if (!container.ContainsKey(uniqueCode))
                return false;
            
            var callback = container[uniqueCode];
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
            if (!containerUse)
                return false;
            
            foreach (var callback in container.Values)
            {
                callback.OnInitCallback();
            }

            return true;
        }
        
        public static bool UpdateCallback()
        {
            if (containerUse)
                return false;
            
            foreach (var callback in container.Values)
            {
                callback.OnUpdateCallback();
            }

            return true;
        }

        #endregion
        
    }   
}