using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
public class TankControllerScript
{

    public TankControllerScript(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //GameObject go = GameObject.Instantiate(tankPrefab);

        TankView = GameObject.Instantiate<TankView>(tankPrefab);

        TankView.Initialise(this);

        Debug.Log("tank view created", TankView);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public void ApplyDamage(BulletType bulletType, int damage)
    {
        if (TankModel.Health - damage <= 0)
        {
                //death event

        }
        else
        {
                TankModel.Health -= damage;
                Debug.Log("Player took damage: " + TankModel.Health);
        }
    }
    }
}