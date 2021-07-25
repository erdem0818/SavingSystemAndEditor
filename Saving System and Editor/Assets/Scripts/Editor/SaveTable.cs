using Assets.Scripts.SaveSystem;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class SaveTable : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("Savings", EditorStyles.boldLabel);

            foreach (var e in Savings.Instance.ReadableSavings)
            {
                var key = $"Key: {e.Key}";
                var value = $"Value: {e.Value}";
                EditorGUILayout.TextField(key, value);
            }
        }

        [MenuItem("Window/SaveTable")]
        private static void ShowWindow()
        {
            EditorWindow.GetWindow<SaveTable>("SAVINGS");
        }
    }
}
