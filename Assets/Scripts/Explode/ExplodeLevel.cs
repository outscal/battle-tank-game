using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeLevel : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject player;
    [SerializeField] private GameObject Level;

    public IEnumerator DestroyLevel()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Enemy count: " + enemies.Length);
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Player: " + player.name);

        Debug.Log("Coroutine started");
        StartCoroutine(DestroyPlayer());
        StartCoroutine(DestroyEnemies());
        StartCoroutine(DestroyGround());
        yield return null;
    }

    private IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(3);
        Level.SetActive(false);
    }
    private IEnumerator DestroyEnemies()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyView>().DestroyTank();
        }
    }
    private IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1);
        Destroy(player);
    }


}