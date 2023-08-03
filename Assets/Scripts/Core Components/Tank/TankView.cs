using UnityEngine;

// [RequireComponent(Rigidbody)]
public class TankView : MonoBehaviour
{
    public Vector3 Position { get; set; }
    public Vector3 LocalScale { get; set; }
    public Quaternion Rotation { get; set; }

    public bool ApplyTranform { get; set; }

    protected virtual void Awake()
    {
        Position = transform.position;
        Rotation = transform.rotation;
        LocalScale = transform.localScale;
        ApplyTranform = false;
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
}