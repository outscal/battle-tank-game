using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChasingState : EnemyState
{
    [SerializeField]
    private Color differentColor;
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.ChangeColor(differentColor);
    }
}
