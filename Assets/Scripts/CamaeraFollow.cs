using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Event;

public class CamaeraFollow : MonoBehaviour
{
    private TankView player;
    private Vector3 posDifference;

    void Start()
    {
        EventService.Instance.PlayerSpawn += GetPLayer;

    }

    private void GetPLayer()
    {
        player = TankService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            player = TankService.Instance.GetCurrentPlayer();
            posDifference = player.transform.position - transform.position;
        }
        else
        {
            Debug.Log("player is null");
        }
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            //posDifference = playerTarget.transform.position - transform.position;
            transform.position = player.transform.position ;
        }
    }

    //public void setTarget(Transform target)
    //{
    //    playerTarget = target;
    //    posDifference = playerTarget.transform.position - transform.position;
    //}
}
