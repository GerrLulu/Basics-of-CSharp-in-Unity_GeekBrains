using Interface;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.IntrctvObjcts
{
    public abstract class InteractiveObject : MonoBehaviour, IFly, ICloneable, IExecute
    {
        [Header ("Для редактора")]
        [SerializeField] private bool _isAllowScaling = true;
        [SerializeField] private float _activeDis;

        private bool _isInteractable;
        private float _lengthFly;

        protected Color _color;

        public bool IsInteractable
        {
            get {  return _isInteractable; }
            set
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

        private void OnTriggerEnter(Collider other)
        {
            if (_isInteractable && other.gameObject.tag == "Player")
            {
                Interaction();
                IsInteractable = false;
            }
            return;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractiveObjectImage.jpg",
                _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Transform t = transform;

            var flat = new Vector3(_activeDis, 0, _activeDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawSphere(Vector3.zero, 5);
#endif
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