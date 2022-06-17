using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoGenericSingleton<TankService>
{
    public TankView _tankView;
    public Joystick _joystick;
    public TankSO[] _tankScriptableObjects;

    private void Start()
    {
        CreateNewTank();
    }

    private void CreateNewTank()
    {
        //creating a tank model
        TankSO tankScriptableObject = _tankScriptableObjects[Random.Range(0, _tankScriptableObjects.Length)];
        TankModel tankModel = new TankModel(tankScriptableObject);

        //spawning the tank using the created tank model
        TankController tankController = new TankController(tankModel, _tankView, _joystick);
    }
}