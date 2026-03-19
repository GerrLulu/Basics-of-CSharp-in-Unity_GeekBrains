using System.Collections;
using UnityEngine;
using static UnityEngine.Debug;

namespace Model
{
    public sealed class PlayerBall : PlayerBase
    {
        [SerializeField] private float _boost = 10.0f;
        [SerializeField] private float _slow = 3.0f;

        private Rigidbody _rigidbody;


        private void Start() => _rigidbody = GetComponent<Rigidbody>();


        public override void Move (float x, float y, float z) => _rigidbody.AddForce(new Vector3(
            x, y, z) * Speed);

        public void Booster() => StartCoroutine(BoostSpeed());

        public void Slowdowner() => StartCoroutine(SlowSpeed());


        private IEnumerator BoostSpeed()
        {
            Speed = Speed * _boost;
            Log("Скорость увеличелась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed / _boost;
            Log("Скорость вернулась в норму");
        }

        private IEnumerator SlowSpeed()
        {
            Speed = Speed / _slow;
            Log("Скорость уменьшилась");
            yield return new WaitForSeconds(10.0f);
            Speed = Speed * _slow;
            Log("Скорость вернулась в норму");
        }
    }
}