using System.Collections;
using System.Collections.Generic;
using EnemyScriptableObjects;
using UnityEngine;

namespace EnemyTankServices
{
    // Handles spawning of enemy tank and communication of enemy tank service with other services.
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        private EnemyType enemyType;
        public EnemyTankView enemyTankPrefab;
        public EnemyTankScriptableObjectList enemyTankSOList;

        // Stores controllers of all active enemy tanks in the scene.
        [HideInInspector] public List<EnemyTankController> enemyTanks = new List<EnemyTankController>();

        private void Start()
        {
            enemyType= (EnemyType)Random.Range(0, enemyTankSOList.enemyTankScriptableObject.Length);
            EnemyTankController tankController = CreateEnemyTank(enemyType);
        }

        // Spawns specified type of enemy tank and returns tank controller. 
        public EnemyTankController CreateEnemyTank(EnemyType enemyType)
        {
            // To search for sciptable object which holds data of specified enemy tank.
            foreach (EnemyTankScriptableObject enemyTankSO in enemyTankSOList.enemyTankScriptableObject)
            {
                if (enemyTankSO.enemyType == enemyType)
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
