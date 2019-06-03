using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        Debug.LogError("[Singleton Error] " + typeof(T).ToString() + " is missing");
                    }
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(instance);
            }
            else if (instance != null)
            {
                Destroy(this);
            }
        }
    }
}