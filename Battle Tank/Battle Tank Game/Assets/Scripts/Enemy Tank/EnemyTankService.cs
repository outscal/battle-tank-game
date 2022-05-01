using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView enemyTankView;
    
    void Start()
    {
        CreateEnemyTank();
    }

    private void CreateEnemyTank()
    {
        EnemyTankModel enemyTankModel = new EnemyTankModel(100);
        EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, enemyTankView);
    }
    
}
