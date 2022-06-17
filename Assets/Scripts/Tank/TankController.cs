using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankController : MonoGenericSingleton<TankController>
{

    public float movement;
    public float movementSpeed = 30;
    public float rotation;
    public float rotationSpeed = 120;
    public Rigidbody rb;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {

        rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y, joystick.Vertical * movementSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    public void Move()
    {
        //adding velocity to rigidbody of the player tank game object
        //rb.velocity = transform.forward * movement * movementSpeed;
        rb.velocity = new Vector3(movement * movementSpeed, rotation * rotationSpeed);
    }

    public void Rotate()
    {
        //rotating the rigidbody of the player tank game object
        // Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        // Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        // rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
