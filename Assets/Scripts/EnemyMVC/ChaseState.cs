using UnityEngine;
using Tanks.Tank;
using UnityEngine.AI;
public class ChaseState : TankState
{
    private TankView tankView;
    private NavMeshAgent navmeshAgent;
    public override void OnEnterState()
    {
        base.OnEnterState();
        tankView = TankView.Instance;
        navmeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navmeshAgent.destination = tankView.transform.position;
    }


    public override void OnExitState()
    {
        base.OnExitState();
    }
}
