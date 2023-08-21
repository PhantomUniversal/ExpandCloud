/*
 * day : 2023-08-21
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Phantom
{
    public class MetalivePrefab : Editor
    {

        #region Prefab

        [MenuItem("GameObject/Phantom/Prefab/Test", priority = 1)]
        public static void Test()
        {
            if (IsDuplicatedMenu()) return;
            
            CreatePrefab("Test.prefab");
        }
        
        public static void CreatePrefab(string prefabName)
        {
            var rootPath = SourcePath();
            var path = rootPath + "/" + prefabName;            
            var prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
            
            // SelectionMode.TopLevel => Top of top parents
            // SelectionMode.Unfiltered => choice 
            var selections = Selection.GetTransforms(SelectionMode.Unfiltered);            
            if(selections.Length > 0)
            {
                for (int i = 0; i < selections.Length; i++)
                {
                    var obj = Instantiate(prefab, selections[i]);
                    obj.name = prefabName.Split('.')[0];
                    
                    // 아래 두개는 => for문 끝나고 하는게 좋지 않을까?
                    Selection.activeGameObject = obj;
                    EditorSceneManager.SaveScene(obj.gameObject.scene);
                }
            }
            else
            {
                var searchParent = "InteractiveCollection";
                var parent = GameObject.Find(searchParent);
                if(parent == null)
                {
                    parent = new GameObject(searchParent);
                }

                var obj = Instantiate(prefab, parent.transform);
                obj.name = prefabName.Split('.')[0];
                Selection.activeGameObject = obj;
                EditorSceneManager.SaveScene(obj.gameObject.scene);
            }  
        }
        
        private static string duplicatedMenu = "";
        private static bool IsDuplicatedMenu([CallerMemberName] string memberName = "")
        {
            string menu = memberName + DateTime.Now.ToString();
            if (duplicatedMenu.Equals(menu))
            {
                return true;
            }
            else
            {
                duplicatedMenu = menu;
                return false;
            }
        }
        
        private static string SourcePath([CallerFilePath] string fileName = null)
        {
            if (fileName.Contains("com.phantom.sdk"))
            {
                return "Packages/com.phantom.sdk/Editor/Prefab/Source";
            }
            else
            {
                return "Assets/Phantom/Editor/Prefab/Source";
            }
        }

        #endregion
        
    }
}

# endif