using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{ 
    public EnemyTankList enemyTankList;    
   
    void Start()
    {
        StartGame();
        
    }

    void StartGame()
    {
        for(int i = 0; i < 3; i++)
        {
            CreateTank(i);
        }
        
    }

    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 position;
        x = Random.Range(-35, 35);
        y = 1;
        z = Random.Range(-20, 30);
        position  = new Vector3(x, y, z);
        return position;
    }

    private void CreateTank(int i)
    {
        int index = Random.Range(0, enemyTankList.enemyTanks.Length);
        EnemyTankScriptableObjects enemyTankSO = enemyTankList.enemyTanks[index];
        EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankSO);
        EnemyTankController tankController = new EnemyTankController(enemyTankModel, enemyTankSO.enemyTankView, RandomPosition());         
    }
    
}
