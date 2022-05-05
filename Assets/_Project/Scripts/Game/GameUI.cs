using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public event Action OnDeath;
    public event Action<int, int> onDeath;

    public int myID; //TankService thing
    private void Start()
    {
        OnDeath += GameUI_OnDeath;
        onDeath += GameUI_onDeath;

        OnDeath?.Invoke();
        onDeath?.Invoke(0, 100);
    }

    private void GameUI_onDeath(int deadTankID, int killedTankID)
    {
        if (killedTankID == myID)
        {

        }
        else if(deadTankID == myID)
        {

        }
    }

    private void GameUI_OnDeath()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        OnDeath -= GameUI_OnDeath;
        onDeath -= GameUI_onDeath;
    }
}
