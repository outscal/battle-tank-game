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
            EnemyTankView enemyView = enemyTankScriptableObject.EnemyTankView;
            Vector3 pos = enemyNewPos.position;
            EnemyTankModel enemyModel = new EnemyTankModel(enemyTankScriptableObject);
            EnemyTankController enemy = new EnemyTankController(enemyModel, enemyView, pos);
            return enemy;
        }

        void SpawningEnemy()
        {
            int num = Random.Range(0, enemyPos.Count-1);
            CreateNewTank(enemyPos[num]);
            enemyPos.RemoveAt(num);
        }

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
    }
}