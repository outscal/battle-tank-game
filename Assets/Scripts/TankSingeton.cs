using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSingeton<T> : MonoBehaviour where T: TankSingeton<T>
{
    private static T instance ;
    public T Instance { get { return instance; } }

   protected void Awake()
    {
        if (instance == null)
        {
            instance =(T) this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
}
