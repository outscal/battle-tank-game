using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankview;
    void Start()
    {
        CreateTank();
    }

    private TankController CreateTank()
    {
        TankModel model = new TankModel(5, 100f);
        TankController tank = new TankController(model, tankview);
        return tank;
    }
}
