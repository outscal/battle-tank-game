using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;
using TankGame.Tank;
public class EnemyPatroling : EnemyState
{
    private float timeElapsed;
    private Coroutine coroutine;
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyView.SetTankColor(changedColor);
        enemyView.StartPatroling();

    }

    public override void OnExitState()
    {
        base.OnExitState();
        //enemyView.SetTankColor(EnemyColor);
        Debug.Log("state is exited");
        enemyView.StopPatroling();
    }
    //private void Update()
    //{
    //    timeElapsed += Time.deltaTime;
    //    if (timeElapsed > 5f)
    //    {
    //        enemyView.ChangeState(enemyView.chasingState);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            enemyView.ChangeState(enemyView.chasingState);
        }
    }
}
