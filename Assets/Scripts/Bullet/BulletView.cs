
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerTankView tankView;

    public float speed;

    private BulletController bulletController;
    private void Awake()
    {
        bulletController = new BulletController(this);
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        bulletController.SetInitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        bulletController.MoveForword();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
