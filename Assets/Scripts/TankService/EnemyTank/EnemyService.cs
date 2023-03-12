using UnityEngine;

namespace TankBattle.Tank.EnemyTank
{
    public class EnemyService : MonoBehaviour
    {
        
        [SerializeField] private Transform spawnPoint;

        private int enemyTankIndex = 1;
        private TankController enemyTankController;

        void Start()
        {
            enemyTankController = CreateTank.CreateTankService.Instance.CreateTank(spawnPoint.position, enemyTankIndex);
        }
    }
}
