using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    private void Start()
    {

        Debug.Log("Tank View Created");
    }

    private void Update()
    {
        Debug.Log("View Class Update called");
    }
}
