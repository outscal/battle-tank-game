using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTanks<T> : MonoBehaviour where T : SingletonTanks<T>
{
    private static SingletonTanks<T> instance;
    public static SingletonTanks<T> Instance { get { return instance; } }

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
