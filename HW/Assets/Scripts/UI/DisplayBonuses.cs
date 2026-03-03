using UnityEngine.UI;

namespace UI
{
    public sealed class DisplayBonuses
    {
        private Text _text;


        public DisplayBonuses(Text text)
        {
            _text = text;
        }


        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }
    }
}