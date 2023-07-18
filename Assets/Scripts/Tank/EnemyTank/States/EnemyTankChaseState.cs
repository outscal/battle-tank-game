using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankChaseState : EnemyTankState
{
    private PlayerTankView playerTank;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        playerTank = tankView.PlayerTank;
    }

    private void Update()
    {
        tankController.RotateTank(playerTank.transform.position);
        tankController.MoveTank(playerTank.transform.position);
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
