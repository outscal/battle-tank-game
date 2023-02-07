
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float moveSpeed;
    public float TurnSpeed;
    public float Health;
    public TankType tankType;
    public int Damage;
    public Material color;
    public TankModel(TankObject tankObject)
    {
        color = tankObject.color;
        moveSpeed = tankObject.moveSpeed;
        TurnSpeed = tankObject.TurnSpeed;
        tankType = tankObject.tankType;
        Health = tankObject.Health;
        Damage = tankObject.Damage;
    }

    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
}
