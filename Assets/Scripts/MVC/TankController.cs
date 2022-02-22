using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankController : MonoBehaviour
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    public Rigidbody rb;

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        // TankView tankView = GameObject.Instantiate<TankView>(tankPrefab);
        rb = tankView.gameObject.GetComponent<Rigidbody>();
        tankView.setTankController(this);


    }

    public TankModel TankModel { get; }
}