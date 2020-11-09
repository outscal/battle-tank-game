using UnityEngine;


public class TankController : MonoSingletonGeneric<TankController>
{   
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private GameObject tankExplosion;
    private Rigidbody rigidbody;
    private Transform tank;

    protected override void Awake()
    {
        base.Awake();
        tank = gameObject.transform;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (joystick.pressed)
        {
            if (Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            {
                rigidbody.velocity = new Vector3(joystick.Horizontal * 15f, 0, joystick.Vertical * 15f);
                tank.rotation = Quaternion.LookRotation(new Vector3(joystick.Horizontal * 10f, rigidbody.velocity.y, joystick.Vertical * 10f));
            }
        }
        else {
            rigidbody.velocity = new Vector3();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BossEnemy")) {

            TankProvider.Instance.Boom(transform);
            Destroy(gameObject);
        }
    }
    
}

