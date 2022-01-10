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
        Health = tankScriptableObject.health;
        TurnSpeed = (int)tankScriptableObject.TurnSpeed;
        tankColor = tankScriptableObject.TankColor;
        MaxHealth = tankScriptableObject.health;
        FullHealthColor = Color.green;
        ZeroHealthColor = Color.red;
    }
    public int Speed { get;}
    public int TurnSpeed { get; }
    public Color tankColor { get; private set; }
    public float MaxHealth { get; private set; }
    public Color FullHealthColor { get; private set; }
    public Color ZeroHealthColor { get; private set; }
    public float Health { get; set; }
    public TankType TankType { get; }

    public void SetTankController(TankController controller)
    {
        tankcontroller = controller;
    }
    public void destroyModel()
    {
        tankcontroller = null;
        /*BulletType = null;*/
    }
}
