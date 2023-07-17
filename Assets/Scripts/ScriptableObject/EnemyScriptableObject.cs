using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public int strength;
    public BulletType bulletType;
    public EnemyView enemyView;
}