using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScene : MonoSingletonGeneric<DestroyScene>
{
    private GameObject[] enemies;
    private GameObject[] scene;
    /*public int DestroyTanks()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) enemies = GameObject.FindGameObjectsWithTag("BossEnemy");
        if (enemies.Length == 0) Destroy(gameObject);
            for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(DestroyCoroutine(enemies[i]));
        }
        return 0;
    }*/

    public IEnumerator DestroyTanks(GameObject[] gameObject)
    {
         
            for (int i = 0; i < enemies.Length; i++)
            {
                TankProvider.Instance.Boom(gameObject[i].transform);

                 yield return new WaitForSeconds(0.5f);
                 Destroy(gameObject[i]);
            }

        yield return new WaitForSeconds(2f);
        Destroy(GameObject.Find("Ground"));
        StartCoroutine(DestroySceneObjects());

    }
    public IEnumerator DestroySceneObjects()
    {
        scene = UnityEngine.Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < scene.Length; i++)
        {
                yield return new WaitForSeconds(0.1f);
                Destroy(scene[i]);
        }

    }


    public void DestroyAll() {
        EnemySpawnController.playerDead = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) enemies = GameObject.FindGameObjectsWithTag("BossEnemy");
        if (enemies.Length == 0) Destroy(gameObject);
        StartCoroutine(DestroyTanks(enemies));/*
        Destroy(GameObject.Find("Ground"));*/
      
    }
}
