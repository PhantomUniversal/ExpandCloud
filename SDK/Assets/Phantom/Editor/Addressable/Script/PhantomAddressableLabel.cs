/*
 * day : 2023-08-21
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Phantom
{
    public class PhantomAddressableLabel
    {

        #region Label

        public static readonly string version = "0.0.1(Beta)";

        public static readonly string release = "2023-08-21";

        public static readonly List<string> labels = new List<string>()
        {
            "World",
            "Map",
            "Skybox",
            "Texture",
            "Sound",
            "Video",
            "Data",
            "Player",
            "Enemy",
            "Npc"
        };

        public static bool InstallCheck()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingLabels = setting.GetLabels();

                foreach (var label in labels)
                {
                    if (label.Length == 0)
                        continue;                  
                    
                    if (!settingLabels.Exists(x => x == label))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool Install()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingLabels = setting.GetLabels();
                
                foreach (var label in labels)
                {
                    if(label.Length == 0)
                        continue;

                    if (!settingLabels.Exists(x => x == label))
                    {
                        setting.AddLabel(label, true);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool UnInstall()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingLabels = setting.GetLabels();

                foreach (var label in labels)
                {
                    if(label.Length == 0)
                        continue;

                    if (settingLabels.Exists(x => x == label))
                    {
                        setting.RemoveLabel(label, true);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        #endregion

    }
}

#endif