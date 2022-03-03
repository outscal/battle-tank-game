using EnemyTankServices;
using GlobalServices;
using UnityEngine;
using System.Collections;
namespace GameplayServices
{
    public class GameManager : MonoSingletonGeneric<GameManager>
    {
        public void DestroyAllGameObjects()
        {
            DestroyEnemyObjects();
            DestroyGroundObjects();
        }

        private void DestroyEnemyObjects()
        {
            StartCoroutine("Destroy");

            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTank");

            for (int i = 0; i < enemyObjects.Length; i++)
            {

                enemyObjects[i].GetComponent<EnemyTankView>().tankController.Death();
            }
        }

        private void DestroyGroundObjects()
        {
            StartCoroutine("Destroy");


            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Ground");

            for (int i = enemyObjects.Length - 1; i >= 0; i--)
            {

                Destroy(enemyObjects[i]);
            }
        }
        IEnumerator Destroy()
        {

            yield return new WaitForSeconds(1.5f);
        }
    }
}
