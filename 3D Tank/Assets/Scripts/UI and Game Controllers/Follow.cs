using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
    

public class Follow : MonoBehaviour
{   
    [SerializeField]
    CinemachineVirtualCamera cam;
    private void Update()
    {
        if (TankController.Instance.homingLaunched)
        {
            cam.Follow = GameObject.FindGameObjectWithTag("Homing").transform;
        }
        else
        {
            cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
