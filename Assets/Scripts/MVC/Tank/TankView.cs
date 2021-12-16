using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    [SerializeField] private FixedJoystick js;
    private void Start()
    {
       // PlayerMovement p = new PlayerMovement(js);
        Debug.Log("Tank View Created");
        gameObject.AddComponent<PlayerMovement>();
        //PlayerMovement lpop = new PlayerMovement(js);

    }

    private void Update()
    {
        Debug.Log("View Class Update called");
    }
}
