using Level;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ParentLevel))]
    public sealed class BehaviorEditorLesson7 : UnityEditor.Editor
    {
        private bool _toggleComponent;


        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ParentLevel parentLevel = (ParentLevel)target;

            parentLevel.SensitiveX = EditorGUILayout.Slider(parentLevel.SensitiveX, 2.0f, 10.0f);
            parentLevel.SensitiveZ = EditorGUILayout.Slider(parentLevel.SensitiveZ, 2.0f, 10.0f);

            parentLevel.Max = EditorGUILayout.Slider(parentLevel.Max, 1.0f, 20.0f);
            parentLevel.Min = EditorGUILayout.Slider(parentLevel.Min, 0.1f, 15.0f);

            _toggleComponent = GUILayout.Toggle(_toggleComponent, "Добавлять компоненты?");

            if (_toggleComponent)
            {
                var isPressAddButton = GUILayout.Button("Add Component", EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Remove Component", EditorStyles.miniButtonLeft);
                
                if (isPressAddButton)
                    parentLevel.AddComponent();
                if (isPressRemoveButton)
                    parentLevel.RemoveComponent();
            }
        }
    }
}