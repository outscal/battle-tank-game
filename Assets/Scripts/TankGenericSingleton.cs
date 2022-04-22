using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGenericSingleton<T> : MonoBehaviour where T : TankGenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
         if(instance == null)
         {
            instance = (T)this;
         }
         else
         {
            Debug.LogError("Someone is trying to create Duplicate Singleton!!");
            Destroy(this);
         }
    }
}
