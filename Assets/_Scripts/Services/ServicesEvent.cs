using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace BattleTank
{
    public class ServicesEvent : Singleton<ServicesEvents>
    {
        public event Action OnPlayerDeath;

        public event Action OnGameStarted;
        public event Action OnGameLoaded;

        public event Action<int> OnPurchaseSuccessful;
        public event Action<int> OnPurchasedFailed;

    }
}