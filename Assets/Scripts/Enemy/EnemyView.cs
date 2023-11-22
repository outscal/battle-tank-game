using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyView : MonoBehaviour
{
    private EnemyController EnemyController;
    public Rigidbody rb;
    public GameObject parent;
    private EnemyState currentState;
    // [SerializeField]
    // private List<EnemyStates> enemyStates;
    [SerializeField]
    public TankChasingState chasingState;
    [SerializeField]
    public TankPatrollingState patrolingState;
    [SerializeField]

    private EnemyState startingState;
    Renderer renderer;
    private void Awake(){
        rb = GetComponent<Rigidbody>();

        if(rb == null){
            Debug.LogError("RigidBody not found");
        }
    }

    private void Start(){
        // ChangeState(GetComponent<TankPatrolling>());
        ChangeState(startingState);
    }

    public void SetEnemyController(EnemyController enemyController){
        EnemyController = enemyController;
    }

 
    public Rigidbody GetRigidBody(){
        return rb;
    }

    public void ChangeColor(Color color){
        renderer = this.parent.transform.GetChild(0).GetComponent<Renderer>();
        renderer.material.SetColor("_Color",Color.blue);
        renderer = this.parent.transform.GetChild(3).GetComponent<Renderer>();
        
        renderer.material.SetColor("_Color",Color.blue);
        // image.color = color;
    }

    public void ChangeState(EnemyState newState){
        if(currentState != null){
            currentState.OnExitState();
        }

        currentState = newState;
        currentState.OnEnterState();
    }
}
