using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGenerics<T> : MonoBehaviour where T : SingletonGenerics<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Duplication of Singleton class " + instance + " is not Allowed");
            Destroy(this);
        }
    }
}
