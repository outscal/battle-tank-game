using UnityEngine;

public class TankModel
{
   private TankController tankController;

   //function for setting the tankcontroller reference when we call this function
   public void SetTankController(TankController _tankController)
   {
       tankController = _tankController;
   }
}
