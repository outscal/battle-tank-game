using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    [SerializeField]
    private Joystick joystick;
    public TankModel TankModel { get; }
    public TankView TankView { get; }
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }
    /*    public int PlayerNumber = 1;*/
    public AudioSource MovementAudio;
    public AudioClip EngineIdling;
    public AudioClip EngineDriving;
    public float PitchRange = 0.2f;

    [SerializeField]
    private float Speed = 10f;
    [SerializeField]
    private float TurnSpeed = 180f;
    private string MovementAxisName;
    private string TurnAxisName;
    private Rigidbody Rigidbody;
    private float MovementInputValue;
    private float TurnInputValue;
    private float OriginalPitch;

    protected override void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        Rigidbody.isKinematic = false;    // No forces applied
        MovementInputValue = 0;
        TurnInputValue = 0;
    }
    private void OnDisable()
    {
        Rigidbody.isKinematic = true;
    }
    private void Start()
    {
        MovementAxisName = "Vertical";
        TurnAxisName = "Horizontal";
        OriginalPitch = MovementAudio.pitch;
    }
    private void Update()
    {
        MovementInputValue = joystick.Vertical;
        TurnInputValue = joystick.Horizontal;
        EngineAudio();
    }
    private void EngineAudio()
    {
        //Playing audio when tank is moving vs not moving 
        if(Mathf.Abs (MovementInputValue) < 0.1f && Mathf.Abs (TurnInputValue) < 0.1f)
        {
            if(MovementAudio.clip == EngineDriving)
            {
                MovementAudio.clip = EngineIdling;
                MovementAudio.pitch = Random.Range(OriginalPitch - PitchRange, OriginalPitch + PitchRange);
                MovementAudio.Play();
            }
        }
        else
        {
            if (MovementAudio.clip == EngineIdling)
            {
                MovementAudio.clip = EngineDriving;
                MovementAudio.pitch = Random.Range(OriginalPitch - PitchRange, OriginalPitch + PitchRange);
                MovementAudio.Play();
            }
        }
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    private void Move()
    {
        //Adjusting position of tank
        Vector3 movement = transform.forward * MovementInputValue*Speed*Time.deltaTime;  //Speed per frame
        Rigidbody.MovePosition(Rigidbody.position + movement);
    }
    private void Turn()
    {
        //Adjusting rotation of tank
        float turn = TurnInputValue * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }
}
