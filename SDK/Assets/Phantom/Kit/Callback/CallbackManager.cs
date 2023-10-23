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

    }
}