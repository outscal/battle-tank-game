using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class BulletView : MonoBehaviour
{
    public BulletController BulletController { set; get; }

    public Vector3 Position { get; set; }
    public Vector3 LocalScale { get; set; }
    public Quaternion Rotation { get; set; }
    public bool ApplyTranform { get; set; }

    public Rigidbody RigidbodyComponent { get; private set; }
    public MeshCollider MeshColliderComponent { get; private set; }

    protected virtual void Awake()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        LocalScale = transform.localScale;
        ApplyTranform = false;

        RigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        MeshColliderComponent = gameObject.GetComponent<MeshCollider>();
    }

    protected virtual void Update()
    {
        if (BulletController != null)
        {
            BulletController.Update();
        }
    }

    protected virtual void LateUpdate()
    {
        if (ApplyTranform)
        {
            transform.position = Position;
            transform.rotation = Rotation;
            transform.localScale = LocalScale;
            ApplyTranform = false;
        }
    }

    protected virtual void FixedUpdate() { }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);

        if (BulletController != null)
        {
            BulletController.OnCollisionEnter(collision);
        }

        TankView tankView = collision.gameObject.GetComponent<TankView>();
        if (tankView != null)
        {
            tankView.TankController.TakeDamage(BulletController.GetDamage());
        }
    }
}