using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankType tankType;
  private FixedJoystick js;
    PlayerMovement playerMovement;
    private void Start()
    {
        Debug.Log("Tank View Created");
        gameObject.AddComponent<PlayerMovement>();
        //playerMovement.SetPlayerMovementReference(TankService);
        
        playerMovement.SetPlayerMovementReference(js); 
    }

    private void Update()
    {
        Debug.Log("View Class Update called");
    }
}
