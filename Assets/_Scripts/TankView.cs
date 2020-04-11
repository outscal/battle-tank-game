using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankController tankController;
    void Start()
    {
        Debug.Log("Tank View created");
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal1");
        //Debug.Log("tha value of horizonatal: " + horizontal);
        float vertical = Input.GetAxisRaw("Vertical1");
        //Debug.Log("tha value of vertical: " + vertical);
        Vector3 position = transform.position;
        //transform.position = tankController.moveTankInHorizontalDirection(horizontal, position);
        //transform.position = tankController.moveTankInVerticalDirection(vertical, position);
        transform.position = tankController.moveTank(horizontal, vertical, position);
    }

    public void SetTankController(TankController tc)
    {
        tankController = tc;
    }
}
