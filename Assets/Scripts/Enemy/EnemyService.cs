using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericSingleton<EnemyService>
{
    public EnemyView enemyView;
    public EnemyScriptableObjectList enemyList;
    // public List<EnemyController> enemies = new List<EnemyController>();

    private void Start()
    {
        CreateNewTank();
    }

    private EnemyController CreateNewTank()
    {
        // TankScriptableObject tankScriptableObject = tankConfiguration[1];
        EnemyScriptableObject enemyScriptableObject = enemyList.enemytanks[1];
        EnemyModel model = new EnemyModel(enemyScriptableObject);
        // TankModel model = new TankModel(TankType.None,5, 100);
        EnemyController enemy = new EnemyController(model, enemyView);
        return enemy;
    }
}
