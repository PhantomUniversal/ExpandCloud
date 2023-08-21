using UnityEngine;

namespace Phantom
{
    public class UIResolution : MonoBehaviour
    {
        #region Lifecycle

        private void Awake()
        {
            if (resolutionCamera && resolutionScreenSize.x > 0 && resolutionScreenSize.y > 0)
            {
                var screenSize = new Vector2(Screen.width, Screen.height);
                Screen.SetResolution((int)resolutionScreenSize.x,
                    (int)(screenSize.y / screenSize.x * resolutionScreenSize.x), true);

                if (resolutionScreenSize.x / resolutionScreenSize.y < screenSize.x / screenSize.y)
                {
                    var width = resolutionScreenSize.x / resolutionScreenSize.y / (screenSize.x / screenSize.y);
                    resolutionCamera.rect = new Rect((1f - width) / 2f, 0f, width, 1f);
                }
                else
                {
                    var height = screenSize.x / screenSize.y / (resolutionScreenSize.x / resolutionScreenSize.y);
                    resolutionCamera.rect = new Rect(0f, (1f - height) / 2f, 1f, height);
                }
            }

            if (resolutionFrameRate > 0) Application.targetFrameRate = resolutionFrameRate;
        }

        #endregion

        #region Variable

        [SerializeField] private Camera resolutionCamera;

        [SerializeField] private Vector2 resolutionScreenSize = Vector2.zero;

        [SerializeField] private int resolutionFrameRate;

        #endregion
    }
}