using Interface;
using Model.IntrctvObjcts;
using Model.Player;
using System.IO;
using UnityEngine;

namespace SaveData
{
    public sealed class SaveDataRepository
    {
        private readonly IData _data;

        private const string FOLDER_NAME = "dataSave";
        private const string FILE_NAME = "data.bat";
        private readonly string _path;


        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
                _data = new PlayerPrefsData();
            else
                _data = new JsonData();

            _path = Path.Combine(Application.dataPath, FOLDER_NAME);
        }


        public void Save(PlayerBase player, InteractiveObject[] intObject)
        {
            if (!Directory.Exists(Path.Combine(_path)))
                Directory.CreateDirectory(_path);

            SavedDataInfo[] saveObjects = new SavedDataInfo[intObject.Length + 1];
            for (var i = 0; i < saveObjects.Length - 1; i++)
            {
                saveObjects[i] = new SavedDataInfo()
                {
                    Position = intObject[i].transform.position,
                    Name = intObject[i].name,
                    IsEnabled = intObject[i].isActiveAndEnabled
                };
            }

            saveObjects[saveObjects.Length - 1] = new SavedDataInfo()
            {
                Position = player.transform.position,
                Name = player.name,
                IsEnabled = player.isActiveAndEnabled
            };

            _data.Save(saveObjects, Path.Combine(_path, FILE_NAME));
        }

        public void Load(PlayerBase player, InteractiveObject[] intObject)
        {
            var file = Path.Combine(_path, FILE_NAME);

            if (!File.Exists(file))
                return;

            SavedDataInfo[] sdInfos = _data.Load(file);
            Debug.Log(sdInfos.Length);
            for (var i = 0; i < sdInfos.Length -1 ; i++)
            {
                intObject[i].transform.position = sdInfos[i].Position;
                intObject[i].name = sdInfos[i].Name;
                intObject[i].IsInteractable = sdInfos[i].IsEnabled;
            }

            player.transform.position = sdInfos[sdInfos.Length - 1].Position;
            player.name = sdInfos[sdInfos.Length - 1].Name;
            player.gameObject.SetActive(sdInfos[sdInfos.Length - 1].IsEnabled);
        }
    }
}