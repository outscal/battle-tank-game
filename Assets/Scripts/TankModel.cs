using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankScriptableObject tankScriptableObject;
    public int playerId;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        this.tankScriptableObject = tankScriptableObject;

        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

    }
    public TankModel(TankType tanktype, int speed, float health)
    {
        Tanktype = tanktype;
        Speed = speed;
        Health = health;

        playerId = Random.Range(1, 1000);
    }

    public TankType Tanktype { get; }
    public TankType TankType { get; private set; }
    public int Speed { get; }
    public float Health { get; set; }
    public int PlayerId { get; }
    public int SpeedLive { get { return (int)tankScriptableObject.Speed; } }
}
