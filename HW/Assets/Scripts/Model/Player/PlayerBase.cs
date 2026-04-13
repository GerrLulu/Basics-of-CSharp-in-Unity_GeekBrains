using UnityEngine;

namespace Model.Player
{
    public abstract class PlayerBase : MonoBehaviour
    {
        [Header("Скорость игрока")]
        public float Speed;


        public abstract void Move(float x, float y, float z);
    }
}