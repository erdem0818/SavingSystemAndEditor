using UnityEditor;
using UnityEngine;
using Assets.Scripts.SaveSystem;

namespace Assets.Scripts.EditorUtils
{
    public class EditorUtils : MonoBehaviour
    {
        [MenuItem("Utils/DeleteAllSavings")]
        public static void DeleteAllSavings()
        {
            //OnSavingsDelete?.Invoke();
            SaveSystem.SaveSystem.DeleteAllSavings();
            Savings.ClearDictionary();
            Debug.Log("deleted static");
        }
    }
}
