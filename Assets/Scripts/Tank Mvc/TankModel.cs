using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankController tankControllerRef;
    

    public TankModel()
    {

    }


    public void SetTankConroller(TankController _tankController)
    {
        tankControllerRef = _tankController;
    }
}
