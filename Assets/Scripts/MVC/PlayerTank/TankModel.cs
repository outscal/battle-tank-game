using UnityEngine;
using UnityEngine.UI;

public class TankModel 
{
    private TankController tankController;
    

    public float movementSpeed;
    public float rotateSpeed;
    public TankTypeEnum tankType;
    public string tankName;
    internal float currentHealth;
    public float health;
    



    public TankModel(TankScriptableObject tankScriptableObject)
    {
       tankType = tankScriptableObject.TankType;
       movementSpeed = tankScriptableObject.speed;
       rotateSpeed = tankScriptableObject.rspeed;
       tankName = tankScriptableObject.TankName;
       health = tankScriptableObject.StartingHealth;
             
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }
}
