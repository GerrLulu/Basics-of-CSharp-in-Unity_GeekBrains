using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;


        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }


        public void GameOver()
        {
            _finishGameLabel.text = "Вы проиграли";
        }
    }
}