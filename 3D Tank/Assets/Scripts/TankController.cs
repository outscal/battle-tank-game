using UnityEngine;

public class TankController : GameController<TankController>
{
    public Joystick[] joystick;
    public float moveSpeed = 40f;
    public float turnSpeed = 180f;
    private Rigidbody rb;

    public AudioSource m_MovementAudio;         
    public AudioClip m_EngineIdling;            
    public AudioClip m_EngineDriving;           
    public float m_PitchRange = 0.2f;
    private float m_OriginalPitch;

    float horizontalMove;
    float verticalMove;


    public TankController(TankModel model,TankView tankprefab)
    {
        Model = model;

        tankView = GameObject.Instantiate<TankView>(tankprefab);
    }

    public TankModel Model { get; }
    public TankView tankView { get; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        joystick[0] = JoystickController.Instance.joystick1;
        joystick[1] = JoystickController.Instance.horizontalJoystick;
        joystick[2] = JoystickController.Instance.verticalJoystick;

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
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * verticalMove * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void EngineAudio()
    {
        if (Mathf.Abs(horizontalMove) < 0.1f && Mathf.Abs(verticalMove) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }


    private void Turn()
    {
        float turn = horizontalMove * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f,turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

}
