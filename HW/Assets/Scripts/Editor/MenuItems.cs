using System.Security.Cryptography;
using UnityEditor;

namespace Editor
{
    public sealed class MenuItems
    {
        [MenuItem("Меню для урока 7/Пункт для создания окна")]
        private static void MenuCreateWindow()
        {
            EditorWindow.GetWindow(typeof(WindowForLesson7), false, "Создать окно");
        }
    }
}
