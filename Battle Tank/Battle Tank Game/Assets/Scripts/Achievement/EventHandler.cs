using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoGenericSingleton<EventHandler>
{
    public event Action OnBulletFired;
    //public event Action OnEnemyDeath;

    public void InvokeOnBulletFired()
    {
        OnBulletFired?.Invoke();
    }

    // public void InvokeOnEnemyDeath()
    // {
    //     OnEnemyDeath?.Invoke();
    // }

}