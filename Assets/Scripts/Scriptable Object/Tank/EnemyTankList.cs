using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewEnemyTankList", menuName = "User/Tank/EnemyTankList", order = 1)]
    public class EnemyTankList:TankList
    {
        [SerializeField] private EnemyTank[] list;

        public override Tank[] List => list;
    }
}