using UnityEngine;

namespace Phantom.Callback
{
    public abstract class CallbackBase : MonoBehaviour, ICallback
    {

        #region VARIABLE

        [Header("[ Callback ]")]
        [HideInInspector] public string uid;
        
        #endregion



        #region OVERRIDE

        protected abstract void OnOpen();
        
        protected abstract void OnClose();

        protected abstract void OnError();
        
        protected abstract void OnEvent();

        #endregion
        
        
        
        #region LIFECLCYE
        
        private void OnEnable()
        {
            CallbackOption option = new CallbackOption()
            {
                Uid = this.uid
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
        
        public void OnOpenCallback()
        {
            uid = Callback.FindUid(this);
        }

        public void OnCloseCallback()
        {
            
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