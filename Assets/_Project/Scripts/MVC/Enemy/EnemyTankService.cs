using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView EnemyTankView;
    private EnemyTankModel EnemyTankModel;
    public int numOfEnemies;

    //public Transform spawnEnemy;

    public TankScriptableObjectList tankScriptableObjectList;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            CreateEnemyTank();
        }
    }
    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = Random.Range(-35, 35);
        y = 1;
        z = Random.Range(-20, 30);
        pos = new Vector3(x, y, z);
        return pos;
    }

    private EnemyTankController CreateEnemyTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
        //Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        EnemyTankModel = new EnemyTankModel(tankScriptableObject);
        EnemyTankController enemyTank = new EnemyTankController(EnemyTankModel, EnemyTankView, RandomPosition());
        return enemyTank;
    }
}
