using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController<T> : MonoBehaviour where T : TankController<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
public class PlayerTank : TankController<PlayerTank>
{
    protected override void Awake()
    {
        base.Awake();
    }
}