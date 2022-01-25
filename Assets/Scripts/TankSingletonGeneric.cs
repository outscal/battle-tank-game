using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSingletonGeneric<T> : MonoBehaviour
{
    public static TankSingletonGeneric<T> instance;

    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
