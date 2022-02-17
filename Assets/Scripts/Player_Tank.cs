using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank : Singleton_Generic<Player_Tank>
{
    protected override void Awake()
    {
        Debug.Log("Player_Tank Awake");
        base.Awake();
    }
}