using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric <TankController>
{
    private float moveSpeed, dirX, dirY;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private Rigidbody rb;
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    void Start()
    {
        moveSpeed = 0.2f;
    }
    private void FixedUpdate()
    {
            rb.transform.localPosition += Vector3.forward * dirY;
            rb.transform.localPosition += Vector3.right * dirX;
    }
    private void Update()
    {
        dirX = joystick.Horizontal * moveSpeed;
        dirY = joystick.Vertical * moveSpeed;
    }
    public TankController (TankModel tankModel, TankView tankPrefab)
    {
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }
}
