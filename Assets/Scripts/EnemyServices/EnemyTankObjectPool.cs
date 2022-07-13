using GlobalServices;
using UnityEngine;

namespace EnemyTankServices
{
    public class EnemyTankObjectPool : ObjectPoolService<EnemyTankController>
    {
        protected override EnemyTankController CreateItem()
        {
            int rand = Random.Range(0, EnemyTankService.Instance.enemyTankList.enemies.Length);
            EnemyTankController tankController = EnemyTankService.Instance.CreateEnemyTank((EnemyType)rand);

            tankController.DisableTankView();

            return tankController;
        }
    }
}
