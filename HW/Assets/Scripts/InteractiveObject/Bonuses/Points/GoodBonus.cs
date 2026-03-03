using Interface;
using UnityEngine;

namespace InteractiveObjectNS.Bonuses.Points
{
    public sealed class GoodBonus : InteractiveObjectPoints, IFlicker
    {
        private Material _material;


        private void Awake() => _material = GetComponent<Renderer>().material;


        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        public override object Clone()
        {
            return Instantiate(gameObject, new Vector3(6.77f, 0.6f, -5.38f),
                transform.rotation,transform.parent);
        }
    }
}