#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Phantom
{
    public class PhantomAddressableExport 
    {
        public static bool Export()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingEntrys = new List<AddressableAssetEntry>();
                setting.GetAllAssets(settingEntrys, true);
                
                foreach (var entry in settingEntrys)
                {
                    if (entry.AssetPath.EndsWith(".unity"))
                    {
                        var removeResult = PhantomAddressable.RemoveEntry(entry);
                        if (!removeResult)
                        {
                            return false;
                        }
                    }
                }
                
                var settingScenes = EditorBuildSettings.scenes;
                if (settingScenes.Length > 0)
                {
                    for (int i = 0; i < settingScenes.Length; i++)
                    {
                        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(settingScenes[i].path);
                        if (sceneAsset != null)
                        {
                            var group = "[ Example ] - GroupName";
                            var address = $"[ Example ] - ProjectCode_Export(code)_{i}";
                            var label = "Scene";

                            var addResult = PhantomAddressable.AddEntry(sceneAsset, group, address, label);
                            if (!addResult)
                            {
                                return false;
                            }
                        }
                    }
                }

                var remoteResult = PhantomAddressable.SettingAllGroup();
                if (!remoteResult)
                {
                    return false;
                }
                
                AddressableAssetSettings.CleanPlayerContent();
                if (Directory.Exists(ExportPath()))
                {
                    Directory.Delete(ExportPath(), true);
                }
                
                EditorCoroutineUtility.StartCoroutineOwnerless(ExportAsync());
                
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        public static IEnumerator ExportAsync()
        {
            // 빌드 시작
            AddressableAssetSettings.BuildPlayerContent();
            
            // 빌드 진행중일때 대기
            while (BuildPipeline.isBuildingPlayer)
            {
                yield return null;
            }

            // 빌드 완료후 지정한 폴더 열기
            ExportFolder();
        }
        
        public static string ExportPath()
        {
            AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
            var version = settings.profileSettings.GetProfileName(settings.activeProfileId);

            var path = Application.dataPath.Replace("/Assets", "");
            path += $"/ServerData/{version}/";

            var platform = EditorUserBuildSettings.activeBuildTarget;
            switch(platform)
            {
                case BuildTarget.Android:
                    path += "Android";
                    break;
                case BuildTarget.iOS:
                    path += "iOS";
                    break;
                default:
                    path += "StandaloneWindows64";
                    break;
            }

            return path;
        }
        
        public static void ExportFolder()
        {
            var result = PhantomAddressable.SettingAllGroup();
            if (result)
            {
                if (!Directory.Exists(ExportPath()))
                {
                    Directory.CreateDirectory(ExportPath());
                }

                System.Diagnostics.Process.Start(ExportPath());
            }
        }
    }    
}

# endif