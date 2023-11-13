using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Phantom.Callback
{
    public class CallbackTest : CallbackBase
    {
        
        #region CALLBACK

        // ==================================================
        // [ CallbackBase ]
        // ==================================================
        protected override void OnOpen()
        {
            Debug.Log(uid);
        }

        protected override void OnClose()
        {
            
        }

        protected override void OnError()
        {
            
        }

        protected override void OnEvent()
        {
            
        }
    
        #endregion


    }
}