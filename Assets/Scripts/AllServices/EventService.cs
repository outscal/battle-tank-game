using System;
using UnityEngine;

namespace AllServices
{
    // Observer pattern implementation. Handles all event actions.
    public class EventService : GenericSingleton<EventService>
    {

        public event Action OnEnemyDeath;
        public event Action OnplayerFiredBullet;

        public event Action OnFireButtonPressed;
        public event Action OnFireButtonReleased;

        public void InvokeOnEnemyDeathEvent()
        {
            OnEnemyDeath?.Invoke();
        }

        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnplayerFiredBullet?.Invoke();
        }

        public void InvokeOnFireButtonPressedEvent()
        {
            OnFireButtonPressed?.Invoke();
        }

        public void InvokeOnFireButtonReleasedEvent()
        {
            OnFireButtonReleased?.Invoke();
        }
    }
}

