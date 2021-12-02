using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float DampTime;

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position, DampTime);
    }
}
