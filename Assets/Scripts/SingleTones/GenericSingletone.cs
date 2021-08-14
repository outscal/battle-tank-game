using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    ///Generic singletone class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //public class GenericMonoSingletone<T> : MonoBehaviour where T : GenericMonoSingletone<T>
    //{
    //    private static T instance;

    //    public static T Instance { get { return instance; } }

    //    protected virtual void Awake()
    //    {
    //        if (instance == null)
    //        {
    //            instance = (T)this;
    //            DontDestroyOnLoad(this.gameObject);
    //        }
    //        else
    //        {
    //            Destroy(this.gameObject);
    //        }
    //    }
    //}

    ///// <summary>
    ///// player class taht inherited from base singletone class 
    ///// </summary>
    //public class PlayerTank : GenericMonoSingletone<PlayerTank>
    //{
    //    protected override void Awake()
    //    {
    //        base.Awake();
    //        //game logic
    //    }
    //}
    ///// <summary>
    ///// enemy class that is inherited from base generic singletone
    ///// </summary>
    //public class EnemyTank : GenericMonoSingletone<EnemyTank>
    //{
    //    protected override void Awake()
    //    {
    //        base.Awake();
    //        //game logic
    //    }
    //}
    //public class GenericSingleton<T> where T : GenericSingleton<T> {

    //    private static T instance;

    //    public static T Instance { get { return instance; } }

    //    protected virtual void Awake()
    //    {
    //        if (instance == null)
    //        {
    //            instance = (T) this;
    //        }
    //        else
    //        {
    //            instance = null;
    //        }
    //    }

    //}

    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;

        static object m_lock = new Object();

        public static T GetInstance()
        {
            lock (m_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        GameObject obj = new GameObject();

                        obj.name = typeof(T).ToString();

                        instance = obj.AddComponent<T>();

                        DontDestroyOnLoad(obj);
                    }
                }
            }

            return instance;
        }
    }
}
