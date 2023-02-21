using System;
namespace Tank.EventService
{
    public class EventManagement : Singleton<EventManagement>
    {
        public event Action<int> OnEnemyDeath;
        public event Action OnPlayerDeath;
        public event Action<int> OnPlayerShoot;
        public void PlayerShoot(int count)
        {
            OnPlayerShoot?.Invoke(count);
        }
        public void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
        public void EnemyDeath(int count)
        {
            OnEnemyDeath?.Invoke(count);
        }
    }
}