using System;
using System.Collections;
using UnityEngine;

namespace Model.Player
{
    public sealed class PlayerBall : PlayerBase
    {
        [Space(10)]
        [Header("“екстовые сообщени€ при нормализации скорости")]
        [SerializeField] private string _speedNormInfo = "—корость стала нормальной";
        
        private Rigidbody _rigidbody;

        public event Action<string> ChangerSpeedDisplay = delegate (string s) { };


        private void Start() => _rigidbody = GetComponent<Rigidbody>();


        public override void Move (float x, float y, float z) => _rigidbody.AddForce(new Vector3(
            x, y, z) * Speed);

        public void ChangerSpeed(float f, float t, string s) => StartCoroutine(ChangeSpeed(f, t, s));


        private IEnumerator ChangeSpeed(float speedMultiplier, float timeChanger,
            string speedInfo)
        {
            Speed = Speed * speedMultiplier;
            ChangerSpeedDisplay?.Invoke(speedInfo);

            yield return new WaitForSeconds(timeChanger);

            Speed = Speed / speedMultiplier;
            ChangerSpeedDisplay?.Invoke(_speedNormInfo);
        }
    }
}