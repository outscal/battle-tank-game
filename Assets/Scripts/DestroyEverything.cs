using System.Collections;
using TankBattle.Tank;
using TankBattle.Tank.EnemyTank;
using UnityEngine;

namespace TankBattle
{
    public class DestroyEverything : GenericSingleton<DestroyEverything>
    {
        [SerializeField] private EnemyService enemyService;
        [SerializeField] private GameObject destroyObjectFloor;
        [SerializeField] private GameObject destroyObjectRest;

        private TankController enemyTankController;


        // coroutines
        private Coroutine coroutine;
        private WaitForSeconds _wait;

        public void RunCoroutine()
        {
            StartCoroutine(deathRoutine());
        }

        private IEnumerator deathRoutine()
        {
            Debug.Log("Start Destroying");
            _wait = new WaitForSeconds(1f);
            enemyTankController = enemyService.GetEnemyTankController();

            yield return _wait;
            yield return StartCoroutine(deathRoutineEnemy());
            _wait = new WaitForSeconds(2f);
            yield return _wait;
            yield return StartCoroutine(deathRoutineWorld());
        }

        private IEnumerator deathRoutineEnemy()
        {
            Debug.Log("Destroy Enemy");
            float deathDamage = 200f;
            enemyTankController.TakeDamage(deathDamage);
            _wait = new WaitForSeconds(5f);
            yield return null;
        }

        private IEnumerator deathRoutineWorld()
        {
            Debug.Log("Destroy Floor");
            Destroy(destroyObjectFloor);
            _wait = new WaitForSeconds(2f);
            yield return _wait;
            Destroy(destroyObjectRest);
            Debug.Log("Destroyed rest");
        }
    }
}
