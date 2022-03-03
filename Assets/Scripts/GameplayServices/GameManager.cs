using EnemyTankServices;
using GlobalServices;
using UnityEngine;
using System.Collections;
namespace GameplayServices
{
    public class GameManager : MonoSingletonGeneric<GameManager>
    {
        [SerializeField] private GameObject[] EnvronmentPrefabs;
        [SerializeField] private GameObject EnemyTank;
        public void DestroyAllGameObjects()
        {

            StartCoroutine(Destroy());

        }
        IEnumerator Destroy()
        {
            foreach (var prefab in EnvronmentPrefabs)
            {
                Destroy(prefab);
                yield return new WaitForSeconds(0.7f);
            }
            Destroy(EnemyTank);
        }
    }
}
