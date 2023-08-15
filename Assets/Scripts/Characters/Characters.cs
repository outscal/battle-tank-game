using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters<T> : MonoBehaviour where T :Characters<T>
{
    private static T instance;
    public static T Instacnce { get {  return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            Debug.Log("Character init");
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Duplicate Character instance detected");
            Destroy(gameObject);
        }
    }

}



