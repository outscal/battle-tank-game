using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric <TankService>
{
    public GameObject TankPrefab;
    public FixedJoystick joystick;
    

    private void Start()
    {
        GetTank();
    }

    private TankController GetTank()
    {
        Instantiate(TankPrefab, Vector3.zero,Quaternion.identity);
        TankController tankController = TankPrefab.GetComponent<TankController>();
        tankController.joystick = joystick;
        return tankController;
    }
}