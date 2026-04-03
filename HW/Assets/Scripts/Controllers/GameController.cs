using Enumes;
using Geekbrains;
using Helper;
using Interface;
using Model.IntrctvObjcts.Bonuses;
using Model.IntrctvObjcts.Bonuses.Points;
using Model.IntrctvObjcts.Bonuses.Speed;
using Model.Player;
using System;
using UnityEngine;
using UnityEngine.UI;
using View.UI;

namespace Controllers
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public Text Text;
        public PlayerType PlayerType = PlayerType.Ball;

        private int _sumBonus;

        private ListExecuteObject _interactiveObjects;
        private Reference _reference;
        private CameraController _cameraController;
        private InputController _inputController;
        private DisplayBonuses _displayBonuses;
        private DisplaySpeed _displaySpeed;


        private void Awake()
        {
            FindObjectOfType<GoodBonus>().Clone();
            FindObjectOfType<BadBonus>().Clone();
            FindObjectOfType<SpeedBonus>().Clone();
            FindObjectOfType<SlowdownBonus>().Clone();

            //_playerBall = FindObjectOfType<PlayerBall>();

            _interactiveObjects = new ListExecuteObject();
            _reference = new Reference();

            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }

            foreach (IExecute intObj in _interactiveObjects)
            {
                if (intObj is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer += ChangePoints;
                else if (intObj is SpeedBonus speedBonus)
                    speedBonus.CaughtPlayer += _reference.PlayerBall.Booster;
                else if (intObj is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer += _reference.PlayerBall.Slowdowner;
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
            _reference.PlayerBall.SpeedBoost += ChangeSpeed;
            _reference.PlayerBall.SpeedSlow += ChangeSpeed;
            _reference.PlayerBall.SpeedNorm += ChangeSpeed;
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
            _reference.PlayerBall.SpeedBoost -= ChangeSpeed;
            _reference.PlayerBall.SpeedSlow -= ChangeSpeed;
            _reference.PlayerBall.SpeedNorm -= ChangeSpeed;

            foreach (IExecute intObj in _interactiveObjects)
            {
                if (intObj is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer -= ChangePoints;
                else if (intObj is SpeedBonus speeBonus)
                    speeBonus.CaughtPlayer -= _reference.PlayerBall.Booster;
                else if (intObj is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer -= _reference.PlayerBall.Slowdowner;
            }
        }


        private void ChangePoints(int value)
        {
            _sumBonus += value;
            _displayBonuses.Display(_sumBonus);
        }

        private void ChangeSpeed(string value) => _displaySpeed.Display(value);
    }
}