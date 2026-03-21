using System;
using UnityEngine;

namespace Model.IntrctvObjcts.Bonuses
{
    public abstract class InteractiveObjectPoints : InteractiveObject, IComparable<InteractiveObjectPoints>
    {
        [SerializeField] private int _points;
        
        public event Action<int> CaughtPlayer = delegate (int i) { };


        protected override void Interaction() => CaughtPlayer?.Invoke(_points);

        public int CompareTo(InteractiveObjectPoints other) => name.CompareTo(other.name);
    }
}