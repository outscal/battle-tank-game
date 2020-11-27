using System;
using UnityEngine;
using Singleton;

namespace GameEvents
{
    public class GameEventsManager : MonoSingletonGeneric<GameEventsManager>
    {
        public static event Action enemyKilled;
        public static event Action bulletShot;
        
        public void InvokeEnemyKilledEvent()
        {
            enemyKilled?.Invoke();
        }
        public void InvokeBulletShotEvent()
        {
            bulletShot?.Invoke();
        }
    }
}
