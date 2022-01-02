using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankSO;
public class EnemyTankModel
{
    public int Speed { get; }
    public float Health { get; set; }
    public TankType TankType { get; }


    public EnemyTankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

    }
}
