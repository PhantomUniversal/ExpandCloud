/*
 * day : 2023-08-21
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

namespace Phantom
{
    public class PhantomTag
    {
        #region Tag

        public static readonly string version = "0.0.1";

        public static readonly string release = "2023-08-21";

        public static readonly List<string> tags = new List<string>()
        {
            "GameManager",
            "NetworkManager",
            "SoundManager"
        };

        public static bool InstallCheck()
        {
            try
            {
                foreach (var tag in tags)
                {
                    if(tag.Length == 0)
                        continue;

                    if (!InternalEditorUtility.tags.Contains(tag))
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

        public static void InstallClick() => Install();
        public static bool Install()
        {
            try
            {
                foreach (var tag in tags)
                {
                    if(tag.Length == 0)
                        continue;
                    
                    if (!InternalEditorUtility.tags.Contains(tag))
                    {
                        InternalEditorUtility.AddTag(tag);
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

        public static void UnInstallClick() => UnInstall();
        public static bool UnInstall()
        {
            try
            {
                foreach (var tag in tags)
                {
                    if(tag.Length == 0)
                        continue;
                    
                    if (InternalEditorUtility.tags.Contains(tag))
                    {
                        InternalEditorUtility.RemoveTag(tag);
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

# endif