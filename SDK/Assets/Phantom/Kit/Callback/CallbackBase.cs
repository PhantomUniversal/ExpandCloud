using System.Collections.Generic;
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



        #region MyRegion

        protected abstract void OnConnect();
        
        protected abstract void OnDisConnect();

        protected abstract void OnError();
        
        protected abstract void OnMessage(string message);
        
        protected abstract void OnUpdate();

        #endregion
        
        
        
        #region LIFECLCYE

        private void OnEnable()
        {
            CallbackOption option = new CallbackOption()
            {
                Uid = callbackUid
            };
            
            var result = Callback.Add(this, option);
            if(result)
                OnConnect();
            else
                OnError();
        }

        private void OnDisable()
        {
            var result = Callback.Remove(this);
            if (result)
                OnDisConnect();
            else
                OnError();
        }

        #endregion



        #region CALLBACK
        
        // ==================================================
        // [ ICallback ]
        // ==================================================
        public void OnOptionCallback(CallbackOption option)
        {
            CurrentCallbackUid = option is null ? "" : option.Uid;
        }
        
        public void OnMessageCallback(string message)
        {
            OnMessage(message);
        }
        
        public void OnUpdateCallback()
        {
            OnUpdate();
        }

        #endregion
        
    }
}