using System;
public class EventManagement : Singleton<EventManagement>
{
    public event Action OnEnemyDeath;
    public event Action OnPlayerDeath;
    public void InvokeOnEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }
    public void InvokeOnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
}
