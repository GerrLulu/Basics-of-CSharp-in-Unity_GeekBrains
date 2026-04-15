using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        //private Button _buttonRestart;


        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;

            endGame.SetActive(false);
        }


        public void GameOver(int value)
        {
            _finishGameLabel.text = $"Игра окончена!/nВы набрали {value} очков.";
        }
    }
}