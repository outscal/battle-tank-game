using System;
namespace Tank.EventService
{
    public class EventManagement : Singleton<EventManagement>
    {
        public static event Action OnEnemyDeath;
        public static event Action OnPlayerDeath;
        public static event Action OnPlayerShoot;
        public static event Action<int> OnWaveComplete;
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