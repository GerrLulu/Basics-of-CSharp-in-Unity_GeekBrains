using System;
using System.Collections;
using UnityEngine;

namespace Model.Player
{
    public sealed class PlayerBall : PlayerBase
    {
        [Space(10)]
        [Header("Для редактирования скорости")]
        [SerializeField] private float _boost;
        [SerializeField] private float _slow;
        [Tooltip("Сколько времени скорость будет изменена")]
        [SerializeField] private float _timeChangeSpeed;
        [Space(10)]
        [Header("Текстовые сообщения при изменении скорости")]
        [SerializeField] private string _speedBoostInfo = "Скорость увеличелась";
        [SerializeField] private string _speedSlowInfo = "Скорость увеличелась";
        [SerializeField] private string _speedNormInfo = "Скорость стала нормальной";
        private Rigidbody _rigidbody;

        public event Action<string> SpeedBoost = delegate (string s) { };
        public event Action<string> SpeedSlow = delegate (string s) { };
        public event Action<string> SpeedNorm = delegate (string s) { };


        private void Start() => _rigidbody = GetComponent<Rigidbody>();


        public override void Move (float x, float y, float z) => _rigidbody.AddForce(new Vector3(
            x, y, z) * Speed);

        public void Booster() => StartCoroutine(BoostSpeed());

        public void Slowdowner() => StartCoroutine(SlowSpeed());


        private IEnumerator BoostSpeed()
        {
            Speed = Speed * _boost;
            SpeedBoost?.Invoke(_speedBoostInfo);

            yield return new WaitForSeconds(_timeChangeSpeed);

            Speed = Speed / _boost;
            SpeedNorm?.Invoke(_speedNormInfo);
        }

        private IEnumerator SlowSpeed()
        {
            Speed = Speed / _slow;
            SpeedSlow?.Invoke(_speedSlowInfo);

            yield return new WaitForSeconds(_timeChangeSpeed);

            Speed = Speed * _slow;
            SpeedNorm?.Invoke(_speedNormInfo);
        }
    }
}