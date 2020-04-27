using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Enemy;

public class EnemyAttacking : EnemyState
{
    private Vector3 newDirection;
    private TankView target;
    public GameObject attackingExitZone;


    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.SetTankColor(changedColor);
        target = TankService.Instance.GetCurrentPlayer();
        newDirection = target.transform.position - transform.position;
        InvokeRepeating("Fire", 1f, enemyView.GetFireRate());

    }

    private void Fire()
    {
        enemyView.FireBullet();
    }

    public override void OnExitState()
    {
        base.OnExitState();
        CancelInvoke();
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            newDirection = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(newDirection);
           enemyView.transform.rotation = rotation;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<TankView>())
    //    {
    //        enemyView.ChangeState(enemyView.attackingState);
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            enemyView.ChangeState(enemyView.chasingState);
        }
    }
}
