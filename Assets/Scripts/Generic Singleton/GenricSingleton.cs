using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenricSingleton<T>:MonoBehaviour where T : GenricSingleton<T>
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            return instance ;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
            instance = (T)this;
        else
            Destroy(this);
    }

}
