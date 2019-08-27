using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    private static T instance = null;
    public static T Instance { get { return instance; } }
    protected virtual void Awake()
    {
        if(instance == null || instance != this)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Warning.....Duplicate instance is being created");
            Destroy(this);
        }
    }
}
