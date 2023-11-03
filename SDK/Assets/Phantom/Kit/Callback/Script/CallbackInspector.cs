#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.AnimatedValues;
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
    public class CallbackManagerInspector : PhantomGUIEditorBase
    {

        #region VARIABLE

        private bool _callbackListEnable;
        
        #endregion
        
        

        #region CALLBACK

        protected override void OnOpen()
        {
            _callbackListEnable = EditorPrefs.GetBool("CALLBACK_LIST_ENABLE");
        }

        protected override void OnClose()
        {
            EditorPrefs.SetBool("CALLBACK_LIST_ENABLE", _callbackListEnable);
        }

        protected override void OnDraw()
        {
            // ==================================================
            // [ Layout ]
            // ==================================================
            CallbackManager callback = (CallbackManager)target;
            EditorGUI.BeginChangeCheck();

            PhantomGUIEditor.BeginIndentedVertical();
            
            // Foldout
            _callbackListEnable = PhantomGUIEditor.Foldout(_callbackListEnable, "Callback");
            
            // FadeGroup
            PhantomGUIEditor.BeginFadeGroup(_callbackListEnable);
            EditorGUILayout.LabelField("");
            PhantomGUIEditor.EndFadeGroup();
            
            PhantomGUIEditor.EndIndentedVertical();
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(callback);
            }
        }
        
        #endregion

    }
}

#endif