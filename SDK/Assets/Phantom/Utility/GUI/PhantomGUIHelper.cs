using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomGUIHelper
    {

        #region VARIABLE
        
        private static readonly PhantomGUIScopeStack<Color> FoldoutColorStack = new ();
        
        #endregion

        

        #region METHOD
        
        public static void ResetFocusControl()
        {
            GUIUtility.hotControl = 0;
            DragAndDrop.activeControlID = 0;
            GUIUtility.keyboardControl = 0;
        }
        
        // ==================================================
        // [ Layout ]
        // ==================================================
        public static void PushFoldoutColor(Color color)
        {
            FoldoutColorStack.Push(EditorStyles.label.normal.textColor);
            EditorStyles.label.normal.textColor = color;
            PhantomGUIStyle.Foldout.normal.textColor = color;
            PhantomGUIStyle.Foldout.onNormal.textColor = color;
        }
        
        public static void PopFoldoutColor()
        {
            Color color = FoldoutColorStack.Pop();
            EditorStyles.label.normal.textColor = color;
            PhantomGUIStyle.Foldout.normal.textColor = color;
            PhantomGUIStyle.Foldout.onNormal.textColor = color;
        }
        
        #endregion
        
        
        
        
        
        

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // private static readonly PhantomGUIScopeStack<float> ContextWidthStackOdinVersion = new PhantomGUIScopeStack<float>();
        // private static readonly Func<float> ContextWidthGetter;
        // private static readonly Action<float> ContextWidthSetter;
        // private static readonly Func<Stack<float>> ContextWidthStackGetter;
        // private static float betterContextWidth;
        //
        //
        // internal static int confirmedPopupControlId = -1;
        // internal static int focusedControlId = -1;
        //
        //
        // public static float ContextWidth => ContextWidthGetter();
        //
        // public static float BetterLabelWidth
        // {
        //     get
        //     {
        //         if ((double) BetterContextWidth == 0.0)
        //             return EditorGUIUtility.labelWidth;
        //         PushContextWidth(BetterContextWidth);
        //         float labelWidth = EditorGUIUtility.labelWidth;
        //         PopContextWidth();
        //         return labelWidth;
        //     }
        //     set => EditorGUIUtility.labelWidth = value;
        // }
        //
        // public static float BetterContextWidth
        // {
        //     get => (double) betterContextWidth == 0.0 ? ContextWidth : betterContextWidth;
        //     set => betterContextWidth = value;
        // }
        //
        // public static float CurrentIndentAmount => (float) (EditorGUI.indentLevel * 15);
        //
        //
        // public static void PushContextWidth(float width)
        // {
        //     if (ContextWidthSetter != null)
        //     {
        //         ContextWidthStackOdinVersion.Push(width);
        //         ContextWidthSetter(width);
        //     }
        //     else
        //         ContextWidthStackGetter().Push(width);
        // }
        //
        // public static void PopContextWidth()
        // {
        //     if (ContextWidthSetter != null)
        //     {
        //         float num = ContextWidthStackOdinVersion.Pop();
        //         ContextWidthSetter(num);
        //     }
        //     else
        //     {
        //         Stack<float> floatStack = ContextWidthStackGetter();
        //         if (floatStack.Count <= 0)
        //             return;
        //         double num = (double) floatStack.Pop();
        //     }
        // }
    }
}