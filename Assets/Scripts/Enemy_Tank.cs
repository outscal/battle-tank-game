using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tank : Singleton_Generic<Enemy_Tank>
{
    protected override void Awake()
    {
        Debug.Log("Enemy_Tank Awake");
        base.Awake();
    }
}
