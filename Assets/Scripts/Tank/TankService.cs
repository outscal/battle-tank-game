using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    void Start()
    {
        TankModel tankModel = new TankModel(10f, 180f);
        TankController tankController = new TankController(tankModel, tankView);
    }

}
