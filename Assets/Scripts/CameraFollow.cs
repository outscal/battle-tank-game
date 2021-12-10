using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float DampTime;
    private GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("tank");
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position, DampTime);
    }
}
