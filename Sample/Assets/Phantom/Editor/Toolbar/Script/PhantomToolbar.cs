/*
 1. Toolbar add and remove 기능
    => Custom  
 */

#if UNITY_EDITOR

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Phantom
{
    [InitializeOnLoad]
    public class PhantomToolbar
    {
        static PhantomToolbar()
        {
            EditorApplication.update += Toolbar;
        }

        #region Toolbar

        private static readonly Type toolbarType = typeof(Editor).Assembly.GetType("UnityEditor.Toolbar");
        private static ScriptableObject currentToolbar;
        
        private static void Toolbar()
        {
            if (currentToolbar == null)
            {
                UnityEngine.Object[] toolbars = Resources.FindObjectsOfTypeAll(toolbarType);
                currentToolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;
                if (currentToolbar != null)
                {
                    FieldInfo root = currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
                    VisualElement toolbar = root.GetValue(currentToolbar) as VisualElement;

                    VisualElement toolbarZone = toolbar.Q("ToolbarZoneRightAlign");
                    VisualElement toolbarStyle = new VisualElement()
                    {
                        style =
                        {
                            flexGrow = 1,
                            flexDirection = FlexDirection.Row,
                        }
                    };

                    IMGUIContainer container = new IMGUIContainer();
                    container.onGUIHandler += ToolbarGUI;
                    toolbarStyle.Add(container);
                    toolbarZone.Add(toolbarStyle);
                }
            }
        }

        private static void ToolbarGUI()
        {
            GUILayout.BeginHorizontal();
            {
                GUILayout.Space(20f);
                
                if (GUILayout.Button(EditorGUIUtility.FindTexture(ToolbarSourcePath() + "/" + "setting.png"), EditorStyles.toolbarButton, GUILayout.Width(40f),
                        GUILayout.Height(20f)))
                {
                    var rect = GUILayoutUtility.GetLastRect();
                    rect.x += 20f;
                    rect.y += 20f;
                    
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Account"), false, PhantomAuth.Tool);
                    menu.AddSeparator("");   
                    menu.AddItem(new GUIContent("Option/Tag/Install"), false, PhantomTag.InstallClick);
                    menu.AddItem(new GUIContent("Option/Tag/UnInstall"), false, PhantomTag.UnInstallClick);
                    menu.AddSeparator($"");
                    menu.AddItem(new GUIContent("Option/Layer/Install"), false, PhantomLayer.InstallClick);
                    menu.AddItem(new GUIContent("Option/Layer/UnInstall"), false, PhantomLayer.UnInstallClick);
                    menu.DropDown(rect);
                }
                
                GUILayout.Space(20f);
            }
            GUILayout.EndHorizontal();
        }

        private static string ToolbarSourcePath([CallerFilePath] string package = null)
        {
            if (package.Contains("com.phantom.sdk"))
            {
                return "Packages/com.phantom.sdk/Editor/Toolbar/Source";
            }
            else
            {
                return "Assets/Phantom/Editor/Toolbar/Source";
            }
        }
        
        #endregion
        
    }
}

#endif