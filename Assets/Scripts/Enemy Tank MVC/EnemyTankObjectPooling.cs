using UnityEngine;
using AllServices;

namespace EnemyTankServices
{
    public class EnemyTankObjectPool : ObjectPoolingService<EnemyTankController>
    {
        protected EnemyTankController CreateItem()
        {
            int rand = Random.Range(0, EnemyTankService.Instance.enemyTankSOList.enemyTankScriptableObject.Length);
            EnemyTankController enemyTankController = EnemyTankService.Instance.CreateEnemyTank((EnemyType)rand);

            enemyTankController.DisableTankView();

            return enemyTankController;
        }
    }
}
