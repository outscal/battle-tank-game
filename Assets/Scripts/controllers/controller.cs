using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Joystick joystick;
    [SerializeField] private Button Accelerator;
    [SerializeField] private Button Reverse;
    bool accelerated;
    bool stopped;


    // Update is called once per frame
    void Update()
    {
        accelerated = getButtonState(Accelerator);
        stopped = getButtonState(Reverse);
        if (accelerated)
        {
            TankService.Instance.playerTankController.MoveTransform(Direction.front);
        }
        if(stopped)
        {
            TankService.Instance.playerTankController.Move(Direction.back);
        }

        if(joystick.Direction.magnitude > 0)
        {
            TankService.Instance.playerTankController.RotateToDirection(joystick.Direction);
        }
    }

    private bool getButtonState(Button button)
    {
        return button.GetComponent<ButtonPressed>().buttonPressed;
    }
}
