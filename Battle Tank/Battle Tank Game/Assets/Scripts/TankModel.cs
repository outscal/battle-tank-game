using UnityEngine;

public class TankModel
{
   private TankController tankController;

   //constructor for tankmodel to communicate with the tankcontroller
   public TankModel()
   {

   }

    //function for setting the tankcontroller reference when we call this function
   public void SetTankController(TankController _tankController)
   {
       tankController = _tankController;
   }
}
