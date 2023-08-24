
using UnityEngine;

public class EnemyServices : MonoBehaviour
{
    public EnemyScriptableObjectList EnemyList;
    public Transform[] Spawnpos;
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
        EnemyController controller = new EnemyController(enemyModel, Enemy,pos);
    }
}
