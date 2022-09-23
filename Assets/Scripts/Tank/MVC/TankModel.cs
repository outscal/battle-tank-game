using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    public void SetTankDController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public float GetMoveSpeed()
    {
        return movSpeed;
    }

}
