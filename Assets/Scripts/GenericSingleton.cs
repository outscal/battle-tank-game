using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void MakeSingleton()
    {
        Debug.Log("Parent class singleton");
        if (instance)
        {
            Debug.Log("the new instance was destroyed");
            Destroy(this);
        }
            
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(instance) ;
        }
            
    }

}


