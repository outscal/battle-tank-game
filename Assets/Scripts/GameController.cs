using Tank;
using UnityEngine;
using Player;
using ScriptableObjects;
using Enemy;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerController playerTank;
        [SerializeField]
        private FloatingJoystick leftJoystick, rightJoystick;

        [SerializeField]
        private TankScriptableObject playerObj, enemyObj;

        void Start()
        {
            CreatePlayer();
            CreateEnemy();
        }

        void CreatePlayer()
        {
            TankController tank = TankService.Instance.CreatePlayer();
            tank.TankSetup(playerObj);
            playerTank = tank.gameObject.GetComponent<PlayerController>();
            playerTank.SetupJoysticks(leftJoystick, rightJoystick);
            CameraController.Instance.SetTarget(playerTank.transform);
        }
        void CreateEnemy()
        {
            TankController tank = EnemySpawnerService.Instance.CreateEnemy();
            tank.TankSetup(enemyObj);
            tank.gameObject.GetComponent<EnemyController>().SetupEnemy(playerTank);
        }
    }
}
