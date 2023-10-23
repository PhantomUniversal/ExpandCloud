#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Phantom.Callback
{
    
    [CustomEditor(typeof(CallbackBase), true)]
    [CanEditMultipleObjects]
    public class CallbackBaseInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
            serializedObject.ApplyModifiedProperties();
            
            // ==================================================
            // [ Style ]
            // ==================================================
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
            };
            
            // ==================================================
            // [ Layout ]
            // ==================================================
            EditorGUI.BeginChangeCheck();
            
            CallbackBase callback = (CallbackBase)target;
            GUILayout.BeginVertical();
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Space(10f);
                    GUILayout.Label("UID", labelStyle, GUILayout.Width(80f), GUILayout.Height(20f));
                    callback.uid = EditorGUILayout.TextField("", callback.uid, GUILayout.ExpandWidth(true), GUILayout.Height(20f));
                    GUILayout.Space(10f);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(callback);
            }
        }
    }
    
    [CustomEditor(typeof(CallbackManager), true)]
    [CanEditMultipleObjects]
    public class CallbackManagerInspector : Editor
    {

        #region VARIABLE

        private string _uid;

        #endregion
        
        
        #region CHECK

        private bool _isList;

        #endregion
        
        

        #region LIFECYCLE

        private void OnEnable()
        {
            _isList = EditorPrefs.GetBool("CALLBACK_LIST_ENABLE");
        }

        private void OnDisable()
        {
            EditorPrefs.SetBool("CALLBACK_LIST_ENABLE", _isList);
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
            serializedObject.ApplyModifiedProperties();
            
            // ==================================================
            // [ Style ]
            // ==================================================
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
            };
            
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold
            };
            
            GUIStyle foldOutStyle = new GUIStyle(EditorStyles.foldout)
            {
                fontSize = 12,
                fontStyle = FontStyle.Bold,
                padding = new RectOffset(20, 0, 0, 0)
            };
            
            // ==================================================
            // [ Layout ]
            // ==================================================
            EditorGUI.BeginChangeCheck();
            
            CallbackManager callback = (CallbackManager)target;
            GUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true), GUILayout.Height(200f));
            {
                GUILayout.Space(5f);

                
                
                GUILayout.Space(5f);
            }
            GUILayout.EndVertical();
            
            GUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            {
                GUILayout.Space(5f);

                EditorGUI.indentLevel++;
                _isList = EditorGUILayout.Foldout(_isList, "Callback", foldOutStyle);
                if (_isList && Callback.Use)
                {
                    GUILayout.Space(5f);
                    
                    foreach (var option in Callback.Containers.Keys)
                    {
                        if (GUILayout.Button(option.Uid, buttonStyle,GUILayout.ExpandWidth(true), GUILayout.Height(40f)))
                        {
                            _uid = option.Uid;
                            Debug.Log($"UID : {option.Uid}\n Category : {option.Category}");
                        }
                    }
                    
                    GUILayout.Space(5f);
                }
                EditorGUI.indentLevel--;
                
                GUILayout.Space(5f);
            }
            GUILayout.EndVertical();
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(callback);
            }
        }
        
        #endregion
        
    }
}

#endif