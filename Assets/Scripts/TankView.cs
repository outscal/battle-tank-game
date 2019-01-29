using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

    public TankController controller;

    private float xAxis, yAxis;

    private void Update()
    {
        if (controller.tankModel.isPlayer == true)
        {
            xAxis = Input.GetAxis("Horizontal1");
            yAxis = Input.GetAxis("Vertical1");

            if (xAxis != 0 || yAxis != 0)
            {
                if (controller != null)
                {
                    controller.MovePlayer(xAxis, yAxis);
                }
            }
        }
    }

    public void Move(float hVal, float vVal, float speed, float rotateSpeed)
    {
        StartCoroutine(MoveObj(hVal, vVal, speed, rotateSpeed));
    }

    private IEnumerator MoveObj(float hVal, float vVal, float speed, float rotateSpeed)
    {
        transform.Translate(vVal * Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, hVal, 0) * rotateSpeed);

        yield return new WaitForEndOfFrame();
    }

}

	