using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="Enemy")]
public class EnemySribtableObject : ScriptableObject
{
    public EnemyType enemyType;
    public float enemySpeed;
    public int enemyHealth;
    public float enemyDamage;
}
