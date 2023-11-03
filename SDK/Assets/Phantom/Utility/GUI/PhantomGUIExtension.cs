using UnityEngine;

namespace Phantom
{
    public static class PhantomGUIExtension
    {
        // ==================================================
        // [ Rect ]
        // ==================================================
        public static Rect Right(Rect rect, float width = 1)
        {
            rect.x = rect.x + rect.width - width;
            rect.width = width;
            return rect;
        }

        public static Rect Left(Rect rect, float width = 1)
        {
            rect.width = width;
            return rect;
        }

        public static Rect Top(Rect rect, float height = 1)
        {
            rect.height = height;
            return rect;
        }
        
        public static Rect Bottom(Rect rect, float height = 1)
        {
            rect.y = rect.y + rect.height - height;
            rect.height = height;
            return rect;
        }
        
    }
}