using System.Collections;
using System.Collections.Generic;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Vector3 spawnerPos, Quaternion spawnerRotation,int enemyNumber, EnemyScriptableObject enemyScriptableObject)
        {
            EnemyModel = enemyModel;
            SpawnerPos = spawnerPos;
            SpawnerRotation = spawnerRotation;
            EnemyNumber = enemyNumber;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView, SpawnerPos, spawnerRotation);
            EnemyView.InitializeController(this);
            EnemyView.SetViewDetails();
        }

        public void ApplyDamage(float damage)
        {

            if (EnemyModel != null)
            {
                if ((EnemyModel.EnemyHealth - damage) <= 0)
                {
                    DestroyView();
                }
                else
                {
                    EnemyModel.EnemyHealth -= damage;
                    EnemyView.SetTankHealth(EnemyModel.EnemyHealth);
                }
            }
            return;
        }

        public void DestroyView()
        {
            EnemyService.Instance.DestroyTank(this);
        }

        public void Destroy()
        {
            if (EnemyView != null && EnemyModel != null)
            {
                EnemyView.Destroy();
                EnemyModel = null;
            }
        }

        public EnemyView EnemyView { get; }
        public EnemyModel EnemyModel { get; set; }
        public Vector3 SpawnerPos { get; }
        public Quaternion SpawnerRotation { get; }
        public int EnemyNumber { get; }
    }
}