using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;

public class EnemyChasing : EnemyState
{
    [SerializeField]
    private Color chasingColor;

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.SetTankColor(chasingColor);
    }
}
