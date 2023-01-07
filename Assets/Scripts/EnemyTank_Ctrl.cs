using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank_Ctrl <T>: MonoBehaviour where T: EnemyTank_Ctrl<T>
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
            Destroy(gameObject);
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
