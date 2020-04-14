using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;

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

        //Vector2 inputDir = (new Vector2(horizontal, vertical)).normalized;
        //if(inputDir != Vector2.zero)
        //{
        //    float targetRotation;
        //    targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        //    transform.eulerAngles = Vector3.up * targetRotation;
        //}

        transform.eulerAngles = Vector3.up * tankController.GetTargetRotation(horizontal,vertical);

        Vector3 position = transform.position;
        transform.position = tankController.MoveTank(horizontal, vertical, position);
    }

    public void SetTankController(TankController tc)
    {
        tankController = tc;
    }
}
