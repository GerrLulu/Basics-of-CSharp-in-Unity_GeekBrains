using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace InteractiveObjectNS.Bonuses
{
    public abstract class InteractiveObjectPoints : InteractiveObject, /*IFly*/
        ICloneable, IComparable<InteractiveObjectPoints>
    {
        [SerializeField] private int _points;

        //private float _lengthFly;

        public event CaughtPlayerChange CaughtPlayer;
        public delegate void CaughtPlayerChange(int value);


        //private void Awake() => _lengthFly = Random.Range(1.0f, 2.0f);


        protected override void Interaction() => CaughtPlayer?.Invoke(_points);

        //public void Fly()
        //{
        //    transform.localPosition = new Vector3(transform.localPosition.x,
        //        Mathf.PingPong(Time.time, _lengthFly),
        //        transform.localPosition.z);
        //}

        public int CompareTo(InteractiveObjectPoints other) => name.CompareTo(other.name);

        public abstract object Clone();
    }
}