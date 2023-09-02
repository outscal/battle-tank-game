using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Characters<PlayerTank>
{
    public void PlayerTankinit()
    {
        print("Player Initiated");
    }
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Player Awake Override");
    }
}
