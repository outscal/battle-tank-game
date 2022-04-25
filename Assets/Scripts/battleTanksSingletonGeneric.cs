using UnityEngine;

public class battleTanksSingletonGeneric<T> : MonoBehaviour where T: battleTanksSingletonGeneric<T>
{
   private static T instance;
   public static T Instance {get{return instance;}}

   protected virtual void Awake()
   {
       if(instance == null)
       {
           DontDestroyOnLoad (gameObject);
           instance = (T)this;
       }
       else
       {
           Debug.LogError("Duplicate Singleton is being created");
           Destroy(this);
       }
   }
}
