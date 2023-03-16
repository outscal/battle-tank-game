using System;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptaleObject", menuName = "ScriptableObject/EnemyTank")]
public class EnemyScriptaleObject : ScriptableObject
{
    public EnemyType EnemyType;
    public string EnemyName;
    public int EnemySpeed;
    public int EnemyHealth;
    public Transform[] WayPoints;
    
    
   // public float Health;
}

