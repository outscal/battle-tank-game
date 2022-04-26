using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoGenericSingleton<T> : MonoBehaviour where T : MonoGenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
