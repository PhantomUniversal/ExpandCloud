/*
 * day : 2023-08-28
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
    [CustomEditor(typeof(SettingData), true)]
    [CanEditMultipleObjects]
    public class SettingInspector : Editor
    {

        #region Variable

        private SettingData settingData;

        #endregion
        
        #region Lifecycle

        private void OnEnable()
        {
            if (settingData == null)
            {
                settingData = (SettingData)target;
            }
        }

        private void OnDisable()
        {
            if (settingData != null)
            {
                settingData = null;
            }
        }
        
        public override void OnInspectorGUI()
        {
            // ==================================================
            // [ Style ]
            // ==================================================
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
            };
            
            GUIStyle paddingStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                padding = new RectOffset(20, 0, 0, 0),  
            };
            
            GUIStyle popupStyle = new GUIStyle(EditorStyles.popup)
            {
                padding = new RectOffset(10, 0, 0, 0),
                fixedHeight = 30f, 
                alignment = TextAnchor.MiddleLeft,
            };
            
            GUIStyle foldOutStyle = new GUIStyle(EditorStyles.foldout)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                padding = new RectOffset(20, 0, 0, 0),                
            };
            
            // ==================================================
            // [ Layout ]
            // ==================================================
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
            serializedObject.ApplyModifiedProperties();
            
            EditorGUI.BeginChangeCheck();
            
            // [ Server ]
            EditorGUI.indentLevel++;
            GUILayout.BeginVertical(EditorStyles.helpBox);
            {
                GUILayout.Space(10f);
                
                settingData.server.use = EditorGUILayout.Foldout(settingData.server.use, "Server", true, foldOutStyle);
                if (settingData.server.use)
                {
                    GUILayout.BeginVertical();
                    {
                        GUILayout.Space(10f);

                        GUILayout.BeginHorizontal();
                        {
                            GUILayout.Space(20f);
                            GUILayout.Label("Type", labelStyle, GUILayout.Width(80f), GUILayout.Height(30f));
                            settingData.server.type = (int)((SettingServerType)EditorGUILayout.EnumPopup((SettingServerType)settingData.server.type, popupStyle, GUILayout.ExpandWidth(true), GUILayout.Height(30f)));
                            GUILayout.Space(20f);
                        }
                        GUILayout.EndHorizontal();

                        if ((SettingServerType)settingData.server.type != SettingServerType.None)
                        {
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Space(20f);
                                GUILayout.Label("API", labelStyle, GUILayout.Width(80f), GUILayout.Height(30f));
                                GUILayout.Label(settingData.server.api, paddingStyle, GUILayout.ExpandWidth(true), GUILayout.Height(30f));
                                GUILayout.Space(20f);
                            }
                            GUILayout.EndHorizontal();   
                        }

                        GUILayout.BeginHorizontal();
                        {
                            GUILayout.Space(20f);
                            GUILayout.Label("Platform", labelStyle, GUILayout.Width(80f), GUILayout.Height(30f));
                            GUILayout.Label(settingData.server.platform, paddingStyle, GUILayout.ExpandWidth(true), GUILayout.Height(30f));
                            GUILayout.Space(20f);
                        }
                        GUILayout.EndHorizontal();
                        
                        GUILayout.Space(10f);
                    }
                    GUILayout.EndVertical();
                }
                
                GUILayout.Space(10f);
            }
            GUILayout.EndVertical();
            
            if (EditorGUI.EndChangeCheck())
            {                
                EditorUtility.SetDirty(settingData);
            }
        }
        
        #endregion
        
    }
}

#endif