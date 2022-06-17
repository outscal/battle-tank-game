using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoGenericSingleton<TankService>
{
    public TankView _tankView;
    public Joystick _joystick;

    private void Start()
    {
        CreateNewTank();
    }

    private void CreateNewTank()
    {
        //creating a tank model
        TankModel tankModel = new TankModel(10, 220, 100);

        //spawning the tank using the created tank model
        TankController tankController = new TankController(tankModel, _tankView, _joystick);
    }
}