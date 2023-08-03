using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletView : MonoBehaviour
{
    public BulletController BulletController { set; get; }

    public Vector3 Position { get; set; }
    public Vector3 LocalScale { get; set; }
    public Quaternion Rotation { get; set; }
    public bool ApplyTranform { get; set; }

    public Rigidbody Rigidbody { get; private set; }

    protected virtual void Awake()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        LocalScale = transform.localScale;
        ApplyTranform = false;

        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    protected virtual void Update() { }

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
}