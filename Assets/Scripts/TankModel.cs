using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankScriptableObject tankScriptableObject;
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
    }

    public TankType Tanktype { get; }
    public TankType TankType { get; private set; }
    public int Speed { get; }
    public float Health { get; }

    public int SpeedLive { get { return (int)tankScriptableObject.Speed; } }
}
