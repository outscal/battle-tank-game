using Tank;
using Enemy;
using UnityEngine;

public class EnemyPatrollingState : EnemyState
{

    public EnemyPatrollingState()
    {

    }

    public EnemyState ExecuteState(EnemyController enemy)
    {
        if (enemy.CheckIfTargetIsVisible())
        {
            return enemy.enemyAttacking;
        }
        else
        {
            KeepPatrolling(enemy);
            return this;
        }
    }


    private void KeepPatrolling(EnemyController enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.distanceCheckPos) < enemy.movementDistance)
        {
            enemy.transform.Translate(enemy.moveDir * 5f * Time.deltaTime);
        }
        else
        {
            enemy.distanceCheckPos = enemy.transform.position;
            enemy.moveDir = -enemy.moveDir;
        }
    }
}
