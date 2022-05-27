using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObjects")  ]
public class TankScriptableObject : ScriptableObject
{
   public TankType tankType;

   public Vector3 scale;
   public string tankName;
   public float tankSpeed;
   public float tankTurnSpeed;
   public float tankHealth;
   public float tankDamage;
   public Color tankColor;
   public int bulletFired;
}
