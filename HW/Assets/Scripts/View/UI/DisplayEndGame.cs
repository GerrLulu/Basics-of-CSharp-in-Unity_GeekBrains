using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.UI
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        private Button _buttonRestart;


        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;

            _buttonRestart = endGame.GetComponentInChildren<Button>();
            _buttonRestart.onClick.AddListener(RestartGame);

            endGame.SetActive(false);
        }


        public void GameOver(int value)
        {
            _finishGameLabel.text = $"Игра окончена!/nВы набрали {value} очков.";
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }
    }
}