using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Instance<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T InstanceClass
        {
            get
            {
                if(instance == null)
                {
                    Debug.Log("[Instance Error] " + typeof(T).ToString() + " is missing");
                }
                return instance;
            }
        }


        private void Awake()
        {
            if (instance == null)
                instance = this as T;
            else if (instance != null)
                Destroy(this);

        }

    }
}