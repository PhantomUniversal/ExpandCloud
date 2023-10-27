#if UNITY_EDITOR

using System.IO;
using UnityEditor;

namespace Phantom
{
    public class DataUtility : Editor
    {
        [MenuItem("Phantom/Data/Setting", priority = 1)]
        public static void Setting()
        {
            var directory = "Assets/Resources";
            var file = $"{nameof(DataSetting)}.asset";
            var path = directory + "/" + file;

            var setting = AssetDatabase.LoadAssetAtPath(path, typeof(DataSetting)) as DataSetting;
            if (setting == null)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                setting = CreateInstance<DataSetting>();
                AssetDatabase.CreateAsset(setting, path);
                AssetDatabase.SaveAssets();
            }
        }
    }
}

#endif