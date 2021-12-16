using System.Collections;
using UnityEngine;


//Summary//
//Script responsible for controlling the tank
//-Summary//
public class TankController : GenericSingleton<TankController>
{
    [SerializeField] Joystick[] joystick;
    [SerializeField] int moveSpeed = 40;
    [SerializeField] int turnSpeed = 180;
    private Rigidbody rb;

    public Transform shootPoint;
    [SerializeField] ParticleSystem particle;

    private float horizontalMove;
    private float verticalMove;


    public TankController(TankModel model,TankView tankprefab)  //Instantiating the tank prefab
    {
        Model = model;

        tankView = GameObject.Instantiate<TankView>(tankprefab);
    }

    public TankModel Model { get; }
    public TankView tankView { get; }

    private void Start()              //getting the required components
    {
        rb = GetComponent<Rigidbody>();
        particle = FindObjectOfType<ParticleSystem>();

        joystick[0] = JoystickController.Instance.joystick1;
        joystick[1] = JoystickController.Instance.horizontalJoystick;
        joystick[2] = JoystickController.Instance.verticalJoystick;
    }

    private void Update()
    {
        if (JoystickController.Instance.joystick1_isActive)
        {
            horizontalMove = joystick[0].Horizontal;
            verticalMove = joystick[0].Vertical;
        }
        else if(JoystickController.Instance.joystick1_isActive == false)
        {
            horizontalMove = joystick[1].Horizontal;
            verticalMove = joystick[2].Vertical;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Death());
        }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()  //Method to move the tank prefab
    {
        Vector3 movement = transform.forward * verticalMove * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()  //Method to turn the Tank prefab
    {
        float turn = horizontalMove * turnSpeed * Time.deltaTime;
        if(Mathf.Abs(turn) > 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    private IEnumerator Death()    //Method for self destruction of tank prefab
    {
        particle.transform.parent = null;
        particle.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
