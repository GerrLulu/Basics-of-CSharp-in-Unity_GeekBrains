using Helper;
using Interface;
using System;
using System.IO;
using UnityEngine;

namespace SaveData
{
    public class JsonData : IData
    {
        public void Save(SavedDataInfo[] data, string path = null)
        {
            string result = "";

            for (var i = 0; i < data.Length; i++)
                result += JsonUtility.ToJson(data[i]) + ";";

            File.WriteAllText(path, Crypto.CryptoXOR(result));
        }

        public SavedDataInfo[] Load (string path = null)
        {
            string str = File.ReadAllText(path);
            str = Crypto.CryptoXOR(str);
            string[] parts = str.Split(";");
            Array.Resize(ref parts, parts.Length - 1);

            SavedDataInfo[] savedDataInfos = new SavedDataInfo[parts.Length];

            for (var i = 0; i < parts.Length; i++)
                savedDataInfos[i] = JsonUtility.FromJson<SavedDataInfo>(parts[i]);

            return savedDataInfos;
        }
    }
}