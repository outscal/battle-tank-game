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
        ObjectInitialization(stateObject);
        timeElapsed = 0f;
    }
    public void OnExitState(EnemyView stateObject)
    {
    }
    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1)
        {
            enemy.stateMachine.ChangeState(new EnemyPatrolState());
        }
    }
}
