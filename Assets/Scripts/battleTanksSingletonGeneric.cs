using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleTanksSingletonGeneric<T> : MonoBehaviour where T: battleTanksSingletonGeneric<T>
{
   private static T instance;
   public static T Instance {get{return instance;}}

   protected virtual void Awake()
   {
       if(instance == null)
       {
           DontDestroyOnLoad(this);
           instance = (T)this;
       }
       else
       {
           Debug.LogError("Duplicate Singleton is being created");
           Destroy(gameObject);
       }
   }
}
public class PlayerTank : battleTanksSingletonGeneric<PlayerTank>
{
    protected override void Awake()
    {
        base.Awake();
        //custom awake
    }
}

public class EnemyTank : battleTanksSingletonGeneric<EnemyTank>
{}