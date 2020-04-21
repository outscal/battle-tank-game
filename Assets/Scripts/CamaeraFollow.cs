using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;

public class CamaeraFollow : MonoBehaviour
{
    private TankView playerTarget;
    private Vector3 posDifference;

    void Start()
    {
        playerTarget = TankService.Instance.GetCurrentPlayer();
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

    //public void setTarget(Transform target)
    //{
    //    playerTarget = target;
    //    posDifference = playerTarget.transform.position - transform.position;
    //}
}
