using System.Collections;
using System.Collections.Generic;
using EnemyScriptableObjects;
using UnityEngine;

namespace EnemyTankServices
{
    // Handles spawning of enemy tank and communication of enemy tank service with other services.
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        private EnemyType enemyTankType;
        public EnemyTankView enemyTankPrefab;
        public EnemyTankScriptableObjectList enemyTankSOList;

        [HideInInspector] public List<EnemyTankController> enemyTanks = new List<EnemyTankController>();

        private void Start()
        {
            // Spawns random type of enemy tank.
            enemyTankType = (EnemyType)Random.Range(0, enemyTankSOList.enemyTankScriptableObject.Length);
            EnemyTankController tankController = CreateEnemyTank(enemyTankType);
        }

        public EnemyTankController CreateEnemyTank(EnemyType enemyType)
        {
            foreach (EnemyTankScriptableObject enemyTankSO in enemyTankSOList.enemyTankScriptableObject)
            {
                if (enemyTankSO.enemyType == enemyTankType)
                {
                    EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankSOList.enemyTankScriptableObject[(int)enemyType]);
                    EnemyTankController tankController = new EnemyTankController(enemyTankModel, enemyTankPrefab);
                    enemyTanks.Add(tankController);
                    return tankController;
                }
            }
            return null;
        }

        // Removes specified tank controller from the tank controller list. 
        public void DestroyEnemy(EnemyTankController enemy)
        {
            for (int i = 0; i < enemyTanks.Count; i++)
            {
                if (enemy == enemyTanks[i])
                {
                    enemyTanks[i] = null;
                    enemyTanks.Remove(enemyTanks[i]);
                }
            }
        }
    }
}
