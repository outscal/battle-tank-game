using System.Collections;
using System.Collections.Generic;
using GameServices;
using UnityEngine;
using AllServices;

namespace EnemyTankServices
{
    public class EnemyTankController
    {
        public EnemyTankModel enemyTankModel { get; }
        public EnemyTankView enemyTankView { get; }

        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView enemyTankPrefab)
        {
            enemyTankModel = tankModel;

            // Spawns enemy tank at random position.
            Transform tranform = TankSpawnPointService.Instance.GetRandomSpawnPoint();
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankPrefab, tranform.position, tranform.rotation);
            enemyTankView.enemyTankController = this;
        }

        public void EnableTankView()
        {
            enemyTankView.gameObject.SetActive(true);
            enemyTankModel.b_IsDead = false;
        }

        public void DisableTankView()
        {
            enemyTankView.gameObject.SetActive(false);
            enemyTankModel.b_IsDead = true;
        }

        // To do all physics calculations.
        public void RangeCheck()
        {
            // Checks whether the player is in sight range or attack range.
            enemyTankModel.b_PlayerInSightRange = Physics.CheckSphere(enemyTankView.transform.position, enemyTankModel.patrollingRange, enemyTankView.playerLayerMask);
            enemyTankModel.b_PlayerInAttackRange = Physics.CheckSphere(enemyTankView.transform.position, enemyTankModel.attackRange, enemyTankView.playerLayerMask);
        }

        public void TakeDamage(int damage)
        {
            enemyTankModel.health -= damage;

            if (enemyTankModel.health <= 0 && !enemyTankModel.b_IsDead)
            {
                Death();
            }
        }

        public void Death()
        {
            enemyTankModel.b_IsDead = true;

            enemyTankView.Death();

            EnemyTankService.Instance.DestroyEnemy(this);
            EventService.Instance.InvokeOnEnemyDeathEvent();
        }
    }
}
