
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController 
{
    private EnemyModel _model;
    protected EnemyView _view;
    private EnemyScriptableObject _scriptableObject;
    private TankView Player;
    private BulletServices _bulletServices;

    public EnemyController(EnemyModel model,  EnemyScriptableObject EnemySO,Transform Enemypos, List<GameObject> enemies)
    {
        _model = model;
        _view = EnemySO.EnemyView;
        _scriptableObject = EnemySO;
        _view.SetEnemyController(this);
        _view.SetPatrolPosition(EnemySO.PatrolPosition, EnemySO.PatrolRadius);
        GameObject enemy= GameObject.Instantiate(_view.gameObject, Enemypos);
        enemies.Add(enemy);
        Debug.Log(enemies.Count);
    }
    private void SetBulletServices(BulletServices bulletServices)
    {
        _bulletServices = bulletServices;
    }
    public EnemyView GetEnemyview()
    {
        return _view;
    }
    public void Patrol()
    {

    }
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public float Attack(float timer,float delay)
    {
        Player= _view.GetTankView();
        Vector3 playerPos = Player.transform.position;
        _view.transform.LookAt(playerPos);
        if (timer > delay)
        {
            _view.shoot()
            return 0;
        }
        return timer + Time.deltaTime;
    }
}
