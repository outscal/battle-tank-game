using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView[] enemyTankView;
    
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        for(int i = 0; i < 3; i++)
            CreateEnemyTank(i);
    }

    private void CreateEnemyTank(int i)
    {
        EnemyTankModel enemyTankModel = new EnemyTankModel(100);
        EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, enemyTankView[i]);
    }
    
}
