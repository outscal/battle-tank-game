using System;
using UnityEngine;

public class EventManager : MonoGenericSingleton<EventManager>
{
    public event Action OnEnemyDeath;
    public event Action OnBulletShoot;

    public void InvokeOnEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }

    public void InvokeOnBulletShoot()
    {
        OnBulletShoot?.Invoke();
    }


}

