using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public Transform[] points;
    int current=0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transform wp = points[current];

        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            current = (current + 1) % points.Length;
            //transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(
               transform.position,
               wp.position,
               speed * Time.deltaTime);
            transform.LookAt(wp.position);
            //current = (current + 1) % points.Length;
            //transform.LookAt(wp.position);
        }
    }
}
