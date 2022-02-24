using System.Linq;
using Assets.Scripts.SaveSystem;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class SaveTable : EditorWindow
    {
        private void OnGUI()
        {
            ShowSavings();
            ClearSavings();
        }

        private void ClearSavings()
        {
            if(GUILayout.Button("Delete Savings"))
                EditorUtils.EditorUtils.DeleteAllSavings();
        }

        private void ShowSavings()
        {
            GUILayout.Label("Savings", EditorStyles.boldLabel);
            
            foreach (var (key, value) in from e in Savings.Instance
                let key = $"Key: {e.Key}"
                let value = $"Value: {e.Value}"
                select (key, value))
            {
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
