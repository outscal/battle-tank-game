using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoystickController : GameController<JoystickController>
{
    public Joystick joystick1;
    public Joystick horizontalJoystick;
    public Joystick verticalJoystick;

    public Button trigger1;
    public Button trigger2;

    public bool joystick1_isActive = true;

    private void Start()
    {
        horizontalJoystick.gameObject.SetActive(false);
        verticalJoystick.gameObject.SetActive(false);
        trigger2.gameObject.SetActive(false);
    }

    public void altActivate1()
    {
        joystick1_isActive = false;
        joystick1.gameObject.SetActive(false);
        horizontalJoystick.gameObject.SetActive(true);
        verticalJoystick.gameObject.SetActive(true);
        trigger1.gameObject.SetActive(false);
        trigger2.gameObject.SetActive(true);
    }

    public void altActivate2()
    {
        joystick1_isActive = true;
        joystick1.gameObject.SetActive(true);
        horizontalJoystick.gameObject.SetActive(false);
        verticalJoystick.gameObject.SetActive(false);
        trigger1.gameObject.SetActive(true);
        trigger2.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
