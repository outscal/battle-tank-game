
using UnityEngine;

public class EnemyModel
{
    public EnemyModel(float enemySpeed, float patrolDistance)
    {
        EnemySpeed = enemySpeed;
        PatrolDistance = patrolDistance;
    }
    public float EnemySpeed
    {
        get;
    }

    public float PatrolDistance
    {
        get;
    }

}
