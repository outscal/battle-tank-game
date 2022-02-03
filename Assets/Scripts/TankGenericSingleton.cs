using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TankGenericSingleton<T> : MonoBehaviour where T : TankGenericSingleton<T>
{
    private static T instance = null;

    //Calling this Generic Instance through a Method as instance object is in Private
    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            //This is the first instnace which takes by the Last GameObject on duplicates
            Debug.Log("This is the First Instance and which takes the last GameObject in Duplicates");
            instance = (T)this;
            DontDestroyOnLoad(this);
        }

        else
        {
            //Duplicate GameObjects will be destroyed
            Debug.Log("I am the Duplicate GameObject" + this.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
