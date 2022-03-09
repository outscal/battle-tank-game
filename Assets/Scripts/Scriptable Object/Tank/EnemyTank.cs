using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewEnemyTank", menuName = "User/Tank/EnemyTank", order = 3)]
    public class EnemyTank:Tank
    {
        #region Serialized Data members

        [SerializeField] private EnemyTankView tankView;

        #endregion

        #region Cosntructors
        EnemyTank()
        {
            tankType = TankType.Enemy;
            tankModel = new EnemyTankModel();
        }

        #endregion
        
        #region Getters

        public override TankView TankView => tankView;

        #endregion
    }
}