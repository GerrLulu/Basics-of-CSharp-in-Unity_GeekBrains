using Interface;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinMap
{
    public sealed class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }


    public sealed class Radar : MonoBehaviour, IExecute
    {
        private readonly float _mapScale = 2;
        private Transform _transfPlayer;
        public static List<RadarObject> RadarObjects = new List<RadarObject>();


        private void Start() => _transfPlayer = Camera.main.transform;


        public static void RegisterRadarObject(GameObject gameObject, Image i)
        {
            Image image = Instantiate(i);
            RadarObjects.Add(new RadarObject { Owner = gameObject, Icon = image });
        }

        public static void RemoveRadarObject(GameObject gameObject)
        {
            List<RadarObject> newList = new List<RadarObject>();

            foreach (RadarObject obj in RadarObjects)
            {
                if (obj.Owner == gameObject)
                {
                    Destroy(obj.Icon);
                    continue;
                }
                newList.Add(obj);
            }

            RadarObjects.RemoveRange(0, RadarObjects.Count);
            RadarObjects.AddRange(newList);
        }

        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in RadarObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position
                    - _transfPlayer.position);
                float distToObject = Vector3.Distance(_transfPlayer.position,
                    radObject.Owner.transform.position) * _mapScale;
                float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270
                    - _transfPlayer.eulerAngles.y;

                radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0)
                    + transform.position;
            }
        }


        public void Execute()
        {
            if (Time.frameCount % 2 == 0)
                DrawRadarDots();
        }
    }
}