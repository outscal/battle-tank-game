using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    private TankScriptableObject tankScriptableObject;

    private int playerId;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

        playerId = Random.Range(1, 100000);
    }
    public TankModel(TankType tankType, int speed, float health)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
    }
    public TankType TankType { get; }
    public int Speed { get; }
    public float Health { get; set; }

    public int PlayerId { get; }
    public int SpeedLive { get { return (int)tankScriptableObject.Speed; } }



}
