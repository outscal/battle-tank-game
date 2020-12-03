using System;
using UnityEngine;
using Singleton;

namespace GameEvents
{
    public class GameEventsManager : MonoSingletonGeneric<GameEventsManager>
    {
        public event Action enemyKilled;
        public event Action bulletShot;
        
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
