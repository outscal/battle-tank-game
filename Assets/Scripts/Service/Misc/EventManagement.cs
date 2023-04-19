using System;
namespace Tank.EventService
{
    public class EventManagement : Singleton<EventManagement>
    {
        public event Action OnEnemyDeath;
        public event Action OnPlayerDeath;
        public event Action OnPlayerShoot;
        public event Action<int> OnWaveComplete;
        public void PlayerShoot()
        {
            OnPlayerShoot?.Invoke();
        }
        public void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
        public void EnemyDeath()
        {
            OnEnemyDeath?.Invoke();
        }
        public void WaveComplete(int wave)
        {
            OnWaveComplete?.Invoke(wave);
        }
    }
}