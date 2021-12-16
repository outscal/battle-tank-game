using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Summary//
    //Script responsible for communication between all the data for tank gameObject
    //-Summary//
public class TankService : GenericSingleton<TankService>
{
    public TankView tankview;
    public TankStats[] stats;
    public void Start() 
    {
        CreateTank();
    }

    //Creating the tank with the required stats
    private TankController CreateTank()
    {
        TankStats Stats = stats[2]; 
        TankModel model = new TankModel(Stats);
        TankController tank = new TankController(model, tankview);
        return tank;
   }
}
