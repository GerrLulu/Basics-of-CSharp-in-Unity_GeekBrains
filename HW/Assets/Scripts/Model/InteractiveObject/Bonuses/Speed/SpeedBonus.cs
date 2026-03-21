using Interface;
using UnityEngine;

namespace Model.IntrctvObjcts.Bonuses.Speed
{
    public sealed class SpeedBonus : InteractiveObjectSpeed, IFlicker
    {
        private Material _material;


        private void Awake() => _material = GetComponent<Renderer>().material;


        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public override void Execute()
        {
            base.Execute();
            Flicker();
        }

        public override object Clone()
        {
            return Instantiate(gameObject, new Vector3(-6.76f, 0.6f, -3.61f),
                transform.rotation, transform.parent);
        }
    }
}