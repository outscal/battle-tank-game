using UnityEngine;

public class TankModel
{
    private TankController tankController;
    
    public float movementInput;
    public float turnInput;
    public float movementSpeed;
    public float rotationSpeed;
    public string tankName;

    public float tankHealth;
    public float tankDamage;
    public Color tankColor;
    public int bulletFired;

   public TankModel(TankScriptableObject _tankScriptableObject)
   {
       tankName = _tankScriptableObject.tankName;
       movementSpeed = _tankScriptableObject.tankSpeed;
       rotationSpeed = _tankScriptableObject.tankTurnSpeed;
       tankHealth = _tankScriptableObject.tankHealth;       
       tankDamage = _tankScriptableObject.tankDamage;
       tankColor = _tankScriptableObject.tankColor;
       bulletFired = _tankScriptableObject.bulletFired;
   }  
}
