using UnityEngine;

namespace Model
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed;
        //private Rigidbody _rigidbody;


        //private void Start()
        //{
        //    _rigidbody = GetComponent<Rigidbody>();
        //}

        //private void FixedUpdate()
        //{
        //    Move();
        //}


        public abstract void Move(float x, float y, float z);
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //_rigidbody.AddForce(movement * Speed);
    }
}