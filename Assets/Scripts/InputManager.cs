using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager> {

    public PlayerController playerController { get; set; }

    private float horizontalVal, verticalVal;

	// Update is called once per frame
	void Update () 
    {
        horizontalVal = Input.GetAxis("Horizontal1");
        verticalVal = Input.GetAxis("Vertical1");

        if (horizontalVal != 0 || verticalVal != 0)
        {
            if (playerController != null)
            {
                playerController.MovePlayer(horizontalVal, verticalVal);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.SpawnBullet();
        }
    }
}
