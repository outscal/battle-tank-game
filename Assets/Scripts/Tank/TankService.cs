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

    public void fire() 
    {
        BulletService.Instance.spawnBullet();
    }

    private void Start()
    {
        TankModel model = new TankModel(250,100, 100f, Color.blue);
        TankController tank = new TankController(model, tankView);
    }

}
