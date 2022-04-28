using EnemyScriptables;
using GlobalServices;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace EnemyTankServices
{
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {
        [SerializeField] private EnemySOList enemyTankList;
        [SerializeField] private EnemyTankView enemyTankView;
        private List<EnemyTankController> enemyTanks = new List<EnemyTankController>();
        private EnemyTankController tankController;
        private EnemyType enemyTankType;
        [SerializeField] private int enemyCount;

        public List<EnemyTankController> EnemyTanks() => enemyTanks;

        private void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                enemyTankType = (EnemyType)Mathf.Floor(Random.Range(0, 3f));
                tankController = CreateEnemyTank(enemyTankType);
            }
            StartCoroutine(SpawnEnemyTanks());

        }

        private EnemyTankController CreateEnemyTank(EnemyType tanktype)
        {
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

        public void Destroy(EnemyTankController tank)
        {
            Destroy(tank.tankView.gameObject);
            //call the couroutine of the dustruction
            enemyTanks.Remove(tank);
            tank = null;
        }

        IEnumerator SpawnEnemyTanks()
        {
            while (enemyCount < 100)
            {
                enemyTankType = (EnemyType)Mathf.Floor(Random.Range(0, 3f));
                tankController = CreateEnemyTank(enemyTankType);
                yield return new WaitForSeconds(7f);
                enemyCount++;
            }
        }
    }
}
