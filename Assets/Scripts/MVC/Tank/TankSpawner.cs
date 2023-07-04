using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    [SerializeField] private float moveSpeed = 30;

    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(moveSpeed);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
