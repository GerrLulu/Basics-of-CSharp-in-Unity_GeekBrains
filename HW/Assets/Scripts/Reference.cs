using Model.Player;
using UnityEngine;

namespace Geekbrains
{
    public sealed class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Canvas _canvas;
        private GameObject _bonuseDisplay;
        private GameObject _speedDisplay;
        private GameObject _endGame;


        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("PlayerBall");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }
        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = Object.FindObjectOfType<Canvas>();
                return _canvas;
            }
        }
        public GameObject BonuseDisplay
        {
            get
            {
                if (_bonuseDisplay == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonuse");
                    _bonuseDisplay = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonuseDisplay;
            }
        }
        public GameObject SpeedDisplay
        {
            get
            {
                if (_speedDisplay == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/SpeedInfo");
                    _speedDisplay = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _speedDisplay;
            }
        }
        //public GameObject EndGame
        //{
        //    get
        //    {
        //        if (_endGame == null)
        //        {
        //            var gameObject = Resources.Load<GameObject>("UI/EndGame");
        //            _endGame = Object.Instantiate(gameObject, Canvas.transform);
        //        }

        //        return _endGame;
        //    }
        //}
    }
}