using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T :GenericSingleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

// public class PlayerTank : GenericSingleton<PlayerTank>
// {
 
// }

// public class EnemyTank : GenericSingleton<EnemyTank>
// {
  
// }

// public class Player_Tank : MonoBehaviour
// {
  
// }

// public class Enemy_Tank : MonoBehaviour
// {

// }