using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaeraFollow : MonoBehaviour
{
    public Transform playerTarget;
    private Vector3 posDifference;

    void Start()
    {
        Debug.Log(playerTarget.transform.position - transform.position);
    }


    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(playerTarget != null)
        {
        transform.position =  playerTarget.transform.position + posDifference;
        }
    }

    public void setTarget(Transform target)
    {
        playerTarget = target;
        posDifference = playerTarget.transform.position - transform.position;
    }
}
