using System;
using Tank;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController _tankController;

    public void SetTankController(TankController tankController) => _tankController = tankController;

    private void Update()
    {
        _tankController.HandleAttacks();
    }

    private void FixedUpdate()
    {
        _tankController.Move();
    }
    
}
