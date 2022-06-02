using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotateSpeed;
    public TankTypeEnum tankType;
    public string tankName;



    public TankModel(TankScriptableObject tankScriptableObject)
    {
       tankType = tankScriptableObject.TankType;
       movementSpeed = tankScriptableObject.speed;
       rotateSpeed = tankScriptableObject.rspeed;
       tankName = tankScriptableObject.TankName;
       
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }
}
