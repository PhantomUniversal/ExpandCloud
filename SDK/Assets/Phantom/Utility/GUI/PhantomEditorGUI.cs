using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomEditorGUI
    {
        // ==================================================
        // [ Layout ]
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
            // style 없을 경우
            style ??= PhantomGUIStyle.Foldout;
            
            // 현재 이벤트 타입가져오기
            EventType type = Event.current.type;
            
            // ??
            bool flag = false;
            
            // 
            if (type != EventType.Layout)
                flag = rect.Contains(Event.current.mousePosition); // rect안에 마우스 포인트가 존재여부 확인
            
            if(flag) // rect안에 마우스 포인트가 존재한다면 => Foldout에 마우스 포인트가 존재할때
                PhantomGUIHelper.PushLabelColor(PhantomColor.HighlightedTextColor);
            
            if(flag && type == EventType.MouseMove)
                PhantomGUIHelper.RequestRepaint();

            if (type == EventType.MouseDown & flag && Event.current.button == 0)
            {
                isVisible = !isVisible;
                PhantomGUIHelper.RequestRepaint();
                PhantomGUIHelper.PushGUIEnabled(true);
                Event.current.Use();
                PhantomGUIHelper.PopGUIEnabled();
                PhantomGUIHelper.RemoveFocusControl();
            }
            
            isVisible = EditorGUI.Foldout(rect, isVisible, label, style);
            if(flag)
                PhantomGUIHelper.PopLabelColor();
            return isVisible;
        }
        
        // public static void DrawSolidRect(Rect rect, Color color, bool usePlaymodeTint = true)
        // {
        //     if (Event.current.type != EventType.Repaint)
        //         return;
        //     
        //     EditorGUI.DrawRect(rect, color);
        // }
        //
        // public static void DrawBorders(Rect rect, int borderWidth, bool usePlaymodeTint = true) => DrawBorders(rect, borderWidth, borderWidth, borderWidth, borderWidth, PhantomColor.BorderColor, usePlaymodeTint);
        //
        // public static void DrawBorders(Rect rect, int borderWidth, Color color, bool usePlaymodeTint = true) => DrawBorders(rect, borderWidth, borderWidth, borderWidth, borderWidth, color, usePlaymodeTint);
        //
        // public static void DrawBorders(Rect rect, int left, int right, int top, int bottom, bool usePlaymodeTint = true)
        // {
        //     DrawBorders(rect, left, right, top, bottom, PhantomColor.BorderColor, usePlaymodeTint);
        // }
        //
        // public static void DrawBorders(Rect rect, int left, int right, int top, int bottom, Color color, bool usePlaymodeTint = true)
        // {
        //     if (Event.current.type != UnityEngine.EventType.Repaint)
        //         return;
        //     if (left > 0)
        //         DrawSolidRect(rect, color, usePlaymodeTint);
        //     if (top > 0)
        //         DrawSolidRect(rect, color, usePlaymodeTint);
        //     if (right > 0)
        //     {
        //         Rect rect1 = rect;
        //         rect1.x += rect.width - (float) right;
        //         rect1.width = (float) right;
        //         DrawSolidRect(rect1, color, usePlaymodeTint);
        //     }
        //     if (bottom <= 0)
        //         return;
        //     
        //     Rect rect2 = rect;
        //     rect2.y += rect.height - (float) bottom;
        //     rect2.height = (float) bottom;
        //     DrawSolidRect(rect2, color, usePlaymodeTint);
        // }
    }
}