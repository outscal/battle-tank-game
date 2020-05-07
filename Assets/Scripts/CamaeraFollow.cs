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
        EventService.Instance.PlayerSpawn += OnPlayerSpawned;
    }

    private void OnPlayerSpawned()
    {
        player = TankService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            //player = TankService.Instance.GetCurrentPlayer();
            transform.parent = player.transform;
            transform.position = player.transform.position + new Vector3(0, 3.18f, -3.04f) ;
            transform.eulerAngles = new Vector3(22.03f, 1.81f, 0);
            //transform.rotation = player.transform.rotation;
            //transform.position = player.transform.position;
            //posDifference = player.transform.position - transform.position;
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
            //transform.position = player.transform.position + new Vector3(0,2f,2f) ;
        }
    }

    //public void setTarget(Transform target)
    //{
    //    playerTarget = target;
    //    posDifference = playerTarget.transform.position - transform.position;
    //}
}
