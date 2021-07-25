using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class EditorUtils : MonoBehaviour
    {
        public static event Action OnSavingsDelete;

        [ContextMenu(nameof(DeleteAllPrefs))]
        public void DeleteAllPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("deleted");
        }

        [MenuItem("Utils/DeleteAll")]
        private static void DeleteAllSavings()
        {
            OnSavingsDelete?.Invoke();
            Debug.Log("deleted");
        }
    }
}
