using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public class SaveSystem
    {
        private SaveSystem(){}

        //public static event System.Action<string, string> OnKeyAdded;
        //public static event System.Action<string> OnKeyRemoved;

        private static readonly Dictionary<string, string> _savings = new Dictionary<string, string>();

        public static void SaveData<T>(T data, string key)
        {
            if(HasSaving(key))
            {
                #if UNITY_EDITOR
                Debug.LogWarning("The key you wanted to add is already exists - this key's value is overwritten");
                #endif
                DeleteSaving(key);

                WriteData(data, key);
                return;
            }
            WriteData(data, key); 
            //?PlayerPrefs.Save();
        }
        private static void WriteData<T>(T data, string key)
        {
            string serializedData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, serializedData);

            _savings.Add(key, serializedData);
            //OnKeyAdded?.Invoke(key, serializedData);  
            Savings.AddToDictionary(key, serializedData);
        }
        public static T GetOrCreateData<T>(string key) where T : new()
        {
            T data;
            if(HasSaving(key))
            {
                data = GetExistingData<T>(key);
                return data;
            }

            data = new T();
            WriteData(data, key);
            return data;
        }
        private static T GetExistingData<T>(string key) where T : new()
        {
            string valueString = _savings[key];
            T data = JsonUtility.FromJson<T>(valueString);
            return data;
        }
        public static bool HasSaving(string key)
        {
           if(_savings.ContainsKey(key)) return true;
           return false;
        }
        ///<summary>
        /// Deletes all saves
        ///</summary>
        public static void DeleteAllSavings()
        {
            _savings.Clear();
            PlayerPrefs.DeleteAll();
            //todo OnKeyRemoved invoke for all keys
        }
        ///<summary>
        /// Deletes the save of given key.
        ///</summary>
        public static void DeleteSaving(string key)
        {
           if(HasSaving(key))
           {
               _savings.Remove(key);
               PlayerPrefs.DeleteKey(key);
               Savings.RemoveFromDictionary(key);
               //OnKeyRemoved?.Invoke(key);
               return;
           }

           #if UNITY_EDITOR
           Debug.LogWarning("The key you entered does not exist.");
           #endif
        }
    }
}
