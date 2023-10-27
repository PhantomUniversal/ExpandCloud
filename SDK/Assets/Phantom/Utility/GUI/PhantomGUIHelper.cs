using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public class PhantomGUIHelper
    {
        private static readonly PhantomGUIScopeStack<bool> GUIEnabledStack = new PhantomGUIScopeStack<bool>();
        private static readonly PhantomGUIScopeStack<Color> LabelColorStack = new ();
        private static readonly PhantomGUIScopeStack<float> ContextWidthStackOdinVersion = new PhantomGUIScopeStack<float>();
        private static readonly Func<float> ContextWidthGetter;
        private static readonly Action<float> ContextWidthSetter;
        private static readonly Func<Stack<float>> ContextWidthStackGetter;
        private static float betterContextWidth;
        public static bool RepaintRequested;
        
        internal static int confirmedPopupControlId = -1;
        internal static int focusedControlId = -1;
        
        
        public static float ContextWidth => ContextWidthGetter();
        
        public static float BetterLabelWidth
        {
            get
            {
                if ((double) BetterContextWidth == 0.0)
                    return EditorGUIUtility.labelWidth;
                PushContextWidth(BetterContextWidth);
                float labelWidth = EditorGUIUtility.labelWidth;
                PopContextWidth();
                return labelWidth;
            }
            set => EditorGUIUtility.labelWidth = value;
        }
        
        public static float BetterContextWidth
        {
            get => (double) betterContextWidth == 0.0 ? ContextWidth : betterContextWidth;
            set => betterContextWidth = value;
        }
        
        public static float CurrentIndentAmount => (float) (EditorGUI.indentLevel * 15);
        
        public static void PushLabelColor(Color color)
        {
            LabelColorStack.Push(EditorStyles.label.normal.textColor);
            EditorStyles.label.normal.textColor = color;
            PhantomGUIStyle.Foldout.normal.textColor = color;
            PhantomGUIStyle.Foldout.onNormal.textColor = color;
        }

        public static void PopLabelColor()
        {
            Color color = LabelColorStack.Pop();
            EditorStyles.label.normal.textColor = color;
            PhantomGUIStyle.Foldout.normal.textColor = color;
            PhantomGUIStyle.Foldout.onNormal.textColor = color;
        }
        
        public static void PushGUIEnabled(bool enabled)
        {
            GUIEnabledStack.Push(GUI.enabled);
            GUI.enabled = enabled;
        }
        
        public static void PopGUIEnabled() => GUI.enabled = GUIEnabledStack.Pop();
        
        public static void RequestRepaint() => RepaintRequested = true;
        
        public static void RemoveFocusControl()
        {
            GUIUtility.hotControl = 0;
            DragAndDrop.activeControlID = 0;
            GUIUtility.keyboardControl = 0;
            focusedControlId = 0;
            confirmedPopupControlId = 0;
        }
        
        public static void PushContextWidth(float width)
        {
            if (ContextWidthSetter != null)
            {
                ContextWidthStackOdinVersion.Push(width);
                ContextWidthSetter(width);
            }
            else
                ContextWidthStackGetter().Push(width);
        }
        
        public static void PopContextWidth()
        {
            if (ContextWidthSetter != null)
            {
                float num = ContextWidthStackOdinVersion.Pop();
                ContextWidthSetter(num);
            }
            else
            {
                Stack<float> floatStack = ContextWidthStackGetter();
                if (floatStack.Count <= 0)
                    return;
                double num = (double) floatStack.Pop();
            }
        }
    }
}