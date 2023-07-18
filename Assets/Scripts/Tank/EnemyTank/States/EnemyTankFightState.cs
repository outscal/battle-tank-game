using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankFightState : EnemyTankState
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
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
