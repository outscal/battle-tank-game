using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private FixedJoystick joystick;

    private Rigidbody rgbd;

    [SerializeField] float v_max = 10;

    Vector3 RIGHT = new Vector3(1, 0, -1);
    Vector3 UP = new Vector3(1, 0, 1);

    Vector3 dir = Vector3.right;

    private void Awake() {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update() {
        /*speed.x = joystick.Horizontal; //Input.GetAxis("Horizontal1");
        speed.z = joystick.Vertical; //Input.GetAxis("Vertical1");
        speed.y = 0;
        speed = Quaternion.Euler(0, 45, 0) * speed;
        speed = speed.normalized * v_max;

        if (speed.magnitude != 0) {
            //dir.y = Vector3.Angle(Vector3.up, speed);
            dir = speed;
        }

        transform.position = transform.position + speed * Time.deltaTime;

        //transform.eulerAngles = dir;
        transform.rotation = Quaternion.LookRotation(dir);*/
    }

    private void FixedUpdate() {
        dir = RIGHT * joystick.Horizontal + UP * joystick.Vertical;
        dir = dir.normalized;
        rgbd.AddForce(dir * v_max * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (rgbd.velocity != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(rgbd.velocity);
        }
    }
}
