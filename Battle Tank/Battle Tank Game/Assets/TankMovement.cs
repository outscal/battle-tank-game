using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : TankControll<TankMovement>
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontalDirection * Time.deltaTime * speed, 0.0f, verticalDirection * Time.deltaTime * speed);                  //dont want to move tank up and down

        transform.position += moveDirection;
    }
}
