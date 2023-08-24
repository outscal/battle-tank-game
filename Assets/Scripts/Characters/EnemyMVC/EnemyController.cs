
using System;
using UnityEngine;

public class EnemyController 
{
    private EnemyModel _model;
    private EnemyView _view;
    private EnemyScriptableObject _scriptableObject;

    public EnemyController(EnemyModel model,  EnemyScriptableObject EnemySO,Transform Enemypos)
    {
        _model = model;
        _view = EnemySO.EnemyView;
        _scriptableObject = EnemySO;
        _view.SetEnemyController(this);
        _view.SetPatrolPosition(EnemySO.PatrolPosition, EnemySO.PatrolRadius);
        GameObject.Instantiate(_view.gameObject, Enemypos);
    }


}
