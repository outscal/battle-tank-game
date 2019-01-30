using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{

    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();

                if(instance == null)
                {
                    GameObject go = new GameObject();
                    instance.name = typeof(T).ToString();
                    instance = go.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(instance);
        }
        else if(instance != null)
        {
            Destroy(instance);
        }

    }

}
