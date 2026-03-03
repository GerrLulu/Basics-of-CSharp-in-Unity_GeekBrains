using Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractiveObjectNS
{
    public abstract class InteractiveObject : MonoBehaviour, IFly
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
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
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
            if (IsInteractable || collision.gameObject.tag == "Player")
            {
                Interaction();
                Destroy(gameObject);
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
    }
}