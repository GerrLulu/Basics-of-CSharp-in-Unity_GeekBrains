using SaveData;

namespace Interface
{
    public interface IData
    {
        void Save(SavedDataInfo[] data, string path = null);
        SavedDataInfo[] Load(string path = null);
    }
}