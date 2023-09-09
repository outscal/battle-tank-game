using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons<T> : MonoBehaviour where T : Singletons<T>
{
    private static T instance;
    public static T Instance {  get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Some one trying to create a duplicate singleton!");
            Destroy(this);
        }
    }
}

public class PlayerTank : Singletons<PlayerTank>
{   
    protected override void Awake()
    {
        base.Awake();
        //Custom Logic For Player Tank
    }
    public PlayerTank() { }
}

public class EnemyTank : Singletons<EnemyTank>
{
    protected override void Awake()
    {
        base.Awake();
        //custom Logic For Player Tank
    }
    public EnemyTank() { }
}
