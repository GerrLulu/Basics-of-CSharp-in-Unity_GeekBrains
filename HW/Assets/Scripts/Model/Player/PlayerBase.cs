using UnityEngine;

namespace Model.Player
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed;


        public abstract void Move(float x, float y, float z);
    }
}