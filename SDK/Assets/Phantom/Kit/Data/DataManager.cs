using UnityEngine;

namespace Phantom
{
    public class DataManager : GenericSingleton<DataManager>
    {

        #region VARIABLE

        private DataSetting _setting;

        #endregion



        #region RETURN

        public bool IsSetting => _setting;

        #endregion


        #region LIFYCYCLE

        protected override void OnOpen()
        {
            _setting = Resources.Load<DataSetting>($"{nameof(DataSetting)}.asset");
        }

        protected override void OnClose()
        {
            Resources.UnloadAsset(_setting);
        }

        #endregion
        
        
        
        #region METHOD

        public bool Add(string soKey, ScriptableObject soValue)
        {
            if (_setting is null)
                return false;

            var data = new DataTable()
            {
                key = soKey,
                value = soValue
            };

            _setting.list.Add(data);
            return true;
        }

        public bool Remove(string soKey)
        {
            if (_setting is null)
                return false;

            var data = _setting.list.Find(x => x.key == soKey);
            if (data is null)
                return false;

            return _setting.list.Remove(data);
        }
    
        public bool Remove(ScriptableObject soValue)
        {
            if (_setting is null)
                return false;
        
            var data = _setting.list.Find(x => x.value == soValue);
            if (data is null)
                return false;

            return _setting.list.Remove(data);
        }
    
        public ScriptableObject Find(string key)
        {
            if (_setting is null)
                return null;

            var setting = _setting.list.Find(x => x.key == key);
            if (setting is null)
                return null;

            return setting.value;
        }

        #endregion
        
    }
}