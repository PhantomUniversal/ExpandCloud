using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomEditorGUI
    {
        // ==================================================
        // [ Layout ]
        // ==================================================

        

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