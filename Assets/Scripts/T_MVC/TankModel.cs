using System.Collections;
using System.Collections.Generic;
using PlayerTankService;
using UnityEngine;

public class TankModel
{
    private TankController tankcontroller;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = (int) tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        TurnSpeed = (int)tankScriptableObject.TurnSpeed;
        tankColor = tankScriptableObject.TankColor; 
    }
    public void SetTankController(TankController controller)
    {
        tankcontroller = controller;
    }
    public TankModel(TankType tanktype, int speed, float health, int TurnSpeed)
    {
        Speed = speed;
        Health = health;
        TankType = tanktype;
        this.TurnSpeed = TurnSpeed;
    }
    public int Speed { get;}
    public int TurnSpeed { get; }
    public Color tankColor { get; private set; }
    public float Health { get; }
    public TankType TankType { get; }
}
