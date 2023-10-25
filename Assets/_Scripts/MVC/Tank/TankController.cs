using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank
{
    public class TankController
    {
        //public TankController (TankModel tankModel, TankView tankPrefab)
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            TankView.Initialise(this);
            //GameObject go = GameObject.Instantiate(tankPrefab);
            //TankView = go.GetComponent<TankView>();
            Debug.Log("Tank View Created", TankView);

          
        }

        public void ApplyDamage(BulletType bulletType, int damage)
        {
            if (TankModel.Health - damage <= 0)
            {
                //death event
            }
            else
            {
                TankModel.Health -= damage;
                Debug.Log("Player took Damage :" + TankModel.Health);
            }
        }

        public void Disable()
        {
            TankView.Disabled();
        }
        public void Enable()
        {
            TankView.Enabled();
        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }
    }
}