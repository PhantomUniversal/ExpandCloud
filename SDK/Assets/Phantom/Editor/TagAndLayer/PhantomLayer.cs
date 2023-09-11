/*
 * day : 2023-08-21
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public class PhantomLayer
    {

        #region Layer

        public static readonly string version = "1.0.0";

        public static readonly string release = "2023-08-21";

        public static readonly List<string> layers = new List<string>()
        {
            "Obstruction",
            "Interactive",
            "Point",
            "Waypoint",
            "Map",
            "Gate",
            "Teleport",
            "Portal",
            "Player",
            "User",
            "Friendly",
            "Enemy",
            "Boss",
            "Npc",
            "Pet",
            "Riding",
        };

        public static bool InstallCheck()
        {
            try
            {
                foreach (var layer in layers)
                {
                    if(layer.Length == 0)
                        continue;

                    if (!InstallExist(layer))
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

        public static bool InstallExist(string layerName)
        {
            try
            {
                var serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                var serializedProperty = serializedObject.FindProperty("layers");
                for (int i = 0; i < 31; i++)
                {
                    var serializedIndex = serializedProperty.GetArrayElementAtIndex(i);
                    if (serializedIndex.stringValue.Equals(layerName))
                    {
                        return true;
                    }
                }
                return false;
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
                for (int i = 0; i < layers.Count; i++)
                {
                    if (layers[i].Length == 0)
                        continue;

                    InstallUpdate(i + 8, layers[i]);
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool InstallUpdate(int index, string layerName)
        {
            try
            {
                var serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                var serializedProperty = serializedObject.FindProperty("layers");
                var serializedIndex = serializedProperty.GetArrayElementAtIndex(index);
                serializedIndex.stringValue = layerName;
                serializedObject.ApplyModifiedProperties();

                return true;
            }
            catch(Exception e)
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
                var serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
                var serializedProperty = serializedObject.FindProperty("layers");

                var baseCount = 8; // 기본 레이어 개수 (0부터 7까지)를 설정합니다.

                for (int i = baseCount; i < serializedProperty.arraySize; i++)
                {
                    SerializedProperty layerProperty = serializedProperty.GetArrayElementAtIndex(i);
                    if (layerProperty != null)
                    {
                        layerProperty.stringValue = ""; // 레이어 이름을 비웁니다.
                    }
                }

                serializedObject.ApplyModifiedProperties();

                return true;
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }    
        }
        
        #endregion

    }
}

# endif