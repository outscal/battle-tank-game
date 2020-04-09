﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Commons
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {
        private static T Instance;
        public static T instance { get { return Instance; } }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;
            }
            else
            {
                Debug.LogError(Instance + "is Tring to create another instance");
                Destroy(gameObject);
            }
        }
    }
}
