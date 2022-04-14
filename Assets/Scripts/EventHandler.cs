using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : SingletonGeneric<EventHandler>
{
    public event Action OnBulletFire;
    public event Action OnEnemyDeath;

    public void InvokeOnBulletFired()
    {
        OnBulletFire?.Invoke();
    }

    public void InvokeOnEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }

}