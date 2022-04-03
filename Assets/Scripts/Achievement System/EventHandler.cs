using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GlobalServices;

public class EventHandler : MonoSingletonGeneric<EventHandler>
{
    public event Action OnBulletFired;

    public void InvokeOnBulletFired()
    {
        OnBulletFired?.Invoke();
    }


}
