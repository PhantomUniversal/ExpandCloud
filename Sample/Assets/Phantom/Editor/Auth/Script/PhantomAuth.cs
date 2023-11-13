/*
 * day : 2023-08-17
 * write : phantom
 * email : chho1365@gmail.com
 */

#if UNITY_EDITOR

using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Phantom
{
    public class PhantomAuth : Editor
    {
        static PhantomAuth()
        {
            Setting();
        }

        #region Tool

        public static void Tool()
        {
            if (IsSetting)
            {
                var window = EditorWindow.GetWindow<PhantomAuthTool>();
                var x = 360f;
                var y = 200f;

                window.position = new Rect(Screen.currentResolution.width * 0.5f, 70, x, y);
                window.titleContent = new GUIContent("[ Phantom ] Auth");
                window.minSize = window.maxSize = new Vector2(x, y);
                window.Show();
            }
            else
            {
                Debug.LogError("Setting does not exist.");
            }
        }

        #endregion

        #region Setting

        public static bool IsSetting
        {
            get
            {
                if (setting)
                {
                    return true;
                }
                else
                {
                    return false;   
                }
            }
        }

        public static PhantomAuthSetting setting;

        public static void Setting()
        {
            var directory = "Assets/PhantomSetting";
            var file = $"{typeof(PhantomAuthSetting).Name}.asset";
            var path = directory + "/" + file;

            setting = AssetDatabase.LoadAssetAtPath(path, typeof(PhantomAuthSetting)) as PhantomAuthSetting;
            if (setting == null)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                setting = CreateInstance<PhantomAuthSetting>();
                AssetDatabase.CreateAsset(setting, path);
                AssetDatabase.SaveAssets();
            }

            if (setting.auto)
            {
                SignIn();
            }
        }

        public static void SettingReset()
        {
            setting.email = "";
            setting.password = "";
            setting.auto = false;
            setting.hide = true;
            setting.token = "";
            setting.refresh = "";
            setting.code = "";
            setting.nickname = "";
            
            EditorUtility.SetDirty(setting);
        }
        
        #endregion

        #region SignIn/Out
        
        public static void SignIn()
        {
            SignInTemp();
            //EditorCoroutineUtility.StartCoroutineOwnerless(SignInAsync());
        }

        private static void SignInTemp()
        {
            if (IsSetting)
            {
                if (string.IsNullOrEmpty(setting.email) || string.IsNullOrEmpty(setting.password))
                {
                    EditorUtility.DisplayDialog("Null", "Please check your email, and password.", "CONFIRM");
                    return;
                }
                
                if (setting.email.Equals("chho1365@gmail.com") && setting.password.Equals("!ch1599623"))
                {
                    setting.status = PhantomAuthStatus.SignIn;
                    setting.token = "Bearer 00001";
                    setting.refresh = "Bearer 00001";
                    setting.code = "GM - 00001";
                    setting.nickname = "Phantom";
                    
                    EditorUtility.SetDirty(setting);
                }
                else
                {
                    EditorUtility.DisplayDialog("Null", "Please check your email, and password.", "CONFIRM");
                }
            }
        }
        
        private static IEnumerator SignInAsync()
        {
            if (IsSetting)
            {
                var wwwForm = new WWWForm();
                wwwForm.AddField("email", setting.email);
                wwwForm.AddField("password", setting.password);

                string url = $"https://";
                using (var request = UnityWebRequest.Post(url, wwwForm))
                {
                    yield return request.SendWebRequest();
                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        EditorUtility.DisplayDialog("Error", "Please check your network connection, email, and password.",
                            "OK");
                    }
                    else
                    {
                        Debug.Log("Success");
                        setting.status = PhantomAuthStatus.SignIn;
                        setting.token = "Bearer 00001";
                        setting.refresh = "Bearer 00001";
                        setting.code = "GM - 00001";
                        setting.nickname = "Phantom";
                        
                        EditorUtility.SetDirty(setting);
                    }
                }
            }
        }
        
        public static void SignOut()
        {
            if (IsSetting)
            {
                setting.status = PhantomAuthStatus.SignOut;
                SettingReset();
            }
        }

        #endregion
        
    }
}

#endif