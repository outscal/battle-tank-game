using UnityEngine;

namespace TankBattle
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}