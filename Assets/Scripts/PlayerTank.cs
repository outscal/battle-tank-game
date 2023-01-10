using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank<T>: MonoBehaviour where T : PlayerTank<T>
{

    private static T instance;
    public static T Instance {get{return instance;}}

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Some one trying to create dublicate PlayerTank singleton");
            Destroy(this);
        }
    }
}
