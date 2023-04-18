using BattleTank.EnemyTank;
using BattleTank.GenericSingleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Services
{
    public class DestructionService : GenericSingleton<DestructionService>
    {
        [SerializeField] private float delayTime;
        [SerializeField] private GameObject environment;
        private List<EnemyTankController> enemyTanks;
        private Coroutine destructionCoroutine;

        public void DestroyEverything()
        {
            if (destructionCoroutine != null)
            {
                return;
            }

            enemyTanks = EnemyTankService.Instance.GetEnemyTankControllersList();
            CameraService.Instance.ZoomOutCamera();
            CollectibleService.Instance.DestroyingWorld();
            UIService.Instance.DeactivateStartingUI();
            destructionCoroutine = StartCoroutine(StartDestruction());
        }

        IEnumerator StartDestruction()
        {
            yield return StartCoroutine(DestroyEnemies());
            yield return StartCoroutine(DestroyEnvironment());
        }

        IEnumerator DestroyEnemies()
        {
            int n = enemyTanks.Count;
            for(int i = 0; i < n; i++)
            {
                if(enemyTanks[i].GetIsTankAlive() == false)
                {
                    continue;
                }
                yield return new WaitForSeconds(delayTime);
                enemyTanks[i].DestroyTank();
            }
        }

        IEnumerator DestroyEnvironment()
        {
            int n = environment.transform.childCount;
            for(int i = n-1; i >= 0; i--)
            {
                yield return new WaitForSeconds(delayTime);
                environment.transform.GetChild(i).gameObject.SetActive(false);
            }
            UIService.Instance.ActivateGameOverPanel();
        }

        public void LoadEnvironment()
        {
            int n = environment.transform.childCount;
            for (int i = n-1; i >= 0; i--)
            {
                environment.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        public void SetCoroutineNull()
        {
            destructionCoroutine = null;
        }
    }
}