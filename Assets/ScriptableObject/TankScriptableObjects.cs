﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "ScriptableObject/NewTank")]
public class TankScriptableObjects : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float movSpeed;
    public float rotSpeed;
    public float health;
}
