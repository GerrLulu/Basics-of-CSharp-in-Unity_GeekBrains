using UnityEngine;
using Interface;

namespace Controllers
{
    public sealed class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;


        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _player.position;
        }


        public void Execute() => _mainCamera.position = _player.position + _offset;
    }
}