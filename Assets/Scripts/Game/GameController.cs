using Tank;
using UnityEngine;
using Player;
using ScriptableObjects;
using Enemy;
using System.Collections;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerController playerTank;
        private EnemyController enemyTank;
        [SerializeField]
        private FloatingJoystick leftJoystick, rightJoystick;

        [SerializeField]
        private TankScriptableObject playerObj, enemyObj;
        public static GameController GC;

        [SerializeField]
        private int numberOfEnemies;

        void Start()
        {
            GC = this;
            CreatePlayer();
            SpawnEnemies();
        }

        void SpawnEnemies()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                CreateEnemy();
            }
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
            enemyTank = EnemySpawnerService.Instance.CreateEnemy();
            enemyTank.TankSetup(enemyObj);
            enemyTank.SetupEnemy(playerTank);
        }

        public void SetPlayerDeath()
        {
            StartCoroutine(KillPlayerAndRespawn());
        }

        private IEnumerator KillPlayerAndRespawn()
        {
            playerTank.gameObject.SetActive(false);
            yield return StartCoroutine(DestroyAllEnemiesAndRespawn());
            TankService.Instance.ResetTank(playerTank);
        }
        private IEnumerator DestroyAllEnemiesAndRespawn()
        {
            yield return new WaitForSeconds(1f);
            enemyTank.gameObject.SetActive(false);
            yield return StartCoroutine(TankService.Instance.RespawnTankAfterDelay(enemyTank));
        }
    }
}
