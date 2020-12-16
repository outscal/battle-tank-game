using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateMachine,Idamagable
{

    public int hp;
    public float payrollSpeed;
    public int dmg;
    private PatrolState ps;
    private AttackState atts;
    private ChaseState chase;
    private bool playerInSightRange;
    private bool playerInAttackRange;
    public LayerMask PlayerMask;

    private void Awake()
    {
        PlayerMask = 1000;
        currentState = addPatrol();
        currentState.EnterState();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, 15, PlayerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position,10,PlayerMask);
        if (playerInSightRange && !playerInAttackRange && gameObject.GetComponent<AttackState>() != null)
        {
            currentState.ExitState();
            Destroy(atts);
            currentState = addChase();
            currentState.EnterState();
        }
        else if (playerInSightRange && gameObject.GetComponent<PatrolState>() != null)
        {
            currentState.ExitState();
            Destroy(ps);
            currentState = addChase();
            currentState.EnterState();
        }
        else if (!playerInSightRange && gameObject.GetComponent<ChaseState>() != null)
        {
            currentState.ExitState();
            Destroy(chase);
            currentState = addPatrol();
            currentState.EnterState();
        }
        else if (playerInAttackRange && gameObject.GetComponent<ChaseState>() != null)
        {
            currentState.ExitState();
            Destroy(chase);
            currentState = addAttack();
            currentState.EnterState();
        }
        /*else if (!playerInAttackRange && gameObject.GetComponent<AttackState>() != null)
        {
            dust.Play();
            currentState.ExitState();
            Destroy(atts);
            currentState = addPatrol();
            currentState.EnterState();
        }*/
        else if (playerInAttackRange && gameObject.GetComponent<AttackState>() != null)
        {
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
            

    }

  

    public void takeDamage() {
        hp -= 25;
        Debug.Log("After hit - " + hp);
        if (isDead())
        {
            GameEvents.Instance.OnPlayerKill += Kill;
            Destroy(gameObject);
            TankProvider.Instance.Boom(transform);
        }
    }

    private void Kill()
    {
        Debug.Log("Called KILL");
        if (++TankController.Instance.Kills == 1) {
            GameEvents.Instance.FirstKillTrigger();
        }
        Debug.Log("Player Kills- "+TankController.Instance.Kills);
        GameEvents.Instance.OnPlayerKill -= Kill;
    }

    private PatrolState addPatrol()
    {
        ps = gameObject.AddComponent<PatrolState>();
        ps.ec = this;
        return ps;
    }

    private AttackState addAttack() {
        atts = gameObject.AddComponent<AttackState>();
        return atts;
    }

    private ChaseState addChase()
    {
        chase = gameObject.AddComponent<ChaseState>();
        chase.ec = this;
        return chase;
    }

    private bool isDead()
    {
        if (hp <= 0) return true;
        return false;
    }
}

