using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView EnemyTankView;
    private EnemyTankModel EnemyTankModel;
    //public Transform spawnEnemy;

    public TankScriptableObjectList tankScriptableObjectList;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        CreateEnemyTank();
    }
    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = Random.Range(-25, 26);
        y = 1;
        z = Random.Range(-25, 26);
        pos = new Vector3(x, y, z);
        return pos;
    }
    private EnemyTankController CreateEnemyTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
        Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        EnemyTankModel = new EnemyTankModel(tankScriptableObject);
        EnemyTankController enemyTank = new EnemyTankController(EnemyTankModel, EnemyTankView, RandomPosition());
        return enemyTank;
    }
}
