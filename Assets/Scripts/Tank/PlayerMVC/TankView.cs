using UnityEngine;
using Cinemachine;
public class TankView : MonoBehaviour
{
    private TankController tankController;
    [HideInInspector]
    public Joystick joystick;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;
    public void SetTankController(TankController _tankController)
    {
        virtualCamera= FindObjectOfType<CinemachineVirtualCamera>();
        virtualCamera.Follow = this.transform;
        tankController = _tankController;
    }

    private void Update()
    {

        if (joystick.Horizontal!=0 || joystick.Vertical!=0)
        {
            tankController.UpdateMovementAndRotation(joystick.Horizontal, joystick.Vertical);
        }
    }
}
