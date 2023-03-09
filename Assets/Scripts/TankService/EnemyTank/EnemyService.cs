using UnityEngine;

namespace TankBattle.Tank.EnemyTank
{
    public class EnemyService : MonoBehaviour
    {
        
        [SerializeField] private Transform spawnPoint;

        private Tank.PlayerTank.MoveController.TankController enemyTankController;

        void Start()
        {
            enemyTankController = Tank.CreateTank.CreateTankService.Instance.CreateEnemyTank(spawnPoint.position);
        }
    }
}
