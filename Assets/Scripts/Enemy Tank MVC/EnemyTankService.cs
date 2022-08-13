using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    public EnemyTankView enemyTankView;
    public EnemyTankScriptableObject enemyTankScriptableObject;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreateEnemyTank();
    }

    private EnemyTankController CreateEnemyTank()
    {
        EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
        EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, enemyTankView);
        enemyTankController.Enemy_TankView.SetTankControllerReference(enemyTankController);
        return enemyTankController;
    }
}
