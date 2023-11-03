#if UNITY_EDITOR

using UnityEditor;

namespace Phantom
{
     public abstract class PhantomGUIEditorBase : Editor
     {

          #region OVERRIDE
          
          protected abstract void OnOpen();
        
          protected abstract void OnClose();
          
          protected abstract void OnDraw();

          #endregion
         
          
          
          #region LIFECYCLE

          private void OnEnable()
          {
               OnOpen();
          }

          private void OnDisable()
          {
               OnClose();
          }

          public override void OnInspectorGUI()
          {
               serializedObject.Update();
               DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
               
               PhantomGUIUtility.Repaint(this);
               OnDraw();
               
               serializedObject.ApplyModifiedProperties();
          }

          #endregion
          
     }
}

#endif