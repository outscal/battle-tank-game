using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Template for creating singleton class.
public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Instance already exist, destroying");
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }
}
