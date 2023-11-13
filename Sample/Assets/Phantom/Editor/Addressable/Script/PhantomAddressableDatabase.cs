/*
 * day : 2023-08-17
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public class PhantomAddressableDatabase : Editor
    {

        #region Database

        public static void DatabaseSetting()
        {
            Database<PhantomAddressableSetting>("Test");
        }
        
        public static void Database<T>(string address) where T : ScriptableObject
        {
            var directory = "Assets/PhantomSetting/Database";
            var file = $"{typeof(T).Name}.asset";
            var path = directory + "/" + file;

            var database = AssetDatabase.LoadAssetAtPath(path, typeof(T)) as T;
            if (database)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                database = CreateInstance<T>();
                AssetDatabase.CreateAsset(database, path);
                AssetDatabase.SaveAssets();
            }
            
            if (PhantomAddressable.FindEntry(database) == null)
            {
                var entryGroup = "Database";
                var entryAddress = $"Database_{address}";
                var entryLabel = "Database";

                PhantomAddressable.AddEntry(database, entryGroup, address, entryLabel);
            }

            Selection.activeObject = database;
        }

        #endregion
        
    }
}

# endif