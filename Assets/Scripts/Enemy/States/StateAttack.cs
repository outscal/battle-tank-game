using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : EnemyTankState
{
    [SerializeField]private float m_turnSpeed;
    [SerializeField]private Transform player;

    [SerializeField]ObjectPool objectPool;
    [SerializeField]private float m_launchForce = 30f;
    [SerializeField]Transform m_FireTransform;
    [SerializeField]private int NoOfShellFired;

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    public override void OnEnterState(){
        base.OnEnterState();
        Debug.Log("Enemy Attack State enter---------------->");
        StartCoroutine(TurnToFace(player.position));
    }

    public override void OnExitState(){
        base.OnExitState();
        Debug.Log("Enemy Attack State exit---------------->");
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator TurnToFace(Vector3 _lookTarget){
        
        Vector3 _dirToLookTarget = (_lookTarget-transform.position).normalized;
        float _targetAngle = 90-Mathf.Atan2(_dirToLookTarget.z,_dirToLookTarget.x)*Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y,_targetAngle))>0.5f){
            float _angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y,_targetAngle,m_turnSpeed*Time.deltaTime);
            transform.eulerAngles = Vector3.up*_angle;
            yield return null;
        }
        for(int i=0;i<NoOfShellFired;i++){
            yield return new WaitForSeconds(0.3f);
            Fire();
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Fire(){
        Rigidbody shellInstance = (objectPool.spawner("Shell",m_FireTransform)).GetComponent<Rigidbody>();  
        shellInstance.velocity = m_launchForce * m_FireTransform.forward;                                    
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````
 

}
