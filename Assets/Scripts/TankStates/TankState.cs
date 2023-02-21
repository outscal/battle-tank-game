using UnityEngine;
using UnityEngine.AI;

public class TankState : MonoBehaviour
{
    protected EnemyView enemyView;
    protected NavMeshAgent agent;

    private void Awake()
    {
        enemyView = GetComponent<EnemyView>();
        agent = enemyView.navMeshAgent;
    }

    public virtual void OnEnterState()
    { 
        this.enabled = true;
    }

    public virtual void OnExitState() { this.enabled = false; }

    public void Update() { }

}
