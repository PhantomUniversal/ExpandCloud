/*
 * day : 2023-09-17
 * write : phantom
 * email : chho1365@gmail.com
 */

using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public class UITool : EditorWindow
    {
        [MenuItem("Phantom/UI/Tool")]
        public static void UIToolEvent()
        {
            // var window = GetWindow<UITool>( typeof(Editor).Assembly.GetType("Inspector"));
            // var x = 1980f;
            // var y = 1080f;
            //
            // window.position = new Rect(Screen.currentResolution.width * 0.5f, 0, x, y);
            // window.titleContent = new GUIContent("[ Phantom ] UI ");
            // window.minSize = window.maxSize = new Vector2(x, y);
            // window.Show();

            var inspector = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");
            var inspectorWindow = GetWindow<UITool>(inspector);
            inspectorWindow.titleContent = new GUIContent("[ Phantom ] UI");
            inspectorWindow.minSize = new Vector2(2000f, 1000f);
            inspectorWindow.Show();
        }
    }
}