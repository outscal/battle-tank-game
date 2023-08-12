using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Joystick joystick;
    [SerializeField] private Button Accelerator;
    [SerializeField] private Button Reverse;
    [SerializeField] private Button Shoot;
    bool accelerated;
    bool stopped;
    private PlayerTankController playerTank;

    // Update is called once per frame
    private void Start()
    {
        Shoot.onClick.AddListener(shootBullet);
        playerTank = TankService.Instance.playerTankController;
    }
    void Update()
    {
        if(playerTank != null) {
            accelerated = getButtonState(Accelerator);
            stopped = getButtonState(Reverse);
            if (accelerated)
            {
                playerTank.moveWithVelocity(Direction.front);
            }
            else if (stopped)
            {
                playerTank.moveWithVelocity(Direction.back);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                playerTank.DestroyTank();
            }

            if (joystick.Direction.magnitude > 0)
            {
                playerTank.RotateToDirection(joystick.Direction);
            }
        }
       
    }

    private void shootBullet()
    {
        Debug.Log("bullet launched");
        playerTank.Fire();
    }

    private bool getButtonState(Button button)
    {
        return button.GetComponent<ButtonPressed>().buttonPressed;
    }
}
