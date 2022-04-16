using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSingletonGenerics<T> : MonoBehaviour where T : TankSingletonGenerics<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Duplication of Singleton class " + instance +" is not Allowed");
            Destroy(this);
        }
    }
}

public class PlayerTank : TankSingletonGenerics<PlayerTank>
{
     protected override void Awake()
    {
        base.Awake();
        //playerTank awake functions
    }

    internal void StartGame()
    {
        Debug.Log("Player Start Game Function");
    }
}

public class EnemyTank : TankSingletonGenerics<EnemyTank>
{
    private void Start()
    {
        PlayerTank.Instance.StartGame();
    }
}
