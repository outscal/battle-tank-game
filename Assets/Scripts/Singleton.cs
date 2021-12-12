using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("trying to create duplicate singleton");
            Destroy(this);
        }
    }
    public class PlayerTank : MonoSingletonGeneric<PlayerTank>
    {
        protected override void Awake()
        {
            base.Awake();
        }

    }
    public class EnemyTank : MonoSingletonGeneric<EnemyTank>
    {

    }
}