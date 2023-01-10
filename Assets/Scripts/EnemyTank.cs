using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank<T> : MonoBehaviour where T : EnemyTank<T>
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
            Debug.LogError("Some one trying to create dublicate EnemyTank singleton");
            Destroy(this);
        }
    }
}
