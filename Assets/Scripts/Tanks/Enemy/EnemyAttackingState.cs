using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class EnemyAttackingState : EnemyState
{
    public EnemyState ExecuteState(EnemyController enemy)
    {
        return ShootIfTargetIsInRange(enemy);
    }
    private EnemyState ShootIfTargetIsInRange(EnemyController enemy)
    {
        enemy.turret.transform.LookAt(enemy.GetTarget().transform.position);
        enemy.ShootBulletIfCooldown();
        if (!enemy.CheckIfTargetIsVisible())
        {
            return enemy.enemyPatrolling;
        }
        else
        {
            return enemy.enemyAttacking;
        }
    }
}
