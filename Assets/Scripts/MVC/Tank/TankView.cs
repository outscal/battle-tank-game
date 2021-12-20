using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    [SerializeField] private FixedJoystick js;
    private void Start()
    {
        Debug.Log("Tank View Created");
        gameObject.AddComponent<PlayerMovement>();

    }

    private void Update()
    {
        Debug.Log("View Class Update called");
    }
}
