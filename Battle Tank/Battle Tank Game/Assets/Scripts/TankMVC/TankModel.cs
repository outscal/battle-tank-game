using UnityEngine;

public class TankModel
{
    private TankController tankController;
    
    public float movementInput;
    public float turnInput;
    public float movementSpeed;
    public float rotationSpeed;

    public float tankHealth;


   //constructor for tankmodel to communicate with the tankcontroller
   public TankModel(TankType _tankType, float _movement, float _rotation)
   {
       movementSpeed = _movement;
       rotationSpeed = _rotation;
   }

   public TankModel(TankScriptableObject _tankScriptableObject)
   {
       movementSpeed = _tankScriptableObject.tankSpeed;
       rotationSpeed = _tankScriptableObject.tankTurnSpeed;
       tankHealth = _tankScriptableObject.tankHealth;       
   }  
}
