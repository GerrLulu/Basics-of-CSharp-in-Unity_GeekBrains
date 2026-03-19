using System;

namespace Excptn
{
    public sealed class GameDesignerException : Exception
    {
        public string TagPlayer { get; }
        public string TagLevelObject { get; }


        public GameDesignerException(string message, string tagPlayer, string tagLevelObject) : base(message)
        {
            TagPlayer = tagPlayer;
            TagLevelObject = tagLevelObject;
        }
    }
}