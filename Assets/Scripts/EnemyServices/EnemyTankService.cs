using EnemyScriptables;
using GlobalServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnemyTankServices
{
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {
        public EnemySOList enemyTankList;
        public EnemyTankView enemyTankView;

        public List<EnemyTankController> enemyTanks = new List<EnemyTankController>();
        private EnemyTankController tankController;
        private EnemyType enemyTankType;

        public List<EnemyTankController> EnemyTanks() => enemyTanks;

        private void Start()
        {
            for (int i = 1; i < 3; i++)
            {
                enemyTankType = (EnemyType)Mathf.Floor(Random.Range(1, 4f));
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
                    return tankController;
                }
            }
            return null;
        }
    }
}
