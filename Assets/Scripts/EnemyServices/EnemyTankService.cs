using EnemySO;
using GameplayServices;
using GlobalServices;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyTankServices
{
    // Handles spawning of enemy tank and communication of enemy tank service with other services.
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {
        public EnemySOList enemyTankList; // Enemy tank scriptable objects list.
        public EnemyTankView enemyTankView;

        // Stores controllers of all active enemy tanks in the scene.
        [HideInInspector] public List<EnemyTankController> enemyTanks = new List<EnemyTankController>();
        
        private EnemyType enemyTankType;

        // Spawns specified type of enemy tank and returns tank controller. 
        public EnemyTankController CreateEnemyTank(EnemyType tanktype)
        {
            // To search for sciptable object which holds data of specified enemy tank.
            foreach (EnemyScriptableObject tank in enemyTankList.enemies)
            {
                if (tank.enemyType == enemyTankType)
                {
                    EnemyTankModel tankModel = new EnemyTankModel(enemyTankList.enemies[(int)tanktype]);
                    EnemyTankController tankController = new EnemyTankController(tankModel, enemyTankView);
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

            // If no enemy tank is present in the scene we start next wave.
            if (enemyTanks.Count == 0)
            {
                WaveManager.Instance.SpawnWave();
            }
        }

        // Disables all the enemy tanks from tank controller list when the game is paused.
        public void TurnOFFEnemies()
        {
            for (int i = 0; i < enemyTanks.Count; i++)
            {
                if (enemyTanks[i] != null)
                {
                    if (enemyTanks[i].tankView) enemyTanks[i].tankView.gameObject.SetActive(false);
                }
            }
        }

        // Enables all the enemy tanks from tank controller list when the game is resumed.
        public void TurnONEnemies()
        {
            for (int i = 0; i < enemyTanks.Count; i++)
            {
                if (enemyTanks[i] != null)
                {
                    if(enemyTanks[i].tankView && !enemyTanks[i].tankModel.b_IsDead) enemyTanks[i].tankView.gameObject.SetActive(true);
                }
            }
        }
    }
}
