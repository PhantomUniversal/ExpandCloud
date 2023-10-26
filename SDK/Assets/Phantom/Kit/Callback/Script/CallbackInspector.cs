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

        private bool _callbackListEnable;
        private CallbackAttribute _callbackListAttribute;
        private GUIContent _callbackListKeyLabel;
        private GUIContent _callbackListValueLabel;
        private float _callbackListKeyLabelWidth;
        private float _callbackListValueHeight;
        
        #endregion
        
        

        #region LIFECYCLE

        private void Awake()
        {
            _callbackListAttribute ??= new CallbackAttribute();
            _callbackListKeyLabel = new GUIContent(_callbackListAttribute.keyLabel);
            _callbackListValueLabel = new GUIContent(_callbackListAttribute.valueLabel);
            _callbackListKeyLabelWidth = EditorStyles.label.CalcSize(_callbackListKeyLabel).x + 20f;
            _callbackListValueHeight = EditorStyles.label.CalcSize(_callbackListValueLabel).x + 20f;
        }

        private void OnEnable()
        {
            _callbackListEnable = EditorPrefs.GetBool("CALLBACK_LIST_ENABLE");
        }

        private void OnDisable()
        {
            EditorPrefs.SetBool("CALLBACK_LIST_ENABLE", _callbackListEnable);
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
            
            // ==================================================
            // [ Layout ]
            // ==================================================
            CallbackManager callback = (CallbackManager)target;
            
            EditorGUI.BeginChangeCheck();
            
            Rect callbackFoldoutRect = EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.Height(20));
            {
                _callbackListEnable = EditorGUILayout.Foldout(_callbackListEnable, "Callback", true, PhantomGUIStyle.FoldoutStyle);
                // Rect callbackAddRect = new Rect(callbackFoldoutRect.xMax, callbackFoldoutRect.y, callbackFoldoutRect.height, callbackFoldoutRect.height);
                // if (GUI.Button(callbackAddRect, "+", PhantomGUIStyle.FieldButtonStyle))
                // {
                //     Debug.Log("Call");
                // }
                
                
            }
            EditorGUILayout.EndVertical();
            
            // Rect callbackListBackgroundRect = EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.Height(20));
            // {
            //     PhantomEditorGUI.DrawSolidRect(callbackListBackgroundRect.AlignTop(1f), PhantomColor.SolidColor);
            //     PhantomEditorGUI.DrawSolidRect(callbackListBackgroundRect, PhantomColor.BoxBackgroundColor);
            //     
            //     if (_callbackListEnable)
            //     {
            //         Rect tagRect = EditorGUILayout.BeginHorizontal();
            //         {
            //             tagRect.height = callbackListRect.height;
            //             PhantomEditorGUI.DrawSolidRect(tagRect.AlignLeft(1f), PhantomColor.SolidColor);
            //             PhantomEditorGUI.DrawSolidRect(tagRect.AlignRight(1f), PhantomColor.SolidColor);
            //             
            //             Rect keyRect = new Rect(callbackListRect.xMin, callbackListRect.yMax, callbackListRect.width * 0.5f, callbackListRect.height);
            //             Rect valueRect = new Rect(callbackListRect.xMin + (callbackListRect.width * 0.5f), callbackListRect.yMax, callbackListRect.width * 0.5f, callbackListRect.height);
            //             if (Event.current.type == EventType.Repaint)
            //             {
            //                 GUI.Label(keyRect, _callbackListKeyLabel, PhantomGUIStyle.LabelCenter);
            //                 GUI.Label(valueRect, _callbackListKeyLabel, PhantomGUIStyle.LabelCenter);
            //                 PhantomEditorGUI.DrawSolidRect(tagRect.AlignBottom(1f), PhantomColor.SolidColor);
            //             }
            //             
            //             // EditorGUILayout.LabelField("Key", PhantomGUIStyle.LabelBoxStyle);
            //             // EditorGUILayout.LabelField("Value", PhantomGUIStyle.LabelBoxStyle);
            //         }
            //         EditorGUILayout.EndHorizontal();
            //
            //         // if (Callback.Use)
            //         // {
            //         //     GUILayout.Space(4f);
            //         //     
            //         //     foreach (var option in Callback.Containers.Keys)
            //         //     {
            //         //         if (GUILayout.Button(option.Uid, PhantomGUIStyle.ButtonStyle, GUILayout.ExpandWidth(true), GUILayout.Height(40f)))
            //         //         {
            //         //             //_uid = option.Uid;
            //         //             Debug.Log($"UID : {option.Uid}\n Category : {option.Category}");
            //         //         }
            //         //     }
            //         //     
            //         //     GUILayout.Space(4f);
            //         // }
            //         // else
            //         // {
            //         //     EditorGUILayout.HelpBox("Callback is not exists", MessageType.Info);
            //         // }
            //     }
            // }
            // EditorGUILayout.EndVertical();
            
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(callback);
            }
            
            serializedObject.ApplyModifiedProperties();
        }
        
        #endregion
        
    }
}

#endif