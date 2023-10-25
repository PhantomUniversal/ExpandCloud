/*
 *  Manager → 관리 필요
 *
 */

using UnityEngine;

namespace Phantom.Callback
{
    public class CallbackManager : GenericSingleton<CallbackManager>
    {
        
        #region METHOD

        public void Init()
        {
            
#if UNITY_EDITOR
            Debug.Log("Init complete");
#endif
            
        }

        #endregion



        #region CALLBACK

        protected override void OnOpen()
        {
            
        }

        protected override void OnClose()
        {
            Callback.Clear();
        }

        #endregion
        
    }
}