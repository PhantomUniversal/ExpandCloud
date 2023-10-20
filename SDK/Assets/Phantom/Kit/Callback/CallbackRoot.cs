namespace Phantom.Callback
{
    public enum CallbackErrorType
    {
        None = 0,
    }
    
    public interface ICallback
    {

        /// <summary>
        /// Callback add callback
        /// </summary>
        void OnConnectCallback(CallbackOption option);
        
        /// <summary>
        /// Callback remove callback
        /// </summary>
        void OnDisConnectCallback();

        /// <summary>
        /// Error callback => Analytics => Error callback? or Debug => Error callback dev ???
        /// </summary>
        void OnErrorCallback();
        
        /// <summary>
        /// Event Callback
        /// </summary>
        void OnEventCallback();

    }
}