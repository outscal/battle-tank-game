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
        Debug.Log("Entered Chase");
    }

    private void Update()
    {
        Vector3 playerPos = playerTank.transform.position;
        Debug.Log(playerPos);
        if (Vector3.Distance(transform.position,playerPos)>=tankView.fightRadius) 
        {
            Vector3 direction = playerPos - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, 2f * Time.deltaTime);
        }
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
