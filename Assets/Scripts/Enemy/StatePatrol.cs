using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : EnemyTankState
{
    [SerializeField]private EnemyManager manager;

    private float m_duration;
    private float time = 0;

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("enemy Patrol state Enter-------->");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("enemy Patrol state Exit-------->");
    }

}
