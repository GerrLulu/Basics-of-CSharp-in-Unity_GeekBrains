using Enumes;
using Geekbrains;
using Helper;
using Interface;
using Model.Finish;
using Model.IntrctvObjcts.Bonuses;
using Model.IntrctvObjcts.Bonuses.Points;
using Model.IntrctvObjcts.Bonuses.Speed;
using Model.Player;
using System;
using UnityEngine;
using View.UI;

namespace Controllers
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;

        private int _sumBonus;

        private ListExecuteObject _interactiveObjects;
        private Reference _reference;
        private CameraController _cameraController;
        private InputController _inputController;
        private DisplayBonuses _displayBonuses;
        private DisplaySpeed _displaySpeed;
        private DisplayEndGame _displayEndGame;
        private FinishPoint _finishPoint;

        private (string name, int point) _tupleExamplePoint;


        private void Awake()
        {
            FindObjectOfType<GoodBonus>().Clone();
            FindObjectOfType<BadBonus>().Clone();
            FindObjectOfType<SpeedBonus>().Clone();
            FindObjectOfType<SlowdownBonus>().Clone();

            _interactiveObjects = new ListExecuteObject();
            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
                player = _reference.PlayerBall;
            _reference.PlayerBall.ChangerSpeedDisplay += ChangeSpeed;

            foreach (IExecute intObj in _interactiveObjects)
            {
                if (intObj is InteractiveObjectPoints bonusPoint)
                {
                    bonusPoint.CaughtPlayer += ChangePoints;
                    _tupleExamplePoint = bonusPoint.ExampleTuplePoints();
                }
                else if (intObj is InteractiveObjectSpeed bonusSpeed)
                    bonusSpeed.CaughtPlayer += _reference.PlayerBall.ChangerSpeed;
            }

            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player, _interactiveObjects);
                _interactiveObjects.AddExecuteObject(_inputController);
            }

            _displayBonuses = new DisplayBonuses(_reference.BonuseDisplay);

            _displaySpeed = new DisplaySpeed(_reference.SpeedDisplay);

            _displayEndGame = new DisplayEndGame(_reference.EndGameDisplay);

            _finishPoint = FindObjectOfType<FinishPoint>();
            _finishPoint.OnFinish += FinalGame;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                IExecute interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                    continue;

                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            _reference.PlayerBall.ChangerSpeedDisplay -= ChangeSpeed;

            foreach (IExecute intObj in _interactiveObjects)
            {
                if (intObj is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer -= ChangePoints;
                else if (intObj is InteractiveObjectSpeed bonusSpeed)
                    bonusSpeed.CaughtPlayer -= _reference.PlayerBall.ChangerSpeed;
            }

            _finishPoint.OnFinish -= FinalGame;
        }


        private void ChangePoints(int value)
        {
            _sumBonus += value;
            _displayBonuses.Display(_sumBonus);

            Debug.Log($"Name: {_tupleExamplePoint.name}; Point: {_tupleExamplePoint.point}");
        }

        private void ChangeSpeed(string value) => _displaySpeed.Display(value);

        private void FinalGame()
        {
            Time.timeScale = 0.0f;
            _displayEndGame.GameOver(_sumBonus);
        }
    }
}