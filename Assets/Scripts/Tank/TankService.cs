using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    void Start()
    {
        TankModel tankModel = new TankModel(movementSpeed, rotationSpeed);
        TankController tankController = new TankController(tankModel, tankView);
    }

}
