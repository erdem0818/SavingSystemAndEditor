using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.SaveSystem
{
    public class Savings : IEnumerable<KeyValuePair<string,string>> , IDisposable
    {
        private static Savings _instance;
        public static Savings Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Savings();
                    return _instance;
                }
                else
                    return _instance;
            }
        }
        private Savings()
        {
            //UnityEngine.Debug.Log("sub");

            //SaveHelper.OnKeyAdded += AddToDictionary;
        }
        public void Dispose()
        {
            //SaveHelper.OnKeyAdded -= AddToDictionary;
            UnityEngine.Debug.Log("dispose");
        }

        private static readonly Dictionary<string, string> _readableSavings = new Dictionary<string, string>();

        public static void AddToDictionary(string key, string value)
        {
            //todo if key exits delete all
            _readableSavings.Add(key, value);
        }
        public static void RemoveFromDictionary(string key)
        {
            _readableSavings.Remove(key);
        }

        public static void ClearDictionary()
        {
            _readableSavings.Clear();
            //todo add this functionality to button
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _readableSavings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
