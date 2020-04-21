using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;

public class EnemyAttacking : EnemyState
{
    private Vector3 newDirection;
    private TankView target;
    public GameObject attackingExitZone;

    public override void OnEnterState()
    {
        base.OnEnterState();
        attackingExitZone.SetActive(true);
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
        attackingExitZone.SetActive(false);
        StopAllCoroutines();
    }
    private void FixedUpdate()
    {
        newDirection =target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(newDirection);
        transform.rotation = rotation;
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            enemyView.ChangeState(enemyView.chasingState);
        }
    }
}
