using BattleTank.EnemyTank;
using BattleTank.GenericSingleton;
using BattleTank.Tank;
using BattleTank.TankSO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Services
{
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        [SerializeField] private EnemyTankView enemyTankView;
        private EnemyTankController enemyTankController;
        [SerializeField] private TankScriptableObjectList tankList;
        public List<EnemyTankController> enemyTankControllersList { get; private set; }
        [SerializeField] private List<ColorType> colors;
        [SerializeField] private float spawnRange;
        [SerializeField] private float safeDistance;
        [SerializeField] private int totalEnemyCount;
        [SerializeField] private int currentEnemyCount;

        private void Start()
        {
            enemyTankControllersList = new List<EnemyTankController>();
        }

        public void SpawnEnemyTanks()
        {
            for (int i = currentEnemyCount; i < totalEnemyCount; i++)
            {
                int TankNO = Random.Range(0, tankList.Tanks.Length);

                EnemyTankController enemyTankController = new EnemyTankController(new TankModel(tankList.Tanks[TankNO]), enemyTankView, GetSpawnPosition(), PlayerTankService.Instance.GetPlayerTank(), colors);
                enemyTankControllersList.Add(enemyTankController);
                currentEnemyCount++;
            }
        }

        public List<EnemyTankController> GetEnemyTankControllersList()
        {
            return enemyTankControllersList;
        }

        public void DecreaseEnemyCount()
        {
            currentEnemyCount--;
            if(currentEnemyCount < 0)
            {
                currentEnemyCount = 0;
            }
        }

        public Vector3 GetSpawnPosition()
        {
            bool pointFound = false;
            Vector3 finalPosition = Vector3.zero;
            NavMeshHit hit;

            while (pointFound != true)
            {
                Vector3 randomDirection = gameObject.transform.position + spawnRange * Random.insideUnitSphere;

                if (NavMesh.SamplePosition(randomDirection, out hit, 1, NavMesh.AllAreas))
                {
                    finalPosition = hit.position;
                    if (Vector3.Distance(PlayerTankService.Instance.GetPlayerTank().transform.position, finalPosition) > safeDistance)
                    {
                        pointFound = true;
                    }
                }
            }

            return finalPosition;
        }
    }
}