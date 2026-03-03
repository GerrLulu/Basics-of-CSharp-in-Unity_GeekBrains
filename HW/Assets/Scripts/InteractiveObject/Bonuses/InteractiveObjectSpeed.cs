using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace InteractiveObjectNS.Bonuses
{
    public abstract class InteractiveObjectSpeed : InteractiveObject, /*IFly*/ ICloneable
    {
        //private float _lengthFly;

        public delegate void CaughtPlayerChange();
        public event CaughtPlayerChange CaughtPlayer;


        //private void Awake() => _lengthFly = Random.Range(1.0f, 2.0f);


        protected override void Interaction() => CaughtPlayer?.Invoke();

        //public void Fly()
        //{
        //    transform.localPosition = new Vector3(transform.localPosition.x,
        //        Mathf.PingPong(Time.time, _lengthFly),
        //        transform.localPosition.z);
        //}

        public abstract object Clone();
    }
}
