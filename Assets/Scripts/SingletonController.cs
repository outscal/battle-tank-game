using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonController<T> : MonoBehaviour where T: SingletonController<T>
{
    private static T instance;
    public static T Instance{get{return instance;}}
    private void Awake() 
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
