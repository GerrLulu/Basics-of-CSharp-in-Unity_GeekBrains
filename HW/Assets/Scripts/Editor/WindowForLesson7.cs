using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public sealed class WindowForLesson7 : EditorWindow
    {
        public int CountObject = 1;
        public float Radius = 10;
        public bool GroupEnabled;
        public bool RandomColor = true;
        public string NameObject = string.Empty;
        public static GameObject ObjectInstantiate;

        private Queue<Transform> _queueRoot = new Queue<Transform>();
        private static int _offset;


        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);

            ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить",
                ObjectInstantiate, typeof(GameObject), true) as GameObject;
            NameObject = EditorGUILayout.TextField("Имя объекта", NameObject);
            GroupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", GroupEnabled);
            RandomColor = EditorGUILayout.Toggle("Случайный цвет", RandomColor);
            CountObject = EditorGUILayout.IntSlider("Количество объектов", CountObject, 1, 100);
            Radius = EditorGUILayout.Slider("Радиус окружности", Radius, 10, 50);

            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Создать объекты");

            if (button)
            {
                if (ObjectInstantiate && NameObject != string.Empty)
                {
                    GameObject root = new GameObject("Root");
                    _queueRoot.Enqueue(root.transform);

                    for (int i = 0; i < CountObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / CountObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                        temp.name = NameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && RandomColor)
                            tempRenderer.material.color = Random.ColorHSV();
                    }

                    root.transform.position = new Vector3(0, _offset++);
                }
                else
                {
                    EditorDialog.DisplayAlertDialog("Ошибка", "Добавте префаб и название объекта", null);
                }
            }

            bool destroyRoot = false;
            if (_queueRoot.Count > 0)
                destroyRoot = GUILayout.Button("Удалить объекты");

            if (destroyRoot)
                DestroyImmediate(_queueRoot.Dequeue().gameObject);
        }
    }
}