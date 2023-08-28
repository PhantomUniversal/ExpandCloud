/*
 * day : 2023-08-28
 * write : phantom
 * email : chho1365@gmail.com
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    [CreateAssetMenu(fileName = "SettingData", menuName = "Phantom/SettingData", order = int.MaxValue)]
    public class SettingData : ScriptableObject
    {
        
        #region Server

        [HideInInspector] 
        public Server server;
        
        [Serializable]
        public class Server
        {
            
#if UNITY_EDITOR
            
            /// <summary>
            /// Inspector category server fold - hide / show
            /// </summary>
            [HideInInspector] 
            public bool use;
            
#endif
            
            /// <summary>
            /// Server type
            /// </summary>
            [HideInInspector]
            public int type;

            /// <summary>
            /// Server api
            /// </summary>
            [HideInInspector]
            public string api
            {
                get
                {
                    switch ((SettingServerType)type)
                    {
                        case SettingServerType.Dev:
                            return "https://Dev";
                        case SettingServerType.QA:
                            return "https://QA";
                        case SettingServerType.Release:
                            return "https://Release";
                        case SettingServerType.Local:
                            return "https://Local";
                        default:
                            return string.Empty;
                    }
                }
            }

            /// <summary>
            /// Server platform => Application platform
            /// </summary>
            [HideInInspector]
            public string platform
            {
                get
                {
                    switch (Application.platform)
                    {
                        case RuntimePlatform.IPhonePlayer:
                            return "iOS";
                        case RuntimePlatform.Android:
                            return "Android";
                        default:
                            return "StandaloneWindow64";
                    }
                }
            }
            
        }

        #endregion

        #region Auth

        [Serializable]
        public class Auth
        {
            
#if UNITY_EDITOR
            
            /// <summary>
            /// Inspector category auth fold - hide / show
            /// </summary>
            [HideInInspector] 
            public bool use;
            
#endif
            
            /// <summary>
            /// Auth access token
            /// </summary>
            [HideInInspector]
            public string accessToken;

            /// <summary>
            /// Auth refresh token;
            /// </summary>
            [HideInInspector]
            public string refreshToken;

            /// <summary>
            /// Auth code;
            /// </summary>
            [HideInInspector]
            public int code;

            /// <summary>
            /// Auth nickname;
            /// </summary>
            [HideInInspector]
            public string nickname;
            
        }

        #endregion

        #region World

        [Serializable]
        public class World
        {
            
            /// <summary>
            /// Setting world type
            /// </summary>
            [HideInInspector]
            public int type;

            /// <summary>
            /// Setting world code => defalut code 
            /// </summary>
            [HideInInspector]
            public int code;

            /// <summary>
            /// Setting world identification => com.~
            /// </summary>
            [HideInInspector]
            public string identificaiton;

            /// <summary>
            /// Setting world version => 1.0.0~
            /// </summary>
            [HideInInspector]
            public string version;
            
        }

        #endregion  

        #region Network
        
        [Serializable]
        public class Network
        {
            /// <summary>
            /// Setting network type
            /// </summary>
            [HideInInspector]
            public int type;

            /// <summary>
            /// Setting network invite option
            /// </summary>
            [HideInInspector]
            public int invite;

            /// <summary>
            /// Setting network channel => Min = ? / Max = ?
            /// </summary>
            [HideInInspector]
            public int channel;

            /// <summary>
            /// Setting netework people count
            /// </summary>
            [HideInInspector]
            public int count;   
        }

        #endregion

        #region Option

        [Serializable]
        public class Option
        {
            /// <summary>
            /// Setting option localization
            /// </summary>
            [HideInInspector]
            public int localization;
        }

        #endregion
        
    }
}