using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IntrctvObjcts
{
    public abstract class InteractiveObject : MonoBehaviour, IFly, ICloneable, IExecute
    {
        private bool _isInteractable;
        private float _lengthFly;

        protected Color _color;

        public bool IsInteractable
        {
            get {  return _isInteractable; }
            private set
            {
                _isInteractable = value;
                gameObject.SetActive(_isInteractable);
            }
        }


        private void Start()
        {
            _isInteractable = true;

            _lengthFly = Random.Range(1.0f, 2.0f);

            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
                renderer.material.color = _color;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isInteractable && collision.gameObject.tag == "Player")
            {
                Interaction();
                IsInteractable = false;
            }
            return;
        }


        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        protected abstract void Interaction();

        public virtual object Clone()
        {
            return null; 
        }

        public virtual void Execute()
        {
            if (!IsInteractable)
                return;
            Fly();
        }
    }
}