using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenricSingleton<T> : MonoBehaviour where T : GenricSingleton<T>, new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
            instance = this as T;
        else
            Destroy(this);
    }

}
