using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewEnemyTankList", menuName = "User/Tank/EnemyTankList", order = 1)]
    public class EnemyTankList:TankList
    {
        #region serialized Data Members

        [SerializeField] private EnemyTank[] list;
        
        #endregion

        #region Getters

        public override Tank[] List => list;

        #endregion
    }
}