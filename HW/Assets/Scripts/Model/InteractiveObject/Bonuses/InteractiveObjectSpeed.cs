using System;
using UnityEngine;

namespace Model.IntrctvObjcts.Bonuses
{
    public abstract class InteractiveObjectSpeed : InteractiveObject
    {
        [Header("Для редактирование логики")]

        [Tooltip("Множитель изменения скорости")]
        [SerializeField] private float _speedMultiplier;
        [Tooltip("Время изменения скорости")]
        [SerializeField] private float _timeChanger;
        [Tooltip("Текст пояснения")]
        [SerializeField] private string _speedInfo;

        public event Action<float, float, string> CaughtPlayer = delegate (float f, float t, string s) { };


        protected override void Interaction() => CaughtPlayer?.Invoke(_speedMultiplier, _timeChanger, _speedInfo);

        public (string name, float speedMultiplier, float timeChanger) ExampleTupleSpeed()
        {
            return (gameObject.name, _speedMultiplier, _timeChanger);
        }
    }
}