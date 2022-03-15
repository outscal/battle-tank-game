using EnemyScriptables;
using GlobalServices;
using UnityEngine;

namespace EnemyTankServices
{
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {
        public EnemySOList enemyTankList;
        public EnemyTankView enemyTankView;

        private EnemyTankController tankController;
        private EnemyType enemyTankType;

        private void Start()
        {
            for (int i = 0; i < 4; i++)
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
