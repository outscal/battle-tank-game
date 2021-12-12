using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    public float speed = 0.10f;
    private float horizontalMove = 0.0f;
    public Joystick joystick;
    private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Mathf.Clamp(joystick.Horizontal, -1,1)  * speed;
       // Debug.Log(joystick.Horizontal);
        Debug.Log("Values is" + horizontalMove);
        gameObject.transform.position = new Vector3(horizontalMove * speed, 0, 0);
    }
}
