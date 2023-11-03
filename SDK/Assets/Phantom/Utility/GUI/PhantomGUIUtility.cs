using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Phantom
{
    public static class PhantomGUIUtility
    {

        #region OBJECT

        public static void PingObject(Object obj)
        {
            if (obj == null)
                return;
            
            if (AssetDatabase.Contains(obj) && !AssetDatabase.IsMainAsset(obj))
            {
                Object loadObject = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(obj));
                if (loadObject is Component component)
                    loadObject = component.gameObject;
                EditorGUIUtility.PingObject(loadObject);
            } 
            
            if (obj is Component component1)
                obj = component1.gameObject;
            EditorGUIUtility.PingObject(obj);
        }

        public static void SelectObject(Object obj)
        {
            if (obj == null)
                return;
            if (AssetDatabase.Contains(obj) && !AssetDatabase.IsMainAsset(obj))
            {
                Object loadObject = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GetAssetPath(obj));
                if (loadObject is Component component)
                    loadObject = component.gameObject;
                Selection.activeObject = loadObject;
            }
            else
            {
                if (obj is Component component)
                    obj = component.gameObject;
                Selection.activeObject = obj;
            }
        }

        #endregion



        #region FADE

        private static AnimBool _fadeEnable;

        public static float Fade(bool isVisible, float speed = 1f)
        {
            _fadeEnable ??= new AnimBool();
            _fadeEnable.target = isVisible;
            _fadeEnable.speed = speed;
            return _fadeEnable.faded;
        }
        
        
        #endregion
        
        
        
        #region REPAINT
        
        private static bool _repaintEnable;
        
        public static void Repaint(this EditorWindow window)
        {
            if (!_repaintEnable && (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse))
                return;
            
            if((bool) (Object) window)
                window.Repaint();
            
            ClearRepaint();
        }

        public static void Repaint(this Editor editor)
        {
            if (!_repaintEnable && (Event.current == null || Event.current.type != EventType.Used && !Event.current.isMouse))
                return;
            
            if((bool) (Object) editor)
                editor.Repaint();
            
            ClearRepaint();
        }
        
        public static void RequestRepaint() => _repaintEnable = true;

        public static void ClearRepaint() => _repaintEnable = false;
        
        #endregion

    }
}