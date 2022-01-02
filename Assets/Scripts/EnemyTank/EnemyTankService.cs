using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BulletSO;
using TankSO;

public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
{
    public EnemyTankView enemyTankView;
    public TankSOList enemyList;
    public BulletSOList bulletList;
    public EnemyTankController enemyTankController;
    public Transform[] points;

    private void Start()
    {
        enemyTankController = CreateEnemyTank();
        enemyTankController.SetEnemyHealthUI();
    }

    private EnemyTankController CreateEnemyTank()
    {
        TankScriptableObject tankScriptableObject = enemyList.tanks[1];
        EnemyTankModel model = new EnemyTankModel(tankScriptableObject);
        EnemyTankController tank = new EnemyTankController(model, enemyTankView);
        return tank;
    }

    private void Update()
    {
        enemyTankController.UpdateEnemyTankPatrolling1();
    }
}