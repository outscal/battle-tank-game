using UnityEngine;

public class EnemyTankAttackState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.agent.transform.position);
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        //Fire();
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
        //enemyTankStateManager.EnemyTankView.FireFunction();
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.attackRange && enemyTankStateManager.attackRange < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    //public void Fire()
    //{
    //    Rigidbody shellInstance = GameObject.Instantiate(EnemyTankView.shellPrefab, EnemyTankView.fireTransform.position, EnemyTankView.fireTransform.rotation) as Rigidbody;

    //    //shellInstance.velocity = EnemyTankModel.CurrentLaunchForce * EnemyTankView.fireTransform.forward;
    //    shellInstance.velocity = 30f * EnemyTankView.fireTransform.forward;

    //    EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MinLaunchForce;
    //}

    //public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    //{

    //}

    //public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    //{
    //    throw new System.NotImplementedException();
    //}
}
