using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTank : SingletonMB<PlayerTank>
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _maxSpeed = 5;
    private Rigidbody _rigidbody;
    private Vector2 _joystickDirection;
    
    protected override void Awake()
    {
        base.Awake();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        TakeJoystickInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void TakeJoystickInputs()
    {
        _joystickDirection = _joystick.Direction;
    }

    void Move()
    {

        Vector3 newForward =(_joystickDirection.magnitude<0.2f)?transform.forward:new Vector3(_joystickDirection.x , 0,
            _joystickDirection.y );;
        newForward = (newForward*_maxSpeed).normalized;
        transform.forward = newForward;
        if(_joystickDirection.magnitude>0.02f)transform.eulerAngles += Vector3.up * 60;
        Vector3 newVelocity = _maxSpeed * _joystickDirection.magnitude * transform.forward;
        _rigidbody.velocity = newVelocity;
        
    }
    
    
}