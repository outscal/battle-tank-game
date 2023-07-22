using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleTon<T> : MonoBehaviour where T : GenericSingleTon<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {

      
        if(instance == null)
        {
            instance = (T)this;
        }

        else
        {
            Destroy(this);
        }
    }
}
