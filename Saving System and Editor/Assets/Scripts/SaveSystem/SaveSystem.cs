using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.SaveSystem
{
    public class Savings
    {
        public static Savings Instance { get; } = new Savings();
        private Savings() { }

        public readonly Dictionary<string, string> ReadableSavings = new Dictionary<string, string>();
    }
    public class SaveSystem<T> where T : class , new() 
    {
        public static SaveSystem<T> Instance { get; } = new SaveSystem<T>();

        private SaveSystem()
        {
            EditorUtils.OnSavingsDelete += DeleteAllSavings;
        }

        public void Destroy()
        {
            Debug.Log("disposed");
            EditorUtils.OnSavingsDelete -= DeleteAllSavings;
        }

        private readonly Dictionary<string, T> _savingDictionary  = new Dictionary<string, T>();
        private readonly Dictionary<string, string> _savingsAsString  = new Dictionary<string, string>();

        public void SaveData(T data, string saveName)
        {
            PlayerPrefs.SetString(saveName, JsonUtility.ToJson(data));
            
            _savingDictionary.Add(saveName, data);
            AddValueAsStringToDictionary(saveName);
        }

        public void AddValueAsStringToDictionary(string saveName)
        {
            var dataString = PlayerPrefs.GetString(saveName);
            _savingsAsString.Add(saveName, dataString);

            //**************
            Savings.Instance.ReadableSavings.Add(saveName, GetDataWithDict(saveName).ToString());
        }

        public T GetDataWithDict(string saveName)
        {
            T data = null;

            if (HasKey(saveName))
                data = _savingDictionary[saveName];
            else
            {
                data = new T();
                SaveData(data,saveName);
            }
            return data;
        }

        public bool HasKey(string saveName)
        {
            return _savingDictionary.ContainsKey(saveName);
        }

        public string GetDataStringByKey(string saveName)
        {
            return !HasKey(saveName) ? string.Empty : _savingsAsString[saveName];
        }

        public void DeleteAllSavings()
        {
            _savingsAsString.Clear();
            _savingDictionary.Clear();
            Savings.Instance.ReadableSavings.Clear();
            PlayerPrefs.DeleteAll();
        }
    }
}
