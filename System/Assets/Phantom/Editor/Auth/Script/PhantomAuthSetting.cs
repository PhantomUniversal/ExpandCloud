/*
 * day : 2023-08-17
 * write : phantom
 * email : chho1365@gmail.com
 */

using UnityEngine;

namespace Phantom
{
    public class PhantomAuthSetting : ScriptableObject
    {
        // status
        [HideInInspector] public PhantomAuthStatus status = PhantomAuthStatus.None;
        
        // signin
        [HideInInspector] public string email = string.Empty;
        [HideInInspector] public string password = string.Empty;
        [HideInInspector] public bool hide = true;
        [HideInInspector] public bool auto = false;
        
        // signout
        [HideInInspector] public string token = string.Empty;
        [HideInInspector] public string refresh = string.Empty;
        [HideInInspector] public string code = string.Empty;
        [HideInInspector] public string nickname = string.Empty;
    }
}