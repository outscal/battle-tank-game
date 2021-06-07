using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private Vector3  m_StartingPosition;
    private Vector3 m_RoamingPosition;

    private void Start()
    {
        m_StartingPosition = transform.position;
        m_RoamingPosition = GetRomingPosition();
    }

    private Vector3 GetRomingPosition()
    {
        return m_StartingPosition + GetRandDir() * Random.Range(10f, 70f);
    }

   
    //genarating Random Direction
    public static Vector3 GetRandDir() 
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
enum EnemyState
{
    Idle,
    Patrolling,
    Attack
}
