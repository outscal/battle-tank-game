using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// enemy tank service
    /// </summary>
    public class EnemyTankService : MonoGenericSingletone<EnemyTankService>
    {
        public EnemyTankScriptableObject enemyTankScriptableObject;
        public List<Transform> enemyPos;
        private EnemyTankController enemyTankController;
        public List<EnemyTankController> enemyTanksList = new List<EnemyTankController>();
        private int count = 0;
        private float spwanTime = 5f;

        private void Start()
        {
            count = 0;
            StartCoroutine(SpawnWaiting());
            count++;           
        }

        private EnemyTankController CreateNewTank(Transform enemyNewPos)
        {
            EnemyTankView enemyTankView = enemyTankScriptableObject.EnemyTankView;
            Vector3 pos = enemyNewPos.position;
            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
            enemyTankController = new EnemyTankController(enemyTankModel, enemyTankView, pos);
            enemyTanksList.Add(enemyTankController);
            return enemyTankController;
        }
        //enemy spawning randomly 
        void SpawningEnemy()
        {
            int num = Random.Range(0, enemyPos.Count-1);
            CreateNewTank(enemyPos[num]);
            enemyPos.RemoveAt(num);
        }
        //coroutine for spawn enemies  
        IEnumerator SpawnWaiting()
        {
            SpawningEnemy();
            yield return new WaitForSeconds(spwanTime);
            if (count >= 5)
            {
                StopCoroutine(SpawnWaiting());
            }
            else
            {
                StartCoroutine(SpawnWaiting());
            }
            count++;
        }
        //destroy enemy tank after death
        public void DestroyEnemyTank(EnemyTankController enemyTank)
        {
            enemyTank.DestroyEnemyController();
        }
        //returns enemytank controller
        public EnemyTankController GetEnemyTankController()
        {
            return enemyTankController;
        }
    }
}