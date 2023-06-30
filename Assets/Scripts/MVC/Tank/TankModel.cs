
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    public float moveSpeed;
   

    public TankModel(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
       
    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
