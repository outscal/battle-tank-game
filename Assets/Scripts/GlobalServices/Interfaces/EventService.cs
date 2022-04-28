using System;

namespace GlobalServices
{
    public class EventService : MonoSingletonGeneric<EventService>
    {
        public event Action OnEnemyDeath;
        public event Action OnplayerFiredBullet;
        public event Action OnWaveSurvived;

        public void InvokeOnEnemyDeathEvent()
        {
            OnEnemyDeath?.Invoke();
        }

        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnplayerFiredBullet?.Invoke();
        }

        public void InvokeOnWaveSurvivedEvent()
        {
            OnWaveSurvived?.Invoke();
        }
    }
}

