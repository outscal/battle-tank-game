using UnityEngine;

public class TankModel
{
    private TankController tankController;

    [SerializeField] public float movementSpeed;
    [SerializeField] public float rotationSpeed;

   //constructor for tankmodel to communicate with the tankcontroller
   public TankModel(float _movement, float _rotation)
   {
       movementSpeed = _movement;
       rotationSpeed = _rotation;
   }

    //function for setting the tankcontroller reference when we call this function
   public void SetTankController(TankController _tankController)
   {
       tankController = _tankController;
   }
}
