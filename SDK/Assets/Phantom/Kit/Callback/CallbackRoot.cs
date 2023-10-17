namespace Phantom.Callback
{
    public enum CallbackErrorType
    {
        None = 0,
    }
    
    public interface ICallback
    {

        /// <summary>
        /// 
        /// </summary>
        void OnOptionCallback(CallbackOption option);
        
        /// <summary>
        /// 
        /// </summary>
        void OnMessageCallback(string message);
        
        /// <summary>
        /// 
        /// </summary>
        void OnUpdateCallback();

    }
}