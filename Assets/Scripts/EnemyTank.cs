using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank<T> : MonoBehaviour where T:EnemyTank<T>
{
    private static T instance;
    public static T Instance{
        get {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance=(T)this;
        }else
        {
           Debug.LogError("duplicate singleton created");
           Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
