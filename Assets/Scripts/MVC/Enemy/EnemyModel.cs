using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public EnemyModel(EnemyScriptaleObject enemyScriptableObject)
    {
        EnemyType = enemyScriptableObject.EnemyType;
        EnemyName = enemyScriptableObject.EnemyName;
        ChaseRange = enemyScriptableObject.ChaseRange;
        ShootRange = enemyScriptableObject.ShootRange;
        CountDownBetweenFire = enemyScriptableObject.CountDownBetweenFire;
        FireRate = enemyScriptableObject.FireRate;
        Target = enemyScriptableObject.Target;
        Health = enemyScriptableObject.Health;
        Waypoints = enemyScriptableObject.wayPoints;
    }

    public EnemyType EnemyType { get; }
    public string EnemyName { get; }
    public float ChaseRange { get; }
    public float ShootRange { get; set; }
    public float CountDownBetweenFire { get; set; }
    public float FireRate { get; }
    public int Health { get; set; }
    public Transform Target;
    public Transform[]  Waypoints {get;}
}
