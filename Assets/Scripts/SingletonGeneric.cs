using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGeneric<T> : MonoBehaviour where T : SingletonGeneric<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
