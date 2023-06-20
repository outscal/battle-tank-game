using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    float horizontalMove;
    float verticalMove;
    [SerializeField] Rigidbody rb;
    [SerializeField] FixedJoystick joystick;
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public void SetJoystick(FixedJoystick _joystick)
    {
        joystick = _joystick;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    void PlayerInput()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
    }
    void Update()
    {
        PlayerInput();
        if (horizontalMove != 0 || verticalMove != 0)
        {
            tankController.MoveTank(horizontalMove, verticalMove);
        }
    }
}
