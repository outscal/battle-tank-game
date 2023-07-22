using System;
using UnityEngine;

namespace BattleTank
{
    public class ServiceEvents
    {
        private static ServiceEvents Instance;
        public static ServiceEvents instance {
            get
            {
                if(Instance == null)
                {
                    Instance = new ServiceEvents();
                }
                return Instance;
            }
         }
        public Action<int> OnEnemyDeath;
        public Action<int> OnBulletFire;
    }
}
