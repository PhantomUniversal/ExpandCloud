using UnityEngine;

namespace Phantom.Callback
{
    public abstract class CallbackBase : MonoBehaviour, ICallback
    {

        #region VARIABLE

        [Header("Callback")]
        [SerializeField] protected string callbackUid;
        protected string CurrentCallbackUid { get; private set; }
        
        #endregion



        #region OVERRIDE

        protected abstract void OnConnect();
        
        protected abstract void OnDisConnect();

        protected abstract void OnError();
        
        protected abstract void OnEvent();

        #endregion
        
        
        
        #region LIFECLCYE

        private void OnEnable()
        {
            CallbackOption option = new CallbackOption()
            {
                Uid = callbackUid
            };
            
            Callback.Add(this, option);
        }

        private void OnDisable()
        {
            Callback.Remove(this);
        }

        #endregion



        #region CALLBACK
        
        // ==================================================
        // [ ICallback ]
        // ==================================================
        
        public void OnConnectCallback(CallbackOption option)
        { 
            CurrentCallbackUid = option is null ? "" : option.Uid;
        }

        public void OnDisConnectCallback()
        {
            CurrentCallbackUid = string.Empty;
        }

        public void OnErrorCallback()
        {
            
        }

        public void OnEventCallback()
        {
            
        }
        
        #endregion
        
    }
}