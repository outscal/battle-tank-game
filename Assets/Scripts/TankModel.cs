
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float moveSpeed;
    public float TurnSpeed;
    public TankModel(float movespeed, float turnspeed)
    {
        moveSpeed = movespeed;
        TurnSpeed = turnspeed;
    }
    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
}
