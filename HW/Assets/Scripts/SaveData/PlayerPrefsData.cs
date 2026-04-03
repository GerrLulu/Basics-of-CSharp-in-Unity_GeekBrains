using Helper;
using Interface;
using UnityEngine;

namespace SaveData
{
    public class PlayerPrefsData : IData
    {
        private int _count;


        public void Save(SavedDataInfo[] data, string path = null)
        {
            _count = data.Length;

            for (var i = 0; i < data.Length; i++)
            {
                PlayerPrefs.SetString("Name", data[i].Name);
                PlayerPrefs.SetFloat("PosX", data[i].Position.x);
                PlayerPrefs.SetFloat("PosY", data[i].Position.y);
                PlayerPrefs.SetFloat("PosZ", data[i].Position.z);
                PlayerPrefs.SetString("IsEnable", data[i].IsEnabled.ToString());
            }

            PlayerPrefs.Save();
        }

        public SavedDataInfo[] Load(string path = null)
        {
            SavedDataInfo[] resulted = new SavedDataInfo[_count];

            for (var i = 0; i < resulted.Length; i++)
            {
                var key = "Name";
                if (PlayerPrefs.HasKey(key))
                    resulted[i].Name = PlayerPrefs.GetString(key);

                key = "PosX";
                if (PlayerPrefs.HasKey(key))
                    resulted[i].Position.x = PlayerPrefs.GetFloat(key);

                key = "PosY";
                if (PlayerPrefs.HasKey(key))
                    resulted[i].Position.y = PlayerPrefs.GetFloat(key);

                key = "PosZ";
                if (PlayerPrefs.HasKey(key))
                    resulted[i].Position.z = PlayerPrefs.GetFloat(key);

                key = "IsEnable";
                if (PlayerPrefs.HasKey(key))
                    resulted[i].IsEnabled = PlayerPrefs.GetString(key).TryBool();
            }

            return resulted;
        }

        public void Clear() => PlayerPrefs.DeleteAll();
    }
}