using EnemyTankServices;
using GlobalServices;
using UnityEngine;
using System.Collections;
namespace GameplayServices
{
    public class GameManager : MonoSingletonGeneric<GameManager>
    {

        [SerializeField] private GameObject[] EnvronmentPrefabs;
        [SerializeField] private GameObject UI;

        public void StartDestruction()
        {

            StartCoroutine(Destroy());
            StartCoroutine(StartUI());

        }
        IEnumerator Destroy()
        {

            foreach (var enemy in EnemyTankService.Instance.EnemyTanks())
            {
                Destroy(enemy.tankView.gameObject);
                yield return new WaitForSeconds(0.2f);

            }
            foreach (var prefab in EnvronmentPrefabs)
            {
                Destroy(prefab);
                yield return new WaitForSeconds(0.7f);
            }
        }
        IEnumerator StartUI()
        {
            yield return new WaitForSeconds(8.8f);
            UI.SetActive(true);
        }
    }
}
