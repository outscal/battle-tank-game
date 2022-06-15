using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class TankView : MonoBehaviour
{
    TankController _tankController;
    public float movement;
    public float rotation;
    public Rigidbody _rb;
    public Joystick _joystick;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _joystick = _tankController.GetJoystick();
    }

    void FixedUpdate()
    {
        movement = _joystick.Vertical;
        rotation = _joystick.Horizontal;

        _tankController.Move(_rb, movement, rotation, gameObject.transform);

        if (movement != 0 || rotation != 0)
        {
            _tankController.Rotate(gameObject.transform, _rb);
        }
    }

    public void SetController(TankController tankController)
    {
        _tankController = tankController;
    }
}
