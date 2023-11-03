using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomGUIEditor
    {
        
        // ==================================================
        // [ Draw ]
        // ==================================================
        public static void DrawBorderRect(Rect rect)
        {
            EditorGUI.DrawRect(PhantomGUIExtension.Left(rect), PhantomGUIColor.BorderColor);
            EditorGUI.DrawRect(PhantomGUIExtension.Right(rect), PhantomGUIColor.BorderColor);
            EditorGUI.DrawRect(PhantomGUIExtension.Top(rect), PhantomGUIColor.BorderColor);
            EditorGUI.DrawRect(PhantomGUIExtension.Bottom(rect), PhantomGUIColor.BorderColor);
        }
        
        
        // ==================================================
        // [ Draw ]
        // ==================================================
        public static Rect BeginVertical()
        {
            Rect rect = EditorGUILayout.BeginVertical();
            return rect;
        }

        public static void EndVertical()
        {
            EditorGUILayout.EndVertical();
        }
        
        
        // ==================================================
        // [ Indented ]
        // ==================================================
        public static Rect BeginIndentedVertical(params GUILayoutOption[] options) => BeginIndentedVertical(GUIStyle.none, options);
        
        // [ Indented ]
        public static Rect BeginIndentedVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUI.indentLevel++;
            Rect rect = style == null ? EditorGUILayout.BeginVertical(options) : EditorGUILayout.BeginVertical(style, options);
            DrawBorderRect(rect);
            return rect;
        }
        
        public static void EndIndentedVertical()
        {            
            EditorGUILayout.EndVertical();
            EditorGUI.indentLevel--;
        }

        internal static Rect BeginIndentedHorizontal(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUI.indentLevel++;
            return style == null ? EditorGUILayout.BeginHorizontal(options) : EditorGUILayout.BeginHorizontal(style, options);
        }

        public static void EndIndentedHorizontal()
        {
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;
        }
        
        
        // ==================================================
        // [ FadeGroup ]
        // ==================================================
        public static void BeginFadeGroup(bool isVisible)
        {
            EditorGUILayout.BeginFadeGroup(PhantomGUIUtility.Fade(isVisible));
            PhantomGUIUtility.RequestRepaint();
        }

        public static void EndFadeGroup()
        {
            EditorGUILayout.EndFadeGroup();
        }
        
        // ==================================================
        // [ Foldout ]
        // ==================================================
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
            style ??= PhantomGUIStyle.Foldout;
            
            EventType type = Event.current.type;
            bool containEnable = false;
            if (type != EventType.Layout)
                containEnable = rect.Contains(Event.current.mousePosition);
                
            if(containEnable)
                PhantomGUIHelper.PushFoldoutColor(PhantomGUIColor.HighlightTextColor);
            
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
            
            return isVisible;
        }
    }
}