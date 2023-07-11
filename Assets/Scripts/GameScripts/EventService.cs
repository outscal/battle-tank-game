using System;

namespace BattleTank.Events
{
    public class EventService
    {
        private static EventService instance = null;
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventService();

                return instance;
            }
        }

        public event Action OnEnemyDestroy;
        public event Action OnPlayerFiredBullet;
        public event Action<float> OnDistanceTravelled;

        public void InvokeEnemyDestroy()
        {
            OnEnemyDestroy?.Invoke();
        }

        public void InvokePlayerFiredBullet()
        {
            OnPlayerFiredBullet?.Invoke();
        }

        public void InvokeDistanceTravelled(float distance)
        {
            OnDistanceTravelled?.Invoke(distance);
        }
    }
}
