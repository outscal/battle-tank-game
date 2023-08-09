using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController<T> : MonoBehaviour where T:GameController<T>
{
     
   private static T instance;

    public static T  Instance
    {
        get { return instance; }
       
    }

    public void Awake()
    {

        if (Instance == null)
        {
            instance = (T) this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
