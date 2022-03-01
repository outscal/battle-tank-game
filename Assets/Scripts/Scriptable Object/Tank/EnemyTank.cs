using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewEnemyTank", menuName = "User/Tank/EnemyTank", order = 3)]
    public class EnemyTank:Tank
    {
        [SerializeField] private EnemyTankView tankView;

        public override TankView TankView => tankView;

        EnemyTank()
        {
            tankType = TankType.Enemy;
            tankModel = new EnemyTankModel();
        }
    }
}