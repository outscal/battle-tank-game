using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private TankController controller;

    private float horizontalVal, verticalVal;

    public void SetController( TankController _controller)
    {
        controller = _controller;
    }
	
	// Update is called once per frame
	void Update () 
    {
        horizontalVal = Input.GetAxis("Horizontal1");
        verticalVal = Input.GetAxis("Vertical1");

        if (horizontalVal != 0 || verticalVal != 0)
        {
            if (controller != null)
            {
                controller.MovePlayer(horizontalVal, verticalVal);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.SpawnBullet();
        }
    }
}
