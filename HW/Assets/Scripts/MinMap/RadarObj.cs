using UnityEngine;
using UnityEngine.UI;

namespace MinMap
{
    public sealed class RadarObj : MonoBehaviour
    {
        [SerializeField]private Image _ico;


        private void OnValidate() => _ico = Resources.Load<Image>("MinMap/RadarObject");

        private void OnEnable() => Radar.RegisterRadarObject(gameObject, _ico);

        private void OnDisable() => Radar.RemoveRadarObject(gameObject);
    }
}