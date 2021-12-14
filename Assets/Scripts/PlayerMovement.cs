using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private FixedJoystick fixedjoyStick;

    public PlayerMovement()
    {

    }

    public PlayerMovement(GameObject obj, FixedJoystick fs)
    {
        Debug.Log("Player Movement Accessed");
        
    }

    public void nextPsoition()
    {
        float horizontalInput = fixedjoyStick.Horizontal;
        float verticalInput = fixedjoyStick.Vertical;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,
            verticalInput * speed * Time.deltaTime);

    }

    void Update()
    {
        Debug.Log("Update Accessed");
        float horizontalInput = fixedjoyStick.Horizontal;
        float verticalInput = fixedjoyStick.Vertical;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,
            verticalInput * speed * Time.deltaTime);
    }
}