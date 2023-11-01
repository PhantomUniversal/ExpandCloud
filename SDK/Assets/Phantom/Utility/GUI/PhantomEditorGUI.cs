using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomEditorGUI
    {
        // ==================================================
        // [ Layout ]
        // ==================================================

        public static Rect BeginVertical()
        {
            Rect rect = EditorGUILayout.BeginVertical();
            // Top
            EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMin, rect.width, 1f), PhantomColor.BorderColor);
            // Bottom
            EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMax, rect.width, 1f), PhantomColor.BorderColor);
            // Left
            EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMin, 1f, rect.height), PhantomColor.BorderColor);
            // Right
            EditorGUI.DrawRect(new Rect(rect.xMax, rect.yMin, 1f, rect.height), PhantomColor.BorderColor);
            
            return rect;
        }

        public static void EndVertical()
        {
            EditorGUILayout.EndVertical();
        }
        
        
        public static bool Foldout(bool isVisible, string label, GUIStyle style = null) 
            => Foldout(isVisible, new GUIContent(label), style);

        public static bool Foldout(bool isVisible, GUIContent label, GUIStyle style = null)
        {
            float fieldWidth = EditorGUIUtility.fieldWidth;
            EditorGUIUtility.fieldWidth = 10f;
            Rect controlRect = EditorGUILayout.GetControlRect(false);
            EditorGUIUtility.fieldWidth = fieldWidth;
            return Foldout(controlRect, isVisible, label, style);
        }
        
        public static bool Foldout(Rect rect, bool isVisible, GUIContent label, GUIStyle style = null)
        {
            EditorGUI.indentLevel++;
            style ??= PhantomGUIStyle.Foldout;
            
            EventType type = Event.current.type;
            bool containEnable = false;
            if (type != EventType.Layout)
                containEnable = rect.Contains(Event.current.mousePosition);
                
            if(containEnable)
                PhantomGUIHelper.PushFoldoutColor(PhantomColor.HighlightTextColor);
            
            // Event.current.button == 0 => Left mouse button
            if (containEnable & type == EventType.MouseDown && Event.current.button == 0)
            {
                isVisible = !isVisible;
                GUI.enabled = true;
                Event.current.Use(); // 현재 사용중인 이벤트를 제거한다.
                GUI.enabled = false;
                PhantomGUIHelper.ResetFocusControl();
            }

            isVisible = EditorGUI.Foldout(rect, isVisible, label, style);
            if(containEnable)
                PhantomGUIHelper.PopFoldoutColor();
            
            EditorGUI.indentLevel--;
            
            return isVisible;
        }
    }
}