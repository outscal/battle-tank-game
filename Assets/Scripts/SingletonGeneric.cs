using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGeneric<T> : MonoBehaviour where T : SingletonGeneric<T>
{
    private static SingletonGeneric<T> instance;
    public static SingletonGeneric<T> Instance { get { return instance; } }

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
