
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyServices : MonoBehaviour
{
    public EnemyScriptableObjectList EnemyList;
    public Transform[] Spawnpos;
    [SerializeField]
    private float destroyDelay;
    private EnemyController controller;
    [SerializeField]
    private List<GameObject> enemies;
    private void Start()
    {
        CreateEnemy();
    }
    private void CreateEnemy()
    {
        foreach(Transform i in Spawnpos)
        {
            CreateEnemy(i);
        }
        //EnemyScriptableObject Enemy = EnemyList.EnemyObjects[0];
       // EnemyModel enemyModel = new EnemyModel(Enemy);
        //EnemyController controller = new EnemyController(enemyModel, Enemy);
    }
    private void CreateEnemy(Transform pos)
    {
        EnemyScriptableObject Enemy = EnemyList.EnemyObjects[0];
        EnemyModel enemyModel = new EnemyModel(Enemy);
        controller = new EnemyController(enemyModel, Enemy,pos,enemies);
    }
    public IEnumerator KillAllEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Debug.Log("Destroying GameObject"+ enemy.name);
            Destroy(enemy);
            yield return new WaitForSeconds(destroyDelay);
        }
    }
    public List<GameObject> GetEnemies()
    {
        return enemies;
    }
}
