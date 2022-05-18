using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTank;

    private void LateUpdate()
    {
        transform.position = playerTank.position;
    }
}