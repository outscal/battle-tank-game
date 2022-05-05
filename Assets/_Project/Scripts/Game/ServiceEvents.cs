using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceEvents : SingletonGenerics<ServiceEvents>
{
    public event Action OnPlayerDeath;

    public event Action OnGameLoaded;
    public event Action OnGameStarted;
    public event Action OnGamePaused;
    public event Action OnGameEnded;
    public event Action OnGameFailed;

    public event Action<int> OnPurchaseSuccess;
    public event Action<int> OnPurchaseFailed;
    public event Action<int> OnPurchaseCancelled;

}
