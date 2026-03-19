using Enumes;
using Geekbrains;
using IntrctvObjcts.Bonuses;
using IntrctvObjcts.Bonuses.Points;
using IntrctvObjcts.Bonuses.Speed;
using Model;
using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {

        public Text Text;
        //public PlayerBall PlayerBall;
        public PlayerType PlayerType = PlayerType.Ball;

        private int _sumBonus;
        private ListExecuteObject _interactiveObjects;
        private Reference _reference;
        private CameraController _cameraController;
        private InputController _inputController;
        private DisplayBonuses _displayBonuses;


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

            _cameraController = new CameraController(player.transform, player.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObjects.AddExecuteObject(_inputController);
            }

            _displayBonuses = new DisplayBonuses(_reference.Bonuse);

            foreach(var o in _interactiveObjects)
            {
                if (o is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer += ChangePoints;
                else if (o is SpeedBonus speedBonus)
                    speedBonus.CaughtPlayer += _reference.PlayerBall.Booster;
                else if (o is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer += _reference.PlayerBall.Slowdowner;
            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                    continue;

                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer -= ChangePoints;
                else if (o is SpeedBonus speeBonus)
                    speeBonus.CaughtPlayer -= _reference.PlayerBall.Booster;
                else if (o is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer -= _reference.PlayerBall.Slowdowner;
            }
        }


        private void ChangePoints(int value)
        {
            _sumBonus += value;
            _displayBonuses.Display(_sumBonus);
        }
    }
}