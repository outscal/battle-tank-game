using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implemented MonoSingletonGeneric class for player tank and enemy tank.
/// </summary>
namespace Outscal.BattleTank3DProject
{
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
                Debug.LogError("Some one trying to create a duplicate singleton");
                Destroy(this);
            }
        }
    }
}