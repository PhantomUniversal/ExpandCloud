using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomGUIStyle
    {

        #region VARIABLE
        
        private static GUIStyle _label;

        private static GUIStyle _labelCenter;
        
        #endregion



        #region LIFECYCLE

        public static GUIStyle Label
        {
            get
            {
                _label ??= new(EditorStyles.label)
                {
                    margin = new RectOffset(0, 0, 0, 0)
                };
                
                return _label;
            }
        }

        public static GUIStyle LabelCenter
        {
            get
            {
                _labelCenter ??= new(Label)
                {
                    alignment = TextAnchor.MiddleCenter,
                    margin = new RectOffset(0, 0, 0, 0),
                    clipping = TextClipping.Clip
                };

                return _labelCenter;
            }
        }
        
        #endregion
        
        
        public static GUIStyle LabelStyle => new(GUI.skin.label)
        {
            fontSize = 12,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleLeft,
        };

        public static GUIStyle LabelBoxStyle => new(EditorStyles.helpBox)
        {
            fontSize = 12,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };
        
        public static GUIStyle BtnStyle => new (GUI.skin.button)
        {
            fontSize = 12,
            fontStyle = FontStyle.Bold
        };
        
        public static GUIStyle IconBtnBoxStyle => new (EditorStyles.helpBox)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };
        
        public static GUIStyle FoldoutStyle => new (EditorStyles.foldout)
        {
            fontSize = 12,
            fontStyle = FontStyle.Bold,
            padding = new RectOffset(20, 0, 0, 0),
            margin = new RectOffset(10, 0, 0, 0),
        };
    }
}