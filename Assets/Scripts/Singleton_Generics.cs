using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Generic<T> : MonoBehaviour where T : Singleton_Generic<T>
{
    private static T instance;

    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Duplicate singleton creating!!!");
            Destroy(this);
        }
    }
}