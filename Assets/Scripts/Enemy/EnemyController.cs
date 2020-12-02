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
    private ParticleSystem dust;
    private bool playerInSightRange;
    public LayerMask PlayerMask;

    private void Awake()
    {
        dust = GetComponent<ParticleSystem>();
        PlayerMask = 1000;
        currentState = addPatrol();
        currentState.EnterState();
        var renderer = dust.GetComponent<Renderer>();
        renderer.material.SetColor("", new Color(255,194,71,255));
        dust.Play();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position,10,PlayerMask);
        if (playerInSightRange && gameObject.GetComponent<PatrolState>() != null)
        {
            dust.Stop();
            currentState.ExitState();
            Destroy(ps);
            currentState = addAttack();
            currentState.EnterState();
        }
        else if (!playerInSightRange && gameObject.GetComponent<AttackState>() != null)
        {
            dust.Play();
            currentState.ExitState();
            Destroy(atts);
            currentState = addPatrol();
            currentState.EnterState();
        }
        else if (playerInSightRange  && gameObject.GetComponent<AttackState>() != null) 
        {
            gameObject.transform.LookAt(GameObject.Find("Tank").transform);
        }

    }
    public void takeDamage() {
        hp -= 25;
        Debug.Log("After hit - " + hp);
        if (isDead())
        {
            Destroy(gameObject);
            TankProvider.Instance.Boom(transform);
        }
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

    private bool isDead()
    {
        if (hp <= 0) return true;
        return false;
    }
}

