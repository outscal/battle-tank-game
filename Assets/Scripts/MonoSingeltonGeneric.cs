using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingeltonGeneric<T> : MonoBehaviour where T : MonoSingeltonGeneric<T>
{
    private static T _instance;

    public static T Instance { get { return _instance; } }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            Destroy(this);
        }
    }

}
