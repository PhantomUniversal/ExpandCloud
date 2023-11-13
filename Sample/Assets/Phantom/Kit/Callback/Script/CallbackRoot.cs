namespace Phantom.Callback
{
    public enum CallbackErrorType
    {
        None = 0,
    }
    
    public interface ICallback
    {

        /// <summary>
        /// Add interface return callback
        /// </summary>
        void OnOpenCallback();
        
        /// <summary>
        /// Remove interface return callback
        /// </summary>
        void OnCloseCallback();

        /// <summary>
        /// Error callback => Analytics => Error callback? or Debug => Error callback dev ???
        /// </summary>
        void OnErrorCallback();
        
        /// <summary>
        /// event callback
        /// </summary>
        void OnEventCallback();

    }
}