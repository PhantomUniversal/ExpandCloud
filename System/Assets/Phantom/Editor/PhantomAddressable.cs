#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Phantom
{
    public class PhantomAddressable : Editor
    {

        #region Group
        
        // ==================================================
        // [ Create ]
        // ==================================================
        public static bool CreateGroup(string groupName)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;
                var settingGroup = settingGroups.Find(x => x.name == groupName);

                if (settingGroup == null)
                {
                    var bundledAssetGroupSchema = CreateInstance<BundledAssetGroupSchema>();
                    var contentUpdateGroupSchema = CreateInstance<ContentUpdateGroupSchema>();

                    var addressableAssetGroupSchema = new List<AddressableAssetGroupSchema>
                    {
                        bundledAssetGroupSchema,
                        contentUpdateGroupSchema,
                    };

                    setting.CreateGroup
                    (
                        groupName: groupName,
                        setAsDefaultGroup: false,
                        readOnly: false,
                        postEvent: true,
                        schemasToCopy: addressableAssetGroupSchema
                    );

                    var result = SettingGroup(groupName);
                    if (!result)
                    {
                        Debug.LogError("Group setting fail");
                    }
                }
                
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        
        // ==================================================
        // [ Remove ]
        // ==================================================
        public static bool RemoveGroup(string groupName)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;
                var settingGroup = settingGroups.Find(x => x.name == groupName);
                if (settingGroup != null)
                {
                    setting.RemoveGroup(settingGroup);
                }

                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        // 강제성이 동반하는 작업
        // 백업 후 삭제하는방법을 찾아보는게 좋을듯
        public static bool RemoveAllGroup()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;

                for (int i = 0; i < settingGroups.Count; i++)
                {
                    setting.RemoveGroup(settingGroups[i]);
                }

                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool RemoveAllEmptyGroup()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;

                for (int i = 0; i < settingGroups.Count; i++)
                {
                    var settingGroup = settingGroups[i];
                    if (settingGroup.IsDefaultGroup())
                    {
                        // Group이 기본 설정 그룹일 경우
                        continue;
                    }

                    if (0 < settingGroup.entries.Count)
                    {
                        // Group내에 정보가 있을경우
                        continue;
                    }
                    
                    setting.RemoveGroup(settingGroup);
                }
                
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        
        // ==================================================
        // [ Find ]
        // ==================================================
        public static AddressableAssetGroup FindGroup(string groupName)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;
                
                return settingGroups.Find(x => x.name == groupName);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return null;
            }
        }
        
        
        // ==================================================
        // [ Setting ]
        // * SettingGroup => RemoteGroup 변경이 좋지 않을까?
        // ==================================================
        public static bool SettingDefalutGroup()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroup = setting.DefaultGroup;
                
                if (settingGroup != null)
                {
                    var bundledAssetGroupSchema = settingGroup.GetSchema<BundledAssetGroupSchema>();
                    if (bundledAssetGroupSchema == null)
                    {
                        bundledAssetGroupSchema = settingGroup.AddSchema<BundledAssetGroupSchema>();
                    }

                    bundledAssetGroupSchema.BuildPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteBuildPath);
                    bundledAssetGroupSchema.LoadPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteLoadPath);
                }
            
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        public static bool SettingGroup(string groupName)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;
                var settingGroup = settingGroups.Find(x => x.name == groupName);
            
                if (settingGroup == null)
                {
                    Debug.LogError("No search group");
                    return false;
                }

                if (settingGroup != null)
                {
                    var bundledAssetGroupSchema = settingGroup.GetSchema<BundledAssetGroupSchema>();
                    if (bundledAssetGroupSchema == null)
                    {
                        bundledAssetGroupSchema = settingGroup.AddSchema<BundledAssetGroupSchema>();
                    }

                    bundledAssetGroupSchema.BuildPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteBuildPath);
                    bundledAssetGroupSchema.LoadPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteLoadPath);
                    
                    EditorUtility.SetDirty(bundledAssetGroupSchema);
                }
            
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool SettingAllGroup()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;

                foreach (var settingGroup in settingGroups)
                {
                    if (settingGroup.Name.Equals("Built In Data"))
                    {
                        continue;
                    }
                    
                    var bundledAssetGroupSchema = settingGroup.GetSchema<BundledAssetGroupSchema>();
                    if (bundledAssetGroupSchema == null)
                    {
                        bundledAssetGroupSchema = settingGroup.AddSchema<BundledAssetGroupSchema>();
                    }
                    
                    bundledAssetGroupSchema.BuildPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteBuildPath);
                    bundledAssetGroupSchema.LoadPath.SetVariableByName(settingGroup.Settings,
                        AddressableAssetSettings.kRemoteLoadPath);
                    
                    EditorUtility.SetDirty(bundledAssetGroupSchema);
                }
                
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool SortNameGroup()
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroups = setting.groups;
                
                settingGroups.Sort((a, b) => a.Name.CompareTo(b.name));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        #endregion


        
        #region Entry

        // ==================================================
        // [ Add ]
        // 
        // * Replace
        // targetGroup, targetAddressable, targetLable => Class로 묶는것이 어떨까? 
        //
        // ==================================================
        
        public static bool AddEntry(UnityEngine.Object entryTarget, string entryGroup , string entryAddress, string entryLabel)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingGroupName = string.IsNullOrEmpty(entryGroup) ? setting.DefaultGroup.name : entryGroup;
                var settingGroup = FindGroup(settingGroupName);

                if (settingGroup == null)
                {
                    settingGroup = setting.DefaultGroup;
                }

                var result = SettingGroup(settingGroupName);
                if (!result)
                {
                    Debug.LogWarning("Group setting error! check group information");
                }

                var objectPath = AssetDatabase.GetAssetPath(entryTarget);
                var objectGuid = AssetDatabase.AssetPathToGUID(objectPath);
                var objectEntry = setting.CreateOrMoveEntry(objectGuid, settingGroup);
                if (objectEntry == null)
                {
                    Debug.LogError("Add entry fail");
                    return false;
                }
                
                if (!string.IsNullOrEmpty(entryAddress))
                {
                    objectEntry.SetAddress(entryAddress);    
                }

                if (!string.IsNullOrEmpty(entryLabel))
                {
                    objectEntry.SetLabel(entryLabel, true);
                }
                
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        // ==================================================
        // [ Remove ]
        // * Entry remove 후에 빈 그룹은 삭제하는게 좋지 않을까?
        // ==================================================
        public static bool RemoveEntry(AddressableAssetEntry entry)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var result = setting.RemoveAssetEntry(entry.guid);
                if (!result)
                {
                    Debug.LogError("Entry remove fail");
                    return false;
                }

                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }

        public static bool RemoveEntry(UnityEngine.Object entryTarget)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var targetPath = AssetDatabase.GetAssetPath(entryTarget);
                var targetGuid = AssetDatabase.AssetPathToGUID(targetPath);

                var result = setting.RemoveAssetEntry(targetGuid);
                if (!result)
                {
                    Debug.LogError("Entry remove fail");
                    return false;
                }

                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        public static bool RemoveEntry(string entryAddress)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingEntrys = new List<AddressableAssetEntry>();
                setting.GetAllAssets(settingEntrys, true);
                
                foreach (var entry in settingEntrys)
                {
                    if (entry.address == entryAddress)
                    {
                        setting.RemoveAssetEntry(entry.guid);   
                    }
                }
                
                EditorUtility.SetDirty(setting);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
        // ==================================================
        // [ Find ]
        // ==================================================
        public static AddressableAssetEntry FindEntry(string entryAddress)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingEntrys = new List<AddressableAssetEntry>();
                setting.GetAllAssets(settingEntrys, true);

                return settingEntrys.Find(x => x.address == entryAddress);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return null;
            }             
        }

        public static AddressableAssetEntry FindEntry(UnityEngine.Object entryTarget)
        {
            try
            {
                var setting = AddressableAssetSettingsDefaultObject.Settings;
                var settingEntrys = new List<AddressableAssetEntry>();
                setting.GetAllAssets(settingEntrys, true);
            
                return settingEntrys.Find(x => x.MainAsset == entryTarget);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return null;
            }
        }
        
        #endregion


        public static bool ClearCache()
        {
            try
            {
                return Caching.ClearCache();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
        }
        
    }
}

#endif