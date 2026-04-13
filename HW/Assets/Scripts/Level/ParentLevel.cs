using UnityEngine;

namespace Level
{
    public class ParentLevel : MonoBehaviour
    {
        [Header("Сенса")]
        public float SensitiveX = 7.0f;
        public float SensitiveZ = 7.0f;
        [Header("Наклон")]
        public float Max = 10.0f;
        public float Min = -10.0f;

        private float _rotationX;
        private float _rotationZ;


        protected void RotateLevel()
        {
            _rotationX += Input.GetAxis("Mouse Y") * SensitiveX;
            _rotationX = Mathf.Clamp(_rotationX, Min, Max);

            _rotationZ += Input.GetAxis("Mouse X") * SensitiveZ;
            _rotationZ = Mathf.Clamp(_rotationZ, Min, Max);

            transform.localEulerAngles = new Vector3(-_rotationX, 0, _rotationZ);
        }

        public void AddComponent()
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<BoxCollider>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
}