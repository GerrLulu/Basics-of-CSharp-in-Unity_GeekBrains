using Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.IntrctvObjcts.Bonuses.Speed
{
    public sealed class SlowdownBonus : InteractiveObjectSpeed, IRotation
    {
        private float _speedRotation;


        private void Awake() => _speedRotation = Random.Range(10.0f, 50.0f);


        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public override void Execute()
        {
            base.Execute();
            Rotation();
        }

        public override object Clone()
        {
            return Instantiate(gameObject, new Vector3(-6.79f, 0.6f, 0.53f),
                transform.rotation, transform.parent);
        }
    }
}