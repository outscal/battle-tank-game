using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    ///Generic singletone class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSingleTone<T> : MonoBehaviour where T : GenericSingleTone<T>
    {
        private static T instance;

        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// player class taht inherited from base singletone class 
    /// </summary>
    public class PlayerTank : GenericSingleTone<PlayerTank>
    {
        protected override void Awake()
        {
            base.Awake();
            //game logic
        }
    }
    /// <summary>
    /// enemy class that is inherited from base generic singletone
    /// </summary>
    public class EnemyTank : GenericSingleTone<EnemyTank>
    {
        protected override void Awake()
        {
            base.Awake();
            //game logic
        }
    }
}