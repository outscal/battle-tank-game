using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : TankController
{

    public EnemyTankModel EnemyTankModel { protected set; get; }
    public EnemyTankView EnemyTankView { protected set; get; }

    EnemyTankState EnemyTankState { set; get; }

    Dictionary<EnemyTankStates, EnemyTankState> EnemyTankStatesObjects;

    public float Horizontal { get { return horizontal; } }
    public float Vertical { get { return vertical; } }

    public EnemyTankController(EnemyTankScriptableObject enemyTankScriptableObject) : base((TankScriptableObject)enemyTankScriptableObject)
    {

        EnemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
        TankModel = (TankModel)EnemyTankModel;

        EnemyTankView = GameObject.Instantiate<EnemyTankView>(EnemyTankModel.EnemyTankViewPrefab);
        TankView = (TankView)EnemyTankView;

        EnemyTankView.EnemyTankController = this;
        TankView.TankController = (TankController)this;

        // Initialize the dictionary and populate it with state objects
        EnemyTankStatesObjects = new Dictionary<EnemyTankStates, EnemyTankState>
        {
            { EnemyTankStates.Idle, new EnemyTankStateIdle(this) },
            { EnemyTankStates.Attack, new EnemyTankStateAttack(this) },
            { EnemyTankStates.Chase, new EnemyTankStateChase(this) },
            { EnemyTankStates.Patrol, new EnemyTankStatePatrol(this) },
        };

        SetState(EnemyTankStates.Idle);
    }

    public override void Update()
    {
        if (!EnemyTankModel.IsAlive)
        {
            GameObject.Destroy(EnemyTankView.gameObject);
            return;
        }

        if (EnemyTankState != null)
            EnemyTankState.Tick();
    }

    public void OnCollisionEnter(Collision collision)
    {
        ResetDirection();
    }

    public void SetState(EnemyTankStates state)
    {
        if (state == EnemyTankModel.CurrentState)
            return;
        if (EnemyTankState != null)
            switch (EnemyTankModel.CurrentState)
            {
                case EnemyTankStates.Idle:
                    ((EnemyTankStateIdle)EnemyTankState).OnStateExit();
                    break;
                case EnemyTankStates.Patrol:
                    ((EnemyTankStatePatrol)EnemyTankState).OnStateExit();
                    break;
                case EnemyTankStates.Chase:
                    ((EnemyTankStateChase)EnemyTankState).OnStateExit();
                    break;
                case EnemyTankStates.Attack:
                    ((EnemyTankStateAttack)EnemyTankState).OnStateExit();
                    break;
            }

        EnemyTankState = EnemyTankStatesObjects[state];

        switch (state)
        {
            case EnemyTankStates.Idle:
                ((EnemyTankStateIdle)EnemyTankState).OnStateEnter();
                break;
            case EnemyTankStates.Patrol:
                ((EnemyTankStatePatrol)EnemyTankState).OnStateEnter();
                break;
            case EnemyTankStates.Chase:
                ((EnemyTankStateChase)EnemyTankState).OnStateEnter();
                break;
            case EnemyTankStates.Attack:
                ((EnemyTankStateAttack)EnemyTankState).OnStateEnter();
                break;
        }
    }

    public void ResetDirection()
    {
        // using random function to generate a random direction
        // Tank moves in random direction and this changes every x random seconds
        // or if tank collides with any objects
        horizontal = UnityEngine.Random.Range(-1f, 1f);
        vertical = UnityEngine.Random.Range(-1f, 1f);
    }

    public void CanSeePlayer()
    {
        Vector3 start = EnemyTankView.BulletSpawnPosition.position;
        Vector3 direction = EnemyTankView.BulletSpawnPosition.forward.normalized; // Normalize the direction vector
        float distance = EnemyTankModel.Speed; // Or the desired distance

        // Calculate the end position based on the start position, direction, and distance
        Vector3 end = start + direction * distance;

        int layerMask = 1 << LayerMask.NameToLayer("Tank");

        // Perform the raycast
        RaycastHit raycastHit;
        bool hasHit = Physics.Raycast(start, end, out raycastHit, layerMask);

        // Now you can check if the raycast hit something and get information from the RaycastHit if needed
        if (hasHit)
        {
            GameObject hitObject = raycastHit.collider.gameObject;
            // Raycast getting hit on tankparts sometimes, so using
            // parent component check too
            if (hitObject.GetComponent<PlayerTankView>() != null || hitObject.GetComponentInParent<PlayerTankView>() != null)
            {
                SetState(EnemyTankStates.Attack);
            }
        }
    }
}