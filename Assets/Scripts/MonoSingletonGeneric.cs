using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonGeneric : MonoBehaviour
{
    public static MonoSingletonGeneric instance;

    private void Awake()
    {
        CreateSingleton();
    }


    private void CreateSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {

    }
}
