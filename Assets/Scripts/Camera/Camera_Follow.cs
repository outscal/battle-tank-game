using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 offset = new Vector3(-9f, 20f, -9f);
    private float camSpeed = 5f;

    private void LateUpdate()
    {
        if (Target == null) return;

        Vector3 newPos = Target.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPos, camSpeed * Time.deltaTime);

        transform.LookAt(Target.position);
        
    }
}
