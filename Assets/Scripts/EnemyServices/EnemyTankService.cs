using EnemyScriptables;
using GlobalServices;
using System.Collections.Generic;
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

        public List<EnemyTankController> EnemyTanks() => enemyTanks;

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                enemyTankType = (EnemyType)Mathf.Floor(Random.Range(0, 3f));
                tankController = CreateEnemyTank(enemyTankType);
            }

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
    }
}
