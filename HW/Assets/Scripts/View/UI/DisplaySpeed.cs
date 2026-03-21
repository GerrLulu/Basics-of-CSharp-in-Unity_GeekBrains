using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public sealed class DisplaySpeed
    {
        private Text _speedLable;


        public DisplaySpeed(GameObject bonus)
        {
            _speedLable = bonus.GetComponentInChildren<Text>();
            _speedLable.text = String.Empty;
        }


        public void Display(string value)
        {
            _speedLable.text = value;
        }
    }
}