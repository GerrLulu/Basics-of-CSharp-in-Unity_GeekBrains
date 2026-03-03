using InteractiveObjectNS;
using InteractiveObjectNS.Bonuses;
using InteractiveObjectNS.Bonuses.Points;
using InteractiveObjectNS.Bonuses.Speed;
using Interface;
using PlayerNS;
using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private int _sumBonus;

        public Text _text;
        public PlayerBall _playerBall;

        private InteractiveObject[] _interactiveObjects;
        private DisplayBonuses _displayBonuses;


        private void Awake()
        {
            FindObjectOfType<GoodBonus>().Clone();
            FindObjectOfType<BadBonus>().Clone();
            FindObjectOfType<SpeedBonus>().Clone();
            FindObjectOfType<SlowdownBonus>().Clone();

            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _displayBonuses = new DisplayBonuses(_text);
            //_playerBall = FindObjectOfType<PlayerBall>();
            foreach(var o in _interactiveObjects)
            {
                if (o is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer += ChangePoints;
                else if (o is SpeedBonus speeBonus)
                    speeBonus.CaughtPlayer += _playerBall.Booster;
                else if (o is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer += _playerBall.Slowdowner;
            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                    continue;

                if (interactiveObject is IFly fly)
                    fly.Fly();
                if (interactiveObject is IFlicker flicker)
                    flicker.Flicker();
                if (interactiveObject is IRotation rotation)
                    rotation.Rotation();
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObjectPoints bonus)
                    bonus.CaughtPlayer -= ChangePoints;
                else if (o is SpeedBonus speeBonus)
                    speeBonus.CaughtPlayer -= _playerBall.Booster;
                else if (o is SlowdownBonus slowdownBonus)
                    slowdownBonus.CaughtPlayer -= _playerBall.Slowdowner;

                Destroy(o.gameObject);
            }
        }


        private void ChangePoints(int value)
        {
            _sumBonus += value;
            _displayBonuses.Display(_sumBonus);
        }
    }
}