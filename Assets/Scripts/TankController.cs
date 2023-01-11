using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation *= Quaternion.Euler(0f, -rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
