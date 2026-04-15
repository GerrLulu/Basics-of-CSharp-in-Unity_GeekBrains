using System;
using UnityEngine;

namespace Model.Finish
{
    public sealed class FinishPoint : MonoBehaviour
    {
        public event Action OnFinish = delegate { };


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
                OnFinish?.Invoke();
            return;
        }
    }
}