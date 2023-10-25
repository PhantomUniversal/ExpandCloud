using UnityEditor;
using UnityEngine;

namespace Phantom
{
    public static class PhantomColor
    {
        public static readonly Color DarkEditorBackground = EditorGUIUtility.isProSkin ? new Color(0.192f, 0.192f, 0.192f, 1f) : new Color(0.0f, 0.0f, 0.0f, 0.0f);
        
        public static readonly Color LayoutDefaultColor = new Color(0.338f, 0.338f, 0.338f, 1f);
        
        public static readonly Color SolidColor = EditorGUIUtility.isProSkin ? new Color(0.1f, 0.1f, 0.1f, 1f) : new Color(0.338f, 0.338f, 0.338f, 1f);
        
        public static readonly Color BackgroundColor = EditorGUIUtility.isProSkin ? new Color(0.11f, 0.11f, 0.11f, 0.8f) : new Color(0.38f, 0.38f, 0.38f, 0.6f);
        
        
        
        // Odin
        
        public static Color ValidatorGreen = new Color(0.224f, 0.71f, 0.29f, 1f);
        /// <summary>Inspector Orange</summary>
        public static Color InspectorOrange = new Color(0.949f, 0.384f, 0.247f, 1f);
        /// <summary>Serializer Yellow</summary>
        public static Color SerializerYellow = new Color(1f, 0.682f, 0.0f, 1f);
        /// <summary>Green valid color</summary>
        public static Color GreenValidColor = new Color(0.2f, 0.75686276f, 0.02745098f);
        /// <summary>Red error color</summary>
        public static Color RedErrorColor = EditorGUIUtility.isProSkin ? new Color(1f, 0.3254902f, 0.2901961f) : new Color(0.69411767f, 0.047058824f, 0.047058824f, 1f);
        /// <summary>Yellow warning color</summary>
        public static Color YellowWarningColor = EditorGUIUtility.isProSkin ? new Color(1f, 0.75686276f, 0.02745098f) : new Color(0.7882353f, 0.5921569f, 0.0f, 1f);
        /// <summary>Border color.</summary>
        public static readonly Color BorderColor = EditorGUIUtility.isProSkin ? new Color(0.11f, 0.11f, 0.11f, 0.8f) : new Color(0.38f, 0.38f, 0.38f, 0.6f);
        /// <summary>Box background color.</summary>
        public static readonly Color BoxBackgroundColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.05f) : new Color(1f, 1f, 1f, 0.2f);
        /// <summary>Dark editor background color.</summary>
        
        /// <summary>Editor window background color.</summary>
        public static readonly Color EditorWindowBackgroundColor = EditorGUIUtility.isProSkin ? new Color(0.22f, 0.22f, 0.22f, 1f) : new Color(0.76f, 0.76f, 0.76f, 1f);
        /// <summary>Menu background color.</summary>
        public static readonly Color MenuBackgroundColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.035f) : new Color(0.87f, 0.87f, 0.87f, 1f);
        /// <summary>Header box background color.</summary>
        public static readonly Color HeaderBoxBackgroundColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.06f) : new Color(1f, 1f, 1f, 0.26f);
        /// <summary>Highlighted Button Color.</summary>
        public static readonly Color HighlightedButtonColor = EditorGUIUtility.isProSkin ? new Color(0.0f, 1f, 0.0f, 1f) : new Color(0.0f, 1f, 0.0f, 1f);
        /// <summary>Highlight text color.</summary>
        public static readonly Color HighlightedTextColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 1f) : new Color(0.0f, 0.0f, 0.0f, 1f);
        /// <summary>Highlight property color.</summary>
        public static readonly Color HighlightPropertyColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.6f) : new Color(0.0f, 0.0f, 0.0f, 0.6f);
        /// <summary>List item hover color for every other item.</summary>
        public static readonly Color ListItemColorHoverEven = EditorGUIUtility.isProSkin ? new Color(0.22320001f, 0.22320001f, 0.22320001f, 1f) : new Color(0.89f, 0.89f, 0.89f, 1f);
        /// <summary>List item hover color for every other item.</summary>
        public static readonly Color ListItemColorHoverOdd = EditorGUIUtility.isProSkin ? new Color(0.2472f, 0.2472f, 0.2472f, 1f) : new Color(0.904f, 0.904f, 0.904f, 1f);
        /// <summary>List item drag background color.</summary>
        public static readonly Color ListItemDragBg = new Color(0.1f, 0.1f, 0.1f, 1f);
        /// <summary>List item drag background color.</summary>
        public static readonly Color ListItemDragBgColor = EditorGUIUtility.isProSkin ? new Color(0.1f, 0.1f, 0.1f, 1f) : new Color(0.338f, 0.338f, 0.338f, 1f);
        /// <summary>Column title background colors.</summary>
        public static readonly Color ColumnTitleBg = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.019f) : new Color(1f, 1f, 1f, 0.019f);
        /// <summary>
        /// The default background color for when a menu item is selected.
        /// </summary>
        public static readonly Color DefaultSelectedMenuTreeColorDarkSkin = new Color(0.243f, 0.373f, 0.588f, 1f);
        /// <summary>
        /// The default background color for when a menu item is selected.
        /// </summary>
        public static readonly Color DefaultSelectedInactiveMenuTreeColorDarkSkin = new Color(0.838f, 0.838f, 0.838f, 0.134f);
        /// <summary>
        /// The default background color for when a menu item is selected.
        /// </summary>
        public static readonly Color DefaultSelectedMenuTreeColorLightSkin = new Color(0.243f, 0.49f, 0.9f, 1f);
        /// <summary>
        /// The default background color for when a menu item is selected.
        /// </summary>
        public static readonly Color DefaultSelectedInactiveMenuTreeColorLightSkin = new Color(0.5f, 0.5f, 0.5f, 1f);
        /// <summary>A mouse over background overlay color.</summary>
        public static readonly Color MouseOverBgOverlayColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.028f) : new Color(1f, 1f, 1f, 0.3f);

        /// <summary>Menu button active background color.</summary>
        public static readonly Color MenuButtonActiveBgColor = EditorGUIUtility.isProSkin ? new Color(0.243f, 0.373f, 0.588f, 1f) : new Color(0.243f, 0.49f, 0.9f, 1f);
        /// <summary>Menu button border color.</summary>
        
        /// <summary>Menu button color.</summary>
        public static readonly Color MenuButtonColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        /// <summary>Menu button hover color.</summary>
        public static readonly Color MenuButtonHoverColor = new Color(1f, 1f, 1f, 0.08f);
        /// <summary>A light border color.</summary>
        public static readonly Color LightBorderColor = (Color) new Color32((byte) 90, (byte) 90, (byte) 90, byte.MaxValue);
        
    }
}