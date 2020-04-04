using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;

    protected override void Awake()
    {
        base.Awake();
    }


    private void Start()
    {
        TankModel model = new TankModel(5, 100f);
        TankController tank = new TankController(model, tankView);
    }

}
