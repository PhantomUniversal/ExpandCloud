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

        public bool Init()
        {
            _setting = Resources.Load<DataSetting>($"{nameof(DataSetting)}.asset");
            return _setting;
        }

        public bool Fina()
        {
            if (!_setting) return false;
            Resources.UnloadAsset(_setting);
            return true;
        }

        public DataSetting Setting()
        {
            if (!_setting) return null;
            return _setting;
        }
        
        public bool Add(string soKey, object soValue)
        {
            if (_setting is null) return false;

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
            if (_setting is null) return false;

            var data = _setting.list.Find(x => x.key == soKey);
            if (data is null)
                return false;

            return _setting.list.Remove(data);
        }
    
        public bool Remove(object soValue)
        {
            if (_setting is null) return false;
        
            var data = _setting.list.Find(x => x.value == soValue);
            if (data is null)
                return false;

            return _setting.list.Remove(data);
        }
    
        public T Find<T>(string key) where T : Object 
        {
            if (_setting is null) return null;

            var data = _setting.list.Find(x => x.key == key);
            if (data is null)
                return null;

            return (T)data.value;
        }

        #endregion
        
    }
}