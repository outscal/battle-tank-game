using EnemyTankServices;
using GlobalServices;
using UnityEngine;
using System.Collections;
namespace GameplayServices
{
    public class GameManager : MonoSingletonGeneric<GameManager>
    {
        [SerializeField] private GameObject[] EnvronmentPrefabs;
        public void DestroyAllGameObjects()
        {
            StartCoroutine(Destroy());
        }
        IEnumerator Destroy()
        {
            foreach (var enemy in EnemyTankService.Instance.EnemyTanks())
            {
                Debug.Log("In destroy");
                Destroy(enemy.tankView.gameObject);
                yield return new WaitForSeconds(0.5f);
            }

            foreach (var prefab in EnvronmentPrefabs)
            {
                Destroy(prefab);
                yield return new WaitForSeconds(0.5f);
            }

            GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
            for (int i = 0; i < tanks.Length; i++)
            {
                GameObject.Destroy(tanks[i]);
                yield return new WaitForSeconds(0.5f);
            }

            
        }
    }
}
