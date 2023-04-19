using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;
    private EnemyTankObject tank;
    private float health;
    public EnemyModel (EnemyTankObject _tank)
    {
        this.tank = _tank;
        health = tank.Health;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public EnemyType type
    {
        get
        {
            return tank.EnemyType;
        }
    }
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public float speed
    {
        get
        {
            return tank.Speed;
        }
    }
    public float DetectionRadius
    {
        get
        {
            return tank.DetectionRadius;
        }
        
    }
    public float EngageRadius
    {
        get
        {
            return tank.EngageRadius;
        }
    }
    public float AttackRadius
    {
        get
        {
            return tank.AttackRadius;
        }
    }
    public Vector3[] patrolPoints
    {
        get
        {
            return tank.PatrolPoints;
        }
    }
    public void RestoreHealth()
    {
        health = tank.Health;
    }
    public TypeDamagable Type
    {
        get{return tank.Type;}
    }
}
