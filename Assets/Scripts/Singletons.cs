using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons instance;
    [HideInInspector]
    public int lifeCount;
    void Awake()
    {
        MakeSingleton();
    }
    void Start()
    {
    }
    void MakeSingleton()
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
    public void DoSomething()
    {
        print("from singleton script functn");
    }
}// class