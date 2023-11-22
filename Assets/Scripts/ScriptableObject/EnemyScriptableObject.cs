using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyScriptableObject")]

public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType enemyType;
    public EnemyView enemyView;
    public float Speed ;
    public float rotationSpeed;
    public float Health;
    public float fireRate;
    public float attackDistace;
}
