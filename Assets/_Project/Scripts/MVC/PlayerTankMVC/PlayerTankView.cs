using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTankView : TankView
{
    protected override void ControlTank()
    {
        tankController.PlayerTankMovement();
        tankController.PlayerTankRotation();
    }
}
