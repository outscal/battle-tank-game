using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleTanksSingletonGeneric<T> : MonoBehaviour where T: battleTanksSingletonGeneric<T>
{
   private static T instance;
   public static T Instance {get{return instance;}}

   private void Awake()
   {
       if(instance == null)
       {
           instance = (T)this;
       }
       else
       {
           Debug.LogError("Duplicate Singleton is being created");
           Destroy(this);
       }
   }
}
public class PlayerTank : battleTanksSingletonGeneric<PlayerTank>
{

}

public class EnemyTank : battleTanksSingletonGeneric<EnemyTank>
{
    
}