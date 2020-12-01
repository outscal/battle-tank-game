using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : EnemyTankState
{
    [SerializeField]private Transform m_pathHolder;
    [SerializeField]private float m_moveSpeed;
    [SerializeField]private float m_waitTime;
    [SerializeField]private float m_turnSpeed;
    
    private Vector3 m_currentPosition;
    private Vector3 m_nextPosition;
    private Coroutine m_patrolCoroutine;
    private Coroutine m_turnToPlayerCoroutine;


//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("enemy Patrol state Enter-------->");

        Vector3[] m_wayPoints = new Vector3[m_pathHolder.childCount];

        for(int i=0;i<m_wayPoints.Length;i++){
            m_wayPoints[i] = m_pathHolder.GetChild(i).position;
            m_wayPoints[i] = new Vector3(m_wayPoints[i].x,transform.position.y,m_wayPoints[i].z);
        }

        m_patrolCoroutine = StartCoroutine(Patrol(m_wayPoints));
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("enemy Patrol state Exit-------->");
        StopCoroutine(m_patrolCoroutine);
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator Patrol(Vector3[] _wayPoints){
        
        transform.position = _wayPoints[0];                                                                                         //set position to start of path
        int _targetWaypointIndex = 1;
        Vector3 _targetWaypointPosition = _wayPoints[_targetWaypointIndex];
        transform.LookAt(_targetWaypointPosition);
        
        while(true){
            transform.position = Vector3.MoveTowards(transform.position,_targetWaypointPosition,m_moveSpeed*Time.deltaTime);
            if(transform.position == _targetWaypointPosition){
                _targetWaypointIndex = (_targetWaypointIndex+1)%_wayPoints.Length;                                                  //once index reach to maximum it is set back to 0
                _targetWaypointPosition = _wayPoints[_targetWaypointIndex];
        
                yield return new WaitForSeconds(m_waitTime);                                                                        //gaurd wait before moving to next position
                yield return StartCoroutine(TurnToFace(_targetWaypointPosition));
            }
            
            yield return null;                                                                                                      //loop runs only once per frame
        }                                                                                                   
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
            m_turnToPlayerCoroutine = null;
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private void OnDrawGizmos() {
        Vector3 _startPosition = m_pathHolder.GetChild(0).position;
        Vector3 _previousPosition = _startPosition;  
        foreach(Transform _waypoint in m_pathHolder){
            Gizmos.DrawSphere(_waypoint.position,0.2f);                                                   //draw sphere for each waypoint
            Gizmos.DrawLine(_previousPosition,_waypoint.position);                                      //connect all waypoint
            _previousPosition = _waypoint.position;
        }
        Gizmos.DrawLine(_previousPosition,_startPosition);                                              //join start point and end point
    }
}
