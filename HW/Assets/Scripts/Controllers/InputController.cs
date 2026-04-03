using Geekbrains;
using Interface;
using Model.IntrctvObjcts;
using Model.Player;
using SaveData;
using UnityEngine;

namespace Controllers
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly InteractiveObject[] _interactiveObjects;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;


        public InputController(PlayerBase player, ListExecuteObject listExecuteObject)
        {
            _playerBase = player;
            _interactiveObjects = listExecuteObject.InteractiveObjects;

            _saveDataRepository = new SaveDataRepository();
        }


        public void Execute()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            _playerBase.Move(moveHorizontal, 0.0f, moveVertical);

            if (Input.GetKeyDown(_savePlayer))
                _saveDataRepository.Save(_playerBase, _interactiveObjects);
            if (Input.GetKeyDown(_loadPlayer))
                _saveDataRepository.Load(_playerBase, _interactiveObjects);
        }
    }
}