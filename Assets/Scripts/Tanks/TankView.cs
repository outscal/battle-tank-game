using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement, rotation;
    private void Start()
    {
        Move();
    }

    private void Move()
    {
        movement = Input.GetAxis("Horizontal1");
        rotation = Input.GetAxis("Vertical1");
    }

    private void FixedUpdate()
    {
        tankController.Move(movement, tankController.TankModel.MovSpeed);
        tankController.Rotate(rotation, tankController.TankModel.RotSpeed);
    }

    public void SetTankController(TankController tankControl)
    {
        tankController = tankControl;
    }
}
