using System;
using System.Diagnostics;

namespace Phantom.Callback
{
    [Conditional("UNITY_EDITOR")]
    public sealed class CallbackAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly string keyLabel = "Key";

        /// <summary>
        /// 
        /// </summary>
        public readonly string valueLabel = "Value";
    }
}