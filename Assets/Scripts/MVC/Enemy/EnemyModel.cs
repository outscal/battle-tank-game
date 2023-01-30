using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public EnemyModel(EnemyScriptaleObject enemyScriptableObject)
    {
        EnemyType = enemyScriptableObject.EnemyType;
        EnemyName = enemyScriptableObject.EnemyName;
        EnemyRange = enemyScriptableObject.EnemyRange;
        DistanceBetweenTarget = enemyScriptableObject.DistanceBetweenTarget;
        CountDownBetweenFire = enemyScriptableObject.CountDownBetweenFire;
        FireRate = enemyScriptableObject.FireRate;
        Target = enemyScriptableObject.Target;
        Health = enemyScriptableObject.Health;
  
    }

    public EnemyType EnemyType { get; }
    public string EnemyName { get; }
    public float EnemyRange { get; }
    public float DistanceBetweenTarget { get; set; }
    public float CountDownBetweenFire { get; set; }
    public float FireRate { get; }
    public int Health { get; set; }
    public Transform Target;




   


}
