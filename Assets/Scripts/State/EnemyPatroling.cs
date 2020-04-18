using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
public class EnemyPatroling : EnemyState
{
    private float timeElapsed;
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.SetTankColor(changedColor);
    }

    public override void OnExitState()
    {
        base.OnExitState();
        //enemyView.SetTankColor(EnemyColor);
        Debug.Log("state is exited");
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 5f)
        {
            enemyView.ChangeState(enemyView.chasingState);
        }
    }
}
