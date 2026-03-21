using Interface;
using Model.Player;
using UnityEngine;

namespace Controllers
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;


        public InputController(PlayerBase player)
        {
            _playerBase = player;
        }


        public void Execute()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            _playerBase.Move(moveHorizontal, 0.0f, moveVertical);
        }
    }
}