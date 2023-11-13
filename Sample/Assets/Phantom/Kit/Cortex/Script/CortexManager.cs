using UnityEngine;

namespace Phantom
{
    public class CortexManager : GenericSingleton<CortexManager>
    {
        #region Variable

        private float deltaTime;

        #endregion


        #region Lifecycle

        private void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            Cortex.mesc = deltaTime * 1000.0f;
            Cortex.fps = 1.0f / deltaTime;
        }

        private void OnGUI()
        {
            int w = Screen.width, h = Screen.height;
            var style = new GUIStyle();
            var rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = 40;
            style.normal.textColor = Color.green;
            var text = string.Format("{0:0.0} ms ({1:0.}fps))", Cortex.mesc, Cortex.fps);
            GUI.Label(rect, text, style);
        }

        #endregion

        protected override void OnOpen()
        {
            
        }

        protected override void OnClose()
        {
            
        }
    }
}