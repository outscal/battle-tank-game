using UnityEngine.AI;
using UnityEngine;
public class EnemyIdleState : StateInterface<EnemyView>
{
    private float timeElapsed = 0f;
    private EnemyView enemy;
    private void ObjectInitialization(EnemyView stateObject)
    {
        enemy = stateObject;
    }
    public void OnEnterState(EnemyView stateObject)
    {
        Debug.Log("Entering Idle State");
        ObjectInitialization(stateObject);
        timeElapsed = 0f;
    }
    public void OnExitState(EnemyView stateObject)
    {
        Debug.Log("Exiting Idle State");
    }
    public void Update()
    {
        Debug.Log("Idle State Update Called");
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1)
        {
            Debug.LogError("Dune "+ enemy.dune);
            //PatrolState();
            enemy.stateMachine.ChangeState(new EnemyPatrolState());
        }
    }
}
