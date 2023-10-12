using System;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class UiBase : MonoBehaviour
    {
        public static UiBase Instance { get; private set; }

        private Stack<GameObject> _prefabs = new();

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        public GameObject ShowPrefab(string url)
        {
            // if (_prefabs.Count > 0)
            // {
            //     // Top().SetActive(false);
            //     
            // }
            var prefab = UnityEngine.Resources.Load(url) as GameObject;
            _prefabs.Push(prefab);
            return Instantiate(prefab, this.transform);
        }

        public void HidePrefab()
        {
            DestroyImmediate(_prefabs.Pop(),true);
        }

        private GameObject Top()
        {
            return _prefabs.Peek();
        }
    }
}