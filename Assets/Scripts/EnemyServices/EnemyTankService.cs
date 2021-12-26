using BulletSO;
using EnemySO;
using GlobalServices;
using UnityEngine;

namespace EnemyTankServices
{
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {
        public EnemySOList enemyTankList;

        private EnemyTankController tankController;
        private EnemyType enemyTankType;

        private void Start()
        {
            enemyTankType = (EnemyType)Mathf.Floor(Random.Range(0, 2.5f));

            tankController = CreateEnemyTank(enemyTankType);
        }

        private EnemyTankController CreateEnemyTank(EnemyType tanktype)
        {
            foreach (EnemyScriptableObject tank in enemyTankList.enemies)
            {
                if (tank.enemyType == enemyTankType)
                {
                    EnemyTankModel tankModel = new EnemyTankModel(enemyTankList.enemies[(int)tanktype]);

                    EnemyTankController tankController = new EnemyTankController(tankModel, enemyTankList.enemies[(int)tanktype].enemyView);
                    return tankController;
                }
            }
            return null;
        }
    }
}
