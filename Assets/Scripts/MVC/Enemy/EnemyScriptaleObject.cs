using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptaleObject", menuName = "ScriptableObject/EnemyTank")]
public class EnemyScriptaleObject : ScriptableObject
{
    public EnemyType EnemyType;
    public string EnemyName;
    public float EnemyRange;
    public float DistanceBetweenTarget;
    //public Transform[] ProjectileSpawnPoint;
   // public GameObject ProjectlePrefab;
    public float CountDownBetweenFire;
    public float FireRate;
    public Transform Target;
   
    
}

