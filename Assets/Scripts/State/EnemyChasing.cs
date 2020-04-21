using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TankGame.Enemy;
using TankGame.Tank;

public class EnemyChasing : EnemyState
{
    [SerializeField]
    private Color chasingColor;
    public GameObject attackingZone;
    private NavMeshAgent enemyAgent;
    private TankView targetPlayer;
    private Vector3 targetPosition;

    public override void OnEnterState()
    {
        base.OnEnterState();
        targetPlayer = TankService.Instance.GetCurrentPlayer();
        SetNavmeshAgent();
        enemyView.SetTankColor(chasingColor);
        InvokeRepeating("Fire", 1f, enemyView.GetFireRate());
    }
    public override void OnExitState()
    {
        base.OnExitState();
        CancelInvoke();
        DisabeNavmeshAgent();
    }

    private void Fire()
    {
        enemyView.FireBullet();
    }

    private void SetNavmeshAgent()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.isStopped = false;

    }

    private void DisabeNavmeshAgent()
    {
        //enemyAgent.gameObject.SetActive(false);
        enemyAgent.isStopped = true;
    }
    private void Update()
    {
        if(targetPlayer != null)
        {
        targetPosition = targetPlayer.transform.position;
        enemyAgent.destination = targetPosition;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<TankView>())
        {   
            enemyView.ChangeState(enemyView.patrolingState);
           
        }
    }

}


