/*
 * day : 2023-09-11
 * write : phantom
 * email : chho1365@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class UI
    {

        #region Variable

        internal static bool containerUse;

        internal static List<IUICallback> container;        

        #endregion



        #region Check

        public static bool Use()
        {
            return containerUse;
        }

        public static int Count()
        {
            return container.Count;
        }

        #endregion


        
        #region Method

        public static void AddCallback(object target)
        {
            var callback = target as IUICallback;
            if (callback is null)
                return;
            
            container ??= new List<IUICallback>();
            if(container.Contains(callback) == false)
                container.Add(callback);

            if (container is not null && container.Count > 0)
                containerUse = true;
        }

        public static void RemoveCallback(object target)
        {
            var callback = target as IUICallback;
            if (callback is null)
                return;

            if (container is null || container.Count == 0)
            {
                containerUse = false;
                return;
            }

            if (container.Contains(callback))
            {
                var enable = container.Remove(callback);
                if (enable)
                {
                    if (container.Count == 0)
                        containerUse = false;
                }
            }
                
        }

        public static void ClearCallback()
        {
            if (containerUse)
            {
                container.Clear();
                containerUse = false;
            }
        }

        public static void InitCallback()
        {
            if (containerUse)
            {
                foreach (var callback in container)
                {
                    callback.OnInitCallback();
                }
            }
        }
        
        public static void UpdateCallback()
        {
            if (containerUse)
            {
                foreach (var callback in container)
                {
                    callback.OnUpdateCallback();
                }
            }
        }

        #endregion
        
    }   
}