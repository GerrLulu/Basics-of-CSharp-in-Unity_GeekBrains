using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(PathAttributeLesson7))]
    public sealed class PathDrawerLesson7 : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                EditorGUI.BeginProperty(position, label, property);
                EditorGUI.ObjectField(position, property, typeof(GameObject), GUIContent.none);

                if (property.objectReferenceValue != null)
                {
                    GameObject target = property.objectReferenceValue as GameObject;
                    string path = GetPath(target);

                    EditorGUI.LabelField(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.width, EditorGUIUtility.singleLineHeight), $"Path: {path}");
                }
                else
                    EditorGUI.LabelField(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.width, EditorGUIUtility.singleLineHeight), $"Path: none");

                EditorGUI.EndProperty();
            }
            else
                EditorGUI.HelpBox(position, "Не GameObject", MessageType.Info);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2;
        }


        private string GetPath(GameObject obj)
        {
            string path = obj.name;
            Transform parent = obj.transform.parent;

            while (parent != null)
            {
                path = parent.name + "/" + path;
                parent = parent.parent;
            }

            return path;
        }
    }
}