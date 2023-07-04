using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    [SerializeField] private float tankSpeed = 15;

    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tankSpeed);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
