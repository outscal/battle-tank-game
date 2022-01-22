using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template to create Generic Singleton Class
public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    private static T instance; 
    public static T Instance { get { return instance; } }   
    
    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(this); 
        }
        else
        {
            instance = (T)this;
        }
    }
}
