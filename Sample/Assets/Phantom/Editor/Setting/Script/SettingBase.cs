/*
 * day : 2023-08-28
 * write : phantom
 * email : chho1365@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public enum SettingServerType
    {
        None = 0,
        Dev = 1,
        QA = 2,
        Release = 3,
        Local = 4,
    }

    public enum SettingWorldType
    {
        None = 0,
        World = 1,
        Custom = 99,
        Event = 777,
        Test = 9999,
    }

    public enum SettingNetworkType
    {
        None = 0,
        MultiPlay = 1
    }

    public enum SettingPortalType
    {
        None = 0,
        Direct = 1,
        Invite = 2,
        Random = 3
    }

    public enum SettingLocalizationType
    {
        None = 0,
        Kr = 1,
        En = 2,
        Jp = 3
    }
}