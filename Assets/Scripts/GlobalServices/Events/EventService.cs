using System;
using UnityEngine;

namespace GlobalServices
{
    // Observer pattern implementation. Handles all event actions.
    public class EventService : MonoSingletonGeneric<EventService>
    {
        public event Action OnGameStarted;
        public event Action OnGameOver;
        public event Action OnGameResumed;
        public event Action OnGamePaused;

        public event Action OnEnemyDeath;
        public event Action OnplayerFiredBullet;
        public event Action OnWaveSurvived;

        public event Action OnFireButtonPressed;
        public event Action OnFireButtonReleased;

        public void InvokeOnGameStartedEvent()
        {
            OnGameStarted?.Invoke();
        }

        public void InvokeOnGameOverEvent()
        {
            OnGameOver?.Invoke();
        }

        public void InvokeOnGamePausedEvent()
        {
            OnGamePaused?.Invoke();
        }

        public void InvokeOnGameResumedEvent()
        {
            OnGameResumed?.Invoke();
        }

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

