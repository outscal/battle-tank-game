using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //Summary//
    //Script responsible for communication between all the data for tank gameObject
    //-Summary//
public class TankService : GenericSingleton<TankService>
{
    TankController tank;
    public TankView tankview;
    public TankStats[] stats;
    public float currentHealth = 0;


    public void Awake() 
    {
        CreateTank();
    }

    //Creating the tank with the required stats
    private TankController CreateTank()
    {
        TankStats Stats = stats[2]; 
        TankModel model = new TankModel(Stats);
        currentHealth = model.Health;
        tank = new TankController(model, tankview);
        return tank;
    }

    public TankController getController()
    {
        return tank;
    }
}
