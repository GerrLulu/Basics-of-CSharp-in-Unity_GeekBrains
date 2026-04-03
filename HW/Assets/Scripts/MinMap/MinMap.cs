using UnityEngine;

namespace MinMap
{
    public sealed class MinMap : MonoBehaviour
    {
        private Transform _transformPlayer;


        private void Start()
        {
            _transformPlayer = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0 , 0);
            transform.position = _transformPlayer.position + new Vector3(0, 5.0f, 0);

            var rt = Resources.Load<RenderTexture>("MinMap/MinMapTexture");

            GetComponent<Camera>().targetTexture = rt;
        }

        private void LateUpdate()
        {
            var newPosition = _transformPlayer.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _transformPlayer.eulerAngles.y, 0);
        }
    }
}