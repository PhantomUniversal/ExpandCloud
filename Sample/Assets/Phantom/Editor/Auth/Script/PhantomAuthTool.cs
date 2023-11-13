/*
 * day : 2023-08-17
 * write : phantom
 * email : chho1365@gmail.com
 */

using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public class PhantomAuthTool : EditorWindow
    {
        #region Lifecycle
        
        // private void CreateGUI()
        // {
        //     // 1회 => 시작시
        //     Debug.Log("CreateGUI");
        // }

        private void OnGUI()
        {
            // ==================================================
            // [ Style ]
            // ==================================================
            var labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft
            };

            var fieldStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                alignment = TextAnchor.MiddleLeft
            };

            var buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter
            };
            
            // ==================================================
            // [ Layout ]
            // ==================================================
            if (Event.current.keyCode == KeyCode.Escape)
            {
                Close();
                return;
            }

            if (Event.current.keyCode == KeyCode.Return)
            {
                if (PhantomAuth.setting.status != PhantomAuthStatus.SignIn)
                {
                    PhantomAuth.SignIn();
                }
                return;
            }

            EditorGUI.BeginChangeCheck();

            if (PhantomAuth.setting.status == PhantomAuthStatus.SignIn)
            {
                GUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    
                    // AccessToken
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);

                        // Auth UserCodeNumber 
                        GUILayout.Label("AccessToken", labelStyle, GUILayout.Width(100f), GUILayout.Height(20f));
                        GUILayout.Label(PhantomAuth.setting.token, GUILayout.ExpandWidth(true), GUILayout.Height(20f));

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    // RefreshToken
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);
                        
                        GUILayout.Label("RefreshToken", labelStyle, GUILayout.Width(100f), GUILayout.Height(20f));
                        GUILayout.Label(PhantomAuth.setting.refresh, GUILayout.ExpandWidth(true), GUILayout.Height(20f));

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    // Code
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);
                        
                        GUILayout.Label("Code", labelStyle, GUILayout.Width(100f), GUILayout.Height(20f));
                        GUILayout.Label(PhantomAuth.setting.code, GUILayout.ExpandWidth(true), GUILayout.Height(20f));

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    // Nickname
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);
                        
                        GUILayout.Label("Nickname", labelStyle, GUILayout.Width(100f), GUILayout.Height(20f));
                        GUILayout.Label(PhantomAuth.setting.nickname, GUILayout.ExpandWidth(true), GUILayout.Height(20f));

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.Space(20f);
                    
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);

                        // 로그아웃
                        if (GUILayout.Button(EditorGUIUtility.FindTexture(SourcePath() + "/" + "signout.png"), buttonStyle, GUILayout.ExpandWidth(true), GUILayout.Height(40f)))
                        {
                            PhantomAuth.SignOut();
                        }

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndVertical();
            }
            else
            {
                GUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    
                    // ==================================================
                    // [ Email ]
                    // ==================================================
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);
                    
                        EditorGUILayout.LabelField("Email", labelStyle, GUILayout.Width(80f), GUILayout.Height(20f));
                        PhantomAuth.setting.email = EditorGUILayout.TextField(PhantomAuth.setting.email, GUILayout.Width(220f), GUILayout.Height(20f));
                    
                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.Space(2f);
                    
                    // ==================================================
                    // [ Password ]
                    // ==================================================
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);
                        
                        EditorGUILayout.LabelField("Password", labelStyle, GUILayout.Width(80f), GUILayout.Height(20f));

                        if (PhantomAuth.setting.hide)
                        {
                            PhantomAuth.setting.password = EditorGUILayout.PasswordField(PhantomAuth.setting.password, GUILayout.Width(220f), GUILayout.Height(20f));
                        }
                        else
                        {
                            PhantomAuth.setting.password = EditorGUILayout.TextField(PhantomAuth.setting.password, GUILayout.Width(220f), GUILayout.Height(20f));
                        }
                        
                        GUILayout.Space(4f);
                        
                        GUILayout.BeginVertical();
                        {
                            GUILayout.Space(4f);

                            if (PhantomAuth.setting.hide)
                            {
                                if (GUILayout.Button(EditorGUIUtility.FindTexture(SourcePath() + "/" + "show.png"), EditorStyles.iconButton, GUILayout.Width(20f), GUILayout.Height(20f)))
                                {
                                    PhantomAuth.setting.hide = false;
                                }
                            }
                            else
                            {
                                if (GUILayout.Button(EditorGUIUtility.FindTexture(SourcePath() + "/" + "hide.png"), EditorStyles.iconButton, GUILayout.Width(20f), GUILayout.Height(20f)))
                                {
                                    PhantomAuth.setting.hide = true;
                                }
                            }
                            
                            GUILayout.Space(4f);
                        }
                        GUILayout.EndVertical();
                    }
                    GUILayout.EndHorizontal();
                    
                    // Auto => Editor access signin
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(100f);
                        
                        GUILayout.Space(4f);
                        PhantomAuth.setting.auto = EditorGUILayout.Toggle("", PhantomAuth.setting.auto, EditorStyles.toggle, GUILayout.Width(20f), GUILayout.Height(20f));
                        GUILayout.Label("Auto (sign in)", fieldStyle, GUILayout.Width(80f), GUILayout.Height(20f));

                        GUILayout.Space(20f);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.Space(20f);
                    
                    // Signin
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(20f);

                        if (GUILayout.Button(EditorGUIUtility.FindTexture(SourcePath() + "/" + "signin.png"), buttonStyle, GUILayout.ExpandWidth(true), GUILayout.Height(40f)))
                        {
                            PhantomAuth.SignIn();
                        }

                        GUILayout.Space(32f);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndVertical();
            }
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(PhantomAuth.setting);
            }
        }

        #endregion


        #region Method
        
        private string SourcePath([CallerFilePath] string package = null)
        {
            if (package.Contains("com.phantom.sdk"))
            {
                return "Packages/com.phantom.sdk/Editor/Auth/Source";
            }
            else
            {
                return "Assets/Phantom/Editor/Auth/Source";
            }
        }
        
        #endregion
    }
}